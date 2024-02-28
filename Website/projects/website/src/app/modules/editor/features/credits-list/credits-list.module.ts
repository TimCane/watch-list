import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { EffectsModule } from '@ngrx/effects';
import { StoreModule } from '@ngrx/store';
import { ConfirmationService, MessageService } from 'primeng/api';
import { ActionBarModule } from '../../components/action-bar/action-bar.module';
import { CreditsEffects } from '../../state/credits/credits.effect';
import { creditsReducer } from '../../state/credits/credits.reducer';
import { CreditsListDataTableModule } from './credits-list-data-table/credits-list-data-table.module';
import { CreditsListRoutingModule } from './credits-list-routing.module';
import { CreditsListComponent } from './credits-list.component';

@NgModule({
  declarations: [CreditsListComponent],
  imports: [
    CommonModule,
    CreditsListRoutingModule,
    CreditsListDataTableModule,
    ActionBarModule,
    StoreModule.forFeature('creditsFeature', creditsReducer),
    EffectsModule.forFeature([CreditsEffects]),
  ],
  providers: [MessageService, ConfirmationService],
})
export class CreditsListModule {}
