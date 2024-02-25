import { createReducer, on } from '@ngrx/store';
import {
  confirmEmailAddress,
  confirmEmailAddressFailure,
  confirmEmailAddressSuccess,
  cookieCheckFailure,
  cookieCheckSuccess,
  forgotPassword,
  forgotPasswordFailure,
  forgotPasswordSuccess,
  loadConfirmEmailAddressPage,
  loadForgotPasswordPage,
  loadLoginPage,
  loadLogoutPage,
  loadRegisterPage,
  loadRequestEmailAddressConfirmationPage,
  loadResetPasswordPage,
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
  whoAmISuccess,
} from './authentication.action';
import { AuthenticationState, initialState } from './authentication.state';

export const authenticationReducer = createReducer<AuthenticationState>(
  initialState,

  //#region Login
  on(loadLoginPage, (state) => ({
    ...state,
    error: '',
    status: 'pending',
  })),

  on(login, (state) => ({
    ...state,
    user: null,
    bearerToken: null,
    refreshToken: null,
    status: 'loading',
  })),

  on(loginSuccess, (state, { bearerToken, refreshToken }) => ({
    ...state,
    bearerToken: bearerToken,
    refreshToken: refreshToken,
    error: null,
    status: 'success',
  })),

  on(loginFailure, (state, { error }) => ({
    ...state,
    error: error,
    status: 'error',
  })),
  //#endregion

  //#region Forgot Password
  on(loadForgotPasswordPage, (state) => ({
    ...state,
    error: '',
    status: 'pending',
  })),

  on(forgotPassword, (state) => ({
    ...state,
    status: 'loading',
  })),

  on(forgotPasswordSuccess, (state, { success }) => ({
    ...state,
    error: success ? null : 'There was an error, please try again later.',
    status: success ? 'success' : 'error',
  })),

  on(forgotPasswordFailure, (state, { error }) => ({
    ...state,
    error: error,
    status: 'error',
  })),
  //#endregion

  //#region Register
  on(loadRegisterPage, (state) => ({
    ...state,
    error: '',
    status: 'pending',
  })),

  on(register, (state) => ({
    ...state,
    status: 'loading',
  })),

  on(registerSuccess, (state, { success }) => ({
    ...state,
    error: success ? null : 'There was an error, please try again later.',
    status: success ? 'success' : 'error',
  })),

  on(registerFailure, (state, { error }) => ({
    ...state,
    error: error,
    status: 'error',
  })),
  //#endregion

  //#region ResetPassword
  on(loadResetPasswordPage, (state) => ({
    ...state,
    error: '',
    status: 'pending',
  })),

  on(resetPassword, (state) => ({
    ...state,
    status: 'loading',
  })),

  on(resetPasswordSuccess, (state, { success }) => ({
    ...state,
    error: success ? null : 'There was an error, please try again later.',
    status: success ? 'success' : 'error',
  })),

  on(resetPasswordFailure, (state, { error }) => ({
    ...state,
    error: error,
    status: 'error',
  })),
  //#endregion

  //#region ConfirmEmailAddress
  on(loadConfirmEmailAddressPage, (state) => ({
    ...state,
    error: '',
    status: 'pending',
  })),

  on(confirmEmailAddress, (state) => ({
    ...state,
    status: 'loading',
  })),

  on(confirmEmailAddressSuccess, (state, { success }) => ({
    ...state,
    error: success ? null : 'There was an error, please try again later.',
    status: success ? 'success' : 'error',
  })),

  on(confirmEmailAddressFailure, (state, { error }) => ({
    ...state,
    error: error,
    status: 'error',
  })),
  //#endregion

  //#region Request Email Address Confirmation
  on(loadRequestEmailAddressConfirmationPage, (state) => ({
    ...state,
    error: '',
    status: 'pending',
  })),

  on(requestEmailAddressConfirmation, (state) => ({
    ...state,
    status: 'loading',
  })),

  on(requestEmailAddressConfirmationSuccess, (state, { success }) => ({
    ...state,
    error: success ? null : 'There was an error, please try again later.',
    status: success ? 'success' : 'error',
  })),

  on(requestEmailAddressConfirmationFailure, (state, { error }) => ({
    ...state,
    error: error,
    status: 'error',
  })),
  //#endregion

  //#region Logout
  on(loadLogoutPage, (state) => ({
    ...state,
    error: '',
    status: 'pending',
  })),

  on(logout, (state) => ({
    ...state,
    status: 'loading',
  })),

  on(logoutSuccess, (state, { success }) => ({
    ...state,
    user: success ? null : state.user,
    bearerToken: success ? null : state.bearerToken,
    refreshToken: success ? null : state.refreshToken,
    error: success ? null : 'There was an error, please try again later.',
    status: success ? 'success' : 'error',
  })),

  on(logoutFailure, (state, { error }) => ({
    ...state,
    error: error,
    status: 'error',
  })),
  //#endregion

  on(whoAmISuccess, (state, { user }) => ({
    ...state,
    user: user,
    error: null,
    status: 'success',
  })),

  on(loginFailure, (state, { error }) => ({
    ...state,
    user: null,
    bearerToken: null,
    refreshToken: null,
    error: error,
    status: 'error',
  })),

  on(cookieCheckSuccess, (state, { bearerToken, refreshToken }) => ({
    ...state,
    bearerToken: bearerToken,
    refreshToken: refreshToken,
    error: null,
    status: 'success',
  })),

  on(cookieCheckFailure, (state, { error }) => ({
    ...state,
    error: error,
    status: 'error',
  }))
);
