import { Component } from '@angular/core';
import { faMagnifyingGlass } from '@fortawesome/free-solid-svg-icons';
import { faCoffee } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'first-home-page',
  templateUrl: './first-home-page.component.html',
  styleUrl: './first-home-page.component.css'
})
export class FirstHomePageComponent {
faMagnifyingClass = faMagnifyingGlass;
faCoffee = faCoffee;
}
