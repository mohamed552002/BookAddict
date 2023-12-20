import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FirstHomePageComponent } from './first-home-page.component';

describe('FirstHomePageComponent', () => {
  let component: FirstHomePageComponent;
  let fixture: ComponentFixture<FirstHomePageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [FirstHomePageComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FirstHomePageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
