import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MoviesListDataTableComponent } from './movies-list-data-table.component';

describe('MoviesListDataTableComponent', () => {
  let component: MoviesListDataTableComponent;
  let fixture: ComponentFixture<MoviesListDataTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MoviesListDataTableComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MoviesListDataTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
