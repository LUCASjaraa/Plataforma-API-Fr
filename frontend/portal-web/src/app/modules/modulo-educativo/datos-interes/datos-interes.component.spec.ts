import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DatosInteresComponent } from './datos-interes.component';

describe('DatosInteresComponent', () => {
  let component: DatosInteresComponent;
  let fixture: ComponentFixture<DatosInteresComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DatosInteresComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DatosInteresComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
