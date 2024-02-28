import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CollectionDetailEditFormComponent } from './collection-detail-edit-form.component';

describe('CollectionDetailEditFormComponent', () => {
  let component: CollectionDetailEditFormComponent;
  let fixture: ComponentFixture<CollectionDetailEditFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CollectionDetailEditFormComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CollectionDetailEditFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
