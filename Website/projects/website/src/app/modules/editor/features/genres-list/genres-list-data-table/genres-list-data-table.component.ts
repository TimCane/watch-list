import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { LazyLoadEvent } from 'primeng/api';
import { AppState } from 'projects/website/src/app/app.state';
import { DataTableColumn } from '../../../components/data-table/data-table.component';
import { loadGenres } from '../../../state/genres/genres.action';
import {
  getGenres,
  getGenresTotal,
} from '../../../state/genres/genres.selectors';
import { LazyLoadToPaginationRequest } from '../../../utils/lazy-load-converter';

@Component({
  selector: 'editor-genres-list-data-table',
  templateUrl: './genres-list-data-table.component.html',
  styleUrls: ['./genres-list-data-table.component.scss'],
})
export class GenresListDataTableComponent {
  public genres$ = this.store.select(getGenres);
  public total$ = this.store.select(getGenresTotal);

  columns: DataTableColumn[] = [];

  onDataLoad(event: LazyLoadEvent) {
    let request = LazyLoadToPaginationRequest(event);
    this.store.dispatch(loadGenres({ request }));
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
