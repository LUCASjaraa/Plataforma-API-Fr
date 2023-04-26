import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewslidesComponent } from './viewslides.component';

describe('ViewslidesComponent', () => {
  let component: ViewslidesComponent;
  let fixture: ComponentFixture<ViewslidesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewslidesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ViewslidesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
