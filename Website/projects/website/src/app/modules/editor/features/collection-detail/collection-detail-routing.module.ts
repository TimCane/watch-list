import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CollectionDetailComponent } from './collection-detail.component';

const routes: Routes = [{ path: '', component: CollectionDetailComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CollectionDetailRoutingModule { }
