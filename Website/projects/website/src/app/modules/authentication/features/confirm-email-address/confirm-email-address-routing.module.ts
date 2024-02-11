import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ConfirmEmailAddressComponent } from './confirm-email-address.component';

const routes: Routes = [{ path: '', component: ConfirmEmailAddressComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ConfirmEmailAddressRoutingModule { }
