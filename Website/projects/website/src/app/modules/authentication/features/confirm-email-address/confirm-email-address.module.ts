import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ConfirmEmailAddressRoutingModule } from './confirm-email-address-routing.module';
import { ConfirmEmailAddressComponent } from './confirm-email-address.component';


@NgModule({
  declarations: [
    ConfirmEmailAddressComponent
  ],
  imports: [
    CommonModule,
    ConfirmEmailAddressRoutingModule
  ]
})
export class ConfirmEmailAddressModule { }
