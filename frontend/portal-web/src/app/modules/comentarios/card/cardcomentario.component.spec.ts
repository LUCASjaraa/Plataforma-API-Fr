import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CardcomentarioComponent } from './cardcomentario.component';

describe('CardcomentarioComponent', () => {
  let component: CardcomentarioComponent;
  let fixture: ComponentFixture<CardcomentarioComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CardcomentarioComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CardcomentarioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
