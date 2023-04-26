import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrepostcatastrofeComponent } from './prepostcatastrofe.component';

describe('PrepostcatastrofeComponent', () => {
  let component: PrepostcatastrofeComponent;
  let fixture: ComponentFixture<PrepostcatastrofeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PrepostcatastrofeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PrepostcatastrofeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
