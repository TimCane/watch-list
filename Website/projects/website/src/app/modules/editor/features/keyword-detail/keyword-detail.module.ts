import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { ActionBarModule } from '../../components/action-bar/action-bar.module';
import { KeywordDetailEditFormModule } from './keyword-detail-edit-form/keyword-detail-edit-form.module';
import { KeywordDetailRoutingModule } from './keyword-detail-routing.module';
import { KeywordDetailComponent } from './keyword-detail.component';

@NgModule({
  declarations: [KeywordDetailComponent],
  imports: [
    CommonModule,
    KeywordDetailRoutingModule,
    ActionBarModule,
    KeywordDetailEditFormModule,
  ],
})
export class KeywordDetailModule {}
