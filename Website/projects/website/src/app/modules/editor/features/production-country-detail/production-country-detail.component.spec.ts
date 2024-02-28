import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductionCountryDetailComponent } from './production-country-detail.component';

describe('ProductionCountryDetailComponent', () => {
  let component: ProductionCountryDetailComponent;
  let fixture: ComponentFixture<ProductionCountryDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProductionCountryDetailComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProductionCountryDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
