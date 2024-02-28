import { ComponentFixture, TestBed } from '@angular/core/testing';

import { KeywordDetailEditFormComponent } from './keyword-detail-edit-form.component';

describe('KeywordDetailEditFormComponent', () => {
  let component: KeywordDetailEditFormComponent;
  let fixture: ComponentFixture<KeywordDetailEditFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ KeywordDetailEditFormComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(KeywordDetailEditFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
