import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SessionStorageService } from './storage/session-storage.service';

@Injectable({
  providedIn: 'root',
})
export class CookieService {
  constructor(private session: SessionStorageService) {}

  getCookie() {
    return new Observable<{ bearerToken: string; refreshToken: string }>(
      (sub) => {
        let bearerToken = this.session.getItem<string>('bearerToken');
        let refreshToken = this.session.getItem<string>('refreshToken');

        if (bearerToken == null) {
          sub.error('No Bearer Token');
          return;
        }

        if (refreshToken == null) {
          sub.error('No Refresh Token');
          return;
        }

        sub.next({
          bearerToken,
          refreshToken,
        });
      }
    );
  }

  setCookie(bearerToken: string, refreshToken: string) {
    this.session.setItem('bearerToken', bearerToken);
    this.session.setItem('refreshToken', refreshToken);
  }

  clearCookie() {
    this.session.removeItem('bearerToken');
    this.session.removeItem('refreshToken');
  }
}
