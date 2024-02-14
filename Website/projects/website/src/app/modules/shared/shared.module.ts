import { NgModule } from '@angular/core';
import { EffectsModule } from '@ngrx/effects';
import { StoreModule } from '@ngrx/store';
import { AnonymousGuard } from './guards/anonymous.guard';
import { AuthGuard } from './guards/auth.guard';
import { AuthenticationEffects } from './state/authentication.effect';
import { authenticationReducer } from './state/authentication.reducer';

@NgModule({
  declarations: [],
  imports: [
    StoreModule.forFeature('authenticationFeature', authenticationReducer),
    EffectsModule.forFeature([AuthenticationEffects]),
  ],
  providers: [AuthGuard, AnonymousGuard],
})
export class SharedModule {}
