import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RequestEmailAddressConfirmationRoutingModule } from './request-email-address-confirmation-routing.module';
import { RequestEmailAddressConfirmationComponent } from './request-email-address-confirmation.component';


@NgModule({
  declarations: [
    RequestEmailAddressConfirmationComponent
  ],
  imports: [
    CommonModule,
    RequestEmailAddressConfirmationRoutingModule
  ]
})
export class RequestEmailAddressConfirmationModule { }
