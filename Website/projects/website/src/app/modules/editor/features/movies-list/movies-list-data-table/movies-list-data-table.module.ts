import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { CardModule } from 'primeng/card';
import { DataTableModule } from '../../../components/data-table/data-table.module';
import { MoviesListDataTableComponent } from './movies-list-data-table.component';

@NgModule({
  declarations: [MoviesListDataTableComponent],
  imports: [CommonModule, CardModule, DataTableModule],
  exports: [MoviesListDataTableComponent],
})
export class MoviesListDataTableModule {}
