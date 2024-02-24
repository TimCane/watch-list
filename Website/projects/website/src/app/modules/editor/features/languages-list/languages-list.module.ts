import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LanguagesListRoutingModule } from './languages-list-routing.module';
import { LanguagesListComponent } from './languages-list.component';


@NgModule({
  declarations: [
    LanguagesListComponent
  ],
  imports: [
    CommonModule,
    LanguagesListRoutingModule
  ]
})
export class LanguagesListModule { }
