import { createEntityAdapter, EntityState } from '@ngrx/entity';
import { ProductionCountry } from 'api-client';

export interface ProductionCountriesState
  extends EntityState<ProductionCountry> {
  selectedProductionCountryId: string | null;
  total: number | null;

  error: string | null;
  status: 'pending' | 'loading' | 'error' | 'success'; //TODO: Enum
}

export function selectProductionCountryId(
  productionCountry: ProductionCountry
): string {
  return productionCountry.id ?? '';
}

export const productionCountriesAdapter =
  createEntityAdapter<ProductionCountry>({
    selectId: selectProductionCountryId,
  });

export const initialState: ProductionCountriesState =
  productionCountriesAdapter.getInitialState({
    selectedProductionCountryId: null,
    total: 0,
    error: null,
    status: 'pending',
  });
