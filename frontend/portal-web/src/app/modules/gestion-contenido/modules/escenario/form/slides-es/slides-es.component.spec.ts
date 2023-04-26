import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SlidesEsComponent } from './slides-es.component';

describe('SlidesEsComponent', () => {
  let component: SlidesEsComponent;
  let fixture: ComponentFixture<SlidesEsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SlidesEsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SlidesEsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
