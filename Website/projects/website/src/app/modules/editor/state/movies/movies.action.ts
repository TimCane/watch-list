import { createAction, props } from '@ngrx/store';
import { Movie, PagedRequest } from 'api-client';

export const selectMovie = createAction(
  '[Movie Page] Select Movie',
  props<{ movieId: string | null }>()
);

export const loadMovieSuccess = createAction(
  '[Movie Page] Load Movie',
  props<{ movie: Movie }>()
);

export const loadMovieFailure = createAction(
  '[Movie API] Movie Load Failure',
  props<{ error: string }>()
);

export const loadMovies = createAction(
  '[Movie Page] Load Movies',
  props<{ request: PagedRequest }>()
);

export const loadMoviesSuccess = createAction(
  '[Movie API] Movies Load Success',
  props<{ movies: Movie[]; total: number }>()
);

export const loadMoviesFailure = createAction(
  '[Movie API] Movies Load Failure',
  props<{ error: string }>()
);

export const updateMovie = createAction(
  '[Movie Page] Update Movie',
  props<{ movie: Movie }>()
);

export const updateMovieSuccess = createAction(
  '[Movie API] Movie Update Success',
  props<{ movie: Movie }>()
);

export const updateMovieFailure = createAction(
  '[Movie API] Movie Update Failure',
  props<{ error: string }>()
);

export const createMovie = createAction(
  '[Movie Page] Create Movie',
  props<{ movie: Movie }>()
);

export const createMovieSuccess = createAction(
  '[Movie API] Movie Create Success',
  props<{ movie: Movie }>()
);

export const createMovieFailure = createAction(
  '[Movie API] Movie Create Failure',
  props<{ error: string }>()
);

export const deleteMovie = createAction(
  '[Movie Page] Delete Movie',
  props<{ movie: Movie }>()
);

export const deleteMovieSuccess = createAction(
  '[Movie API] Movie Delete Success',
  props<{ movieId: string; success: boolean }>()
);

export const deleteMovieFailure = createAction(
  '[Movie API] Movie Delete Failure',
  props<{ error: string }>()
);
