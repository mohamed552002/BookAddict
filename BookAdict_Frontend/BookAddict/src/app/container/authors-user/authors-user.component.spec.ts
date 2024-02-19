import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AuthorsUserComponent } from './authors-user.component';

describe('AuthorsUserComponent', () => {
  let component: AuthorsUserComponent;
  let fixture: ComponentFixture<AuthorsUserComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AuthorsUserComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AuthorsUserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
