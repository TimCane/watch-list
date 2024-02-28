import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GenreDetailComponent } from './genre-detail.component';

const routes: Routes = [{ path: '', component: GenreDetailComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class GenreDetailRoutingModule { }
