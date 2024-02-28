import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LanguagesListComponent } from './languages-list.component';

const routes: Routes = [{ path: '', component: LanguagesListComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LanguagesListRoutingModule { }
