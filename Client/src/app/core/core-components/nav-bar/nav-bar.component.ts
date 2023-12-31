import { Component } from '@angular/core';
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

  toggleNavbar() {
    this.isActive = !this.isActive;
  }
}
