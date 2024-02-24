import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProductionCompaniesListRoutingModule } from './production-companies-list-routing.module';
import { ProductionCompaniesListComponent } from './production-companies-list.component';


@NgModule({
  declarations: [
    ProductionCompaniesListComponent
  ],
  imports: [
    CommonModule,
    ProductionCompaniesListRoutingModule
  ]
})
export class ProductionCompaniesListModule { }
