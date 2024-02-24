import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductionCompaniesListComponent } from './production-companies-list.component';

const routes: Routes = [{ path: '', component: ProductionCompaniesListComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProductionCompaniesListRoutingModule { }
