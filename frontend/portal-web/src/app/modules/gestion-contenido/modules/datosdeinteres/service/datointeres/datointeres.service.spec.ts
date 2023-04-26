import { TestBed } from '@angular/core/testing';

import { DatointeresService } from './datointeres.service';

describe('DatointeresService', () => {
  let service: DatointeresService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DatointeresService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
