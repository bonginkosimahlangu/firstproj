import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AssetaddComponent } from './assetadd.component';

describe('AssetaddComponent', () => {
  let component: AssetaddComponent;
  let fixture: ComponentFixture<AssetaddComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AssetaddComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AssetaddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
