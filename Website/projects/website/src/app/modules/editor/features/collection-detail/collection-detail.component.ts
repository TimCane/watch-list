import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { AppState } from 'projects/website/src/app/app.state';

@Component({
  selector: 'editor-collection-detail',
  templateUrl: './collection-detail.component.html',
  styleUrls: ['./collection-detail.component.scss'],
})
export class CollectionDetailComponent {
  constructor(private store: Store<AppState>) {}

  onSave() {}
  onDelete() {}
}
