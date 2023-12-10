import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from './material/material.module';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { GoogleMapsModule } from '@angular/google-maps'


@NgModule({
  declarations: [
  ],
  imports: [
    CommonModule,
    MaterialModule,
    GoogleMapsModule,
  ],
  exports: [
    MaterialModule,
    ReactiveFormsModule,
    RouterModule,
    GoogleMapsModule
  ]
})
export class SharedModule { }
