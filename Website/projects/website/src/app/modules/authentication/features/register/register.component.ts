import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Store } from '@ngrx/store';
import { AppState } from 'projects/website/src/app/app.state';
import {
  loadRegisterPage,
  register,
} from '../../../shared/state/authentication.action';
import {
  selectError,
  selectStatus,
} from '../../../shared/state/authentication.selectors';
import { Enforce } from '../../../shared/utils/enforce-form-group';
import { confirmPasswordValidator } from '../../directives/confirm-password/confirm-password.directive';

export const StrongPasswordRegx: RegExp =
  /^(?=[^A-Z]*[A-Z])(?=[^a-z]*[a-z])(?=\D*\d).{8,}$/;

interface RegisterForm {
  emailAddress: string;
  name: string;
  password: string;
  confirmPassword: string;
}

@Component({
  selector: 'authentication-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent {
  status$ = this.store.select(selectStatus);
  error$ = this.store.select(selectError);

  constructor(private store: Store<AppState>) {
    this.store.dispatch(loadRegisterPage());
  }

  public registerForm!: FormGroup<Enforce<RegisterForm>>;

  ngOnInit() {
    this.registerForm = new FormGroup<Enforce<RegisterForm>>(
      {
        emailAddress: new FormControl('', {
          nonNullable: true,
          validators: [Validators.required, Validators.email],
        }),
        name: new FormControl('', {
          nonNullable: true,
          validators: [Validators.required],
        }),
        password: new FormControl('', {
          nonNullable: true,
          validators: [
            Validators.required,
            Validators.pattern(StrongPasswordRegx),
          ],
        }),
        confirmPassword: new FormControl('', {
          nonNullable: true,
          validators: [Validators.required],
        }),
      },
      { validators: confirmPasswordValidator }
    );
  }

  get emailAddress() {
    return this.registerForm.get('emailAddress');
  }

  get name() {
    return this.registerForm.get('name');
  }

  get password() {
    return this.registerForm.get('password');
  }

  get confirmPassword() {
    return this.registerForm.get('confirmPassword');
  }

  onRegister() {
    if (this.registerForm.valid) {
      let emailAddress = this.registerForm.value.emailAddress!;
      let name = this.registerForm.value.name!;
      let password = this.registerForm.value.password!;

      this.store.dispatch(register({ emailAddress, name, password }));
    }
  }
}
