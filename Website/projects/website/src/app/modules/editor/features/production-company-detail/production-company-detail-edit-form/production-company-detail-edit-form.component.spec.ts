import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductionCompanyDetailEditFormComponent } from './production-company-detail-edit-form.component';

describe('ProductionCompanyDetailEditFormComponent', () => {
  let component: ProductionCompanyDetailEditFormComponent;
  let fixture: ComponentFixture<ProductionCompanyDetailEditFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProductionCompanyDetailEditFormComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProductionCompanyDetailEditFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
