import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductionCompanyDetailComponent } from './production-company-detail.component';

describe('ProductionCompanyDetailComponent', () => {
  let component: ProductionCompanyDetailComponent;
  let fixture: ComponentFixture<ProductionCompanyDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProductionCompanyDetailComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProductionCompanyDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
