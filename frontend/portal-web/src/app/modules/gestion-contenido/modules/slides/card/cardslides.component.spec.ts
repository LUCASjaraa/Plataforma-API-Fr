import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CardslidesComponent } from './cardslides.component';

describe('CardslidesComponent', () => {
  let component: CardslidesComponent;
  let fixture: ComponentFixture<CardslidesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CardslidesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CardslidesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
