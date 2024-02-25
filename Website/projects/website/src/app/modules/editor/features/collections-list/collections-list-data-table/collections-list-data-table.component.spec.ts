import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CollectionsListDataTableComponent } from './collections-list-data-table.component';

describe('CollectionsListDataTableComponent', () => {
  let component: CollectionsListDataTableComponent;
  let fixture: ComponentFixture<CollectionsListDataTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CollectionsListDataTableComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CollectionsListDataTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
