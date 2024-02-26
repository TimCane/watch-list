import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProductionCountryDetailRoutingModule } from './production-country-detail-routing.module';
import { ProductionCountryDetailComponent } from './production-country-detail.component';


@NgModule({
  declarations: [
    ProductionCountryDetailComponent
  ],
  imports: [
    CommonModule,
    ProductionCountryDetailRoutingModule
  ]
})
export class ProductionCountryDetailModule { }
