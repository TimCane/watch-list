import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { EffectsModule } from '@ngrx/effects';
import { StoreModule } from '@ngrx/store';
import { ConfirmationService, MessageService } from 'primeng/api';
import { MoviesEffects } from '../../state/movies/movies.effect';
import { moviesReducer } from '../../state/movies/movies.reducer';
import { MoviesListDataTableModule } from './movies-list-data-table/movies-list-data-table.module';
import { MoviesListRoutingModule } from './movies-list-routing.module';
import { MoviesListComponent } from './movies-list.component';

@NgModule({
  declarations: [MoviesListComponent],
  imports: [
    CommonModule,
    MoviesListRoutingModule,
    MoviesListDataTableModule,
    StoreModule.forFeature('moviesFeature', moviesReducer),
    EffectsModule.forFeature([MoviesEffects]),
  ],
  providers: [MessageService, ConfirmationService],
})
export class MoviesListModule {}
