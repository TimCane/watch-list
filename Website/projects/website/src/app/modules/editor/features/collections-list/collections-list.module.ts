import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CollectionsListRoutingModule } from './collections-list-routing.module';
import { CollectionsListComponent } from './collections-list.component';


@NgModule({
  declarations: [
    CollectionsListComponent
  ],
  imports: [
    CommonModule,
    CollectionsListRoutingModule
  ]
})
export class CollectionsListModule { }
