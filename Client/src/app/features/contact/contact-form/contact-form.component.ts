import { Component } from '@angular/core';
import { ApiService } from 'src/app/core/core-services/api-service/api.service';
import { FormBuilder, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { emailVdtr } from 'src/app/auth/validators/emailValidator';

  @Component({
    selector: 'app-contact-form',
    templateUrl: './contact-form.component.html',
    styleUrls: ['./contact-form.component.css']
  })
  export class ContactFormComponent {
    response: Object | undefined;
    error: boolean | undefined;


    contactForm = this.fb.group({
      name: ['', [Validators.required, Validators.minLength(2)]],
      companyName: ['', [Validators.required, Validators.minLength(2)]],
      email: ['', [Validators.required, emailVdtr()]],
      phone: ['', [Validators.required, Validators.minLength(10)]],
      data: ['', [Validators.required, Validators.minLength(10)]]
    }
    )

    sendData() {
      if (this.contactForm.invalid) {
        return
      }

      const { name, companyName, email, phone, data } = this.contactForm.value;

      const contactFormData = {
        name: name as string,
        companyName: companyName as string,
        email: email as string,
        phone: phone as string,
        description: data as string
      }

      this.apiService.sendContactData(contactFormData).subscribe(
        {
          next: (response) => {
            if (response.status !== 201) {
              this.popUp(`Error ${response.status}: ${response.type}`)
            } else {
              this.popUp('Succes - Your message has been sent to us!')
            }
          },
          error: (error) => {
            this.popUp(`Error ${error.status}: ${error.statusText}`)
            
            this.contactForm.reset();
            // this.contactForm.markAllAsTouched();
            
            // this.popUp('Succes - Your message has been sent to us!')
            // ^^ to test visuals until a working API response is present
          }
        }

      )

    }

    popUp(message: string): void {
      this.snackBar.open(message, 'Close', {
        duration: 3000,
        horizontalPosition: 'center',
        verticalPosition: 'top',
      })
    }

    constructor(private fb: FormBuilder, private apiService: ApiService, private snackBar: MatSnackBar) {

    }

  }

