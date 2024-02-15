import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RequestEmailAddressConfirmationComponent } from './request-email-address-confirmation.component';

describe('RequestEmailAddressConfirmationComponent', () => {
  let component: RequestEmailAddressConfirmationComponent;
  let fixture: ComponentFixture<RequestEmailAddressConfirmationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RequestEmailAddressConfirmationComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RequestEmailAddressConfirmationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
