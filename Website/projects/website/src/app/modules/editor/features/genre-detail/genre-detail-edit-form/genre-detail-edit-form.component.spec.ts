import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GenreDetailEditFormComponent } from './genre-detail-edit-form.component';

describe('GenreDetailEditFormComponent', () => {
  let component: GenreDetailEditFormComponent;
  let fixture: ComponentFixture<GenreDetailEditFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GenreDetailEditFormComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GenreDetailEditFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
