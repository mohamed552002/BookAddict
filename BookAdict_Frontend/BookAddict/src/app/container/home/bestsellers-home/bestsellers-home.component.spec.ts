import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BestsellersHomeComponent } from './bestsellers-home.component';

describe('BestsellersHomeComponent', () => {
  let component: BestsellersHomeComponent;
  let fixture: ComponentFixture<BestsellersHomeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [BestsellersHomeComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(BestsellersHomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
