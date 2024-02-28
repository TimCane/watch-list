import { createFeatureSelector, createSelector } from '@ngrx/store';
import {
  ProductionCountriesState,
  productionCountriesAdapter,
} from './production-countries.state';

export const productionCountriesFeature =
  createFeatureSelector<ProductionCountriesState>('productionCountriesFeature');
const selector = <T>(mapping: (state: ProductionCountriesState) => T) =>
  createSelector(productionCountriesFeature, mapping);

const { selectEntities, selectAll } = productionCountriesAdapter.getSelectors();

export const selectProductionCountryEntities = selector(selectEntities);

export const getProductionCountries = selector(selectAll);

export const getSelectedProductionCountryId = selector(
  (state) => state.selectedProductionCountryId
);

export const getProductionCountriesTotal = selector((state) => state.total);

export const getProductionCountry = createSelector(
  selectProductionCountryEntities,
  getSelectedProductionCountryId,
  (productionCountries, selectedProductionCountryId) => {
    if (selectedProductionCountryId) {
      return productionCountries[selectedProductionCountryId];
    }
    return null;
  }
);
