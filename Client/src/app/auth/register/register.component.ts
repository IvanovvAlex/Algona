import { Component } from '@angular/core';
import { animate, state, style, transition, trigger } from '@angular/animations';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';

import { matchPasswordsValidator } from '../validators/matchPasswordsValidator';
import { Router } from '@angular/router';
import { AuthService } from '../auth.service';

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
export class RegisterComponent {
  errorFormServer: string = '';

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
    private snackBar: MatSnackBar
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

  //TODO: handle register request
  onSubmit() {
    if (this.registerForm.invalid) return;

    const { firstName, lastName, email, passGroup } = this.registerForm.value;
    const bodyValues: { [key: string]: string } = {
      firstName: firstName!,
      lastName: lastName!,
      email: email!,
      password: passGroup!.password!,
      confirmPassword: passGroup!.rePassword!,
    };

    this.authService.register(bodyValues).subscribe({
      next: (response) => {
        if (response.status !== 201) {
          this.errorFormServer = `Error ${response.status}: ${response.statusText}`;
        } else {
          this.router.navigate(['/']);
          this.snackBar.open('Succesfully logged in!', 'Close', {
            duration: 3000,
          });
        }
      },
      error: (error) => {
        this.errorFormServer = `Error ${error.status}: ${error.statusText}`;
      },
    });

    if (this.errorFormServer !== '') {
      this.snackBar.open(this.errorFormServer, 'Close', {
        duration: 5000,
      });

      this.registerForm.reset();
      this.registerForm.markAllAsTouched();
    }
  }
}
