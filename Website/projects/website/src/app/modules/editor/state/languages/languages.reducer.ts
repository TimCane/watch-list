import { createReducer, on } from '@ngrx/store';
import {
  createLanguage,
  createLanguageFailure,
  createLanguageSuccess,
  deleteLanguage,
  deleteLanguageFailure,
  deleteLanguageSuccess,
  loadLanguageFailure,
  loadLanguageSuccess,
  loadLanguages,
  loadLanguagesFailure,
  loadLanguagesSuccess,
  selectLanguage,
  updateLanguage,
  updateLanguageFailure,
  updateLanguageSuccess,
} from './languages.action';
import {
  LanguagesState,
  initialState,
  languagesAdapter,
} from './languages.state';

export const languagesReducer = createReducer<LanguagesState>(
  initialState,

  on(selectLanguage, (state, { languageId }) => {
    return { ...state, selectedLanguageId: languageId };
  }),

  on(loadLanguages, (state) => ({
    ...state,
    total: 0,
    status: 'loading',
    selectedLanguageId: null,
  })),

  on(loadLanguageSuccess, (state, { language }) => {
    return languagesAdapter.upsertOne(language, {
      ...state,
      error: null,
      status: 'success',
    });
  }),

  on(loadLanguageFailure, (state, { error }) => {
    return languagesAdapter.removeAll({
      ...state,
      total: 0,
      selectedLanguageId: null,
      error: error,
      status: 'error',
    });
  }),

  on(loadLanguagesSuccess, (state, { languages, total }) => {
    return languagesAdapter.setAll(languages, {
      ...state,
      total,
      error: null,
      status: 'success',
    });
  }),

  on(loadLanguagesFailure, (state, { error }) => {
    return languagesAdapter.removeAll({
      ...state,
      total: 0,
      selectedLanguageId: null,
      error: error,
      status: 'error',
    });
  }),

  on(updateLanguage, (state) => ({
    ...state,
    status: 'loading',
  })),

  on(updateLanguageSuccess, (state, { language }) => {
    return languagesAdapter.updateOne(
      { id: language.id!, changes: language },
      {
        ...state,
        error: null,
        status: 'success',
      }
    );
  }),

  on(updateLanguageFailure, (state, { error }) => ({
    ...state,
    error: error,
    status: 'error',
  })),

  on(createLanguage, (state) => ({
    ...state,
    status: 'loading',
  })),

  on(createLanguageSuccess, (state, { language }) => {
    return languagesAdapter.addOne(language, {
      ...state,
      error: null,
      status: 'success',
    });
  }),

  on(createLanguageFailure, (state, { error }) => ({
    ...state,
    error: error,
    status: 'error',
  })),

  on(deleteLanguage, (state) => ({
    ...state,
    status: 'loading',
  })),

  on(deleteLanguageSuccess, (state, { languageId }) => {
    return languagesAdapter.removeOne(languageId, {
      ...state,
      error: null,
      status: 'success',
    });
  }),

  on(deleteLanguageFailure, (state, { error }) => ({
    ...state,
    error: error,
    status: 'error',
  }))
);

export const getSelectedLanguageId = (state: LanguagesState) =>
  state.selectedLanguageId;

// get the selectors
const { selectIds, selectEntities, selectAll, selectTotal } =
  languagesAdapter.getSelectors();

// select the array of language ids
export const selectLanguageIds = selectIds;

// select the dictionary of language entities
export const selectLanguageEntities = selectEntities;

// select the array of languages
export const selectAllLanguages = selectAll;

// select the total language count
export const selectLanguageTotal = selectTotal;
