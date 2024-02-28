import { NgModule } from '@angular/core';
import { EffectsModule } from '@ngrx/effects';
import { StoreModule } from '@ngrx/store';
import { HoverClassDirective } from './directives/hover-class.directive';
import { AnonymousGuard } from './guards/anonymous.guard';
import { AuthGuard } from './guards/auth.guard';
import { ArraySortPipe } from './pipes/array-sort.pipe';
import { AuthenticationEffects } from './state/authentication.effect';
import { authenticationReducer } from './state/authentication.reducer';

@NgModule({
  declarations: [ArraySortPipe, HoverClassDirective],
  imports: [
    StoreModule.forFeature('authenticationFeature', authenticationReducer),
    EffectsModule.forFeature([AuthenticationEffects]),
  ],
  providers: [AuthGuard, AnonymousGuard],
  exports: [ArraySortPipe, HoverClassDirective],
})
export class SharedModule {}
