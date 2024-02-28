import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreditDetailComponent } from './credit-detail.component';

const routes: Routes = [{ path: '', component: CreditDetailComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CreditDetailRoutingModule { }
