import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BookUserComponent } from './book-user.component';

describe('BookUserComponent', () => {
  let component: BookUserComponent;
  let fixture: ComponentFixture<BookUserComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [BookUserComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(BookUserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
