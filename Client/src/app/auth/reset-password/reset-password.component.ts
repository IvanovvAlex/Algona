import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormGroupDirective, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { matchPasswordsValidator } from '../validators/matchPasswordsValidator';

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrl: './reset-password.component.css'
})
export class ResetPasswordComponent {
    resetPasswordForm: FormGroup;
    token!: string; //tempoprary email token


    constructor(private fb: FormBuilder, private route: ActivatedRoute) {
      this.resetPasswordForm = this.fb.group({
        newPassword: ['', [Validators.required, Validators.minLength(6)]],
        confirmPassword: ['', Validators.required]
      }, {
        validators: [ matchPasswordsValidator('newPassword', 'confirmPassword')]
        
      });

      //Extract the temporary token from the URL parameters
      this.route.queryParams.subscribe(params => {
        this.token = params['token'];
      });
    }


    onSubmit(formDirevtive: FormGroupDirective): void {
      if(this.resetPasswordForm.invalid) {
        return
      }

      const newPassword = this.resetPasswordForm.value.newPassword;
      // TODO: handle reset-password request

      formDirevtive.resetForm();
      this.resetPasswordForm.reset();
  

    }
}
