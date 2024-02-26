import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProductionCompanyDetailRoutingModule } from './production-company-detail-routing.module';
import { ProductionCompanyDetailComponent } from './production-company-detail.component';


@NgModule({
  declarations: [
    ProductionCompanyDetailComponent
  ],
  imports: [
    CommonModule,
    ProductionCompanyDetailRoutingModule
  ]
})
export class ProductionCompanyDetailModule { }
