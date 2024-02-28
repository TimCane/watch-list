import { createAction, props } from '@ngrx/store';
import { Genre, PagedRequest } from 'api-client';

export const selectGenre = createAction(
  '[Genre Page] Select Genre',
  props<{ genreId: string | null }>()
);

export const loadGenreSuccess = createAction(
  '[Genre Page] Load Genre',
  props<{ genre: Genre }>()
);

export const loadGenreFailure = createAction(
  '[Genre API] Genre Load Failure',
  props<{ error: string }>()
);

export const loadGenres = createAction(
  '[Genre Page] Load Genres',
  props<{ request: PagedRequest }>()
);

export const loadGenresSuccess = createAction(
  '[Genre API] Genres Load Success',
  props<{ genres: Genre[]; total: number }>()
);

export const loadGenresFailure = createAction(
  '[Genre API] Genres Load Failure',
  props<{ error: string }>()
);

export const updateGenre = createAction(
  '[Genre Page] Update Genre',
  props<{ genre: Genre }>()
);

export const updateGenreSuccess = createAction(
  '[Genre API] Genre Update Success',
  props<{ genre: Genre }>()
);

export const updateGenreFailure = createAction(
  '[Genre API] Genre Update Failure',
  props<{ error: string }>()
);

export const createGenre = createAction(
  '[Genre Page] Create Genre',
  props<{ genre: Genre }>()
);

export const createGenreSuccess = createAction(
  '[Genre API] Genre Create Success',
  props<{ genre: Genre }>()
);

export const createGenreFailure = createAction(
  '[Genre API] Genre Create Failure',
  props<{ error: string }>()
);

export const deleteGenre = createAction(
  '[Genre Page] Delete Genre',
  props<{ genre: Genre }>()
);

export const deleteGenreSuccess = createAction(
  '[Genre API] Genre Delete Success',
  props<{ genreId: string; success: boolean }>()
);

export const deleteGenreFailure = createAction(
  '[Genre API] Genre Delete Failure',
  props<{ error: string }>()
);
