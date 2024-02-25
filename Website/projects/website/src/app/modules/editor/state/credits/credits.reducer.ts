import { createReducer, on } from '@ngrx/store';
import {
  createCredit,
  createCreditFailure,
  createCreditSuccess,
  deleteCredit,
  deleteCreditFailure,
  deleteCreditSuccess,
  loadCreditFailure,
  loadCreditSuccess,
  loadCredits,
  loadCreditsFailure,
  loadCreditsSuccess,
  selectCredit,
  updateCredit,
  updateCreditFailure,
  updateCreditSuccess,
} from './credits.action';
import { CreditsState, creditsAdapter, initialState } from './credits.state';

export const creditsReducer = createReducer<CreditsState>(
  initialState,

  on(selectCredit, (state, { creditId }) => {
    return { ...state, selectedCreditId: creditId };
  }),

  on(loadCredits, (state) => ({
    ...state,
    total: 0,
    status: 'loading',
    selectedCreditId: null,
  })),

  on(loadCreditSuccess, (state, { credit }) => {
    return creditsAdapter.upsertOne(credit, {
      ...state,
      error: null,
      status: 'success',
    });
  }),

  on(loadCreditFailure, (state, { error }) => {
    return creditsAdapter.removeAll({
      ...state,
      total: 0,
      selectedCreditId: null,
      error: error,
      status: 'error',
    });
  }),

  on(loadCreditsSuccess, (state, { credits, total }) => {
    return creditsAdapter.setAll(credits, {
      ...state,
      total,
      error: null,
      status: 'success',
    });
  }),

  on(loadCreditsFailure, (state, { error }) => {
    return creditsAdapter.removeAll({
      ...state,
      total: 0,
      selectedCreditId: null,
      error: error,
      status: 'error',
    });
  }),

  on(updateCredit, (state) => ({
    ...state,
    status: 'loading',
  })),

  on(updateCreditSuccess, (state, { credit }) => {
    return creditsAdapter.updateOne(
      { id: credit.id!, changes: credit },
      {
        ...state,
        error: null,
        status: 'success',
      }
    );
  }),

  on(updateCreditFailure, (state, { error }) => ({
    ...state,
    error: error,
    status: 'error',
  })),

  on(createCredit, (state) => ({
    ...state,
    status: 'loading',
  })),

  on(createCreditSuccess, (state, { credit }) => {
    return creditsAdapter.addOne(credit, {
      ...state,
      error: null,
      status: 'success',
    });
  }),

  on(createCreditFailure, (state, { error }) => ({
    ...state,
    error: error,
    status: 'error',
  })),

  on(deleteCredit, (state) => ({
    ...state,
    status: 'loading',
  })),

  on(deleteCreditSuccess, (state, { creditId }) => {
    return creditsAdapter.removeOne(creditId, {
      ...state,
      error: null,
      status: 'success',
    });
  }),

  on(deleteCreditFailure, (state, { error }) => ({
    ...state,
    error: error,
    status: 'error',
  }))
);

export const getSelectedCreditId = (state: CreditsState) =>
  state.selectedCreditId;

// get the selectors
const { selectIds, selectEntities, selectAll, selectTotal } =
  creditsAdapter.getSelectors();

// select the array of credit ids
export const selectCreditIds = selectIds;

// select the dictionary of credit entities
export const selectCreditEntities = selectEntities;

// select the array of credits
export const selectAllCredits = selectAll;

// select the total credit count
export const selectCreditTotal = selectTotal;
