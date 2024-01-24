import { Component, HostListener } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';

import { AuthService } from 'src/app/auth/auth.service';

@Component({
    selector: 'app-nav-bar',
    templateUrl: './nav-bar.component.html',
    styleUrls: [ './nav-bar.component.css' ]
})
export class NavBarComponent {
    isActive: boolean = false;

    selectedLanguage: string = '';
    selectedIconClass: string = '';

    constructor(
        private translate: TranslateService,
        private router: Router,
        public authService: AuthService,
        private snackBar: MatSnackBar
    ) { }

    ngOnInit() {
        this.selectedLanguage = 'EN';
        this.selectedIconClass = 'flag-icon-us';

    }

    @HostListener('document:click', [ '$event' ])
    click(event: Event): void {

        const isClickOnNavbarToggler = (event.target as HTMLElement).classList.contains('navbar-toggler-icon');
        const clickedElement = (event.target as HTMLElement).getAttribute('data-bs-toggle');

        if (clickedElement === 'collapse' || isClickOnNavbarToggler) {
            this.toggleNavbar();
        } else {
            if (clickedElement !== 'dropdown') {
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
            this.router.navigate([ currentUrl ]);
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

    onLogout(): void {
        let logoutMsg: string = '';
        this.translate.get('logout.message').subscribe(msg => logoutMsg = msg);

        this.authService.logout$().subscribe({
            next: (res) => {
                localStorage.removeItem('token');
                this.authService.currentUserSignal.set(null);

                this.snackBar.open(logoutMsg, ' X ', { duration: 5000 });

                this.router.navigate([ '/auth/login' ]);
            },
            error: res => {
                localStorage.removeItem('token');
                this.authService.currentUserSignal.set(null);
                this.router.navigate([ '/auth/login' ]);
            }
        });
    }
}
