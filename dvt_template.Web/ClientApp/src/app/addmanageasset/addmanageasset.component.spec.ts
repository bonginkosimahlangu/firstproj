import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddmanageassetComponent } from './addmanageasset.component';

describe('AddmanageassetComponent', () => {
  let component: AddmanageassetComponent;
  let fixture: ComponentFixture<AddmanageassetComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddmanageassetComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddmanageassetComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
