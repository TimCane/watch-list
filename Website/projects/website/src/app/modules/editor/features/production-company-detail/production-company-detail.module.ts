import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { ActionBarModule } from '../../components/action-bar/action-bar.module';
import { ProductionCompanyDetailEditFormModule } from './production-company-detail-edit-form/production-company-detail-edit-form.module';
import { ProductionCompanyDetailRoutingModule } from './production-company-detail-routing.module';
import { ProductionCompanyDetailComponent } from './production-company-detail.component';

@NgModule({
  declarations: [ProductionCompanyDetailComponent],
  imports: [
    CommonModule,
    ProductionCompanyDetailRoutingModule,
    ActionBarModule,
    ProductionCompanyDetailEditFormModule,
  ],
})
export class ProductionCompanyDetailModule {}
