import { Component } from '@angular/core';
import { ApiService } from 'src/app/core/core-services/api-service/api.service';
import { FormBuilder, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';


@Component({
  selector: 'app-contact-form',
  templateUrl: './contact-form.component.html',
  styleUrls: ['./contact-form.component.css']
})
export class ContactFormComponent {
  response: Object | undefined;
  error: boolean | undefined;


  contactForm = this.fb.group({
    name: ['', [Validators.required]],
    email: ['', [Validators.required]],
    data: ['', [Validators.required]]
  }
  )

  sendData() {
    if (this.contactForm.invalid) {
      return
    }

    const { name, email, data } = this.contactForm.value;

    const contactFormData = {
      name: name as string,
      email: email as string,
      data: data as string
    }

    this.apiService.sendData(contactFormData).subscribe(
      {
        next: (response) => {
          if (response.status !== 200) {
            this.popUp(`Error ${response.status}: ${response.statusText}`)
          } else {
            this.popUp('Succes - Your message has been sent to us!')
          }
        },
        error: (error) => {
          this.popUp(`Error ${error.status}: ${error.statusText}`)
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
