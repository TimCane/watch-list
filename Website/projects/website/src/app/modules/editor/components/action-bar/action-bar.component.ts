import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'editor-action-bar',
  templateUrl: './action-bar.component.html',
  styleUrls: ['./action-bar.component.scss'],
})
export class ActionBarComponent {
  @Input() showNew: boolean = false;
  @Input() showSave: boolean = false;
  @Input() showDelete: boolean = false;

  @Output() onNewClick = new EventEmitter<void>();
  @Output() onSaveClick = new EventEmitter<void>();
  @Output() onDeleteClick = new EventEmitter<void>();

  onDeleteClicked() {
    this.onDeleteClick.emit();
  }
  onSaveClicked() {
    this.onSaveClick.emit();
  }
  onNewClicked() {
    this.onNewClick.emit();
  }
}
