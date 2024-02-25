import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { LazyLoadEvent } from 'primeng/api';
import { AppState } from 'projects/website/src/app/app.state';
import { DataTableColumn } from '../../../components/data-table/data-table.component';
import { loadProductionCountries } from '../../../state/production-countries/production-countries.action';
import {
  getProductionCountries,
  getProductionCountriesTotal,
} from '../../../state/production-countries/production-countries.selectors';
import { LazyLoadToPaginationRequest } from '../../../utils/lazy-load-converter';

@Component({
  selector: 'editor-production-countries-list-data-table',
  templateUrl: './production-countries-list-data-table.component.html',
  styleUrls: ['./production-countries-list-data-table.component.scss'],
})
export class ProductionCountriesListDataTableComponent {
  public productionCountries$ = this.store.select(getProductionCountries);
  public total$ = this.store.select(getProductionCountriesTotal);

  columns: DataTableColumn[] = [];

  onDataLoad(event: LazyLoadEvent) {
    let request = LazyLoadToPaginationRequest(event);
    this.store.dispatch(loadProductionCountries({ request }));
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
        caption: 'Iso',
        field: 'iso',
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
