import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { GenresListRoutingModule } from './genres-list-routing.module';
import { GenresListComponent } from './genres-list.component';


@NgModule({
  declarations: [
    GenresListComponent
  ],
  imports: [
    CommonModule,
    GenresListRoutingModule
  ]
})
export class GenresListModule { }
