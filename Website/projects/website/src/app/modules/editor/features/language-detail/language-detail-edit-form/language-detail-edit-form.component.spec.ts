import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LanguageDetailEditFormComponent } from './language-detail-edit-form.component';

describe('LanguageDetailEditFormComponent', () => {
  let component: LanguageDetailEditFormComponent;
  let fixture: ComponentFixture<LanguageDetailEditFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LanguageDetailEditFormComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LanguageDetailEditFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
