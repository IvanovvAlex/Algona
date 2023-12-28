import { Component } from '@angular/core';
import { FormBuilder, FormGroup, FormGroupDirective, Validators } from '@angular/forms';

@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrl: './forgot-password.component.css'
})
export class ForgotPasswordComponent {

  forgotPasswordForm!: FormGroup;

  constructor(private fb: FormBuilder) {

    this.forgotPasswordForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]]
    }) 
  }

  onSubmit(formDirevtive: FormGroupDirective):void {

    if(this.forgotPasswordForm.invalid) {
      return
    }

    const email = this.forgotPasswordForm.value.email;
    //TODO: handle forgot-password request

    formDirevtive.resetForm();
    this.forgotPasswordForm.reset();
    
  }

  
}
