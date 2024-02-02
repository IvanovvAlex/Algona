import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from './material/material.module';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { GoogleMapsModule } from '@angular/google-maps'
import { PaginatorComponent } from '../components-WIP-folder/paginator/paginator.component';


@NgModule({
  declarations: [
    PaginatorComponent
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
    GoogleMapsModule,
    PaginatorComponent
  ]
})
export class SharedModule { }
