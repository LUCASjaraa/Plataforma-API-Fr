import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewrelatosComponent } from './viewrelatos.component';

describe('RelatosComponent', () => {
  let component: ViewrelatosComponent;
  let fixture: ComponentFixture<ViewrelatosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewrelatosComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ViewrelatosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
