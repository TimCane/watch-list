import { createEntityAdapter, EntityState } from '@ngrx/entity';
import { Language } from 'api-client';

export interface LanguagesState extends EntityState<Language> {
  selectedLanguageId: string | null;
  total: number | null;

  error: string | null;
  status: 'pending' | 'loading' | 'error' | 'success'; //TODO: Enum
}

export function selectLanguageId(language: Language): string {
  return language.id ?? '';
}

export const languagesAdapter = createEntityAdapter<Language>({
  selectId: selectLanguageId,
});

export const initialState: LanguagesState = languagesAdapter.getInitialState({
  selectedLanguageId: null,
  total: 0,
  error: null,
  status: 'pending',
});
