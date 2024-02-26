import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LanguageDetailRoutingModule } from './language-detail-routing.module';
import { LanguageDetailComponent } from './language-detail.component';


@NgModule({
  declarations: [
    LanguageDetailComponent
  ],
  imports: [
    CommonModule,
    LanguageDetailRoutingModule
  ]
})
export class LanguageDetailModule { }
