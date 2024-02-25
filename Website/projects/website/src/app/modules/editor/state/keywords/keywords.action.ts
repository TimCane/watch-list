import { createAction, props } from '@ngrx/store';
import { Keyword, PagedRequest } from 'api-client';

export const selectKeyword = createAction(
  '[Keyword Page] Select Keyword',
  props<{ keywordId: string | null }>()
);

export const loadKeywordSuccess = createAction(
  '[Keyword Page] Load Keyword',
  props<{ keyword: Keyword }>()
);

export const loadKeywordFailure = createAction(
  '[Keyword API] Keyword Load Failure',
  props<{ error: string }>()
);

export const loadKeywords = createAction(
  '[Keyword Page] Load Keywords',
  props<{ request: PagedRequest }>()
);

export const loadKeywordsSuccess = createAction(
  '[Keyword API] Keywords Load Success',
  props<{ keywords: Keyword[]; total: number }>()
);

export const loadKeywordsFailure = createAction(
  '[Keyword API] Keywords Load Failure',
  props<{ error: string }>()
);

export const updateKeyword = createAction(
  '[Keyword Page] Update Keyword',
  props<{ keyword: Keyword }>()
);

export const updateKeywordSuccess = createAction(
  '[Keyword API] Keyword Update Success',
  props<{ keyword: Keyword }>()
);

export const updateKeywordFailure = createAction(
  '[Keyword API] Keyword Update Failure',
  props<{ error: string }>()
);

export const createKeyword = createAction(
  '[Keyword Page] Create Keyword',
  props<{ keyword: Keyword }>()
);

export const createKeywordSuccess = createAction(
  '[Keyword API] Keyword Create Success',
  props<{ keyword: Keyword }>()
);

export const createKeywordFailure = createAction(
  '[Keyword API] Keyword Create Failure',
  props<{ error: string }>()
);

export const deleteKeyword = createAction(
  '[Keyword Page] Delete Keyword',
  props<{ keyword: Keyword }>()
);

export const deleteKeywordSuccess = createAction(
  '[Keyword API] Keyword Delete Success',
  props<{ keywordId: string; success: boolean }>()
);

export const deleteKeywordFailure = createAction(
  '[Keyword API] Keyword Delete Failure',
  props<{ error: string }>()
);
