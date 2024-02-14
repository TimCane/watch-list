import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { AppState } from 'projects/website/src/app/app.state';
import {
  loadResetPasswordPage,
  resetPassword,
} from '../../../shared/state/authentication.action';
import {
  selectError,
  selectStatus,
} from '../../../shared/state/authentication.selectors';
import { Enforce } from '../../../shared/utils/enforce-form-group';
import { isGuid } from '../../../shared/utils/is-guid';
import { confirmPasswordValidator } from '../../directives/confirm-password/confirm-password.directive';
import { StrongPasswordRegx } from '../register/register.component';

interface ResetPasswordForm {
  password: string;
  confirmPassword: string;
}

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.scss'],
})
export class ResetPasswordComponent {
  status$ = this.store.select(selectStatus);
  error$ = this.store.select(selectError);

  private userPromptId: string = '';

  constructor(
    private store: Store<AppState>,
    private route: ActivatedRoute,
    private router: Router
  ) {
    this.store.dispatch(loadResetPasswordPage());

    if (isGuid(this.route.snapshot.params['id'])) {
      this.userPromptId = this.route.snapshot.params['id'];
    } else {
      this.router.navigate(['/', 'auth', 'forgot-password']);
    }
  }

  public resetPasswordForm!: FormGroup<Enforce<ResetPasswordForm>>;

  ngOnInit() {
    this.resetPasswordForm = new FormGroup<Enforce<ResetPasswordForm>>(
      {
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

  get password() {
    return this.resetPasswordForm.get('password');
  }

  get confirmPassword() {
    return this.resetPasswordForm.get('confirmPassword');
  }

  onResetPasswordSubmit() {
    if (this.resetPasswordForm.valid) {
      let newPassword = this.resetPasswordForm.value.password!;

      this.store.dispatch(
        resetPassword({ newPassword, userPromptId: this.userPromptId })
      );
    }
  }
}
