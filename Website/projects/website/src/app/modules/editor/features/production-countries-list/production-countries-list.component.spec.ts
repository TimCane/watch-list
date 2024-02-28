import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductionCountriesListComponent } from './production-countries-list.component';

describe('ProductionCountriesListComponent', () => {
  let component: ProductionCountriesListComponent;
  let fixture: ComponentFixture<ProductionCountriesListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProductionCountriesListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProductionCountriesListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
