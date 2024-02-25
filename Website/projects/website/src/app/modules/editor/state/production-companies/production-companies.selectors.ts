import { createFeatureSelector, createSelector } from '@ngrx/store';
import {
  ProductionCompaniesState,
  productionCompaniesAdapter,
} from './production-companies.state';

export const productionCompaniesFeature =
  createFeatureSelector<ProductionCompaniesState>('productionCompaniesFeature');
const selector = <T>(mapping: (state: ProductionCompaniesState) => T) =>
  createSelector(productionCompaniesFeature, mapping);

const { selectEntities, selectAll } = productionCompaniesAdapter.getSelectors();

export const selectProductionCompanyEntities = selector(selectEntities);

export const getProductionCompanies = selector(selectAll);

export const getSelectedProductionCompanyId = selector(
  (state) => state.selectedProductionCompanyId
);

export const getProductionCompaniesTotal = selector((state) => state.total);

export const getProductionCompany = createSelector(
  selectProductionCompanyEntities,
  getSelectedProductionCompanyId,
  (productionCompanies, selectedProductionCompanyId) => {
    if (selectedProductionCompanyId) {
      return productionCompanies[selectedProductionCompanyId];
    }
    return null;
  }
);
