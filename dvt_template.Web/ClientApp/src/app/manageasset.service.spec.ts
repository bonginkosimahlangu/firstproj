import { TestBed, inject } from '@angular/core/testing';

import { ManageAssetService } from './manageasset.service';

describe('ManageassetService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ManageAssetService]
    });
  });

  it('should be created', inject([ManageAssetService], (service: ManageAssetService) => {
    expect(service).toBeTruthy();
  }));
});
