import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarddatosdeinteresComponent } from './carddatosdeinteres.component';

describe('CarddatosdeinteresComponent', () => {
  let component: CarddatosdeinteresComponent;
  let fixture: ComponentFixture<CarddatosdeinteresComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CarddatosdeinteresComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CarddatosdeinteresComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
