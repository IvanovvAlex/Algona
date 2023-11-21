import { Component } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { animate, state, style, transition, trigger } from '@angular/animations';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
    styleUrls: [ './login.component.css' ],
    animations: [
        trigger('fade', [
            state('void', style({ opacity: 0 })),
            transition('void => *', [ animate('0.6s 0.1s linear') ])
        ]),
    ]
})
export class LoginComponent {
    errorFormServer: string = '';

    loginForm = this.fb.group({
        email: new FormControl('', [ Validators.required, Validators.email ]),
        password: new FormControl('', [ Validators.required ]),
    });

    constructor(private fb: FormBuilder, private snackBar: MatSnackBar) { }

    get fc() {
        return this.loginForm.controls;
    }

    //TODO: handle login request
    onSubmit() {
        if (this.loginForm.invalid) return;
        const { email, password } = this.loginForm.value;

        if (this.errorFormServer !== '') {
            this.snackBar.open(this.errorFormServer, 'Close', {
                duration: 5000,
            });

            this.loginForm.reset();
            this.loginForm.markAllAsTouched();
        }
    }
}
