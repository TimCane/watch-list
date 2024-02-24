import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProductionCountriesListRoutingModule } from './production-countries-list-routing.module';
import { ProductionCountriesListComponent } from './production-countries-list.component';


@NgModule({
  declarations: [
    ProductionCountriesListComponent
  ],
  imports: [
    CommonModule,
    ProductionCountriesListRoutingModule
  ]
})
export class ProductionCountriesListModule { }
