import { ComponentFixture, TestBed } from '@angular/core/testing';

import { KeywordsListDataTableComponent } from './keywords-list-data-table.component';

describe('KeywordsListDataTableComponent', () => {
  let component: KeywordsListDataTableComponent;
  let fixture: ComponentFixture<KeywordsListDataTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ KeywordsListDataTableComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(KeywordsListDataTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
