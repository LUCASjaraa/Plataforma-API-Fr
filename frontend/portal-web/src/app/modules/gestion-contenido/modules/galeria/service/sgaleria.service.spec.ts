import { TestBed } from '@angular/core/testing';

import { SgaleriaService } from './sgaleria.service';

describe('SgaleriaService', () => {
  let service: SgaleriaService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SgaleriaService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
