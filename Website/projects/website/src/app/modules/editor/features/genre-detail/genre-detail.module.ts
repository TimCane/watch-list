import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { ActionBarModule } from '../../components/action-bar/action-bar.module';
import { GenreDetailEditFormModule } from './genre-detail-edit-form/genre-detail-edit-form.module';
import { GenreDetailRoutingModule } from './genre-detail-routing.module';
import { GenreDetailComponent } from './genre-detail.component';

@NgModule({
  declarations: [GenreDetailComponent],
  imports: [
    CommonModule,
    GenreDetailRoutingModule,
    ActionBarModule,
    GenreDetailEditFormModule,
  ],
})
export class GenreDetailModule {}
