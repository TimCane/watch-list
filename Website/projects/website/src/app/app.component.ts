import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { PrimeNGConfig } from 'primeng/api';
import { AppState } from './app.state';
import { cookieCheck } from './modules/shared/state/authentication.action';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  constructor(
    private primengConfig: PrimeNGConfig,
    private store: Store<AppState>
  ) {
    this.store.dispatch(cookieCheck());
  }

  ngOnInit() {
    this.primengConfig.ripple = true;
  }
}
