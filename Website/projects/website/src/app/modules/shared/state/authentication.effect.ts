import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import { ApiException, UserService } from 'api-client';
import { catchError, from, map, of, switchMap } from 'rxjs';
import { AppState } from '../../../app.state';
import {
  confirmEmailAddress,
  confirmEmailAddressFailure,
  confirmEmailAddressSuccess,
  forgotPassword,
  forgotPasswordFailure,
  forgotPasswordSuccess,
  login,
  loginFailure,
  loginSuccess,
  logout,
  logoutFailure,
  logoutSuccess,
  register,
  registerFailure,
  registerSuccess,
  requestEmailAddressConfirmation,
  requestEmailAddressConfirmationFailure,
  requestEmailAddressConfirmationSuccess,
  resetPassword,
  resetPasswordFailure,
  resetPasswordSuccess,
  whoAmIFailure,
  whoAmISuccess,
} from './authentication.action';

@Injectable()
export class AuthenticationEffects {
  constructor(
    private actions$: Actions,
    private store: Store<AppState>,
    private userService: UserService
  ) {}

  login$ = createEffect(() =>
    this.actions$.pipe(
      ofType(login),
      switchMap(({ emailAddress, password }) =>
        from(this.userService.authenticate({ emailAddress, password })).pipe(
          map(({ bearerToken, refreshToken }) =>
            loginSuccess({
              bearerToken: bearerToken!,
              refreshToken: refreshToken!,
            })
          ),
          catchError((error: ApiException) =>
            of(loginFailure({ error: error.response }))
          )
        )
      )
    )
  );

  forgotPassword$ = createEffect(() =>
    this.actions$.pipe(
      ofType(forgotPassword),
      switchMap(({ emailAddress }) =>
        from(this.userService.forgotPassword({ emailAddress })).pipe(
          map(({ success }) =>
            forgotPasswordSuccess({
              success: success!,
            })
          ),
          catchError((error: ApiException) =>
            of(forgotPasswordFailure({ error: error.response }))
          )
        )
      )
    )
  );

  register$ = createEffect(() =>
    this.actions$.pipe(
      ofType(register),
      switchMap(({ emailAddress, name, password }) =>
        from(this.userService.register({ emailAddress, name, password })).pipe(
          map(({ success }) =>
            registerSuccess({
              success: success!,
            })
          ),
          catchError((error: ApiException) =>
            of(registerFailure({ error: error.response }))
          )
        )
      )
    )
  );

  resetPassword$ = createEffect(() =>
    this.actions$.pipe(
      ofType(resetPassword),
      switchMap(({ userPromptId, newPassword }) =>
        from(
          this.userService.resetPassword({ userPromptId, newPassword })
        ).pipe(
          map(({ success }) =>
            resetPasswordSuccess({
              success: success!,
            })
          ),
          catchError((error: ApiException) =>
            of(resetPasswordFailure({ error: error.response }))
          )
        )
      )
    )
  );

  requestEmailAddressConfirmation$ = createEffect(() =>
    this.actions$.pipe(
      ofType(requestEmailAddressConfirmation),
      switchMap(({ emailAddress }) =>
        from(
          this.userService.requestEmailAddressConfirmation({ emailAddress })
        ).pipe(
          map(({ success }) =>
            requestEmailAddressConfirmationSuccess({
              success: success!,
            })
          ),
          catchError((error: ApiException) =>
            of(
              requestEmailAddressConfirmationFailure({ error: error.response })
            )
          )
        )
      )
    )
  );

  confirmEmailAddress$ = createEffect(() =>
    this.actions$.pipe(
      ofType(confirmEmailAddress),
      switchMap(({ userPromptId }) =>
        from(this.userService.confirmEmailAddress({ userPromptId })).pipe(
          map(({ success }) =>
            confirmEmailAddressSuccess({
              success: success!,
            })
          ),
          catchError((error: ApiException) =>
            of(confirmEmailAddressFailure({ error: error.response }))
          )
        )
      )
    )
  );

  logout$ = createEffect(() =>
    this.actions$.pipe(
      ofType(logout),
      switchMap(() =>
        from(this.userService.logout()).pipe(
          map(({ success }) =>
            logoutSuccess({
              success: success!,
            })
          ),
          catchError((error: ApiException) =>
            of(logoutFailure({ error: error.response }))
          )
        )
      )
    )
  );

  whoAmI$ = createEffect(() =>
    this.actions$.pipe(
      ofType(loginSuccess),
      switchMap((_) =>
        from(this.userService.whoAmI()).pipe(
          map(({ user }) =>
            whoAmISuccess({
              user: user!,
            })
          ),
          catchError((error: ApiException) =>
            of(whoAmIFailure({ error: error.response }))
          )
        )
      )
    )
  );
}
