import { Injectable, inject } from '@angular/core';
import {
  ActivatedRouteSnapshot,
  CanActivateFn,
  Router,
  RouterStateSnapshot,
  UrlTree,
} from '@angular/router';
import { Store, select } from '@ngrx/store';
import { Observable, tap } from 'rxjs';
import { AppState } from '../../../app.state';
import { selectIsAuthenticated } from '../state/authentication.selectors';

export const authGuardFunction: CanActivateFn = (
  route: ActivatedRouteSnapshot,
  state: RouterStateSnapshot
):
  | Observable<boolean | UrlTree>
  | Promise<boolean | UrlTree>
  | boolean
  | UrlTree => inject(AuthGuard).canActivate(route);

@Injectable()
export class AuthGuard {
  constructor(private store: Store<AppState>, private router: Router) {}

  canActivate(route: ActivatedRouteSnapshot): Observable<boolean> {
    return this.store.pipe(
      select(selectIsAuthenticated),
      tap((isAuthenticated) => {
        if (!isAuthenticated) {
          this.router.navigate(['/', 'auth', 'login']);
        }
      })
    );
  }
}
