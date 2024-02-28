import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { EffectsModule } from '@ngrx/effects';
import { StoreModule } from '@ngrx/store';
import { ConfirmationService, MessageService } from 'primeng/api';
import { ActionBarModule } from '../../components/action-bar/action-bar.module';
import { GenresEffects } from '../../state/genres/genres.effect';
import { genresReducer } from '../../state/genres/genres.reducer';
import { GenresListDataTableModule } from './genres-list-data-table/genres-list-data-table.module';
import { GenresListRoutingModule } from './genres-list-routing.module';
import { GenresListComponent } from './genres-list.component';

@NgModule({
  declarations: [GenresListComponent],
  imports: [
    CommonModule,
    GenresListRoutingModule,
    GenresListDataTableModule,
    ActionBarModule,
    StoreModule.forFeature('genresFeature', genresReducer),
    EffectsModule.forFeature([GenresEffects]),
  ],
  providers: [MessageService, ConfirmationService],
})
export class GenresListModule {}
