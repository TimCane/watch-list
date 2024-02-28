interface BaseDataTableAction {
  id: string;
  type: 'icon' | 'label';
  class: string;
  visible: boolean;
  order: number;
}

export interface IconDataTableAction extends BaseDataTableAction {
  type: 'icon';
  icon: string;
}

export interface LabelDataTableAction extends BaseDataTableAction {
  type: 'label';
  label: string;
}

export type DataTableAction = IconDataTableAction | LabelDataTableAction;
