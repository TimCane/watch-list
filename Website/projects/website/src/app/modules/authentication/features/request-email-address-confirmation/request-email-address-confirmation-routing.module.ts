import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RequestEmailAddressConfirmationComponent } from './request-email-address-confirmation.component';

const routes: Routes = [{ path: '', component: RequestEmailAddressConfirmationComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RequestEmailAddressConfirmationRoutingModule { }
