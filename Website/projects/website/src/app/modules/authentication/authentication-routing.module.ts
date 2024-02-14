import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { anonymousGuardFunction } from '../shared/guards/anonymous.guard';
import { authGuardFunction } from '../shared/guards/auth.guard';
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
        canActivate: [anonymousGuardFunction],
      },
      {
        path: 'logout',
        loadChildren: () =>
          import('./features/logout/logout.module').then((m) => m.LogoutModule),
        canActivate: [authGuardFunction],
      },
      {
        path: 'register',
        loadChildren: () =>
          import('./features/register/register.module').then(
            (m) => m.RegisterModule
          ),
        canActivate: [anonymousGuardFunction],
      },
      {
        path: 'confirm-email-address',
        loadChildren: () =>
          import(
            './features/confirm-email-address/confirm-email-address.module'
          ).then((m) => m.ConfirmEmailAddressModule),
        canActivate: [anonymousGuardFunction],
      },
      {
        path: 'forgot-password',
        loadChildren: () =>
          import('./features/forgot-password/forgot-password.module').then(
            (m) => m.ForgotPasswordModule
          ),
        canActivate: [anonymousGuardFunction],
      },
      {
        path: 'reset-password',
        loadChildren: () =>
          import('./features/reset-password/reset-password.module').then(
            (m) => m.ResetPasswordModule
          ),
        canActivate: [anonymousGuardFunction],
      },
      {
        path: 'request-email-address-confirmation',
        loadChildren: () =>
          import(
            './features/request-email-address-confirmation/request-email-address-confirmation.module'
          ).then((m) => m.RequestEmailAddressConfirmationModule),
        canActivate: [anonymousGuardFunction],
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AuthenticationRoutingModule {}
