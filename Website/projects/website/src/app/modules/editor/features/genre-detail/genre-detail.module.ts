import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { GenreDetailRoutingModule } from './genre-detail-routing.module';
import { GenreDetailComponent } from './genre-detail.component';


@NgModule({
  declarations: [
    GenreDetailComponent
  ],
  imports: [
    CommonModule,
    GenreDetailRoutingModule
  ]
})
export class GenreDetailModule { }
