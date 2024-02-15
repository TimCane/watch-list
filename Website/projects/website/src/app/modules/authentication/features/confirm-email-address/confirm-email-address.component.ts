import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { AppState } from 'projects/website/src/app/app.state';
import {
  confirmEmailAddress,
  loadConfirmEmailAddressPage,
} from '../../../shared/state/authentication.action';
import {
  selectError,
  selectStatus,
} from '../../../shared/state/authentication.selectors';
import { isGuid } from '../../../shared/utils/is-guid';

@Component({
  selector: 'app-confirm-email-address',
  templateUrl: './confirm-email-address.component.html',
  styleUrls: ['./confirm-email-address.component.scss'],
})
export class ConfirmEmailAddressComponent implements OnInit {
  status$ = this.store.select(selectStatus);
  error$ = this.store.select(selectError);

  private userPromptId: string = '';

  constructor(
    private store: Store<AppState>,
    private route: ActivatedRoute,
    private router: Router
  ) {
    this.store.dispatch(loadConfirmEmailAddressPage());

    if (isGuid(this.route.snapshot.params['id'])) {
      this.userPromptId = this.route.snapshot.params['id'];
    } else {
      this.router.navigate(['/', 'auth', 'login']);
    }
  }
  ngOnInit(): void {
    this.store.dispatch(
      confirmEmailAddress({ userPromptId: this.userPromptId })
    );
  }
}
