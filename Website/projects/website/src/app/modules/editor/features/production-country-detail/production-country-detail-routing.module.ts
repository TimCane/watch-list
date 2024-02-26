import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductionCountryDetailComponent } from './production-country-detail.component';

const routes: Routes = [{ path: '', component: ProductionCountryDetailComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProductionCountryDetailRoutingModule { }
