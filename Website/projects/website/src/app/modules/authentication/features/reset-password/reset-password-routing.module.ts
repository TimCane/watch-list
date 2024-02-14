import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ResetPasswordComponent } from './reset-password.component';

const routes: Routes = [
  { path: ':id', component: ResetPasswordComponent },
  {
    path: '',
    pathMatch: 'full',
    redirectTo: '/auth/forgot-password',
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ResetPasswordRoutingModule {}
