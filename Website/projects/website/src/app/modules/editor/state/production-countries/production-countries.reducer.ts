import { createReducer, on } from '@ngrx/store';
import {
  createProductionCountry,
  createProductionCountryFailure,
  createProductionCountrySuccess,
  deleteProductionCountry,
  deleteProductionCountryFailure,
  deleteProductionCountrySuccess,
  loadProductionCountries,
  loadProductionCountriesFailure,
  loadProductionCountriesSuccess,
  loadProductionCountryFailure,
  loadProductionCountrySuccess,
  selectProductionCountry,
  updateProductionCountry,
  updateProductionCountryFailure,
  updateProductionCountrySuccess,
} from './production-countries.action';
import {
  ProductionCountriesState,
  initialState,
  productionCountriesAdapter,
} from './production-countries.state';

export const productionCountriesReducer =
  createReducer<ProductionCountriesState>(
    initialState,

    on(selectProductionCountry, (state, { productionCountryId }) => {
      return { ...state, selectedProductionCountryId: productionCountryId };
    }),

    on(loadProductionCountries, (state) => ({
      ...state,
      total: 0,
      status: 'loading',
      selectedProductionCountryId: null,
    })),

    on(loadProductionCountrySuccess, (state, { productionCountry }) => {
      return productionCountriesAdapter.upsertOne(productionCountry, {
        ...state,
        error: null,
        status: 'success',
      });
    }),

    on(loadProductionCountryFailure, (state, { error }) => {
      return productionCountriesAdapter.removeAll({
        ...state,
        total: 0,
        selectedProductionCountryId: null,
        error: error,
        status: 'error',
      });
    }),

    on(
      loadProductionCountriesSuccess,
      (state, { productionCountries, total }) => {
        return productionCountriesAdapter.setAll(productionCountries, {
          ...state,
          total,
          error: null,
          status: 'success',
        });
      }
    ),

    on(loadProductionCountriesFailure, (state, { error }) => {
      return productionCountriesAdapter.removeAll({
        ...state,
        total: 0,
        selectedProductionCountryId: null,
        error: error,
        status: 'error',
      });
    }),

    on(updateProductionCountry, (state) => ({
      ...state,
      status: 'loading',
    })),

    on(updateProductionCountrySuccess, (state, { productionCountry }) => {
      return productionCountriesAdapter.updateOne(
        { id: productionCountry.id!, changes: productionCountry },
        {
          ...state,
          error: null,
          status: 'success',
        }
      );
    }),

    on(updateProductionCountryFailure, (state, { error }) => ({
      ...state,
      error: error,
      status: 'error',
    })),

    on(createProductionCountry, (state) => ({
      ...state,
      status: 'loading',
    })),

    on(createProductionCountrySuccess, (state, { productionCountry }) => {
      return productionCountriesAdapter.addOne(productionCountry, {
        ...state,
        error: null,
        status: 'success',
      });
    }),

    on(createProductionCountryFailure, (state, { error }) => ({
      ...state,
      error: error,
      status: 'error',
    })),

    on(deleteProductionCountry, (state) => ({
      ...state,
      status: 'loading',
    })),

    on(deleteProductionCountrySuccess, (state, { productionCountryId }) => {
      return productionCountriesAdapter.removeOne(productionCountryId, {
        ...state,
        error: null,
        status: 'success',
      });
    }),

    on(deleteProductionCountryFailure, (state, { error }) => ({
      ...state,
      error: error,
      status: 'error',
    }))
  );

export const getSelectedProductionCountryId = (
  state: ProductionCountriesState
) => state.selectedProductionCountryId;

// get the selectors
const { selectIds, selectEntities, selectAll, selectTotal } =
  productionCountriesAdapter.getSelectors();

// select the array of productionCountry ids
export const selectProductionCountryIds = selectIds;

// select the dictionary of productionCountry entities
export const selectProductionCountryEntities = selectEntities;

// select the array of productionCountries
export const selectAllProductionCountries = selectAll;

// select the total productionCountry count
export const selectProductionCountryTotal = selectTotal;
