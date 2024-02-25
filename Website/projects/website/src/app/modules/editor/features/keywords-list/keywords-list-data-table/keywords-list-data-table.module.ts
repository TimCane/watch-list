import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { CardModule } from 'primeng/card';
import { DataTableModule } from '../../../components/data-table/data-table.module';
import { KeywordsListDataTableComponent } from './keywords-list-data-table.component';

@NgModule({
  declarations: [KeywordsListDataTableComponent],
  imports: [CommonModule, CardModule, DataTableModule],
  exports: [KeywordsListDataTableComponent],
})
export class KeywordsListDataTableModule {}
