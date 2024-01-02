import { Component } from '@angular/core';
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

   constructor(private translate: TranslateService) {}

   ngOnInit() {
    this.selectedLanguage = 'EN';
    this.selectedIconClass = 'flag-icon-us'
  }

  switchLanguage(language: string) {
    this.translate.use(language);

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
