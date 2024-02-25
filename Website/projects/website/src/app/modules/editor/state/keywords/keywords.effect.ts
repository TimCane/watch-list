import { Injectable } from '@angular/core';
import { Actions, concatLatestFrom, createEffect, ofType } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import { KeywordService } from 'api-client';
import { MessageService } from 'primeng/api';
import { AppState } from 'projects/website/src/app/app.state';
import { catchError, debounceTime, from, map, of, switchMap } from 'rxjs';
import {
  createKeyword,
  createKeywordFailure,
  createKeywordSuccess,
  deleteKeyword,
  deleteKeywordFailure,
  deleteKeywordSuccess,
  loadKeywordFailure,
  loadKeywordSuccess,
  loadKeywords,
  loadKeywordsFailure,
  loadKeywordsSuccess,
  selectKeyword,
  updateKeyword,
  updateKeywordFailure,
  updateKeywordSuccess,
} from './keywords.action';
import { getKeywords } from './keywords.selectors';

@Injectable()
export class KeywordsEffects {
  constructor(
    private actions$: Actions,
    private store: Store<AppState>,
    private keywordService: KeywordService,
    private messageService: MessageService
  ) {}

  selectKeyword$ = createEffect(() =>
    this.actions$.pipe(
      ofType(selectKeyword),
      concatLatestFrom((action) => this.store.select(getKeywords)),
      switchMap(([{ keywordId }, keywords]) => {
        var m = keywords.find((m) => m.id == keywordId);
        if (m) {
          return of(loadKeywordSuccess({ keyword: m }));
        }
        return from(this.keywordService.getKeyword(keywordId!)).pipe(
          map((keyword) => loadKeywordSuccess({ keyword })),
          catchError((error) => of(loadKeywordFailure({ error })))
        );
      })
    )
  );

  loadKeywords$ = createEffect(() =>
    this.actions$.pipe(
      ofType(loadKeywords),
      switchMap(({ request }) => {
        return from(this.keywordService.getKeywords(request)).pipe(
          map(({ keywords, total }) =>
            loadKeywordsSuccess({
              keywords: keywords ?? [],
              total: total ?? 0,
            })
          ),
          catchError((error) => of(loadKeywordsFailure({ error })))
        );
      })
    )
  );

  createKeyword$ = createEffect(() =>
    this.actions$.pipe(
      ofType(createKeyword),
      switchMap(({ keyword }) =>
        from(this.keywordService.createKeyword(keyword)).pipe(
          map((newKeyword) => createKeywordSuccess({ keyword: newKeyword })),
          catchError((error) => of(createKeywordFailure({ error })))
        )
      )
    )
  );

  deleteKeyword$ = createEffect(() =>
    this.actions$.pipe(
      ofType(deleteKeyword),
      switchMap(({ keyword }) =>
        from(this.keywordService.deleteKeyword(keyword)).pipe(
          map((success) => {
            if (success) {
              return deleteKeywordSuccess({
                keywordId: keyword.id!,
                success,
              });
            } else {
              return deleteKeywordFailure({
                error: 'Unable to delete keyword',
              });
            }
          }),
          catchError((error) => of(deleteKeywordFailure({ error })))
        )
      )
    )
  );

  updateKeyword$ = createEffect(() =>
    this.actions$.pipe(
      ofType(updateKeyword),
      switchMap(({ keyword }) =>
        from(this.keywordService.updateKeyword(keyword)).pipe(
          map((newKeyword) => updateKeywordSuccess({ keyword: newKeyword })),
          catchError((error) => of(updateKeywordFailure({ error })))
        )
      )
    )
  );

  notifyUpdate$ = createEffect(
    () =>
      this.actions$.pipe(
        ofType(updateKeywordSuccess),
        map(({ keyword }) => {
          this.messageService.add({
            severity: 'success',
            summary: 'Successful',
            detail: 'Keyword Updated',
            life: 3000,
          });
        })
      ),
    { dispatch: false }
  );

  notifyCreate$ = createEffect(
    () =>
      this.actions$.pipe(
        ofType(createKeywordSuccess),
        map(({ keyword }) => {
          this.messageService.add({
            severity: 'success',
            summary: 'Successful',
            detail: 'Keyword Created',
            life: 3000,
          });
        })
      ),
    { dispatch: false }
  );

  notifyDelete$ = createEffect(
    () =>
      this.actions$.pipe(
        ofType(deleteKeywordSuccess),
        debounceTime(100),
        map(({ keywordId }) => {
          this.messageService.add({
            severity: 'success',
            summary: 'Successful',
            detail: 'Keyword Deleted',
            life: 3000,
          });
        })
      ),
    { dispatch: false }
  );
}
