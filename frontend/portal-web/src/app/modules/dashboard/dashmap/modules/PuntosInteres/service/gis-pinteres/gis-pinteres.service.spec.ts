import { TestBed } from '@angular/core/testing';

import { GisPinteresService } from './gis-pinteres.service';

describe('GisPinteresService', () => {
  let service: GisPinteresService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GisPinteresService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
