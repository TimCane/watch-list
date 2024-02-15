import {
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { environment } from 'projects/website/src/environments/environment';
import { Observable, first, mergeMap } from 'rxjs';
import { AppState } from '../../../app.state';
import { selectBearerToken } from '../state/authentication.selectors';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  constructor(private router: Router, private store: Store<AppState>) {}

  intercept(
    request: HttpRequest<unknown>,
    next: HttpHandler
  ): Observable<HttpEvent<unknown>> {
    if (
      environment.API_BASE_URL &&
      request.url.startsWith(environment.API_BASE_URL)
    ) {
      return this.store.select(selectBearerToken).pipe(
        first(),
        mergeMap((bearerToken) => {
          if (bearerToken) {
            const authReq = request.clone({
              setHeaders: {
                Authorization: `Bearer ${bearerToken}`,
              },
            });
            return next.handle(authReq);
          }
          return next.handle(request);
        })
      );
    }
    return next.handle(request);
  }
}
