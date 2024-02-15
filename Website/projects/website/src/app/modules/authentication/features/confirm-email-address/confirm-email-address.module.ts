import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { ReactiveFormsModule } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { CardModule } from 'primeng/card';
import { DividerModule } from 'primeng/divider';
import { InputTextModule } from 'primeng/inputtext';
import { PasswordModule } from 'primeng/password';
import { ProgressSpinnerModule } from 'primeng/progressspinner';
import { InputErrorModule } from '../../../shared/components/input-error/input-error.module';
import { ConfirmEmailAddressRoutingModule } from './confirm-email-address-routing.module';
import { ConfirmEmailAddressComponent } from './confirm-email-address.component';

@NgModule({
  declarations: [ConfirmEmailAddressComponent],
  imports: [
    CommonModule,
    ConfirmEmailAddressRoutingModule,
    CardModule,
    ReactiveFormsModule,
    InputTextModule,
    PasswordModule,
    ButtonModule,
    InputErrorModule,
    ProgressSpinnerModule,
    DividerModule,
  ],
})
export class ConfirmEmailAddressModule {}
