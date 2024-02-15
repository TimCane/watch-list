import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { ReactiveFormsModule } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { CardModule } from 'primeng/card';
import { InputTextModule } from 'primeng/inputtext';
import { PasswordModule } from 'primeng/password';
import { ProgressSpinnerModule } from 'primeng/progressspinner';
import { InputErrorModule } from '../../../shared/components/input-error/input-error.module';
import { RequestEmailAddressConfirmationRoutingModule } from './request-email-address-confirmation-routing.module';
import { RequestEmailAddressConfirmationComponent } from './request-email-address-confirmation.component';

@NgModule({
  declarations: [RequestEmailAddressConfirmationComponent],
  imports: [
    CommonModule,
    RequestEmailAddressConfirmationRoutingModule,
    CardModule,
    ReactiveFormsModule,
    InputTextModule,
    PasswordModule,
    ButtonModule,
    InputErrorModule,
    ProgressSpinnerModule,
  ],
})
export class RequestEmailAddressConfirmationModule {}
