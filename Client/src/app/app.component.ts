import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from './auth/auth.service';
import { HttpErrorResponse } from '@angular/common/http';

declare let AOS: any;

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
    title = 'Client';

    constructor(private router: Router, public authService: AuthService) {

    }

    hasRoute() {

        if (this.router.url.match('^[\/{1}]$')) {
            return true
        } else if (this.router.url.includes('/home')) {
            return true
        }
        //  else if (this.router.url.includes('/404')) {
        //     return true
        // } 
        else {
            return false
        }
    }

    ngOnInit(): void {
        AOS.init();

        const localStorageToken = localStorage.getItem('token');
        if (localStorageToken) {
            this.authService.getUser$().subscribe({
                next: userData => {
                    this.authService.currentUserSignal.set(userData)
                },
                error: (res: HttpErrorResponse) => {
                    this.authService.currentUserSignal.set(null);
                    localStorage.removeItem('token');
                }
            })
        }
        else {
            this.authService.currentUserSignal.set(undefined);
        }
    }
}
