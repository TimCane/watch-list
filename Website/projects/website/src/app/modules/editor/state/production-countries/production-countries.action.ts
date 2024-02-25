import { createAction, props } from '@ngrx/store';
import { PagedRequest, ProductionCountry } from 'api-client';

export const selectProductionCountry = createAction(
  '[ProductionCountry Page] Select ProductionCountry',
  props<{ productionCountryId: string | null }>()
);

export const loadProductionCountrySuccess = createAction(
  '[ProductionCountry Page] Load ProductionCountry',
  props<{ productionCountry: ProductionCountry }>()
);

export const loadProductionCountryFailure = createAction(
  '[ProductionCountry API] ProductionCountry Load Failure',
  props<{ error: string }>()
);

export const loadProductionCountries = createAction(
  '[ProductionCountry Page] Load ProductionCountries',
  props<{ request: PagedRequest }>()
);

export const loadProductionCountriesSuccess = createAction(
  '[ProductionCountry API] ProductionCountries Load Success',
  props<{ productionCountries: ProductionCountry[]; total: number }>()
);

export const loadProductionCountriesFailure = createAction(
  '[ProductionCountry API] ProductionCountries Load Failure',
  props<{ error: string }>()
);

export const updateProductionCountry = createAction(
  '[ProductionCountry Page] Update ProductionCountry',
  props<{ productionCountry: ProductionCountry }>()
);

export const updateProductionCountrySuccess = createAction(
  '[ProductionCountry API] ProductionCountry Update Success',
  props<{ productionCountry: ProductionCountry }>()
);

export const updateProductionCountryFailure = createAction(
  '[ProductionCountry API] ProductionCountry Update Failure',
  props<{ error: string }>()
);

export const createProductionCountry = createAction(
  '[ProductionCountry Page] Create ProductionCountry',
  props<{ productionCountry: ProductionCountry }>()
);

export const createProductionCountrySuccess = createAction(
  '[ProductionCountry API] ProductionCountry Create Success',
  props<{ productionCountry: ProductionCountry }>()
);

export const createProductionCountryFailure = createAction(
  '[ProductionCountry API] ProductionCountry Create Failure',
  props<{ error: string }>()
);

export const deleteProductionCountry = createAction(
  '[ProductionCountry Page] Delete ProductionCountry',
  props<{ productionCountry: ProductionCountry }>()
);

export const deleteProductionCountrySuccess = createAction(
  '[ProductionCountry API] ProductionCountry Delete Success',
  props<{ productionCountryId: string; success: boolean }>()
);

export const deleteProductionCountryFailure = createAction(
  '[ProductionCountry API] ProductionCountry Delete Failure',
  props<{ error: string }>()
);
