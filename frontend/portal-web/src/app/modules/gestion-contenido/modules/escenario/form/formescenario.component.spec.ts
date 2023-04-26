import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormescenarioComponent } from './formescenario.component';

describe('FormescenarioComponent', () => {
  let component: FormescenarioComponent;
  let fixture: ComponentFixture<FormescenarioComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FormescenarioComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FormescenarioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
