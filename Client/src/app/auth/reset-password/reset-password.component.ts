import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormGroupDirective, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { matchPasswordsValidator } from '../validators/matchPasswordsValidator';
import { AuthService } from '../auth.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Subscription } from 'rxjs';
import { TranslateService } from '@ngx-translate/core';


@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrl: './reset-password.component.css'
})
export class ResetPasswordComponent implements OnDestroy {
    resetPasswordForm: FormGroup;
    resetToken!: string; 
    errorFromServer: string = '';
    successMsgSubsc: Subscription = new Subscription();
    errorMsgSubsc: Subscription = new Subscription();


    constructor(private fb: FormBuilder, private authService: AuthService, private route: ActivatedRoute,private router: Router,private snackBar: MatSnackBar,private translate: TranslateService) {
      this.resetPasswordForm = this.fb.group({
        passwordGroup: this.fb.group({
          newPassword: ['', [Validators.required, Validators.minLength(5)]],
          confirmPassword: ['', Validators.required],
        }, {
          validators: [matchPasswordsValidator('newPassword', 'confirmPassword')],
        }),
      });
      
      this.route.queryParams.subscribe(params => {
        this.resetToken = this.decodeQueryParams(params[ 'token' ]);
      });
    }

    
    onSubmit(formDirevtive: FormGroupDirective): void {
      if(this.resetPasswordForm.invalid) {
        return
      }

      const newPassword = this.resetPasswordForm.get('passwordGroup.newPassword')?.value;
      const confirmPassword = this.resetPasswordForm.get('passwordGroup.confirmPassword')?.value;
    
      let successMsg: string = '';
      let errorMsg: string = '';
  
      this.successMsgSubsc = this.translate.get('reset.success-msg').subscribe(msg => successMsg = msg);
      this.errorMsgSubsc = this.translate.get('reset.error-msg').subscribe(msg => errorMsg = msg);
  
    
      this.authService.resetPassword(this.resetToken, newPassword,confirmPassword).subscribe(
        {
          next: (response) => {
            this.snackBar.open(successMsg, 'Ok', {
              horizontalPosition: 'center',
              verticalPosition: 'top',
              duration: 5000,
            });

            this.resetPasswordForm.reset();
            this.router.navigate([ '/home' ]);
          },
          error: (error) => {
            this.errorFromServer = errorMsg;
            
            this.snackBar.open(this.errorFromServer, 'Ok', {
              horizontalPosition: 'center',
              verticalPosition: 'top',
              duration: 5000,
            });
          }
        }
      );
      formDirevtive.resetForm();
      this.resetPasswordForm.reset();
    }

    private decodeQueryParams(paramsValue: string): string { 
      let decoded = decodeURIComponent(paramsValue)    
      let decodedWithPlus = decoded.replace(/\s/g, "+");
     
      return decodedWithPlus;
   }


    ngOnDestroy(): void {
      this.successMsgSubsc.unsubscribe();
      this.errorMsgSubsc.unsubscribe();
    }
}
