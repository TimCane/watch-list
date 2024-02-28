import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { Language } from 'api-client';
import { LazyLoadEvent } from 'primeng/api';
import { AppState } from 'projects/website/src/app/app.state';
import { ActionClickEvent } from '../../../components/data-table/models/action-click-event.interface';
import { DataTableAction } from '../../../components/data-table/models/data-table-action.interface';
import { DataTableColumn } from '../../../components/data-table/models/data-table-column.interface';
import { loadLanguages } from '../../../state/languages/languages.action';
import {
  getLanguages,
  getLanguagesTotal,
} from '../../../state/languages/languages.selectors';
import { LazyLoadToPaginationRequest } from '../../../utils/lazy-load-converter';

const VIEW_LANGUAGE: string = 'ViewLanguage';

@Component({
  selector: 'editor-languages-list-data-table',
  templateUrl: './languages-list-data-table.component.html',
  styleUrls: ['./languages-list-data-table.component.scss'],
})
export class LanguagesListDataTableComponent {
  public languages$ = this.store.select(getLanguages);
  public total$ = this.store.select(getLanguagesTotal);

  columns: DataTableColumn[] = [];
  actions: DataTableAction[] = [];

  onDataLoad(event: LazyLoadEvent) {
    let request = LazyLoadToPaginationRequest(event);
    this.store.dispatch(loadLanguages({ request }));
  }

  onActionClick({ actionId, data }: ActionClickEvent<Language>) {
    switch (actionId) {
      case VIEW_LANGUAGE:
        this.onViewLanguage(data);
        break;
    }
  }

  onViewLanguage(language: Language) {
    this.router.navigate(['/', 'editor', 'languages', language.id]);
  }

  constructor(private store: Store<AppState>, private router: Router) {
    this.actions = [
      {
        id: VIEW_LANGUAGE,
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
        caption: 'Created By',
        field: 'createdBy',
        type: 'text',
        filterable: false,
        sortable: true,
        visible: false,
        order: 3,
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
      {
        caption: 'Modified By',
        field: 'modifiedBy',
        type: 'text',
        filterable: false,
        sortable: true,
        visible: false,
        order: 4,
      },
    ];
  }
}
