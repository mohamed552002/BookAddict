import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RelevantBooksComponent } from './relevant-books.component';

describe('RelevantBooksComponent', () => {
  let component: RelevantBooksComponent;
  let fixture: ComponentFixture<RelevantBooksComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [RelevantBooksComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(RelevantBooksComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
