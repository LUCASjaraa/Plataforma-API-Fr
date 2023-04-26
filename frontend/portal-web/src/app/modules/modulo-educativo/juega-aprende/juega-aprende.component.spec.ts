import { ComponentFixture, TestBed } from '@angular/core/testing';

import { JuegaAprendeComponent } from './juega-aprende.component';

describe('JuegaAprendeComponent', () => {
  let component: JuegaAprendeComponent;
  let fixture: ComponentFixture<JuegaAprendeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ JuegaAprendeComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(JuegaAprendeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
