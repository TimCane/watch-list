import { createEntityAdapter, EntityState } from '@ngrx/entity';
import { Genre } from 'api-client';

export interface GenresState extends EntityState<Genre> {
  selectedGenreId: string | null;
  total: number | null;

  error: string | null;
  status: 'pending' | 'loading' | 'error' | 'success'; //TODO: Enum
}

export function selectGenreId(genre: Genre): string {
  return genre.id ?? '';
}

export const genresAdapter = createEntityAdapter<Genre>({
  selectId: selectGenreId,
});

export const initialState: GenresState = genresAdapter.getInitialState({
  selectedGenreId: null,
  total: 0,
  error: null,
  status: 'pending',
});
