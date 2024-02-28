import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { Movie } from 'api-client';
import { LazyLoadEvent } from 'primeng/api';
import { AppState } from 'projects/website/src/app/app.state';
import { ActionClickEvent } from '../../../components/data-table/models/action-click-event.interface';
import { DataTableAction } from '../../../components/data-table/models/data-table-action.interface';
import { DataTableColumn } from '../../../components/data-table/models/data-table-column.interface';
import { loadMovies } from '../../../state/movies/movies.action';
import {
  getMovies,
  getMoviesTotal,
} from '../../../state/movies/movies.selectors';
import { LazyLoadToPaginationRequest } from '../../../utils/lazy-load-converter';

const VIEW_MOVIE: string = 'ViewMovie';

@Component({
  selector: 'editor-movies-list-data-table',
  templateUrl: './movies-list-data-table.component.html',
  styleUrls: ['./movies-list-data-table.component.scss'],
})
export class MoviesListDataTableComponent {
  public movies$ = this.store.select(getMovies);
  public total$ = this.store.select(getMoviesTotal);

  columns: DataTableColumn[] = [];
  actions: DataTableAction[] = [];

  onDataLoad(event: LazyLoadEvent) {
    let request = LazyLoadToPaginationRequest(event);
    this.store.dispatch(loadMovies({ request }));
  }

  onActionClick({ actionId, data }: ActionClickEvent<Movie>) {
    switch (actionId) {
      case VIEW_MOVIE:
        this.onViewMovie(data);
        break;
    }
  }

  onViewMovie(movie: Movie) {
    this.router.navigate(['/', 'editor', 'movies', movie.id]);
  }

  constructor(private store: Store<AppState>, private router: Router) {
    this.actions = [
      {
        id: VIEW_MOVIE,
        type: 'icon',
        icon: 'pi pi-arrow-right',
        class: 'p-button-primary',
        order: 1,
        visible: true,
      },
    ];
    this.columns = [
      {
        caption: 'Adult',
        field: 'adult',
        type: 'boolean',
        filterable: false,
        sortable: true,
        visible: false,
        order: 6,
      },
      {
        caption: 'Budget',
        field: 'budget',
        type: 'numeric',
        filterable: false,
        sortable: true,
        visible: false,
        order: 5,
        format: 'currency',
      },
      {
        caption: 'Homepage',
        field: 'homepage',
        type: 'text',
        filterable: false,
        sortable: true,
        visible: false,
        order: 7,
        format: 'url',
      },
      {
        caption: 'OriginalTitle',
        field: 'originalTitle',
        type: 'text',
        filterable: false,
        sortable: true,
        visible: false,
        order: 1,
      },
      {
        caption: 'Overview',
        field: 'overview',
        type: 'text',
        filterable: false,
        sortable: true,
        visible: true,
        order: 4,
      },
      {
        caption: 'Release Date',
        field: 'releaseDate',
        type: 'date',
        filterable: false,
        sortable: true,
        visible: true,
        order: 2,
        format: 'longDate',
        hoverFormat: 'longTime',
      },
      {
        caption: 'Revenue',
        field: 'revenue',
        type: 'numeric',
        filterable: false,
        sortable: true,
        visible: false,
        order: 8,
        format: 'currency',
      },
      {
        caption: 'Runtime',
        field: 'runtime',
        type: 'numeric',
        filterable: false,
        sortable: true,
        visible: true,
        order: 3,
        format: 'whole',
      },
      {
        caption: 'TagLine',
        field: 'tagLine',
        type: 'text',
        filterable: false,
        sortable: true,
        visible: false,
        order: 9,
      },
      {
        caption: 'Title',
        field: 'title',
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
        order: 10,
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
        order: 10,
      },
      {
        caption: 'Modified On',
        field: 'modifiedOn',
        type: 'date',
        filterable: false,
        sortable: true,
        visible: true,
        order: 11,
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
        order: 11,
      },
    ];
  }
}
