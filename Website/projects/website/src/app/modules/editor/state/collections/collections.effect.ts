import { Injectable } from '@angular/core';
import { Actions, concatLatestFrom, createEffect, ofType } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import { CollectionService } from 'api-client';
import { MessageService } from 'primeng/api';
import { AppState } from 'projects/website/src/app/app.state';
import { catchError, debounceTime, from, map, of, switchMap } from 'rxjs';
import {
  createCollection,
  createCollectionFailure,
  createCollectionSuccess,
  deleteCollection,
  deleteCollectionFailure,
  deleteCollectionSuccess,
  loadCollectionFailure,
  loadCollectionSuccess,
  loadCollections,
  loadCollectionsFailure,
  loadCollectionsSuccess,
  selectCollection,
  updateCollection,
  updateCollectionFailure,
  updateCollectionSuccess,
} from './collections.action';
import { getCollections } from './collections.selectors';

@Injectable()
export class CollectionsEffects {
  constructor(
    private actions$: Actions,
    private store: Store<AppState>,
    private collectionService: CollectionService,
    private messageService: MessageService
  ) {}

  selectCollection$ = createEffect(() =>
    this.actions$.pipe(
      ofType(selectCollection),
      concatLatestFrom((action) => this.store.select(getCollections)),
      switchMap(([{ collectionId }, collections]) => {
        var m = collections.find((m) => m.id == collectionId);
        if (m) {
          return of(loadCollectionSuccess({ collection: m }));
        }
        return from(this.collectionService.getCollection(collectionId!)).pipe(
          map((collection) => loadCollectionSuccess({ collection })),
          catchError((error) => of(loadCollectionFailure({ error })))
        );
      })
    )
  );

  loadCollections$ = createEffect(() =>
    this.actions$.pipe(
      ofType(loadCollections),
      switchMap(({ request }) => {
        return from(this.collectionService.getCollections(request)).pipe(
          map(({ collections, total }) =>
            loadCollectionsSuccess({
              collections: collections ?? [],
              total: total ?? 0,
            })
          ),
          catchError((error) => of(loadCollectionsFailure({ error })))
        );
      })
    )
  );

  createCollection$ = createEffect(() =>
    this.actions$.pipe(
      ofType(createCollection),
      switchMap(({ collection }) =>
        from(this.collectionService.createCollection(collection)).pipe(
          map((newCollection) =>
            createCollectionSuccess({ collection: newCollection })
          ),
          catchError((error) => of(createCollectionFailure({ error })))
        )
      )
    )
  );

  deleteCollection$ = createEffect(() =>
    this.actions$.pipe(
      ofType(deleteCollection),
      switchMap(({ collection }) =>
        from(this.collectionService.deleteCollection(collection)).pipe(
          map((success) => {
            if (success) {
              return deleteCollectionSuccess({
                collectionId: collection.id!,
                success,
              });
            } else {
              return deleteCollectionFailure({
                error: 'Unable to delete collection',
              });
            }
          }),
          catchError((error) => of(deleteCollectionFailure({ error })))
        )
      )
    )
  );

  updateCollection$ = createEffect(() =>
    this.actions$.pipe(
      ofType(updateCollection),
      switchMap(({ collection }) =>
        from(this.collectionService.updateCollection(collection)).pipe(
          map((newCollection) =>
            updateCollectionSuccess({ collection: newCollection })
          ),
          catchError((error) => of(updateCollectionFailure({ error })))
        )
      )
    )
  );

  notifyUpdate$ = createEffect(
    () =>
      this.actions$.pipe(
        ofType(updateCollectionSuccess),
        map(({ collection }) => {
          this.messageService.add({
            severity: 'success',
            summary: 'Successful',
            detail: 'Collection Updated',
            life: 3000,
          });
        })
      ),
    { dispatch: false }
  );

  notifyCreate$ = createEffect(
    () =>
      this.actions$.pipe(
        ofType(createCollectionSuccess),
        map(({ collection }) => {
          this.messageService.add({
            severity: 'success',
            summary: 'Successful',
            detail: 'Collection Created',
            life: 3000,
          });
        })
      ),
    { dispatch: false }
  );

  notifyDelete$ = createEffect(
    () =>
      this.actions$.pipe(
        ofType(deleteCollectionSuccess),
        debounceTime(100),
        map(({ collectionId }) => {
          this.messageService.add({
            severity: 'success',
            summary: 'Successful',
            detail: 'Collection Deleted',
            life: 3000,
          });
        })
      ),
    { dispatch: false }
  );
}
