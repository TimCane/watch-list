import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthenticationComponent } from './authentication.component';

const routes: Routes = [
  {
    path: '',
    component: AuthenticationComponent,
    children: [
      {
        path: 'login',
        loadChildren: () =>
          import('./features/login/login.module').then((m) => m.LoginModule),
      },
      {
        path: 'logout',
        loadChildren: () =>
          import('./features/logout/logout.module').then((m) => m.LogoutModule),
      },
      {
        path: 'register',
        loadChildren: () =>
          import('./features/register/register.module').then(
            (m) => m.RegisterModule
          ),
      },
      {
        path: 'confirm-email-address',
        loadChildren: () =>
          import(
            './features/confirm-email-address/confirm-email-address.module'
          ).then((m) => m.ConfirmEmailAddressModule),
      },
      {
        path: 'forgot-password',
        loadChildren: () =>
          import('./features/forgot-password/forgot-password.module').then(
            (m) => m.ForgotPasswordModule
          ),
      },
      {
        path: 'reset-password',
        loadChildren: () =>
          import('./features/reset-password/reset-password.module').then(
            (m) => m.ResetPasswordModule
          ),
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AuthenticationRoutingModule {}
