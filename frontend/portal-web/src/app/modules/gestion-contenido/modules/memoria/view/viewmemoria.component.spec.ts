import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewmemoriaComponent } from '../viewmemoria.component';

describe('ViewmemoriaComponent', () => {
  let component: ViewmemoriaComponent;
  let fixture: ComponentFixture<ViewmemoriaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewmemoriaComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ViewmemoriaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
