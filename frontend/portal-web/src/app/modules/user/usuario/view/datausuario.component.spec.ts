import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DatausuarioComponent } from './datausuario.component';

describe('DatausuarioComponent', () => {
  let component: DatausuarioComponent;
  let fixture: ComponentFixture<DatausuarioComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DatausuarioComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DatausuarioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
