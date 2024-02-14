import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Store } from '@ngrx/store';
import { AppState } from 'projects/website/src/app/app.state';
import {
  forgotPassword,
  loadForgotPasswordPage,
} from '../../../shared/state/authentication.action';
import {
  selectError,
  selectStatus,
} from '../../../shared/state/authentication.selectors';
import { Enforce } from '../../../shared/utils/enforce-form-group';

interface ForgotPasswordForm {
  emailAddress: string;
}

@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.scss'],
})
export class ForgotPasswordComponent implements OnInit {
  status$ = this.store.select(selectStatus);
  error$ = this.store.select(selectError);

  constructor(private store: Store<AppState>) {
    this.store.dispatch(loadForgotPasswordPage());
  }

  public forgotPasswordForm!: FormGroup<Enforce<ForgotPasswordForm>>;

  ngOnInit() {
    this.forgotPasswordForm = new FormGroup<Enforce<ForgotPasswordForm>>({
      emailAddress: new FormControl('', {
        nonNullable: true,
        validators: [Validators.required, Validators.email],
      }),
    });
  }

  get emailAddress() {
    return this.forgotPasswordForm.get('emailAddress');
  }

  onForgotPasswordSubmit() {
    if (this.forgotPasswordForm.valid) {
      let emailAddress = this.forgotPasswordForm.value.emailAddress!;

      this.store.dispatch(forgotPassword({ emailAddress }));
    }
  }
}
