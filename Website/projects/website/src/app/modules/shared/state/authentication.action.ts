import { createAction, props } from '@ngrx/store';
import { User } from 'api-client';

//#region Login
export const loadLoginPage = createAction('[Login Page] Load');

export const login = createAction(
  '[Login Page] Login',
  props<{ emailAddress: string; password: string }>()
);

export const loginSuccess = createAction(
  '[Authentication API] Login Success',
  props<{ bearerToken: string; refreshToken: string }>()
);

export const loginFailure = createAction(
  '[Authentication API] Login Failure',
  props<{ error: string }>()
);
//#endregion

//#region Forgot Password
export const loadForgotPasswordPage = createAction(
  '[Forgot Password Page] Load'
);

export const forgotPassword = createAction(
  '[Forgot Password Page] Forgot Password',
  props<{ emailAddress: string }>()
);

export const forgotPasswordSuccess = createAction(
  '[Authentication API] Forgot Password Success',
  props<{ success: boolean }>()
);

export const forgotPasswordFailure = createAction(
  '[Authentication API] Forgot Password Failure',
  props<{ error: string }>()
);
//#endregion

//#region Register
export const loadRegisterPage = createAction('[Register Page] Load');

export const register = createAction(
  '[Register Page] Register',
  props<{
    emailAddress: string;
    name: string;
    password: string;
  }>()
);

export const registerSuccess = createAction(
  '[Authentication API] Register Success',
  props<{ success: boolean }>()
);

export const registerFailure = createAction(
  '[Authentication API] Register Failure',
  props<{ error: string }>()
);
//#endregion

//#region ResetPassword
export const loadResetPasswordPage = createAction('[ResetPassword Page] Load');

export const resetPassword = createAction(
  '[ResetPassword Page] ResetPassword',
  props<{
    userPromptId: string;
    newPassword: string;
  }>()
);

export const resetPasswordSuccess = createAction(
  '[Authentication API] ResetPassword Success',
  props<{ success: boolean }>()
);

export const resetPasswordFailure = createAction(
  '[Authentication API] ResetPassword Failure',
  props<{ error: string }>()
);
//#endregion

//#region ConfirmEmailAddress
export const loadConfirmEmailAddressPage = createAction(
  '[ConfirmEmailAddress Page] Load'
);

export const confirmEmailAddress = createAction(
  '[ConfirmEmailAddress Page] Confirm Email Address',
  props<{
    userPromptId: string;
  }>()
);

export const confirmEmailAddressSuccess = createAction(
  '[Authentication API] Confirm Email Address Success',
  props<{ success: boolean }>()
);

export const confirmEmailAddressFailure = createAction(
  '[Authentication API] Confirm Email Address Failure',
  props<{ error: string }>()
);
//#endregion

//#region Request Email Address Confirmation
export const loadRequestEmailAddressConfirmationPage = createAction(
  '[Request Email Address Confirmation Page] Load'
);

export const requestEmailAddressConfirmation = createAction(
  '[Request Email Address Confirmation Page] Request Email Address Confirmation',
  props<{ emailAddress: string }>()
);

export const requestEmailAddressConfirmationSuccess = createAction(
  '[Authentication API] Request Email Address Confirmation Success',
  props<{ success: boolean }>()
);

export const requestEmailAddressConfirmationFailure = createAction(
  '[Authentication API] Request Email Address Confirmation Failure',
  props<{ error: string }>()
);
//#endregion

//#region Logout
export const loadLogoutPage = createAction('[Logout Page] Load');

export const logout = createAction('[Logout Page] Logout');

export const logoutSuccess = createAction(
  '[Authentication API] Logout Success',
  props<{ success: boolean }>()
);

export const logoutFailure = createAction(
  '[Authentication API] Logout Failure',
  props<{ error: string }>()
);
//#endregion

export const whoAmISuccess = createAction(
  '[Authentication API] Who Am I Success',
  props<{ user: User }>()
);

export const whoAmIFailure = createAction(
  '[Authentication API] Who Am I Failure',
  props<{ error: string }>()
);

export const cookieCheck = createAction('[App] Cookie Check');

export const cookieCheckSuccess = createAction(
  '[Authentication API] Cookie Check Success',
  props<{ bearerToken: string; refreshToken: string }>()
);

export const cookieCheckFailure = createAction(
  '[Authentication API] Cookie Check Failure',
  props<{ error: string }>()
);
