import { createAction, props } from '@ngrx/store';
import { MenuItem } from 'primeng/api';

export const updateBreadcrumbs = createAction(
  '[Editor Page] Update Breadcrumbs',
  props<{ breadcrumbs: MenuItem[] }>()
);

export const updateDetailBreadcrumb = createAction(
  '[Editor Page] Add Detail Breadcrumb',
  props<{ breadcrumb: MenuItem }>()
);
