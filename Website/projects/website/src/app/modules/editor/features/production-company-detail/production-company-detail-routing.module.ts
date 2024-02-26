import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductionCompanyDetailComponent } from './production-company-detail.component';

const routes: Routes = [{ path: '', component: ProductionCompanyDetailComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProductionCompanyDetailRoutingModule { }
