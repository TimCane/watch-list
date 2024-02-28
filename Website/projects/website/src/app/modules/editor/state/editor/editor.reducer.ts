import { createReducer, on } from '@ngrx/store';
import { updateBreadcrumbs, updateDetailBreadcrumb } from './editor.action';
import { EditorState, initialState } from './editor.state';

export const editorReducer = createReducer<EditorState>(
  initialState,

  on(updateBreadcrumbs, (state, { breadcrumbs }) => {
    return { ...state, breadcrumbs, detail: null, stats: [], showNew: false };
  }),
  on(updateDetailBreadcrumb, (state, { breadcrumb }) => {
    return { ...state, detail: breadcrumb };
  })
);
