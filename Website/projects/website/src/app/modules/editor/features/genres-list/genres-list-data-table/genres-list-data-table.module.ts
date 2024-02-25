import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { CardModule } from 'primeng/card';
import { DataTableModule } from '../../../components/data-table/data-table.module';
import { GenresListDataTableComponent } from './genres-list-data-table.component';

@NgModule({
  declarations: [GenresListDataTableComponent],
  imports: [CommonModule, CardModule, DataTableModule],
  exports: [GenresListDataTableComponent],
})
export class GenresListDataTableModule {}
