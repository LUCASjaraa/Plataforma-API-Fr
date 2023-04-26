import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CardmemoriaComponent } from './cardmemoria.component';

describe('CardmemoriaComponent', () => {
  let component: CardmemoriaComponent;
  let fixture: ComponentFixture<CardmemoriaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CardmemoriaComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CardmemoriaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
