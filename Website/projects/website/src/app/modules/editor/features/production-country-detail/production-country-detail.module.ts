import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { ActionBarModule } from '../../components/action-bar/action-bar.module';
import { ProductionCountryDetailEditFormModule } from './production-country-detail-edit-form/production-country-detail-edit-form.module';
import { ProductionCountryDetailRoutingModule } from './production-country-detail-routing.module';
import { ProductionCountryDetailComponent } from './production-country-detail.component';

@NgModule({
  declarations: [ProductionCountryDetailComponent],
  imports: [
    CommonModule,
    ProductionCountryDetailRoutingModule,
    ActionBarModule,
    ProductionCountryDetailEditFormModule,
  ],
})
export class ProductionCountryDetailModule {}
