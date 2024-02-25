import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LanguagesListDataTableComponent } from './languages-list-data-table.component';

describe('LanguagesListDataTableComponent', () => {
  let component: LanguagesListDataTableComponent;
  let fixture: ComponentFixture<LanguagesListDataTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LanguagesListDataTableComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LanguagesListDataTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
