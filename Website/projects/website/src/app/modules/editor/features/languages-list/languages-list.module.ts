import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { EffectsModule } from '@ngrx/effects';
import { StoreModule } from '@ngrx/store';
import { ConfirmationService, MessageService } from 'primeng/api';
import { ActionBarModule } from '../../components/action-bar/action-bar.module';
import { LanguagesEffects } from '../../state/languages/languages.effect';
import { languagesReducer } from '../../state/languages/languages.reducer';
import { LanguagesListDataTableModule } from './languages-list-data-table/languages-list-data-table.module';
import { LanguagesListRoutingModule } from './languages-list-routing.module';
import { LanguagesListComponent } from './languages-list.component';

@NgModule({
  declarations: [LanguagesListComponent],
  imports: [
    CommonModule,
    LanguagesListRoutingModule,
    LanguagesListDataTableModule,
    ActionBarModule,
    StoreModule.forFeature('languagesFeature', languagesReducer),
    EffectsModule.forFeature([LanguagesEffects]),
  ],
  providers: [MessageService, ConfirmationService],
})
export class LanguagesListModule {}
