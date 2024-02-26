interface BaseDataTableColumn {
  caption: string;
  field: string;
  sortable: boolean;
  filterable: boolean;
  visible: boolean;
  order: number;
}

export interface TextDataTableColumn extends BaseDataTableColumn {
  type: 'text';
  format?: 'url';
}

export interface BooleanDataTableColumn extends BaseDataTableColumn {
  type: 'boolean';
}

export interface DateDataTableColumn extends BaseDataTableColumn {
  type: 'date';
  hoverFormat: string;
  format: string;
}

export interface NumericDataTableColumn extends BaseDataTableColumn {
  type: 'numeric';
  format: 'currency' | 'whole';
}

export type DataTableColumn =
  | TextDataTableColumn
  | BooleanDataTableColumn
  | DateDataTableColumn
  | NumericDataTableColumn;
