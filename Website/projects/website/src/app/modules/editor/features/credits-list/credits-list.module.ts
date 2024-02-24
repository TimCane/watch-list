import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CreditsListRoutingModule } from './credits-list-routing.module';
import { CreditsListComponent } from './credits-list.component';


@NgModule({
  declarations: [
    CreditsListComponent
  ],
  imports: [
    CommonModule,
    CreditsListRoutingModule
  ]
})
export class CreditsListModule { }
