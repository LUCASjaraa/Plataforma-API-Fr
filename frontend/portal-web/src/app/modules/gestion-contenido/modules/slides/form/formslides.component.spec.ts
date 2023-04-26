import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormslidesComponent } from './formslides.component';

describe('FormslidesComponent', () => {
  let component: FormslidesComponent;
  let fixture: ComponentFixture<FormslidesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FormslidesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FormslidesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
