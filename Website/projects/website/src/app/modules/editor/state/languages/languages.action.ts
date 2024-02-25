import { createAction, props } from '@ngrx/store';
import { Language, PagedRequest } from 'api-client';

export const selectLanguage = createAction(
  '[Language Page] Select Language',
  props<{ languageId: string | null }>()
);

export const loadLanguageSuccess = createAction(
  '[Language Page] Load Language',
  props<{ language: Language }>()
);

export const loadLanguageFailure = createAction(
  '[Language API] Language Load Failure',
  props<{ error: string }>()
);

export const loadLanguages = createAction(
  '[Language Page] Load Languages',
  props<{ request: PagedRequest }>()
);

export const loadLanguagesSuccess = createAction(
  '[Language API] Languages Load Success',
  props<{ languages: Language[]; total: number }>()
);

export const loadLanguagesFailure = createAction(
  '[Language API] Languages Load Failure',
  props<{ error: string }>()
);

export const updateLanguage = createAction(
  '[Language Page] Update Language',
  props<{ language: Language }>()
);

export const updateLanguageSuccess = createAction(
  '[Language API] Language Update Success',
  props<{ language: Language }>()
);

export const updateLanguageFailure = createAction(
  '[Language API] Language Update Failure',
  props<{ error: string }>()
);

export const createLanguage = createAction(
  '[Language Page] Create Language',
  props<{ language: Language }>()
);

export const createLanguageSuccess = createAction(
  '[Language API] Language Create Success',
  props<{ language: Language }>()
);

export const createLanguageFailure = createAction(
  '[Language API] Language Create Failure',
  props<{ error: string }>()
);

export const deleteLanguage = createAction(
  '[Language Page] Delete Language',
  props<{ language: Language }>()
);

export const deleteLanguageSuccess = createAction(
  '[Language API] Language Delete Success',
  props<{ languageId: string; success: boolean }>()
);

export const deleteLanguageFailure = createAction(
  '[Language API] Language Delete Failure',
  props<{ error: string }>()
);
