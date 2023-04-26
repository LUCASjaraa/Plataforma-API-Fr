import { TestBed } from '@angular/core/testing';

import { PuntosinteresService } from './puntosinteres.service';

describe('PuntosinteresService', () => {
  let service: PuntosinteresService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PuntosinteresService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
