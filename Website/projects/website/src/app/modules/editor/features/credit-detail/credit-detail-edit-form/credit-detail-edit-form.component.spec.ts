import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreditDetailEditFormComponent } from './credit-detail-edit-form.component';

describe('CreditDetailEditFormComponent', () => {
  let component: CreditDetailEditFormComponent;
  let fixture: ComponentFixture<CreditDetailEditFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreditDetailEditFormComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreditDetailEditFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
