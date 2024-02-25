import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { LazyLoadEvent } from 'primeng/api';
import { AppState } from 'projects/website/src/app/app.state';
import { DataTableColumn } from '../../../components/data-table/data-table.component';
import { loadLanguages } from '../../../state/languages/languages.action';
import {
  getLanguages,
  getLanguagesTotal,
} from '../../../state/languages/languages.selectors';
import { LazyLoadToPaginationRequest } from '../../../utils/lazy-load-converter';

@Component({
  selector: 'editor-languages-list-data-table',
  templateUrl: './languages-list-data-table.component.html',
  styleUrls: ['./languages-list-data-table.component.scss'],
})
export class LanguagesListDataTableComponent {
  public languages$ = this.store.select(getLanguages);
  public total$ = this.store.select(getLanguagesTotal);

  columns: DataTableColumn[] = [];

  onDataLoad(event: LazyLoadEvent) {
    let request = LazyLoadToPaginationRequest(event);
    this.store.dispatch(loadLanguages({ request }));
  }

  constructor(private store: Store<AppState>) {
    this.columns = [
      {
        caption: 'Name',
        field: 'name',
        type: 'text',
        filterable: false,
        sortable: true,
      },
      {
        caption: 'Created On',
        field: 'createdOn',
        type: 'date',
        filterable: false,
        sortable: true,
      },
      {
        caption: 'Modified On',
        field: 'modifiedOn',
        type: 'date',
        filterable: false,
        sortable: true,
      },
    ];
  }
}
