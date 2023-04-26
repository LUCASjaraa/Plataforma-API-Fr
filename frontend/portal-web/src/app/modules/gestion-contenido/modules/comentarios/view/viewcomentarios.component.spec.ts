import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewcomentariosComponent } from './viewcomentarios.component';

describe('ViewcomentariosComponent', () => {
  let component: ViewcomentariosComponent;
  let fixture: ComponentFixture<ViewcomentariosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewcomentariosComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ViewcomentariosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
