import { createFeatureSelector, createSelector } from '@ngrx/store';
import { KeywordsState, keywordsAdapter } from './keywords.state';

export const keywordsFeature =
  createFeatureSelector<KeywordsState>('keywordsFeature');
const selector = <T>(mapping: (state: KeywordsState) => T) =>
  createSelector(keywordsFeature, mapping);

const { selectEntities, selectAll } = keywordsAdapter.getSelectors();

export const selectKeywordEntities = selector(selectEntities);

export const getKeywords = selector(selectAll);

export const getSelectedKeywordId = selector(
  (state) => state.selectedKeywordId
);

export const getKeywordsTotal = selector((state) => state.total);

export const getKeyword = createSelector(
  selectKeywordEntities,
  getSelectedKeywordId,
  (keywords, selectedKeywordId) => {
    if (selectedKeywordId) {
      return keywords[selectedKeywordId];
    }
    return null;
  }
);
