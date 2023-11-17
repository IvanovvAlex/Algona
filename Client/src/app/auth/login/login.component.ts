import { Component } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
    errorFormServer: string = '';

    loginForm = this.fb.group({
        email: new FormControl('', [ Validators.required, Validators.email ]),
        password: new FormControl('', [ Validators.required ]),
    });

    constructor(private fb: FormBuilder) { }

    get fc() {
        return this.loginForm.controls;
    }

    //TODO: handle login request
    onSubmit() {
        if (this.loginForm.invalid) return;
        const { email, password } = this.loginForm.value;

        if (this.errorFormServer !== '') {
           
            this.loginForm.reset();
            this.loginForm.markAllAsTouched();
        }
    }
}
