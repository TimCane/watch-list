import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { KeywordsListComponent } from './keywords-list.component';

const routes: Routes = [{ path: '', component: KeywordsListComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class KeywordsListRoutingModule { }
