import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DesastreMemoriaComponent } from './desastre-memoria.component';

describe('DesastreMemoriaComponent', () => {
  let component: DesastreMemoriaComponent;
  let fixture: ComponentFixture<DesastreMemoriaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DesastreMemoriaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DesastreMemoriaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
