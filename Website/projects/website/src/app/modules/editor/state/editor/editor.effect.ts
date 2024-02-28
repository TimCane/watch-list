import { Injectable } from '@angular/core';
import { Actions } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import { AppState } from 'projects/website/src/app/app.state';

@Injectable()
export class EditorEffects {
  constructor(private actions$: Actions, private store: Store<AppState>) {}
}
