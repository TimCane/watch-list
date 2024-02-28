import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductionCountriesListDataTableComponent } from './production-countries-list-data-table.component';

describe('ProductionCountriesListDataTableComponent', () => {
  let component: ProductionCountriesListDataTableComponent;
  let fixture: ComponentFixture<ProductionCountriesListDataTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProductionCountriesListDataTableComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProductionCountriesListDataTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
