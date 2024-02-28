import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { CardModule } from 'primeng/card';
import { DataTableModule } from '../../../components/data-table/data-table.module';
import { ProductionCountriesListDataTableComponent } from './production-countries-list-data-table.component';

@NgModule({
  declarations: [ProductionCountriesListDataTableComponent],
  imports: [CommonModule, CardModule, DataTableModule],
  exports: [ProductionCountriesListDataTableComponent],
})
export class ProductionCountriesListDataTableModule {}
