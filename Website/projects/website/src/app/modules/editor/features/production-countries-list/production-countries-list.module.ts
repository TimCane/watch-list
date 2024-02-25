import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { EffectsModule } from '@ngrx/effects';
import { StoreModule } from '@ngrx/store';
import { ConfirmationService, MessageService } from 'primeng/api';
import { ProductionCountriesEffects } from '../../state/production-countries/production-countries.effect';
import { productionCountriesReducer } from '../../state/production-countries/production-countries.reducer';
import { ProductionCountriesListDataTableModule } from './production-countries-list-data-table/production-countries-list-data-table.module';
import { ProductionCountriesListRoutingModule } from './production-countries-list-routing.module';
import { ProductionCountriesListComponent } from './production-countries-list.component';

@NgModule({
  declarations: [ProductionCountriesListComponent],
  imports: [
    CommonModule,
    ProductionCountriesListRoutingModule,
    ProductionCountriesListDataTableModule,
    StoreModule.forFeature(
      'productionCountriesFeature',
      productionCountriesReducer
    ),
    EffectsModule.forFeature([ProductionCountriesEffects]),
  ],
  providers: [MessageService, ConfirmationService],
})
export class ProductionCountriesListModule {}
