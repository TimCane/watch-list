import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { ActionBarModule } from '../../components/action-bar/action-bar.module';
import { CreditDetailEditFormModule } from './credit-detail-edit-form/credit-detail-edit-form.module';
import { CreditDetailRoutingModule } from './credit-detail-routing.module';
import { CreditDetailComponent } from './credit-detail.component';

@NgModule({
  declarations: [CreditDetailComponent],
  imports: [
    CommonModule,
    CreditDetailRoutingModule,
    ActionBarModule,
    CreditDetailEditFormModule,
  ],
})
export class CreditDetailModule {}
