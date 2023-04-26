import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormgaleriaComponent } from './formgaleria.component';

describe('FgaleriaComponent', () => {
  let component: FormgaleriaComponent;
  let fixture: ComponentFixture<FormgaleriaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FormgaleriaComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FormgaleriaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
