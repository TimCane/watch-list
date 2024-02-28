import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Enforce } from '../../../../shared/utils/enforce-form-group';

interface CollectionEditForm {
  id: string;
  name: string;
  createdOn: string;
  modifiedOn: string;
  createdBy: string;
  modifiedBy: string;
}

@Component({
  selector: 'editor-collection-detail-edit-form',
  templateUrl: './collection-detail-edit-form.component.html',
  styleUrls: ['./collection-detail-edit-form.component.scss'],
})
export class CollectionDetailEditFormComponent implements OnInit {
  public editForm!: FormGroup<Enforce<CollectionEditForm>>;

  ngOnInit() {
    this.editForm = new FormGroup<Enforce<CollectionEditForm>>({
      id: new FormControl(
        { value: '', disabled: true },
        {
          nonNullable: true,
          validators: [Validators.required],
        }
      ),
      name: new FormControl('', {
        nonNullable: true,
        validators: [Validators.required],
      }),
      createdOn: new FormControl(
        { value: '', disabled: true },
        {
          nonNullable: true,
          validators: [Validators.required],
        }
      ),
      modifiedOn: new FormControl(
        { value: '', disabled: true },
        {
          nonNullable: true,
          validators: [Validators.required],
        }
      ),
      createdBy: new FormControl(
        { value: '', disabled: true },
        {
          nonNullable: true,
          validators: [Validators.required],
        }
      ),
      modifiedBy: new FormControl(
        { value: '', disabled: true },
        {
          nonNullable: true,
          validators: [Validators.required],
        }
      ),
    });
  }

  get id() {
    return this.editForm.get('id');
  }
  get name() {
    return this.editForm.get('name');
  }
  get createdOn() {
    return this.editForm.get('createdOn');
  }
  get modifiedOn() {
    return this.editForm.get('modifiedOn');
  }
  get createdBy() {
    return this.editForm.get('createdBy');
  }
  get modifiedBy() {
    return this.editForm.get('modifiedBy');
  }
}
