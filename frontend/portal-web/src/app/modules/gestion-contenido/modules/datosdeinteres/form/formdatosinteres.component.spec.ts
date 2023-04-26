import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormdatosinteresComponent } from './formdatosinteres.component';

describe('FormdatosinteresComponent', () => {
  let component: FormdatosinteresComponent;
  let fixture: ComponentFixture<FormdatosinteresComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FormdatosinteresComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FormdatosinteresComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
