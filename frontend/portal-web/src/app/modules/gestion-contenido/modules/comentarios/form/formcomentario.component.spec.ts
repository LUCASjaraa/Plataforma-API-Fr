import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FcomentarioComponent } from './formcomentario.component';

describe('FcomentarioComponent', () => {
  let component: FcomentarioComponent;
  let fixture: ComponentFixture<FcomentarioComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FcomentarioComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FcomentarioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
