import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditWordsComponent } from './add-edit-words.component';

describe('AddEditWordsComponent', () => {
  let component: AddEditWordsComponent;
  let fixture: ComponentFixture<AddEditWordsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEditWordsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEditWordsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
