import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { CardModule } from 'primeng/card';
import { DataTableModule } from '../../../components/data-table/data-table.module';
import { LanguagesListDataTableComponent } from './languages-list-data-table.component';

@NgModule({
  declarations: [LanguagesListDataTableComponent],
  imports: [CommonModule, CardModule, DataTableModule],
  exports: [LanguagesListDataTableComponent],
})
export class LanguagesListDataTableModule {}
