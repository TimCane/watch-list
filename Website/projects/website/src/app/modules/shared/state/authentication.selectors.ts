import { createFeatureSelector, createSelector } from '@ngrx/store';
import { AuthenticationState } from './authentication.state';

export const authenticationFeature = createFeatureSelector<AuthenticationState>(
  'authenticationFeature'
);
const selector = <T>(mapping: (state: AuthenticationState) => T) =>
  createSelector(authenticationFeature, mapping);

export const selectUser = selector((state) => state.user);
export const selectBearerToken = selector((state) => state.bearerToken);
export const selectRefreshToken = selector((state) => state.refreshToken);

export const selectStatus = selector((state) => state.status);
export const selectError = selector((state) => state.error);

export const selectIsAuthenticated = selector((state) => state.user != null);
export const selectIsAnonymous = selector((state) => state.user == null);
