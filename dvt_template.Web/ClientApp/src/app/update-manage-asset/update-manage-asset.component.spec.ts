import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateManageAssetComponent } from './update-manage-asset.component';

describe('UpdateManageAssetComponent', () => {
  let component: UpdateManageAssetComponent;
  let fixture: ComponentFixture<UpdateManageAssetComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UpdateManageAssetComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UpdateManageAssetComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
