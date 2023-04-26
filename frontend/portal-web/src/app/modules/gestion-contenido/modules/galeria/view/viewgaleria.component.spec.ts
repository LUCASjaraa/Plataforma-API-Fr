import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewgaleriaComponent } from './viewgaleria.component';

describe('ViewgaleriaComponent', () => {
  let component: ViewgaleriaComponent;
  let fixture: ComponentFixture<ViewgaleriaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewgaleriaComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ViewgaleriaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
