import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { ActionBarModule } from '../../components/action-bar/action-bar.module';
import { CollectionDetailEditFormModule } from './collection-detail-edit-form/collection-detail-edit-form.module';
import { CollectionDetailRoutingModule } from './collection-detail-routing.module';
import { CollectionDetailComponent } from './collection-detail.component';

@NgModule({
  declarations: [CollectionDetailComponent],
  imports: [
    CommonModule,
    CollectionDetailRoutingModule,
    ActionBarModule,
    CollectionDetailEditFormModule,
  ],
})
export class CollectionDetailModule {}
