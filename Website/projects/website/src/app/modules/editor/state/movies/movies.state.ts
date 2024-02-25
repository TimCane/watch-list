import { createEntityAdapter, EntityState } from '@ngrx/entity';
import { Movie } from 'api-client';

export interface MoviesState extends EntityState<Movie> {
  selectedMovieId: string | null;
  total: number | null;

  error: string | null;
  status: 'pending' | 'loading' | 'error' | 'success'; //TODO: Enum
}

export function selectMovieId(movie: Movie): string {
  return movie.id ?? '';
}

export const moviesAdapter = createEntityAdapter<Movie>({
  selectId: selectMovieId,
});

export const initialState: MoviesState = moviesAdapter.getInitialState({
  selectedMovieId: null,
  total: 0,
  error: null,
  status: 'pending',
});
