import { createAction, props } from '@ngrx/store';
import { Credit, PagedRequest } from 'api-client';

export const selectCredit = createAction(
  '[Credit Page] Select Credit',
  props<{ creditId: string | null }>()
);

export const loadCreditSuccess = createAction(
  '[Credit Page] Load Credit',
  props<{ credit: Credit }>()
);

export const loadCreditFailure = createAction(
  '[Credit API] Credit Load Failure',
  props<{ error: string }>()
);

export const loadCredits = createAction(
  '[Credit Page] Load Credits',
  props<{ request: PagedRequest }>()
);

export const loadCreditsSuccess = createAction(
  '[Credit API] Credits Load Success',
  props<{ credits: Credit[]; total: number }>()
);

export const loadCreditsFailure = createAction(
  '[Credit API] Credits Load Failure',
  props<{ error: string }>()
);

export const updateCredit = createAction(
  '[Credit Page] Update Credit',
  props<{ credit: Credit }>()
);

export const updateCreditSuccess = createAction(
  '[Credit API] Credit Update Success',
  props<{ credit: Credit }>()
);

export const updateCreditFailure = createAction(
  '[Credit API] Credit Update Failure',
  props<{ error: string }>()
);

export const createCredit = createAction(
  '[Credit Page] Create Credit',
  props<{ credit: Credit }>()
);

export const createCreditSuccess = createAction(
  '[Credit API] Credit Create Success',
  props<{ credit: Credit }>()
);

export const createCreditFailure = createAction(
  '[Credit API] Credit Create Failure',
  props<{ error: string }>()
);

export const deleteCredit = createAction(
  '[Credit Page] Delete Credit',
  props<{ credit: Credit }>()
);

export const deleteCreditSuccess = createAction(
  '[Credit API] Credit Delete Success',
  props<{ creditId: string; success: boolean }>()
);

export const deleteCreditFailure = createAction(
  '[Credit API] Credit Delete Failure',
  props<{ error: string }>()
);
