import { Component, OnDestroy } from '@angular/core';
import { FormBuilder, FormGroup, FormGroupDirective, Validators } from '@angular/forms';
import { AuthService } from '../auth.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Subscription } from 'rxjs';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrl: './forgot-password.component.css'
})
export class ForgotPasswordComponent implements OnDestroy {

  forgotPasswordForm!: FormGroup;
  errorFromServer: string = '';
  successMsgSubsc: Subscription = new Subscription();
  errorMsgSubsc: Subscription = new Subscription();

  constructor(private fb: FormBuilder, private authService: AuthService,private snackBar: MatSnackBar, private translate: TranslateService) {

    this.forgotPasswordForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]]
    }) 
  }

  onSubmit(formDirevtive: FormGroupDirective):void {

    if(this.forgotPasswordForm.invalid) {
      return
    }

    const email = this.forgotPasswordForm.value.email;
    
    let successMsg: string = '';
    let errorMsg: string = '';
debugger
    this.successMsgSubsc = this.translate.get('forgot.success-msg').subscribe(msg => successMsg = msg);
    this.errorMsgSubsc = this.translate.get('forgot.error-msg').subscribe(msg => errorMsg = msg);

    this.authService.sendForgotPasswordEmail(email).subscribe(
    
      {
        next: (response) => {
          this.snackBar.open(successMsg, 'Ok', {
            horizontalPosition: 'center',
            verticalPosition: 'top',
            duration: 5000,
          });
          
        },
        error: (error) => {
          if(error.status == 404) {
            this.errorFromServer = error.error.message;
          } else {
          this.errorFromServer = errorMsg;
          }
          
          this.snackBar.open(this.errorFromServer, 'Ok', {
            horizontalPosition: 'center',
            verticalPosition: 'top',
            duration: 5000,
          });
          
          }
        
      }  
  );

    formDirevtive.resetForm();
    this.forgotPasswordForm.reset();
  }

  ngOnDestroy(): void {
    this.successMsgSubsc.unsubscribe();
    this.errorMsgSubsc.unsubscribe();
  }
}
