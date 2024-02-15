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
import { selectIsAnonymous } from '../state/authentication.selectors';

export const anonymousGuardFunction: CanActivateFn = (
  route: ActivatedRouteSnapshot,
  state: RouterStateSnapshot
):
  | Observable<boolean | UrlTree>
  | Promise<boolean | UrlTree>
  | boolean
  | UrlTree => inject(AnonymousGuard).canActivate(route);

@Injectable()
export class AnonymousGuard {
  constructor(private store: Store<AppState>, private router: Router) {}

  canActivate(route: ActivatedRouteSnapshot): Observable<boolean> {
    return this.store.pipe(
      select(selectIsAnonymous),
      tap((isAnonymous) => {
        if (!isAnonymous) {
          this.router.navigate(['/']);
        }
      })
    );
  }
}
