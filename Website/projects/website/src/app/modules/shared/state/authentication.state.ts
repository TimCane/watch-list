import { User } from 'api-client';

export interface AuthenticationState {
  user: User | null;
  bearerToken: string | null;
  refreshToken: string | null;

  error: string | null;
  status: 'pending' | 'loading' | 'error' | 'success';
}

export const initialState: AuthenticationState = {
  user: null,
  bearerToken: null,
  refreshToken: null,
  error: null,
  status: 'pending',
};
