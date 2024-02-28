import { createReducer, on } from '@ngrx/store';
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
import { GenresState, genresAdapter, initialState } from './genres.state';

export const genresReducer = createReducer<GenresState>(
  initialState,

  on(selectGenre, (state, { genreId }) => {
    return { ...state, selectedGenreId: genreId };
  }),

  on(loadGenres, (state) => ({
    ...state,
    total: 0,
    status: 'loading',
    selectedGenreId: null,
  })),

  on(loadGenreSuccess, (state, { genre }) => {
    return genresAdapter.upsertOne(genre, {
      ...state,
      error: null,
      status: 'success',
    });
  }),

  on(loadGenreFailure, (state, { error }) => {
    return genresAdapter.removeAll({
      ...state,
      total: 0,
      selectedGenreId: null,
      error: error,
      status: 'error',
    });
  }),

  on(loadGenresSuccess, (state, { genres, total }) => {
    return genresAdapter.setAll(genres, {
      ...state,
      total,
      error: null,
      status: 'success',
    });
  }),

  on(loadGenresFailure, (state, { error }) => {
    return genresAdapter.removeAll({
      ...state,
      total: 0,
      selectedGenreId: null,
      error: error,
      status: 'error',
    });
  }),

  on(updateGenre, (state) => ({
    ...state,
    status: 'loading',
  })),

  on(updateGenreSuccess, (state, { genre }) => {
    return genresAdapter.updateOne(
      { id: genre.id!, changes: genre },
      {
        ...state,
        error: null,
        status: 'success',
      }
    );
  }),

  on(updateGenreFailure, (state, { error }) => ({
    ...state,
    error: error,
    status: 'error',
  })),

  on(createGenre, (state) => ({
    ...state,
    status: 'loading',
  })),

  on(createGenreSuccess, (state, { genre }) => {
    return genresAdapter.addOne(genre, {
      ...state,
      error: null,
      status: 'success',
    });
  }),

  on(createGenreFailure, (state, { error }) => ({
    ...state,
    error: error,
    status: 'error',
  })),

  on(deleteGenre, (state) => ({
    ...state,
    status: 'loading',
  })),

  on(deleteGenreSuccess, (state, { genreId }) => {
    return genresAdapter.removeOne(genreId, {
      ...state,
      error: null,
      status: 'success',
    });
  }),

  on(deleteGenreFailure, (state, { error }) => ({
    ...state,
    error: error,
    status: 'error',
  }))
);

export const getSelectedGenreId = (state: GenresState) => state.selectedGenreId;

// get the selectors
const { selectIds, selectEntities, selectAll, selectTotal } =
  genresAdapter.getSelectors();

// select the array of genre ids
export const selectGenreIds = selectIds;

// select the dictionary of genre entities
export const selectGenreEntities = selectEntities;

// select the array of genres
export const selectAllGenres = selectAll;

// select the total genre count
export const selectGenreTotal = selectTotal;
