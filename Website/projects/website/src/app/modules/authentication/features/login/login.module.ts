import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { ButtonModule } from 'primeng/button';
import { CardModule } from 'primeng/card';
import { InputTextModule } from 'primeng/inputtext';
import { PasswordModule } from 'primeng/password';

import { ReactiveFormsModule } from '@angular/forms';
import { LoginRoutingModule } from './login-routing.module';
import { LoginComponent } from './login.component';

@NgModule({
  declarations: [LoginComponent],
  imports: [
    CommonModule,
    LoginRoutingModule,
    CardModule,
    ReactiveFormsModule,
    InputTextModule,
    PasswordModule,
    ButtonModule,
  ],
})
export class LoginModule {}
