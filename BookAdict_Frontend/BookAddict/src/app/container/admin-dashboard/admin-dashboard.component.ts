import { Component } from '@angular/core';
import { faDollarSign , faScroll, faBook, faUser } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'admin-dashboard',
  templateUrl: './admin-dashboard.component.html',
  styleUrl: './admin-dashboard.component.css'
})
export class AdminDashboardComponent {
  faDollarSign = faDollarSign;
  faScroll = faScroll;
  faBook = faBook;
  faUser = faUser
}
