import { TestBed } from '@angular/core/testing';

import { RelatosService } from './relatos.service';

describe('RelatosService', () => {
  let service: RelatosService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RelatosService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
