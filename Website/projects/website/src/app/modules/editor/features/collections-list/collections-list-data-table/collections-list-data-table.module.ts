import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { CardModule } from 'primeng/card';
import { DataTableModule } from '../../../components/data-table/data-table.module';
import { CollectionsListDataTableComponent } from './collections-list-data-table.component';

@NgModule({
  declarations: [CollectionsListDataTableComponent],
  imports: [CommonModule, CardModule, DataTableModule],
  exports: [CollectionsListDataTableComponent],
})
export class CollectionsListDataTableModule {}
