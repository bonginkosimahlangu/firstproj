import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteManageAssetComponent } from './delete-manage-asset.component';

describe('DeleteManageAssetComponent', () => {
  let component: DeleteManageAssetComponent;
  let fixture: ComponentFixture<DeleteManageAssetComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DeleteManageAssetComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DeleteManageAssetComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
