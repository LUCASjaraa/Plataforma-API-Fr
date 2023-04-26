import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CardrelatoComponent } from './cardrelato.component';

describe('CardrelatoComponent', () => {
  let component: CardrelatoComponent;
  let fixture: ComponentFixture<CardrelatoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CardrelatoComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CardrelatoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
