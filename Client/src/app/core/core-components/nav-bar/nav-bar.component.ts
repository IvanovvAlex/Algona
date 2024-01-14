import { Component, HostListener } from '@angular/core';
import { Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent {
   isActive: boolean = false;

   selectedLanguage: string = '';
   selectedIconClass: string = '';

   constructor(private translate: TranslateService, private router: Router) {}

   ngOnInit() {
    this.selectedLanguage = 'EN';
    this.selectedIconClass = 'flag-icon-us';

  }

  @HostListener('document:click', ['$event'])
  click(event: Event): void {

    const isClickOnNavbarToggler = (event.target as HTMLElement).classList.contains('navbar-toggler-icon');
    const clickedElement = (event.target as HTMLElement).getAttribute('data-bs-toggle');
    
    if (clickedElement === 'collapse' || isClickOnNavbarToggler) {
      this.toggleNavbar();
    } else {
      if( clickedElement !== 'dropdown') {
      this.closeNavbar();
      }
    }  
  }

  toggleNavbar(): void {
    this.isActive = !this.isActive; 
  }

  closeNavbar(): void {
    this.isActive = false;
  }

  switchLanguage(language: string) {
    this.translate.use(language);
    const currentUrl = this.router.url;

    this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
      this.router.navigate([currentUrl]);
    });

    if (language === 'en') {
      this.selectedLanguage = ' EN';
      this.selectedIconClass = 'flag-icon-us';
    } else if (language === 'bg') {
      this.selectedLanguage = ' BG';
      this.selectedIconClass = 'flag-icon-bg';
    } else if (language === 'de') {
      this.selectedLanguage = ' DE';
      this.selectedIconClass = 'flag-icon-de';
    }
  }

  
}
