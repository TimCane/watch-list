import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { CardModule } from 'primeng/card';
import { DataTableModule } from '../../../components/data-table/data-table.module';
import { ProductionCompaniesListDataTableComponent } from './production-companies-list-data-table.component';

@NgModule({
  declarations: [ProductionCompaniesListDataTableComponent],
  imports: [CommonModule, CardModule, DataTableModule],
  exports: [ProductionCompaniesListDataTableComponent],
})
export class ProductionCompaniesListDataTableModule {}
