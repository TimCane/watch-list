import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { LazyLoadEvent } from 'primeng/api';
import { AppState } from 'projects/website/src/app/app.state';
import { DataTableColumn } from '../../../components/data-table/data-table.component';
import { loadProductionCompanies } from '../../../state/production-companies/production-companies.action';
import {
  getProductionCompanies,
  getProductionCompaniesTotal,
} from '../../../state/production-companies/production-companies.selectors';
import { LazyLoadToPaginationRequest } from '../../../utils/lazy-load-converter';

@Component({
  selector: 'editor-production-companies-list-data-table',
  templateUrl: './production-companies-list-data-table.component.html',
  styleUrls: ['./production-companies-list-data-table.component.scss'],
})
export class ProductionCompaniesListDataTableComponent {
  public productionCompanies$ = this.store.select(getProductionCompanies);
  public total$ = this.store.select(getProductionCompaniesTotal);

  columns: DataTableColumn[] = [];

  onDataLoad(event: LazyLoadEvent) {
    let request = LazyLoadToPaginationRequest(event);
    this.store.dispatch(loadProductionCompanies({ request }));
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
