import { createAction, props } from '@ngrx/store';
import { PagedRequest, ProductionCompany } from 'api-client';

export const selectProductionCompany = createAction(
  '[ProductionCompany Page] Select ProductionCompany',
  props<{ productionCompanyId: string | null }>()
);

export const loadProductionCompanySuccess = createAction(
  '[ProductionCompany Page] Load ProductionCompany',
  props<{ productionCompany: ProductionCompany }>()
);

export const loadProductionCompanyFailure = createAction(
  '[ProductionCompany API] ProductionCompany Load Failure',
  props<{ error: string }>()
);

export const loadProductionCompanies = createAction(
  '[ProductionCompany Page] Load ProductionCompanies',
  props<{ request: PagedRequest }>()
);

export const loadProductionCompaniesSuccess = createAction(
  '[ProductionCompany API] ProductionCompanies Load Success',
  props<{ productionCompanies: ProductionCompany[]; total: number }>()
);

export const loadProductionCompaniesFailure = createAction(
  '[ProductionCompany API] ProductionCompanies Load Failure',
  props<{ error: string }>()
);

export const updateProductionCompany = createAction(
  '[ProductionCompany Page] Update ProductionCompany',
  props<{ productionCompany: ProductionCompany }>()
);

export const updateProductionCompanySuccess = createAction(
  '[ProductionCompany API] ProductionCompany Update Success',
  props<{ productionCompany: ProductionCompany }>()
);

export const updateProductionCompanyFailure = createAction(
  '[ProductionCompany API] ProductionCompany Update Failure',
  props<{ error: string }>()
);

export const createProductionCompany = createAction(
  '[ProductionCompany Page] Create ProductionCompany',
  props<{ productionCompany: ProductionCompany }>()
);

export const createProductionCompanySuccess = createAction(
  '[ProductionCompany API] ProductionCompany Create Success',
  props<{ productionCompany: ProductionCompany }>()
);

export const createProductionCompanyFailure = createAction(
  '[ProductionCompany API] ProductionCompany Create Failure',
  props<{ error: string }>()
);

export const deleteProductionCompany = createAction(
  '[ProductionCompany Page] Delete ProductionCompany',
  props<{ productionCompany: ProductionCompany }>()
);

export const deleteProductionCompanySuccess = createAction(
  '[ProductionCompany API] ProductionCompany Delete Success',
  props<{ productionCompanyId: string; success: boolean }>()
);

export const deleteProductionCompanyFailure = createAction(
  '[ProductionCompany API] ProductionCompany Delete Failure',
  props<{ error: string }>()
);
