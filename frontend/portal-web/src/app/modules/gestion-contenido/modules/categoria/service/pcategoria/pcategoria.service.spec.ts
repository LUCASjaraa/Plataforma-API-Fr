import { TestBed } from '@angular/core/testing';

import { PcategoriaService } from './pcategoria.service';

describe('PcategoriaService', () => {
  let service: PcategoriaService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PcategoriaService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
