import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PuntosinteresComponent } from './formpuntosinteres.component';

describe('PuntosinteresComponent', () => {
  let component: PuntosinteresComponent;
  let fixture: ComponentFixture<PuntosinteresComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PuntosinteresComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PuntosinteresComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
