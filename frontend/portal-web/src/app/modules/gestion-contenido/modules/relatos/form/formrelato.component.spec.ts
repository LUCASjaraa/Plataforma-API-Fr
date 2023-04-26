import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormrelatoComponent } from './formrelato.component';

describe('FormrelatoComponent', () => {
  let component: FormrelatoComponent;
  let fixture: ComponentFixture<FormrelatoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FormrelatoComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FormrelatoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
