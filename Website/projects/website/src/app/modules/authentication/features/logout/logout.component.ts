import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { AppState } from 'projects/website/src/app/app.state';
import {
  loadLogoutPage,
  logout,
} from '../../../shared/state/authentication.action';
import {
  selectError,
  selectStatus,
} from '../../../shared/state/authentication.selectors';

@Component({
  selector: 'authentication-logout',
  templateUrl: './logout.component.html',
  styleUrls: ['./logout.component.scss'],
})
export class LogoutComponent implements OnInit {
  status$ = this.store.select(selectStatus);
  error$ = this.store.select(selectError);

  private userPromptId: string = '';

  constructor(
    private store: Store<AppState>,
    private route: ActivatedRoute,
    private router: Router
  ) {
    this.store.dispatch(loadLogoutPage());
  }
  ngOnInit(): void {
    this.store.dispatch(logout());
  }
}
