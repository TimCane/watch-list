import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreditsListDataTableComponent } from './credits-list-data-table.component';

describe('CreditsListDataTableComponent', () => {
  let component: CreditsListDataTableComponent;
  let fixture: ComponentFixture<CreditsListDataTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreditsListDataTableComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreditsListDataTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
