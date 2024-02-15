import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiClientService } from '../api-client.service';
import { DataService } from '../data-service';
import {
  AuthenticateRequest,
  AuthenticateResponse,
  CheckPasswordResetRequest,
  CheckPasswordResetResponse,
  ConfirmEmailAddressRequest,
  ConfirmEmailAddressResponse,
  ForgotPasswordRequest,
  ForgotPasswordResponse,
  LogoutResponse,
  ReauthenticateRequest,
  ReauthenticateResponse,
  RegisterRequest,
  RegisterResponse,
  RequestEmailAddressConfirmationRequest,
  RequestEmailAddressConfirmationResponse,
  ResetPasswordRequest,
  ResetPasswordResponse,
  WhoAmIResponse,
} from '../generated-api-client.service';

@Injectable({
  providedIn: 'root',
})
export class UserService extends DataService {
  constructor(private apiService: ApiClientService) {
    super();
  }

  authenticate(request: AuthenticateRequest): Observable<AuthenticateResponse> {
    return this.mapResult(
      this.apiService.authenticate(request),
      (res: AuthenticateResponse) => res,
      () => {},
      (err) => this.handleError('authenticate', err)
    );
  }

  register(request: RegisterRequest): Observable<RegisterResponse> {
    return this.mapResult(
      this.apiService.register(request),
      (res: RegisterResponse) => res,
      () => {},
      (err) => this.handleError('register', err)
    );
  }

  reauthenticate(
    request: ReauthenticateRequest
  ): Observable<ReauthenticateResponse> {
    return this.mapResult(
      this.apiService.reauthenticate(request),
      (res: ReauthenticateResponse) => res,
      () => {},
      (err) => this.handleError('reauthenticate', err)
    );
  }

  checkPasswordReset(
    request: CheckPasswordResetRequest
  ): Observable<CheckPasswordResetResponse> {
    return this.mapResult(
      this.apiService.checkPasswordReset(request),
      (res: CheckPasswordResetResponse) => res,
      () => {},
      (err) => this.handleError('checkPasswordReset', err)
    );
  }

  forgotPassword(
    request: ForgotPasswordRequest
  ): Observable<ForgotPasswordResponse> {
    return this.mapResult(
      this.apiService.forgotPassword(request),
      (res: ForgotPasswordResponse) => res,
      () => {},
      (err) => this.handleError('forgotPassword', err)
    );
  }

  resetPassword(
    request: ResetPasswordRequest
  ): Observable<ResetPasswordResponse> {
    return this.mapResult(
      this.apiService.resetPassword(request),
      (res: ResetPasswordResponse) => res,
      () => {},
      (err) => this.handleError('resetPassword', err)
    );
  }

  confirmEmailAddress(
    request: ConfirmEmailAddressRequest
  ): Observable<ConfirmEmailAddressResponse> {
    return this.mapResult(
      this.apiService.confirmEmailAddress(request),
      (res: ConfirmEmailAddressResponse) => res,
      () => {},
      (err) => this.handleError('confirmEmailAddress', err)
    );
  }

  requestEmailAddressConfirmation(
    request: RequestEmailAddressConfirmationRequest
  ): Observable<RequestEmailAddressConfirmationResponse> {
    return this.mapResult(
      this.apiService.requestEmailAddressConfirmation(request),
      (res: RequestEmailAddressConfirmationResponse) => res,
      () => {},
      (err) => this.handleError('requestEmailAddressConfirmation', err)
    );
  }

  logout(): Observable<LogoutResponse> {
    return this.mapResult(
      this.apiService.logout(),
      (res: LogoutResponse) => res,
      () => {},
      (err) => this.handleError('logout', err)
    );
  }

  whoAmI(): Observable<WhoAmIResponse> {
    return this.mapResult(
      this.apiService.whoAmI(),
      (res: WhoAmIResponse) => res,
      () => {},
      (err) => this.handleError('whoAmI', err)
    );
  }
}
