import { createFeatureSelector, createSelector } from '@ngrx/store';
import { GenresState, genresAdapter } from './genres.state';

export const genresFeature =
  createFeatureSelector<GenresState>('genresFeature');
const selector = <T>(mapping: (state: GenresState) => T) =>
  createSelector(genresFeature, mapping);

const { selectEntities, selectAll } = genresAdapter.getSelectors();

export const selectGenreEntities = selector(selectEntities);

export const getGenres = selector(selectAll);

export const getSelectedGenreId = selector((state) => state.selectedGenreId);

export const getGenresTotal = selector((state) => state.total);

export const getGenre = createSelector(
  selectGenreEntities,
  getSelectedGenreId,
  (genres, selectedGenreId) => {
    if (selectedGenreId) {
      return genres[selectedGenreId];
    }
    return null;
  }
);
