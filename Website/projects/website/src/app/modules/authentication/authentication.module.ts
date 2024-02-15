import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { ImageModule } from 'primeng/image';

import { SharedModule } from '../shared/shared.module';
import { AuthenticationRoutingModule } from './authentication-routing.module';
import { AuthenticationComponent } from './authentication.component';

@NgModule({
  declarations: [AuthenticationComponent],
  imports: [
    CommonModule,
    AuthenticationRoutingModule,
    ImageModule,
    SharedModule,
  ],
  providers: [],
})
export class AuthenticationModule {}
