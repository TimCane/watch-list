import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { ProductionCountry } from 'api-client';
import { LazyLoadEvent } from 'primeng/api';
import { AppState } from 'projects/website/src/app/app.state';
import { ActionClickEvent } from '../../../components/data-table/models/action-click-event.interface';
import { DataTableAction } from '../../../components/data-table/models/data-table-action.interface';
import { DataTableColumn } from '../../../components/data-table/models/data-table-column.interface';
import { loadProductionCountries } from '../../../state/production-countries/production-countries.action';
import {
  getProductionCountries,
  getProductionCountriesTotal,
} from '../../../state/production-countries/production-countries.selectors';
import { LazyLoadToPaginationRequest } from '../../../utils/lazy-load-converter';

const VIEW_PRODUCTION_COUNTRY: string = 'ViewProductionCountry';

@Component({
  selector: 'editor-production-countries-list-data-table',
  templateUrl: './production-countries-list-data-table.component.html',
  styleUrls: ['./production-countries-list-data-table.component.scss'],
})
export class ProductionCountriesListDataTableComponent {
  public productionCountries$ = this.store.select(getProductionCountries);
  public total$ = this.store.select(getProductionCountriesTotal);

  columns: DataTableColumn[] = [];
  actions: DataTableAction[] = [];

  onDataLoad(event: LazyLoadEvent) {
    let request = LazyLoadToPaginationRequest(event);
    this.store.dispatch(loadProductionCountries({ request }));
  }

  onActionClick({ actionId, data }: ActionClickEvent<ProductionCountry>) {
    switch (actionId) {
      case VIEW_PRODUCTION_COUNTRY:
        this.onViewProductionCountry(data);
        break;
    }
  }

  onViewProductionCountry(productionCountry: ProductionCountry) {
    this.router.navigate([
      '/',
      'editor',
      'production-countries',
      productionCountry.id,
    ]);
  }

  constructor(private store: Store<AppState>, private router: Router) {
    this.actions = [
      {
        id: VIEW_PRODUCTION_COUNTRY,
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
        caption: 'ISO',
        field: 'iso',
        type: 'text',
        filterable: false,
        sortable: true,
        visible: true,
        order: 2,
      },
      {
        caption: 'Created On',
        field: 'createdOn',
        type: 'date',
        filterable: false,
        sortable: true,
        visible: true,
        order: 3,
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
        order: 4,
        format: 'longDate',
        hoverFormat: 'longTime',
      },
    ];
  }
}
