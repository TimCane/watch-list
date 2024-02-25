import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { LazyLoadEvent } from 'primeng/api';
import { AppState } from 'projects/website/src/app/app.state';
import { DataTableColumn } from '../../../components/data-table/data-table.component';
import { loadCredits } from '../../../state/credits/credits.action';
import {
  getCredits,
  getCreditsTotal,
} from '../../../state/credits/credits.selectors';
import { LazyLoadToPaginationRequest } from '../../../utils/lazy-load-converter';

@Component({
  selector: 'editor-credits-list-data-table',
  templateUrl: './credits-list-data-table.component.html',
  styleUrls: ['./credits-list-data-table.component.scss'],
})
export class CreditsListDataTableComponent {
  public credits$ = this.store.select(getCredits);
  public total$ = this.store.select(getCreditsTotal);

  columns: DataTableColumn[] = [];

  onDataLoad(event: LazyLoadEvent) {
    let request = LazyLoadToPaginationRequest(event);
    this.store.dispatch(loadCredits({ request }));
  }

  constructor(private store: Store<AppState>) {
    this.columns = [
      {
        caption: 'Character',
        field: 'character',
        type: 'text',
        filterable: false,
        sortable: true,
      },
      {
        caption: 'Gender',
        field: 'gender',
        type: 'text',
        filterable: false,
        sortable: true,
      },
      {
        caption: 'Name',
        field: 'name',
        type: 'text',
        filterable: false,
        sortable: true,
      },
      {
        caption: 'Order',
        field: 'order',
        type: 'numeric',
        filterable: false,
        sortable: true,
      },
      {
        caption: 'Type',
        field: 'type',
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
