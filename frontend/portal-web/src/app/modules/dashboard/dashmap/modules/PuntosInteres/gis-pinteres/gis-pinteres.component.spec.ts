import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GisPinteresComponent } from './gis-pinteres.component';

describe('GisPinteresComponent', () => {
  let component: GisPinteresComponent;
  let fixture: ComponentFixture<GisPinteresComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GisPinteresComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GisPinteresComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
