import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CollectionDetailRoutingModule } from './collection-detail-routing.module';
import { CollectionDetailComponent } from './collection-detail.component';


@NgModule({
  declarations: [
    CollectionDetailComponent
  ],
  imports: [
    CommonModule,
    CollectionDetailRoutingModule
  ]
})
export class CollectionDetailModule { }
