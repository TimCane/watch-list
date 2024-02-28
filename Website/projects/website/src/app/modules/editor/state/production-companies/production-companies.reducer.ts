import { createReducer, on } from '@ngrx/store';
import {
  createProductionCompany,
  createProductionCompanyFailure,
  createProductionCompanySuccess,
  deleteProductionCompany,
  deleteProductionCompanyFailure,
  deleteProductionCompanySuccess,
  loadProductionCompanies,
  loadProductionCompaniesFailure,
  loadProductionCompaniesSuccess,
  loadProductionCompanyFailure,
  loadProductionCompanySuccess,
  selectProductionCompany,
  updateProductionCompany,
  updateProductionCompanyFailure,
  updateProductionCompanySuccess,
} from './production-companies.action';
import {
  ProductionCompaniesState,
  initialState,
  productionCompaniesAdapter,
} from './production-companies.state';

export const productionCompaniesReducer =
  createReducer<ProductionCompaniesState>(
    initialState,

    on(selectProductionCompany, (state, { productionCompanyId }) => {
      return { ...state, selectedProductionCompanyId: productionCompanyId };
    }),

    on(loadProductionCompanies, (state) => ({
      ...state,
      total: 0,
      status: 'loading',
      selectedProductionCompanyId: null,
    })),

    on(loadProductionCompanySuccess, (state, { productionCompany }) => {
      return productionCompaniesAdapter.upsertOne(productionCompany, {
        ...state,
        error: null,
        status: 'success',
      });
    }),

    on(loadProductionCompanyFailure, (state, { error }) => {
      return productionCompaniesAdapter.removeAll({
        ...state,
        total: 0,
        selectedProductionCompanyId: null,
        error: error,
        status: 'error',
      });
    }),

    on(
      loadProductionCompaniesSuccess,
      (state, { productionCompanies, total }) => {
        return productionCompaniesAdapter.setAll(productionCompanies, {
          ...state,
          total,
          error: null,
          status: 'success',
        });
      }
    ),

    on(loadProductionCompaniesFailure, (state, { error }) => {
      return productionCompaniesAdapter.removeAll({
        ...state,
        total: 0,
        selectedProductionCompanyId: null,
        error: error,
        status: 'error',
      });
    }),

    on(updateProductionCompany, (state) => ({
      ...state,
      status: 'loading',
    })),

    on(updateProductionCompanySuccess, (state, { productionCompany }) => {
      return productionCompaniesAdapter.updateOne(
        { id: productionCompany.id!, changes: productionCompany },
        {
          ...state,
          error: null,
          status: 'success',
        }
      );
    }),

    on(updateProductionCompanyFailure, (state, { error }) => ({
      ...state,
      error: error,
      status: 'error',
    })),

    on(createProductionCompany, (state) => ({
      ...state,
      status: 'loading',
    })),

    on(createProductionCompanySuccess, (state, { productionCompany }) => {
      return productionCompaniesAdapter.addOne(productionCompany, {
        ...state,
        error: null,
        status: 'success',
      });
    }),

    on(createProductionCompanyFailure, (state, { error }) => ({
      ...state,
      error: error,
      status: 'error',
    })),

    on(deleteProductionCompany, (state) => ({
      ...state,
      status: 'loading',
    })),

    on(deleteProductionCompanySuccess, (state, { productionCompanyId }) => {
      return productionCompaniesAdapter.removeOne(productionCompanyId, {
        ...state,
        error: null,
        status: 'success',
      });
    }),

    on(deleteProductionCompanyFailure, (state, { error }) => ({
      ...state,
      error: error,
      status: 'error',
    }))
  );

export const getSelectedProductionCompanyId = (
  state: ProductionCompaniesState
) => state.selectedProductionCompanyId;

// get the selectors
const { selectIds, selectEntities, selectAll, selectTotal } =
  productionCompaniesAdapter.getSelectors();

// select the array of productionCompany ids
export const selectProductionCompanyIds = selectIds;

// select the dictionary of productionCompany entities
export const selectProductionCompanyEntities = selectEntities;

// select the array of productionCompanies
export const selectAllProductionCompanies = selectAll;

// select the total productionCompany count
export const selectProductionCompanyTotal = selectTotal;
