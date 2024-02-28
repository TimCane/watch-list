import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { AppState } from 'projects/website/src/app/app.state';
import {
  getBreadcrumbs,
  getHome,
  getPageName,
} from '../../state/editor/editor.selectors';

export const ROUTE_DATA_BREADCRUMB = 'breadcrumb';

@Component({
  selector: 'editor-page-header',
  templateUrl: './page-header.component.html',
  styleUrls: ['./page-header.component.scss'],
})
export class PageHeaderComponent {
  public pageName$ = this.store.select(getPageName);
  public breadcrumb$ = this.store.select(getBreadcrumbs);
  public home$ = this.store.select(getHome);

  constructor(private store: Store<AppState>) {}
}
