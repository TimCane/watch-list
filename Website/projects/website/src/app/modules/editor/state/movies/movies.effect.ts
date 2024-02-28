import { Injectable } from '@angular/core';
import { Actions, concatLatestFrom, createEffect, ofType } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import { MovieService } from 'api-client';
import { MessageService } from 'primeng/api';
import { AppState } from 'projects/website/src/app/app.state';
import { catchError, debounceTime, from, map, of, switchMap } from 'rxjs';
import {
  createMovie,
  createMovieFailure,
  createMovieSuccess,
  deleteMovie,
  deleteMovieFailure,
  deleteMovieSuccess,
  loadMovieFailure,
  loadMovieSuccess,
  loadMovies,
  loadMoviesFailure,
  loadMoviesSuccess,
  selectMovie,
  updateMovie,
  updateMovieFailure,
  updateMovieSuccess,
} from './movies.action';
import { getMovies } from './movies.selectors';

@Injectable()
export class MoviesEffects {
  constructor(
    private actions$: Actions,
    private store: Store<AppState>,
    private movieService: MovieService,
    private messageService: MessageService
  ) {}

  selectMovie$ = createEffect(() =>
    this.actions$.pipe(
      ofType(selectMovie),
      concatLatestFrom((action) => this.store.select(getMovies)),
      switchMap(([{ movieId }, movies]) => {
        var m = movies.find((m) => m.id == movieId);
        if (m) {
          return of(loadMovieSuccess({ movie: m }));
        }
        return from(this.movieService.getMovie(movieId!)).pipe(
          map((movie) => loadMovieSuccess({ movie })),
          catchError((error) => of(loadMovieFailure({ error })))
        );
      })
    )
  );

  loadMovies$ = createEffect(() =>
    this.actions$.pipe(
      ofType(loadMovies),
      switchMap(({ request }) => {
        return from(this.movieService.getMovies(request)).pipe(
          map(({ movies, total }) =>
            loadMoviesSuccess({
              movies: movies ?? [],
              total: total ?? 0,
            })
          ),
          catchError((error) => of(loadMoviesFailure({ error })))
        );
      })
    )
  );

  createMovie$ = createEffect(() =>
    this.actions$.pipe(
      ofType(createMovie),
      switchMap(({ movie }) =>
        from(this.movieService.createMovie(movie)).pipe(
          map((newMovie) => createMovieSuccess({ movie: newMovie })),
          catchError((error) => of(createMovieFailure({ error })))
        )
      )
    )
  );

  deleteMovie$ = createEffect(() =>
    this.actions$.pipe(
      ofType(deleteMovie),
      switchMap(({ movie }) =>
        from(this.movieService.deleteMovie(movie)).pipe(
          map((success) => {
            if (success) {
              return deleteMovieSuccess({
                movieId: movie.id!,
                success,
              });
            } else {
              return deleteMovieFailure({
                error: 'Unable to delete movie',
              });
            }
          }),
          catchError((error) => of(deleteMovieFailure({ error })))
        )
      )
    )
  );

  updateMovie$ = createEffect(() =>
    this.actions$.pipe(
      ofType(updateMovie),
      switchMap(({ movie }) =>
        from(this.movieService.updateMovie(movie)).pipe(
          map((newMovie) => updateMovieSuccess({ movie: newMovie })),
          catchError((error) => of(updateMovieFailure({ error })))
        )
      )
    )
  );

  notifyUpdate$ = createEffect(
    () =>
      this.actions$.pipe(
        ofType(updateMovieSuccess),
        map(({ movie }) => {
          this.messageService.add({
            severity: 'success',
            summary: 'Successful',
            detail: 'Movie Updated',
            life: 3000,
          });
        })
      ),
    { dispatch: false }
  );

  notifyCreate$ = createEffect(
    () =>
      this.actions$.pipe(
        ofType(createMovieSuccess),
        map(({ movie }) => {
          this.messageService.add({
            severity: 'success',
            summary: 'Successful',
            detail: 'Movie Created',
            life: 3000,
          });
        })
      ),
    { dispatch: false }
  );

  notifyDelete$ = createEffect(
    () =>
      this.actions$.pipe(
        ofType(deleteMovieSuccess),
        debounceTime(100),
        map(({ movieId }) => {
          this.messageService.add({
            severity: 'success',
            summary: 'Successful',
            detail: 'Movie Deleted',
            life: 3000,
          });
        })
      ),
    { dispatch: false }
  );
}
