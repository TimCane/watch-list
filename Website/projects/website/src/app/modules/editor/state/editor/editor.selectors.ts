import { createFeatureSelector, createSelector } from '@ngrx/store';
import { EditorState } from './editor.state';

export const editorFeature =
  createFeatureSelector<EditorState>('editorFeature');
const selector = <T>(mapping: (state: EditorState) => T) =>
  createSelector(editorFeature, mapping);

export const getHome = selector((state) => state.home);
export const getBreadcrumbs = selector((state) => {
  if (state.detail) {
    return [...state.breadcrumbs, state.detail];
  } else {
    return state.breadcrumbs;
  }
});

export const getPageName = createSelector(
  getBreadcrumbs,
  (breadcrumbs) => breadcrumbs[breadcrumbs.length - 1].label ?? null
);
