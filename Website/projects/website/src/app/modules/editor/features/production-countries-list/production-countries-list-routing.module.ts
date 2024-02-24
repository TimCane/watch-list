import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductionCountriesListComponent } from './production-countries-list.component';

const routes: Routes = [{ path: '', component: ProductionCountriesListComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProductionCountriesListRoutingModule { }
