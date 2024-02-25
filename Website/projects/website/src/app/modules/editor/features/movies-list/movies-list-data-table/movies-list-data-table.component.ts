import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { LazyLoadEvent } from 'primeng/api';
import { AppState } from 'projects/website/src/app/app.state';
import { DataTableColumn } from '../../../components/data-table/data-table.component';
import { loadMovies } from '../../../state/movies/movies.action';
import {
  getMovies,
  getMoviesTotal,
} from '../../../state/movies/movies.selectors';
import { LazyLoadToPaginationRequest } from '../../../utils/lazy-load-converter';

@Component({
  selector: 'editor-movies-list-data-table',
  templateUrl: './movies-list-data-table.component.html',
  styleUrls: ['./movies-list-data-table.component.scss'],
})
export class MoviesListDataTableComponent {
  public movies$ = this.store.select(getMovies);
  public total$ = this.store.select(getMoviesTotal);

  columns: DataTableColumn[] = [];

  onDataLoad(event: LazyLoadEvent) {
    let request = LazyLoadToPaginationRequest(event);
    this.store.dispatch(loadMovies({ request }));
  }

  constructor(private store: Store<AppState>) {
    this.columns = [
      {
        caption: 'Title',
        field: 'title',
        type: 'text',
        filterable: false,
        sortable: true,
      },
      {
        caption: 'Overview',
        field: 'overview',
        type: 'text',
        filterable: false,
        sortable: true,
      },
      {
        caption: 'Release Date',
        field: 'releaseDate',
        type: 'date',
        filterable: false,
        sortable: true,
      },
      {
        caption: 'Runtime',
        field: 'runtime',
        type: 'numeric',
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
