import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { Collection } from 'api-client';
import { LazyLoadEvent } from 'primeng/api';
import { AppState } from 'projects/website/src/app/app.state';
import { ActionClickEvent } from '../../../components/data-table/models/action-click-event.interface';
import { DataTableAction } from '../../../components/data-table/models/data-table-action.interface';
import { DataTableColumn } from '../../../components/data-table/models/data-table-column.interface';
import { loadCollections } from '../../../state/collections/collections.action';
import {
  getCollections,
  getCollectionsTotal,
} from '../../../state/collections/collections.selectors';
import { LazyLoadToPaginationRequest } from '../../../utils/lazy-load-converter';

const VIEW_COLLECTION: string = 'ViewCollection';

@Component({
  selector: 'editor-collections-list-data-table',
  templateUrl: './collections-list-data-table.component.html',
  styleUrls: ['./collections-list-data-table.component.scss'],
})
export class CollectionsListDataTableComponent {
  public collections$ = this.store.select(getCollections);
  public total$ = this.store.select(getCollectionsTotal);

  columns: DataTableColumn[] = [];
  actions: DataTableAction[] = [];

  onDataLoad(event: LazyLoadEvent) {
    let request = LazyLoadToPaginationRequest(event);
    this.store.dispatch(loadCollections({ request }));
  }

  onActionClick({ actionId, data }: ActionClickEvent<Collection>) {
    switch (actionId) {
      case VIEW_COLLECTION:
        this.onViewCollection(data);
        break;
    }
  }

  onViewCollection(collection: Collection) {
    this.router.navigate(['/', 'editor', 'collections', collection.id]);
  }

  constructor(private store: Store<AppState>, private router: Router) {
    this.actions = [
      {
        id: VIEW_COLLECTION,
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
        caption: 'Created By',
        field: 'createdBy',
        type: 'text',
        filterable: false,
        sortable: true,
        visible: false,
        order: 2,
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
      {
        caption: 'Modified By',
        field: 'modifiedBy',
        type: 'text',
        filterable: false,
        sortable: true,
        visible: false,
        order: 3,
      },
    ];
  }
}
