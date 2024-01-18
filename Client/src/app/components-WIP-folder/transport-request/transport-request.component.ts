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
  selector: 'app-transport-request',
  templateUrl: './transport-request.component.html',
  styleUrls: ['./transport-request.component.css'],
  //standalone: true,
  //imports: [CommonModule,MatFormFieldModule, MatInputModule, MatSelectModule,MatDatepickerModule, MatNativeDateModule, ReactiveFormsModule],
})
export class TransportRequestComponent implements OnInit  {
   
  transportForm!: FormGroup;
  errorFormServer: { errors: { [key: string]: string } } = { errors: {} };
  errorMessage:string = '';
 

  constructor(private formBuilder: FormBuilder, private apiService: ApiService, private snackBar: MatSnackBar, private router: Router) { }
 
  
  ngOnInit(): void {
    this.transportForm = this.formBuilder.group({
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

  sendTransportData(formDirevtive: FormGroupDirective) {

    if(this.transportForm.invalid) {
      return
    }

    const {fromAddress,toAddress, fromDate, toDate, numberOfPallets,totalWeight, name, phoneNumber, email} = this.transportForm.value;

    formDirevtive.resetForm();
    this.transportForm.reset;
    
    
    const transportData = {
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

    console.log(transportData)

    this.apiService.sendTransportRequest(transportData).subscribe(
      {
        next: (response) => {
        
          if (response.status !== 200) {
             this.popUp(`Error ${response.status}: ${response.statusText}`)
          } else {
             this.popUp('Succes - Your request for transport has been sent to us!')
          }
        },
        error: (error) => {
          if(error.status !== 200 && error.error.errors) {

            this.errorFormServer = error.error.errors;
            console.log(this.errorFormServer)

            
            this.errorMessage =  Object.entries(this.errorFormServer)
              .map(([key, value]) => `${key}: ${value}`)
              .join('\n');
          this.snackBar.open(this.errorMessage, 'Ok', {
            horizontalPosition: 'center',
            verticalPosition: 'top',
            // duration: 5000,
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
