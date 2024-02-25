import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GenresListDataTableComponent } from './genres-list-data-table.component';

describe('GenresListDataTableComponent', () => {
  let component: GenresListDataTableComponent;
  let fixture: ComponentFixture<GenresListDataTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GenresListDataTableComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GenresListDataTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
