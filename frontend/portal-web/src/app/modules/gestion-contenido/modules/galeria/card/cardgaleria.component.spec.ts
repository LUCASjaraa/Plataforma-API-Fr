import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CardgaleriaComponent } from './cardgaleria.component';

describe('CardgaleriaComponent', () => {
  let component: CardgaleriaComponent;
  let fixture: ComponentFixture<CardgaleriaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CardgaleriaComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CardgaleriaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
