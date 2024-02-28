import { createReducer, on } from '@ngrx/store';
import {
  createKeyword,
  createKeywordFailure,
  createKeywordSuccess,
  deleteKeyword,
  deleteKeywordFailure,
  deleteKeywordSuccess,
  loadKeywordFailure,
  loadKeywordSuccess,
  loadKeywords,
  loadKeywordsFailure,
  loadKeywordsSuccess,
  selectKeyword,
  updateKeyword,
  updateKeywordFailure,
  updateKeywordSuccess,
} from './keywords.action';
import { KeywordsState, initialState, keywordsAdapter } from './keywords.state';

export const keywordsReducer = createReducer<KeywordsState>(
  initialState,

  on(selectKeyword, (state, { keywordId }) => {
    return { ...state, selectedKeywordId: keywordId };
  }),

  on(loadKeywords, (state) => ({
    ...state,
    total: 0,
    status: 'loading',
    selectedKeywordId: null,
  })),

  on(loadKeywordSuccess, (state, { keyword }) => {
    return keywordsAdapter.upsertOne(keyword, {
      ...state,
      error: null,
      status: 'success',
    });
  }),

  on(loadKeywordFailure, (state, { error }) => {
    return keywordsAdapter.removeAll({
      ...state,
      total: 0,
      selectedKeywordId: null,
      error: error,
      status: 'error',
    });
  }),

  on(loadKeywordsSuccess, (state, { keywords, total }) => {
    return keywordsAdapter.setAll(keywords, {
      ...state,
      total,
      error: null,
      status: 'success',
    });
  }),

  on(loadKeywordsFailure, (state, { error }) => {
    return keywordsAdapter.removeAll({
      ...state,
      total: 0,
      selectedKeywordId: null,
      error: error,
      status: 'error',
    });
  }),

  on(updateKeyword, (state) => ({
    ...state,
    status: 'loading',
  })),

  on(updateKeywordSuccess, (state, { keyword }) => {
    return keywordsAdapter.updateOne(
      { id: keyword.id!, changes: keyword },
      {
        ...state,
        error: null,
        status: 'success',
      }
    );
  }),

  on(updateKeywordFailure, (state, { error }) => ({
    ...state,
    error: error,
    status: 'error',
  })),

  on(createKeyword, (state) => ({
    ...state,
    status: 'loading',
  })),

  on(createKeywordSuccess, (state, { keyword }) => {
    return keywordsAdapter.addOne(keyword, {
      ...state,
      error: null,
      status: 'success',
    });
  }),

  on(createKeywordFailure, (state, { error }) => ({
    ...state,
    error: error,
    status: 'error',
  })),

  on(deleteKeyword, (state) => ({
    ...state,
    status: 'loading',
  })),

  on(deleteKeywordSuccess, (state, { keywordId }) => {
    return keywordsAdapter.removeOne(keywordId, {
      ...state,
      error: null,
      status: 'success',
    });
  }),

  on(deleteKeywordFailure, (state, { error }) => ({
    ...state,
    error: error,
    status: 'error',
  }))
);

export const getSelectedKeywordId = (state: KeywordsState) =>
  state.selectedKeywordId;

// get the selectors
const { selectIds, selectEntities, selectAll, selectTotal } =
  keywordsAdapter.getSelectors();

// select the array of keyword ids
export const selectKeywordIds = selectIds;

// select the dictionary of keyword entities
export const selectKeywordEntities = selectEntities;

// select the array of keywords
export const selectAllKeywords = selectAll;

// select the total keyword count
export const selectKeywordTotal = selectTotal;
