import { TestBed } from '@angular/core/testing';

import { scomentariosService } from './scomentarios.service';

describe('GcomentariosService', () => {
  let service: scomentariosService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(scomentariosService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
