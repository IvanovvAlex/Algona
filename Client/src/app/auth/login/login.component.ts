import { Component, OnDestroy } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { animate, state, style, transition, trigger } from '@angular/animations';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Subscription } from 'rxjs';
import { TranslateService } from '@ngx-translate/core';

import { AuthService } from '../auth.service';
import { User } from 'src/app/shared/typization/interfaces';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css'],
    animations: [
        trigger('fade', [
            state('void', style({ opacity: 0 })),
            transition('void => *', [animate('0.6s 0.1s linear')])
        ]),
    ]
})
export class LoginComponent implements OnDestroy {
    errorFormServer: string = '';
    successMsgSubsc: Subscription = new Subscription();
    errorMsgSubsc: Subscription = new Subscription();
    loginSubsc: Subscription = new Subscription();

    loginForm = this.fb.group({
        email: new FormControl('', [Validators.required, Validators.email]),
        password: new FormControl('', [Validators.required]),
    });

    constructor(
        private router: Router,
        private fb: FormBuilder,
        private authService: AuthService,
        private snackBar: MatSnackBar,
        private translate: TranslateService
    ) { }

    get fc() {
        return this.loginForm.controls;
    }

    onSubmit() {
        if (this.loginForm.invalid) return;
        const { email, password } = this.loginForm.value;

        let successMsg: string = '';
        let errorMsg: string = '';

        this.successMsgSubsc = this.translate.get('login.success-message').subscribe(msg => successMsg = msg);
        this.errorMsgSubsc = this.translate.get('login.error-message').subscribe(msg => errorMsg = msg);

        this.loginSubsc = this.authService.login$(email!, password!).subscribe({
            next: (response) => {
                localStorage.setItem('token', response.token);
                this.authService.currentUserSignal.set(response as User);

                this.snackBar.open(successMsg, ' X ', {
                    duration: 5000,
                });
                this.router.navigate([ '/home' ]);
            },
            error: (response: HttpErrorResponse) => {
                if (response.status == 401) {
                    this.errorFormServer = response.error.message;
                } else {
                    this.errorFormServer = errorMsg;
                }

                this.snackBar.open(this.errorFormServer, ' X ', {
                    duration: 5000,
                });
                this.loginForm.reset();
                this.loginForm.markAllAsTouched();
            }
        });
    }

    ngOnDestroy(): void {
        this.successMsgSubsc.unsubscribe();
        this.errorMsgSubsc.unsubscribe();
        this.loginSubsc.unsubscribe();
    }
}
