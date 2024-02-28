import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { CardModule } from 'primeng/card';
import { DataTableModule } from '../../../components/data-table/data-table.module';
import { CreditsListDataTableComponent } from './credits-list-data-table.component';

@NgModule({
  declarations: [CreditsListDataTableComponent],
  imports: [CommonModule, CardModule, DataTableModule],
  exports: [CreditsListDataTableComponent],
})
export class CreditsListDataTableModule {}
