
import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GpuntointeresComponent } from './viewpuntointeres.component';

describe('GpuntointeresComponent', () => {
  let component: GpuntointeresComponent;
  let fixture: ComponentFixture<GpuntointeresComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GpuntointeresComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GpuntointeresComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
