import { createEntityAdapter, EntityState } from '@ngrx/entity';
import { Keyword } from 'api-client';

export interface KeywordsState extends EntityState<Keyword> {
  selectedKeywordId: string | null;
  total: number | null;

  error: string | null;
  status: 'pending' | 'loading' | 'error' | 'success'; //TODO: Enum
}

export function selectKeywordId(keyword: Keyword): string {
  return keyword.id ?? '';
}

export const keywordsAdapter = createEntityAdapter<Keyword>({
  selectId: selectKeywordId,
});

export const initialState: KeywordsState = keywordsAdapter.getInitialState({
  selectedKeywordId: null,
  total: 0,
  error: null,
  status: 'pending',
});
