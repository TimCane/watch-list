import { createFeatureSelector, createSelector } from '@ngrx/store';
import { MoviesState, moviesAdapter } from './movies.state';

export const moviesFeature =
  createFeatureSelector<MoviesState>('moviesFeature');
const selector = <T>(mapping: (state: MoviesState) => T) =>
  createSelector(moviesFeature, mapping);

const { selectEntities, selectAll } = moviesAdapter.getSelectors();

export const selectMovieEntities = selector(selectEntities);

export const getMovies = selector(selectAll);

export const getSelectedMovieId = selector((state) => state.selectedMovieId);

export const getMoviesTotal = selector((state) => state.total);

export const getMovie = createSelector(
  selectMovieEntities,
  getSelectedMovieId,
  (movies, selectedMovieId) => {
    if (selectedMovieId) {
      return movies[selectedMovieId];
    }
    return null;
  }
);
