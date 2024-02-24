import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductionCompaniesListComponent } from './production-companies-list.component';

describe('ProductionCompaniesListComponent', () => {
  let component: ProductionCompaniesListComponent;
  let fixture: ComponentFixture<ProductionCompaniesListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProductionCompaniesListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProductionCompaniesListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
