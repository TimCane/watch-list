import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LanguageDetailComponent } from './language-detail.component';

const routes: Routes = [{ path: '', component: LanguageDetailComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LanguageDetailRoutingModule { }
