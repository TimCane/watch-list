import { createReducer, on } from '@ngrx/store';
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
import { MoviesState, initialState, moviesAdapter } from './movies.state';

export const moviesReducer = createReducer<MoviesState>(
  initialState,

  on(selectMovie, (state, { movieId }) => {
    return { ...state, selectedMovieId: movieId };
  }),

  on(loadMovies, (state) => ({
    ...state,
    total: 0,
    status: 'loading',
    selectedMovieId: null,
  })),

  on(loadMovieSuccess, (state, { movie }) => {
    return moviesAdapter.upsertOne(movie, {
      ...state,
      error: null,
      status: 'success',
    });
  }),

  on(loadMovieFailure, (state, { error }) => {
    return moviesAdapter.removeAll({
      ...state,
      total: 0,
      selectedMovieId: null,
      error: error,
      status: 'error',
    });
  }),

  on(loadMoviesSuccess, (state, { movies, total }) => {
    return moviesAdapter.setAll(movies, {
      ...state,
      total,
      error: null,
      status: 'success',
    });
  }),

  on(loadMoviesFailure, (state, { error }) => {
    return moviesAdapter.removeAll({
      ...state,
      total: 0,
      selectedMovieId: null,
      error: error,
      status: 'error',
    });
  }),

  on(updateMovie, (state) => ({
    ...state,
    status: 'loading',
  })),

  on(updateMovieSuccess, (state, { movie }) => {
    return moviesAdapter.updateOne(
      { id: movie.id!, changes: movie },
      {
        ...state,
        error: null,
        status: 'success',
      }
    );
  }),

  on(updateMovieFailure, (state, { error }) => ({
    ...state,
    error: error,
    status: 'error',
  })),

  on(createMovie, (state) => ({
    ...state,
    status: 'loading',
  })),

  on(createMovieSuccess, (state, { movie }) => {
    return moviesAdapter.addOne(movie, {
      ...state,
      error: null,
      status: 'success',
    });
  }),

  on(createMovieFailure, (state, { error }) => ({
    ...state,
    error: error,
    status: 'error',
  })),

  on(deleteMovie, (state) => ({
    ...state,
    status: 'loading',
  })),

  on(deleteMovieSuccess, (state, { movieId }) => {
    return moviesAdapter.removeOne(movieId, {
      ...state,
      error: null,
      status: 'success',
    });
  }),

  on(deleteMovieFailure, (state, { error }) => ({
    ...state,
    error: error,
    status: 'error',
  }))
);

export const getSelectedMovieId = (state: MoviesState) => state.selectedMovieId;

// get the selectors
const { selectIds, selectEntities, selectAll, selectTotal } =
  moviesAdapter.getSelectors();

// select the array of movie ids
export const selectMovieIds = selectIds;

// select the dictionary of movie entities
export const selectMovieEntities = selectEntities;

// select the array of movies
export const selectAllMovies = selectAll;

// select the total movie count
export const selectMovieTotal = selectTotal;
