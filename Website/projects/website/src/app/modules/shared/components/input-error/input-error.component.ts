import { Component, Input } from '@angular/core';
import { AbstractControl, FormGroupDirective } from '@angular/forms';

@Component({
  selector: 'app-input-error',
  templateUrl: './input-error.component.html',
  styleUrls: ['./input-error.component.scss'],
})
export class InputErrorComponent {
  @Input() form: FormGroupDirective | null = null;
  @Input() control: AbstractControl<string, string> | null = null;
}
