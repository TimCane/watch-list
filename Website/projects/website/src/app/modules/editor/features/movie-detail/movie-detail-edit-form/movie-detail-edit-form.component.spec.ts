import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MovieDetailEditFormComponent } from './movie-detail-edit-form.component';

describe('MovieDetailEditFormComponent', () => {
  let component: MovieDetailEditFormComponent;
  let fixture: ComponentFixture<MovieDetailEditFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MovieDetailEditFormComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MovieDetailEditFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
