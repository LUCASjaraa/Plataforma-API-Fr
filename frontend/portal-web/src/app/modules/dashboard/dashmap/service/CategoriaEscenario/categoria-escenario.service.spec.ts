import { TestBed } from '@angular/core/testing';

import { CategoriaEscenarioService } from './categoria-escenario.service';

describe('CategoriaEscenarioService', () => {
  let service: CategoriaEscenarioService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CategoriaEscenarioService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
