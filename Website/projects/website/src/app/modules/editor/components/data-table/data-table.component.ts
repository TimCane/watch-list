import {
  Component,
  EventEmitter,
  Input,
  Output,
  ViewChild,
} from '@angular/core';
import { LazyLoadEvent } from 'primeng/api';
import { Table } from 'primeng/table';

export interface DataTableColumn {
  caption: string;
  field: string;
  type: 'text' | 'boolean' | 'date' | 'numeric';
  sortable: boolean;
  filterable: boolean;
}

@Component({
  selector: 'editor-data-table',
  templateUrl: './data-table.component.html',
  styleUrls: ['./data-table.component.scss'],
})
export class DataTableComponent<TData> {
  @ViewChild(Table, { static: false }) table!: Table;

  @Output() onLoadData = new EventEmitter<LazyLoadEvent>();

  @Input() searchFields: string[] = [];
  @Input() data: TData[] = [];
  @Input() columns: DataTableColumn[] = [];
  @Input() emptyMessage: string = 'No results found';
  @Input() total: number | null = null;

  loading: boolean = false;
  searchVal: string = '';

  constructor() {}

  ngOnInit() {}

  onLazyLoad(event: LazyLoadEvent) {
    this.onLoadData.emit(event);
  }

  clear() {
    this.searchVal = '';
    this.table.clear();
  }
  search(event: any) {
    this.table.filterGlobal(event.target.value, 'contains');
  }
}
