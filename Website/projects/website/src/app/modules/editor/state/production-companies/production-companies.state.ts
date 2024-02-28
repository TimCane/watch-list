import { createEntityAdapter, EntityState } from '@ngrx/entity';
import { ProductionCompany } from 'api-client';

export interface ProductionCompaniesState
  extends EntityState<ProductionCompany> {
  selectedProductionCompanyId: string | null;
  total: number | null;

  error: string | null;
  status: 'pending' | 'loading' | 'error' | 'success'; //TODO: Enum
}

export function selectProductionCompanyId(
  productionCompany: ProductionCompany
): string {
  return productionCompany.id ?? '';
}

export const productionCompaniesAdapter =
  createEntityAdapter<ProductionCompany>({
    selectId: selectProductionCompanyId,
  });

export const initialState: ProductionCompaniesState =
  productionCompaniesAdapter.getInitialState({
    selectedProductionCompanyId: null,
    total: 0,
    error: null,
    status: 'pending',
  });
