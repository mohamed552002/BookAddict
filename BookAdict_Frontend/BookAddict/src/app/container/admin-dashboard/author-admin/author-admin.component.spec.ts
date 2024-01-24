import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AuthorAdminComponent } from './author-admin.component';

describe('AuthorAdminComponent', () => {
  let component: AuthorAdminComponent;
  let fixture: ComponentFixture<AuthorAdminComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AuthorAdminComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AuthorAdminComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
