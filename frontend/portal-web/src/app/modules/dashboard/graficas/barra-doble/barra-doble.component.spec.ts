import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BarraDobleComponent } from './barra-doble.component';

describe('BarraDobleComponent', () => {
  let component: BarraDobleComponent;
  let fixture: ComponentFixture<BarraDobleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BarraDobleComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BarraDobleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
