import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductionCompaniesListDataTableComponent } from './production-companies-list-data-table.component';

describe('ProductionCompaniesListDataTableComponent', () => {
  let component: ProductionCompaniesListDataTableComponent;
  let fixture: ComponentFixture<ProductionCompaniesListDataTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProductionCompaniesListDataTableComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProductionCompaniesListDataTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
