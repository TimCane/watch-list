import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { EffectsModule } from '@ngrx/effects';
import { StoreModule } from '@ngrx/store';
import { ConfirmationService, MessageService } from 'primeng/api';
import { ActionBarModule } from '../../components/action-bar/action-bar.module';
import { ProductionCompaniesEffects } from '../../state/production-companies/production-companies.effect';
import { productionCompaniesReducer } from '../../state/production-companies/production-companies.reducer';
import { ProductionCompaniesListDataTableModule } from './production-companies-list-data-table/production-companies-list-data-table.module';
import { ProductionCompaniesListRoutingModule } from './production-companies-list-routing.module';
import { ProductionCompaniesListComponent } from './production-companies-list.component';

@NgModule({
  declarations: [ProductionCompaniesListComponent],
  imports: [
    CommonModule,
    ProductionCompaniesListRoutingModule,
    ProductionCompaniesListDataTableModule,
    ActionBarModule,
    StoreModule.forFeature(
      'productionCompaniesFeature',
      productionCompaniesReducer
    ),
    EffectsModule.forFeature([ProductionCompaniesEffects]),
  ],
  providers: [MessageService, ConfirmationService],
})
export class ProductionCompaniesListModule {}
