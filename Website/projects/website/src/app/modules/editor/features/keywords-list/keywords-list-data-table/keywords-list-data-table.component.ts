import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { Keyword } from 'api-client';
import { LazyLoadEvent } from 'primeng/api';
import { AppState } from 'projects/website/src/app/app.state';
import { ActionClickEvent } from '../../../components/data-table/models/action-click-event.interface';
import { DataTableAction } from '../../../components/data-table/models/data-table-action.interface';
import { DataTableColumn } from '../../../components/data-table/models/data-table-column.interface';
import { loadKeywords } from '../../../state/keywords/keywords.action';
import {
  getKeywords,
  getKeywordsTotal,
} from '../../../state/keywords/keywords.selectors';
import { LazyLoadToPaginationRequest } from '../../../utils/lazy-load-converter';

const VIEW_KEYWORD: string = 'ViewKeyword';

@Component({
  selector: 'editor-keywords-list-data-table',
  templateUrl: './keywords-list-data-table.component.html',
  styleUrls: ['./keywords-list-data-table.component.scss'],
})
export class KeywordsListDataTableComponent {
  public keywords$ = this.store.select(getKeywords);
  public total$ = this.store.select(getKeywordsTotal);

  columns: DataTableColumn[] = [];
  actions: DataTableAction[] = [];

  onDataLoad(event: LazyLoadEvent) {
    let request = LazyLoadToPaginationRequest(event);
    this.store.dispatch(loadKeywords({ request }));
  }

  onActionClick({ actionId, data }: ActionClickEvent<Keyword>) {
    switch (actionId) {
      case VIEW_KEYWORD:
        this.onViewKeyword(data);
        break;
    }
  }

  onViewKeyword(keyword: Keyword) {
    this.router.navigate(['/', 'editor', 'keywords', keyword.id]);
  }

  constructor(private store: Store<AppState>, private router: Router) {
    this.actions = [
      {
        id: VIEW_KEYWORD,
        type: 'icon',
        icon: 'pi pi-arrow-right',
        class: 'p-button-primary',
        order: 1,
        visible: true,
      },
    ];
    this.columns = [
      {
        caption: 'Name',
        field: 'name',
        type: 'text',
        filterable: false,
        sortable: true,
        visible: true,
        order: 1,
      },
      {
        caption: 'Created On',
        field: 'createdOn',
        type: 'date',
        filterable: false,
        sortable: true,
        visible: true,
        order: 2,
        format: 'longDate',
        hoverFormat: 'longTime',
      },
      {
        caption: 'Modified On',
        field: 'modifiedOn',
        type: 'date',
        filterable: false,
        sortable: true,
        visible: true,
        order: 3,
        format: 'longDate',
        hoverFormat: 'longTime',
      },
    ];
  }
}
