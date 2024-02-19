import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BooksUserComponent } from './books-user.component';

describe('BooksUserComponent', () => {
  let component: BooksUserComponent;
  let fixture: ComponentFixture<BooksUserComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [BooksUserComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(BooksUserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
