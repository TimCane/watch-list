import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { EffectsModule } from '@ngrx/effects';
import { StoreModule } from '@ngrx/store';

import { ConfirmationService, MessageService } from 'primeng/api';

import { ActionBarModule } from '../../components/action-bar/action-bar.module';
import { CollectionsEffects } from '../../state/collections/collections.effect';
import { collectionsReducer } from '../../state/collections/collections.reducer';
import { CollectionsListDataTableModule } from './collections-list-data-table/collections-list-data-table.module';
import { CollectionsListRoutingModule } from './collections-list-routing.module';
import { CollectionsListComponent } from './collections-list.component';

@NgModule({
  declarations: [CollectionsListComponent],
  imports: [
    CommonModule,
    CollectionsListRoutingModule,
    CollectionsListDataTableModule,
    ActionBarModule,
    StoreModule.forFeature('collectionsFeature', collectionsReducer),
    EffectsModule.forFeature([CollectionsEffects]),
  ],
  providers: [MessageService, ConfirmationService],
})
export class CollectionsListModule {}
