import {Component, OnInit} from '@angular/core';

import {
  FormGroup,
  FormBuilder,
  Validators,
  FormGroupDirective,
} from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { ApiService } from 'src/app/core/core-services/api-service/api.service';

@Component({
  selector: 'app-spedition-request',
  templateUrl: './spedition-request.component.html',
  styleUrls: ['./spedition-request.component.css'],
 // standalone: true,
 // imports: [CommonModule,MatFormFieldModule, MatInputModule, MatSelectModule,MatDatepickerModule, MatNativeDateModule, ReactiveFormsModule],
})
export class SpeditionRequestComponent implements OnInit {

  
  speditionForm!: FormGroup;
  errorFormServer: { errors: { [key: string]: string } } = { errors: {} };
  errorMessage:string = '';
 

  constructor(private formBuilder: FormBuilder, private apiService: ApiService, private snackBar: MatSnackBar, private router: Router) { }
 
  
  ngOnInit(): void {
    this.speditionForm = this.formBuilder.group({
      fromAddress: ['', {validators: Validators.required, updateOn: 'blur'}],
      toAddress: ['', {validators: Validators.required, updateOn: "blur"}],
      fromDate: ['', {validators: Validators.required, updateOn: "blur"}],
      toDate: ['', {validators: Validators.required, updateOn: "blur"}],
      numberOfPallets: ['', {validators: Validators.required, updateOn: "blur"}],
      totalWeight: ['', {validators: Validators.required, updateOn: "blur"}],
      name: ['', {validators: Validators.required, updateOn: "blur"}],
      phoneNumber: ['', {validators: Validators.required, updateOn: "blur"}],
      email: ['', {validators: [Validators.required, Validators.email], updateOn: 'blur'}],

    })
  }

  sendSpeditionData(formDirevtive: FormGroupDirective) {

    if(this.speditionForm.invalid) {
      return
    }

    const {fromAddress,toAddress, fromDate, toDate, numberOfPallets,totalWeight, name, phoneNumber, email} = this.speditionForm.value;

    formDirevtive.resetForm();
    this.speditionForm.reset;
    
    
    const speditionData = {
      fromAddress: fromAddress as string,
      toAddress: toAddress as string,
      fromDate: fromDate as string,
      toDate: toDate as string,
      numberOfPallets: numberOfPallets as number,
      totalWeight: totalWeight as number,
      name: name as string,
      phoneNumber: phoneNumber as string,
      email: email as string
    }

    this.apiService.sendSpeditionRequest(speditionData).subscribe(
      {
        next: (response) => {

          if (response.status !== 200) {
             this.popUp(`Error ${response.status}: ${response.statusText}`)
          } else {
             this.popUp('Success - Your request for transport has been sent to us!')
          }
        },
        error: (error) => {
          
          if(error.status !== 200 && error.error.errors) {

            this.errorFormServer = error.error.errors;
            
            this.errorMessage =  Object.entries(this.errorFormServer)
              .map(([key, value]) => `${key}: ${value}`)
              .join('\n');
          this.snackBar.open(this.errorMessage, 'Ok', {
            horizontalPosition: 'center',
            verticalPosition: 'top',
            duration: 5000,
          });
          
          }
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
  
}
