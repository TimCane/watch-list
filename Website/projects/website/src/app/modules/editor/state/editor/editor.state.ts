import { MenuItem } from 'primeng/api';
import { PageStat } from '../../models/page-stat.interface';

export interface EditorState {
  breadcrumbs: MenuItem[];
  home: MenuItem;
  detail: MenuItem | null;
  stats: PageStat[];
  showNew: boolean;

  error: string | null;
  status: 'pending' | 'loading' | 'error' | 'success';
}

export const initialState: EditorState = {
  breadcrumbs: [],
  home: { icon: 'pi pi-home', routerLink: ['/'] },
  detail: null,
  stats: [],
  showNew: false,
  error: null,
  status: 'pending',
};
