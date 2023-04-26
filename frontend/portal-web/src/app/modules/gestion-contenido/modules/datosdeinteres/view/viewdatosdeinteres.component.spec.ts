import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewdatosdeinteresComponent } from './viewdatosdeinteres.component';

describe('ViewdatosdeinteresComponent', () => {
  let component: ViewdatosdeinteresComponent;
  let fixture: ComponentFixture<ViewdatosdeinteresComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewdatosdeinteresComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ViewdatosdeinteresComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
