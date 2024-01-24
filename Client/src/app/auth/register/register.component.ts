import { Component, OnDestroy } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { animate, state, style, transition, trigger } from '@angular/animations';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Subscription } from 'rxjs';
import { TranslateService } from '@ngx-translate/core';

import { AuthService } from '../auth.service';
import { RegisterUser, User } from 'src/app/shared/typization/interfaces';
import { matchPasswordsValidator } from '../validators/matchPasswordsValidator';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
  animations: [
    trigger('fade', [
      state('void', style({ opacity: 0 })),
      transition('void => *', [animate('0.6s 0.1s linear')]),
    ]),
  ],
})
export class RegisterComponent implements OnDestroy {
    errorFormServer: string = '';
    successMsgSubsc: Subscription = new Subscription();
    errorMsgSubsc: Subscription = new Subscription();
    registerSubsc: Subscription = new Subscription();

  registerForm = this.fb.group({
    firstName: [
      '',
      [Validators.required, Validators.minLength(2), Validators.maxLength(100)],
    ],
    lastName: [
      '',
      [Validators.required, Validators.minLength(2), Validators.maxLength(100)],
    ],
    email: ['', [Validators.required, Validators.email]],
    passGroup: this.fb.group(
      {
        password: ['', [Validators.required, Validators.minLength(5)]],
        rePassword: ['', [Validators.required]],
      },
      {
        validators: [matchPasswordsValidator('password', 'rePassword')],
      }
    ),
  });

  constructor(
    private router: Router,
    private authService: AuthService,
    private fb: FormBuilder,
    private snackBar: MatSnackBar,
    private translate: TranslateService
  ) {}

  get formControl() {
    return this.registerForm.controls;
  }

  get getPass(): FormControl {
    return this.registerForm.controls['passGroup'].get(
      'password'
    ) as FormControl;
  }

  get getRePass(): FormControl {
    return this.registerForm.controls['passGroup'].get(
      'rePassword'
    ) as FormControl;
  }

  hasErrors(controlName: string): boolean {
    return (
      this.registerForm.get(controlName)!.touched &&
      this.registerForm.get(controlName)!.invalid
    );
  }

  onSubmit() {
    if (this.registerForm.invalid) return;

    let successMsg: string = '';
    let errorMsg: string = '';

    this.successMsgSubsc = this.translate.get('register.success-message').subscribe(msg => successMsg = msg);
    this.errorMsgSubsc = this.translate.get('register.error-message').subscribe(msg => errorMsg = msg); 
      
    const { firstName, lastName, email, passGroup } = this.registerForm.value;
    const bodyValues: RegisterUser = {
        firstName: firstName!,
        lastName: lastName!,
        email: email!,
        password: passGroup!.password!,
        confirmPassword: passGroup!.rePassword!,
    };

    this.registerSubsc = this.authService.register$(bodyValues).subscribe({
      next: (response) => {
        localStorage.setItem('token', response.token);
        this.authService.currentUserSignal.set(response as User);

        this.snackBar.open(successMsg, ' X ', {
            duration: 5000,
        });
        this.router.navigate([ '/home' ]);
      },
        error: (response: HttpErrorResponse) => {
            if (response.status == 409) {
                this.errorFormServer = response.error.message;
            } else {
                this.errorFormServer = errorMsg;
            }

            this.snackBar.open(this.errorFormServer, ' X ', {
                duration: 5000,
            });

            this.registerForm.reset();
            this.registerForm.markAllAsTouched();
        },
    });
    }
    ngOnDestroy(): void {
        this.successMsgSubsc.unsubscribe();
        this.errorMsgSubsc.unsubscribe();
        this.registerSubsc.unsubscribe();
    }
}
