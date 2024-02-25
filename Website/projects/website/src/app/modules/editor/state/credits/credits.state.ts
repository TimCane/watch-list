import { createEntityAdapter, EntityState } from '@ngrx/entity';
import { Credit } from 'api-client';

export interface CreditsState extends EntityState<Credit> {
  selectedCreditId: string | null;
  total: number | null;

  error: string | null;
  status: 'pending' | 'loading' | 'error' | 'success'; //TODO: Enum
}

export function selectCreditId(credit: Credit): string {
  return credit.id ?? '';
}

export const creditsAdapter = createEntityAdapter<Credit>({
  selectId: selectCreditId,
});

export const initialState: CreditsState = creditsAdapter.getInitialState({
  selectedCreditId: null,
  total: 0,
  error: null,
  status: 'pending',
});
