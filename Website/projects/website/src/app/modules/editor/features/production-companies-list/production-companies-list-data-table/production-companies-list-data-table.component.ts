import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { ProductionCompany } from 'api-client';
import { LazyLoadEvent } from 'primeng/api';
import { AppState } from 'projects/website/src/app/app.state';
import { ActionClickEvent } from '../../../components/data-table/models/action-click-event.interface';
import { DataTableAction } from '../../../components/data-table/models/data-table-action.interface';
import { DataTableColumn } from '../../../components/data-table/models/data-table-column.interface';
import { loadProductionCompanies } from '../../../state/production-companies/production-companies.action';
import {
  getProductionCompanies,
  getProductionCompaniesTotal,
} from '../../../state/production-companies/production-companies.selectors';
import { LazyLoadToPaginationRequest } from '../../../utils/lazy-load-converter';

const VIEW_PRODUCTION_COMPANY: string = 'ViewKeyword';

@Component({
  selector: 'editor-production-companies-list-data-table',
  templateUrl: './production-companies-list-data-table.component.html',
  styleUrls: ['./production-companies-list-data-table.component.scss'],
})
export class ProductionCompaniesListDataTableComponent {
  public productionCompanies$ = this.store.select(getProductionCompanies);
  public total$ = this.store.select(getProductionCompaniesTotal);

  columns: DataTableColumn[] = [];
  actions: DataTableAction[] = [];

  onDataLoad(event: LazyLoadEvent) {
    let request = LazyLoadToPaginationRequest(event);
    this.store.dispatch(loadProductionCompanies({ request }));
  }

  onActionClick({ actionId, data }: ActionClickEvent<ProductionCompany>) {
    switch (actionId) {
      case VIEW_PRODUCTION_COMPANY:
        this.onViewProductionCompany(data);
        break;
    }
  }

  onViewProductionCompany(productionCompany: ProductionCompany) {
    this.router.navigate([
      '/',
      'editor',
      'production-companies',
      productionCompany.id,
    ]);
  }

  constructor(private store: Store<AppState>, private router: Router) {
    this.actions = [
      {
        id: VIEW_PRODUCTION_COMPANY,
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
