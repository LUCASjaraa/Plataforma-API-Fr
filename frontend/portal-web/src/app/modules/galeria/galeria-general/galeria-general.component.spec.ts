import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GaleriaGeneralComponent } from './galeria-general.component';

describe('GaleriaGeneralComponent', () => {
  let component: GaleriaGeneralComponent;
  let fixture: ComponentFixture<GaleriaGeneralComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GaleriaGeneralComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GaleriaGeneralComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
