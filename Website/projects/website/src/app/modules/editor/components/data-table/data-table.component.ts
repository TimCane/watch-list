import {
  Component,
  EventEmitter,
  Input,
  Output,
  ViewChild,
} from '@angular/core';
import { LazyLoadEvent } from 'primeng/api';
import { Table } from 'primeng/table';
import { ActionClickEvent } from './models/action-click-event.interface';
import { DataTableAction } from './models/data-table-action.interface';
import { DataTableColumn } from './models/data-table-column.interface';

@Component({
  selector: 'editor-data-table',
  templateUrl: './data-table.component.html',
  styleUrls: ['./data-table.component.scss'],
})
export class DataTableComponent<TData> {
  @ViewChild(Table, { static: false }) table!: Table;

  @Output() onLoadData = new EventEmitter<LazyLoadEvent>();
  @Output() onActionClick = new EventEmitter<ActionClickEvent<TData>>();

  @Input() searchFields: string[] = [];
  @Input() data: TData[] = [];
  @Input() actions: DataTableAction[] = [];
  @Input() columns: DataTableColumn[] = [];
  @Input() emptyMessage: string = 'No results found';
  @Input() total: number | null = null;

  defaultColumns: DataTableColumn[] = [];
  selectedColumns: DataTableColumn[] = [];
  hasSelectedColumns: boolean = false;

  showFilterRow: boolean = false;

  loading: boolean = false;
  searchVal: string = '';

  constructor() {}

  ngOnInit() {
    this.showFilterRow = this.columns.some((c) => c.filterable);
    this.defaultColumns = this.columns.filter((c) => c.visible);
    this.selectedColumns = this.defaultColumns;
  }

  onActionClicked(actionId: string, data: TData) {
    this.onActionClick.emit({ actionId, data });
  }

  onLazyLoad(event: LazyLoadEvent) {
    this.onLoadData.emit(event);
  }

  onSelectedColumnsChange() {
    this.hasSelectedColumns = this.selectedColumns != this.defaultColumns;
  }

  resetSelectedColumns() {
    this.selectedColumns = this.defaultColumns;
    this.hasSelectedColumns = false;
  }

  clear() {
    this.searchVal = '';
    this.table.clear();
  }
  search(event: any) {
    this.table.filterGlobal(event.target.value, 'contains');
  }
}
