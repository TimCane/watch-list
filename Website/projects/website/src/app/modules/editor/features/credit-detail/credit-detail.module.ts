import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CreditDetailRoutingModule } from './credit-detail-routing.module';
import { CreditDetailComponent } from './credit-detail.component';


@NgModule({
  declarations: [
    CreditDetailComponent
  ],
  imports: [
    CommonModule,
    CreditDetailRoutingModule
  ]
})
export class CreditDetailModule { }
