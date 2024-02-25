import { createFeatureSelector, createSelector } from '@ngrx/store';
import { LanguagesState, languagesAdapter } from './languages.state';

export const languagesFeature =
  createFeatureSelector<LanguagesState>('languagesFeature');
const selector = <T>(mapping: (state: LanguagesState) => T) =>
  createSelector(languagesFeature, mapping);

const { selectEntities, selectAll } = languagesAdapter.getSelectors();

export const selectLanguageEntities = selector(selectEntities);

export const getLanguages = selector(selectAll);

export const getSelectedLanguageId = selector(
  (state) => state.selectedLanguageId
);

export const getLanguagesTotal = selector((state) => state.total);

export const getLanguage = createSelector(
  selectLanguageEntities,
  getSelectedLanguageId,
  (languages, selectedLanguageId) => {
    if (selectedLanguageId) {
      return languages[selectedLanguageId];
    }
    return null;
  }
);
