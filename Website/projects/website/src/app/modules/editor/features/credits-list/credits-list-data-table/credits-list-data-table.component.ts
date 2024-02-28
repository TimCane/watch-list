import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { Credit } from 'api-client';
import { LazyLoadEvent } from 'primeng/api';
import { AppState } from 'projects/website/src/app/app.state';
import { ActionClickEvent } from '../../../components/data-table/models/action-click-event.interface';
import { DataTableAction } from '../../../components/data-table/models/data-table-action.interface';
import { DataTableColumn } from '../../../components/data-table/models/data-table-column.interface';
import { loadCredits } from '../../../state/credits/credits.action';
import {
  getCredits,
  getCreditsTotal,
} from '../../../state/credits/credits.selectors';
import { LazyLoadToPaginationRequest } from '../../../utils/lazy-load-converter';

const VIEW_CREDIT: string = 'ViewCredit';

@Component({
  selector: 'editor-credits-list-data-table',
  templateUrl: './credits-list-data-table.component.html',
  styleUrls: ['./credits-list-data-table.component.scss'],
})
export class CreditsListDataTableComponent {
  public credits$ = this.store.select(getCredits);
  public total$ = this.store.select(getCreditsTotal);

  columns: DataTableColumn[] = [];
  actions: DataTableAction[] = [];

  onDataLoad(event: LazyLoadEvent) {
    let request = LazyLoadToPaginationRequest(event);
    this.store.dispatch(loadCredits({ request }));
  }

  onActionClick({ actionId, data }: ActionClickEvent<Credit>) {
    switch (actionId) {
      case VIEW_CREDIT:
        this.onViewCredit(data);
        break;
    }
  }

  onViewCredit(credit: Credit) {
    this.router.navigate(['/', 'editor', 'credits', credit.id]);
  }

  constructor(private store: Store<AppState>, private router: Router) {
    this.actions = [
      {
        id: VIEW_CREDIT,
        type: 'icon',
        icon: 'pi pi-arrow-right',
        class: 'p-button-primary',
        order: 1,
        visible: true,
      },
    ];
    this.columns = [
      {
        caption: 'Character',
        field: 'character',
        type: 'text',
        filterable: false,
        sortable: true,
        visible: true,
        order: 2,
      },
      {
        caption: 'Gender',
        field: 'gender',
        type: 'text',
        filterable: false,
        sortable: true,
        visible: true,
        order: 4,
      },
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
        caption: 'Order',
        field: 'order',
        type: 'numeric',
        filterable: false,
        sortable: true,
        visible: true,
        order: 3,
        format: 'whole',
      },
      {
        caption: 'Type',
        field: 'type',
        type: 'text',
        filterable: false,
        sortable: true,
        visible: true,
        order: 5,
      },
      {
        caption: 'Created On',
        field: 'createdOn',
        type: 'date',
        filterable: false,
        sortable: true,
        visible: true,
        order: 6,
        format: 'longDate',
        hoverFormat: 'longTime',
      },
      {
        caption: 'Created By',
        field: 'createdBy',
        type: 'text',
        filterable: false,
        sortable: true,
        visible: false,
        order: 6,
      },
      {
        caption: 'Modified On',
        field: 'modifiedOn',
        type: 'date',
        filterable: false,
        sortable: true,
        visible: true,
        order: 7,
        format: 'longDate',
        hoverFormat: 'longTime',
      },
      {
        caption: 'Modified By',
        field: 'modifiedBy',
        type: 'text',
        filterable: false,
        sortable: true,
        visible: false,
        order: 7,
      },
    ];
  }
}
