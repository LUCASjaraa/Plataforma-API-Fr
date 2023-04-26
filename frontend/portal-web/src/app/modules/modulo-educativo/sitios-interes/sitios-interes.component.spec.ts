import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SitiosInteresComponent } from './sitios-interes.component';

describe('SitiosInteresComponent', () => {
  let component: SitiosInteresComponent;
  let fixture: ComponentFixture<SitiosInteresComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SitiosInteresComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SitiosInteresComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
