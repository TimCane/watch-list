import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { ActionBarModule } from '../../components/action-bar/action-bar.module';
import { MovieDetailEditFormModule } from './movie-detail-edit-form/movie-detail-edit-form.module';
import { MovieDetailRoutingModule } from './movie-detail-routing.module';
import { MovieDetailComponent } from './movie-detail.component';

@NgModule({
  declarations: [MovieDetailComponent],
  imports: [
    CommonModule,
    MovieDetailRoutingModule,
    ActionBarModule,
    MovieDetailEditFormModule,
  ],
})
export class MovieDetailModule {}
