import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewescenariosComponent } from './viewescenarios.component';

describe('ViewescenariosComponent', () => {
  let component: ViewescenariosComponent;
  let fixture: ComponentFixture<ViewescenariosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewescenariosComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ViewescenariosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
