import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreditsListComponent } from './credits-list.component';

const routes: Routes = [{ path: '', component: CreditsListComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CreditsListRoutingModule { }
