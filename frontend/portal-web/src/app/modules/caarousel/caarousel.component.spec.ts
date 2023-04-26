import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CaarouselComponent } from './caarousel.component';

describe('CaarouselComponent', () => {
  let component: CaarouselComponent;
  let fixture: ComponentFixture<CaarouselComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CaarouselComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CaarouselComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
