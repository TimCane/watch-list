import { createFeatureSelector, createSelector } from '@ngrx/store';
import { CreditsState, creditsAdapter } from './credits.state';

export const creditsFeature =
  createFeatureSelector<CreditsState>('creditsFeature');
const selector = <T>(mapping: (state: CreditsState) => T) =>
  createSelector(creditsFeature, mapping);

const { selectEntities, selectAll } = creditsAdapter.getSelectors();

export const selectCreditEntities = selector(selectEntities);

export const getCredits = selector(selectAll);

export const getSelectedCreditId = selector((state) => state.selectedCreditId);

export const getCreditsTotal = selector((state) => state.total);

export const getCredit = createSelector(
  selectCreditEntities,
  getSelectedCreditId,
  (credits, selectedCreditId) => {
    if (selectedCreditId) {
      return credits[selectedCreditId];
    }
    return null;
  }
);
