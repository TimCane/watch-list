import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { KeywordDetailRoutingModule } from './keyword-detail-routing.module';
import { KeywordDetailComponent } from './keyword-detail.component';


@NgModule({
  declarations: [
    KeywordDetailComponent
  ],
  imports: [
    CommonModule,
    KeywordDetailRoutingModule
  ]
})
export class KeywordDetailModule { }
