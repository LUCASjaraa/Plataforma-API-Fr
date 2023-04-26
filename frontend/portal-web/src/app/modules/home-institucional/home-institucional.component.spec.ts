import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HomeInstitucionalComponent } from './home-institucional.component';

describe('HomeInstitucionalComponent', () => {
  let component: HomeInstitucionalComponent;
  let fixture: ComponentFixture<HomeInstitucionalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HomeInstitucionalComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HomeInstitucionalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
