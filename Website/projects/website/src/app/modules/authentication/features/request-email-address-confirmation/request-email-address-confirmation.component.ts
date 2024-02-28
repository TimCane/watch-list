import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Store } from '@ngrx/store';
import { AppState } from 'projects/website/src/app/app.state';
import {
  loadRequestEmailAddressConfirmationPage,
  requestEmailAddressConfirmation,
} from '../../../shared/state/authentication.action';
import {
  selectError,
  selectStatus,
} from '../../../shared/state/authentication.selectors';
import { Enforce } from '../../../shared/utils/enforce-form-group';

interface RequestEmailConfirmationForm {
  emailAddress: string;
}

@Component({
  selector: 'authentication-request-email-address-confirmation',
  templateUrl: './request-email-address-confirmation.component.html',
  styleUrls: ['./request-email-address-confirmation.component.scss'],
})
export class RequestEmailAddressConfirmationComponent implements OnInit {
  status$ = this.store.select(selectStatus);
  error$ = this.store.select(selectError);

  constructor(private store: Store<AppState>) {
    this.store.dispatch(loadRequestEmailAddressConfirmationPage());
  }

  public requestEmailConfirmationForm!: FormGroup<
    Enforce<RequestEmailConfirmationForm>
  >;

  ngOnInit() {
    this.requestEmailConfirmationForm = new FormGroup<
      Enforce<RequestEmailConfirmationForm>
    >({
      emailAddress: new FormControl('', {
        nonNullable: true,
        validators: [Validators.required, Validators.email],
      }),
    });
  }

  get emailAddress() {
    return this.requestEmailConfirmationForm.get('emailAddress');
  }

  onRequestEmailConfirmationSubmit() {
    if (this.requestEmailConfirmationForm.valid) {
      let emailAddress = this.requestEmailConfirmationForm.value.emailAddress!;

      this.store.dispatch(requestEmailAddressConfirmation({ emailAddress }));
    }
  }
}
