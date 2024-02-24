import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { AppState } from '../../app.state';
import { selectUser } from '../shared/state/authentication.selectors';

@Component({
  selector: 'editor',
  templateUrl: './editor.component.html',
  styleUrls: ['./editor.component.scss'],
})
export class EditorComponent {
  user$ = this.store.select(selectUser);

  constructor(private store: Store<AppState>) {}

  sidebarToggle: boolean = false;

  onSidebarToggled() {
    this.sidebarToggle = !this.sidebarToggle;
  }
}
