import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Store } from '@ngrx/store';
import { AppState } from 'projects/website/src/app/app.state';
import {
  loadLoginPage,
  login,
} from '../../../shared/state/authentication.action';
import {
  selectError,
  selectStatus,
} from '../../../shared/state/authentication.selectors';
import { Enforce } from '../../../shared/utils/enforce-form-group';

interface LoginForm {
  emailAddress: string;
  password: string;
}

@Component({
  selector: 'authentication-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  status$ = this.store.select(selectStatus);
  error$ = this.store.select(selectError);

  constructor(private store: Store<AppState>) {
    this.store.dispatch(loadLoginPage());
  }

  public loginForm!: FormGroup<Enforce<LoginForm>>;

  ngOnInit() {
    this.loginForm = new FormGroup<Enforce<LoginForm>>({
      emailAddress: new FormControl('', {
        nonNullable: true,
        validators: [Validators.required, Validators.email],
      }),
      password: new FormControl('', {
        nonNullable: true,
        validators: [Validators.required],
      }),
    });
  }

  get emailAddress() {
    return this.loginForm.get('emailAddress');
  }

  get password() {
    return this.loginForm.get('password');
  }

  onLogin() {
    if (this.loginForm.valid) {
      let emailAddress = this.loginForm.value.emailAddress!;
      let password = this.loginForm.value.password!;

      this.store.dispatch(login({ emailAddress, password }));
    }
  }
}
