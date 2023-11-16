import {Component, OnInit} from '@angular/core';
import {CommonModule} from '@angular/common';
import {MatSelectModule} from '@angular/material/select';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatNativeDateModule} from '@angular/material/core';
import {
  FormGroup,
  FormBuilder,
  Validators,
  ReactiveFormsModule,
  FormGroupDirective,
} from '@angular/forms';



@Component({
  selector: 'app-transport-request',
  templateUrl: './transport-request.component.html',
  styleUrls: ['./transport-request.component.css'],
  standalone: true,
  imports: [CommonModule,MatFormFieldModule, MatInputModule, MatSelectModule,MatDatepickerModule, MatNativeDateModule, ReactiveFormsModule],
})
export class TransportRequestComponent implements OnInit  {
   
  transportForm!: FormGroup;
 

  constructor(private formBuilder: FormBuilder) { }
 
  
  ngOnInit(): void {
    this.transportForm = this.formBuilder.group({
      fromPlace: ['', {validators: Validators.required, updateOn: 'blur'}],
      toPlace: ['', {validators: Validators.required, updateOn: "blur"}],
      fromDate: ['', {validators: Validators.required, updateOn: "blur"}],
      toDate: ['', {validators: Validators.required, updateOn: "blur"}],
      pallets: ['', {validators: Validators.required, updateOn: "blur"}],
      weight: ['', {validators: Validators.required, updateOn: "blur"}],
      name: ['', {validators: Validators.required, updateOn: "blur"}],
      phone: ['', {validators: Validators.required, updateOn: "blur"}],
      email: ['', {validators: [Validators.required, Validators.email], updateOn: 'blur'}],

    })
  }

  sendTransportData(formDirevtive: FormGroupDirective) {

    if(this.transportForm.invalid) {
      return
    }

    const {fromPlace,toPlace, fromDate, toDate, pallets,weight, name, phone, email} = this.transportForm.value;

    formDirevtive.resetForm();
    this.transportForm.reset;
    
    
    const transportData = {
      fromPlace: fromPlace as string,
      toPlace: toPlace as string,
      fromDate: fromDate as string,
      toDate: toDate as string,
      pallets: pallets as number,
      weight: weight as number,
      name: name as string,
      phone: phone as string,
      email: email as string
    }

    console.log(transportData)
  }

}
