import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { EffectsModule } from '@ngrx/effects';
import { StoreModule } from '@ngrx/store';
import { ConfirmationService, MessageService } from 'primeng/api';
import { KeywordsEffects } from '../../state/keywords/keywords.effect';
import { keywordsReducer } from '../../state/keywords/keywords.reducer';
import { KeywordsListDataTableModule } from './keywords-list-data-table/keywords-list-data-table.module';
import { KeywordsListRoutingModule } from './keywords-list-routing.module';
import { KeywordsListComponent } from './keywords-list.component';

@NgModule({
  declarations: [KeywordsListComponent],
  imports: [
    CommonModule,
    KeywordsListRoutingModule,
    KeywordsListDataTableModule,
    StoreModule.forFeature('keywordsFeature', keywordsReducer),
    EffectsModule.forFeature([KeywordsEffects]),
  ],
  providers: [MessageService, ConfirmationService],
})
export class KeywordsListModule {}
