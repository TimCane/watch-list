import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { Genre } from 'api-client';
import { LazyLoadEvent } from 'primeng/api';
import { AppState } from 'projects/website/src/app/app.state';
import { ActionClickEvent } from '../../../components/data-table/models/action-click-event.interface';
import { DataTableAction } from '../../../components/data-table/models/data-table-action.interface';
import { DataTableColumn } from '../../../components/data-table/models/data-table-column.interface';
import { loadGenres } from '../../../state/genres/genres.action';
import {
  getGenres,
  getGenresTotal,
} from '../../../state/genres/genres.selectors';
import { LazyLoadToPaginationRequest } from '../../../utils/lazy-load-converter';

const VIEW_GENRE: string = 'ViewGenre';

@Component({
  selector: 'editor-genres-list-data-table',
  templateUrl: './genres-list-data-table.component.html',
  styleUrls: ['./genres-list-data-table.component.scss'],
})
export class GenresListDataTableComponent {
  public genres$ = this.store.select(getGenres);
  public total$ = this.store.select(getGenresTotal);

  columns: DataTableColumn[] = [];
  actions: DataTableAction[] = [];

  onDataLoad(event: LazyLoadEvent) {
    let request = LazyLoadToPaginationRequest(event);
    this.store.dispatch(loadGenres({ request }));
  }

  onActionClick({ actionId, data }: ActionClickEvent<Genre>) {
    switch (actionId) {
      case VIEW_GENRE:
        this.onViewGenre(data);
        break;
    }
  }

  onViewGenre(genre: Genre) {
    this.router.navigate(['/', 'editor', 'genres', genre.id]);
  }

  constructor(private store: Store<AppState>, private router: Router) {
    this.actions = [
      {
        id: VIEW_GENRE,
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
