import { Injectable } from '@angular/core';
import { Actions, concatLatestFrom, createEffect, ofType } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import { GenreService } from 'api-client';
import { MessageService } from 'primeng/api';
import { AppState } from 'projects/website/src/app/app.state';
import { catchError, debounceTime, from, map, of, switchMap } from 'rxjs';
import {
  createGenre,
  createGenreFailure,
  createGenreSuccess,
  deleteGenre,
  deleteGenreFailure,
  deleteGenreSuccess,
  loadGenreFailure,
  loadGenreSuccess,
  loadGenres,
  loadGenresFailure,
  loadGenresSuccess,
  selectGenre,
  updateGenre,
  updateGenreFailure,
  updateGenreSuccess,
} from './genres.action';
import { getGenres } from './genres.selectors';

@Injectable()
export class GenresEffects {
  constructor(
    private actions$: Actions,
    private store: Store<AppState>,
    private genreService: GenreService,
    private messageService: MessageService
  ) {}

  selectGenre$ = createEffect(() =>
    this.actions$.pipe(
      ofType(selectGenre),
      concatLatestFrom((action) => this.store.select(getGenres)),
      switchMap(([{ genreId }, genres]) => {
        var m = genres.find((m) => m.id == genreId);
        if (m) {
          return of(loadGenreSuccess({ genre: m }));
        }
        return from(this.genreService.getGenre(genreId!)).pipe(
          map((genre) => loadGenreSuccess({ genre })),
          catchError((error) => of(loadGenreFailure({ error })))
        );
      })
    )
  );

  loadGenres$ = createEffect(() =>
    this.actions$.pipe(
      ofType(loadGenres),
      switchMap(({ request }) => {
        return from(this.genreService.getGenres(request)).pipe(
          map(({ genres, total }) =>
            loadGenresSuccess({
              genres: genres ?? [],
              total: total ?? 0,
            })
          ),
          catchError((error) => of(loadGenresFailure({ error })))
        );
      })
    )
  );

  createGenre$ = createEffect(() =>
    this.actions$.pipe(
      ofType(createGenre),
      switchMap(({ genre }) =>
        from(this.genreService.createGenre(genre)).pipe(
          map((newGenre) => createGenreSuccess({ genre: newGenre })),
          catchError((error) => of(createGenreFailure({ error })))
        )
      )
    )
  );

  deleteGenre$ = createEffect(() =>
    this.actions$.pipe(
      ofType(deleteGenre),
      switchMap(({ genre }) =>
        from(this.genreService.deleteGenre(genre)).pipe(
          map((success) => {
            if (success) {
              return deleteGenreSuccess({
                genreId: genre.id!,
                success,
              });
            } else {
              return deleteGenreFailure({
                error: 'Unable to delete genre',
              });
            }
          }),
          catchError((error) => of(deleteGenreFailure({ error })))
        )
      )
    )
  );

  updateGenre$ = createEffect(() =>
    this.actions$.pipe(
      ofType(updateGenre),
      switchMap(({ genre }) =>
        from(this.genreService.updateGenre(genre)).pipe(
          map((newGenre) => updateGenreSuccess({ genre: newGenre })),
          catchError((error) => of(updateGenreFailure({ error })))
        )
      )
    )
  );

  notifyUpdate$ = createEffect(
    () =>
      this.actions$.pipe(
        ofType(updateGenreSuccess),
        map(({ genre }) => {
          this.messageService.add({
            severity: 'success',
            summary: 'Successful',
            detail: 'Genre Updated',
            life: 3000,
          });
        })
      ),
    { dispatch: false }
  );

  notifyCreate$ = createEffect(
    () =>
      this.actions$.pipe(
        ofType(createGenreSuccess),
        map(({ genre }) => {
          this.messageService.add({
            severity: 'success',
            summary: 'Successful',
            detail: 'Genre Created',
            life: 3000,
          });
        })
      ),
    { dispatch: false }
  );

  notifyDelete$ = createEffect(
    () =>
      this.actions$.pipe(
        ofType(deleteGenreSuccess),
        debounceTime(100),
        map(({ genreId }) => {
          this.messageService.add({
            severity: 'success',
            summary: 'Successful',
            detail: 'Genre Deleted',
            life: 3000,
          });
        })
      ),
    { dispatch: false }
  );
}
