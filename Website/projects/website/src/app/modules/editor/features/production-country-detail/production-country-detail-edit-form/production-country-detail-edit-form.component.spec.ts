import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductionCountryDetailEditFormComponent } from './production-country-detail-edit-form.component';

describe('ProductionCountryDetailEditFormComponent', () => {
  let component: ProductionCountryDetailEditFormComponent;
  let fixture: ComponentFixture<ProductionCountryDetailEditFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProductionCountryDetailEditFormComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProductionCountryDetailEditFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
