import { Component } from '@angular/core';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent {
   isActive: boolean = false;

  toggleNavbar() {
    this.isActive = !this.isActive;
  }
}
