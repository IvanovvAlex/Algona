// Module Imports
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared/shared.module';


// Component imports
import { NavBarComponent } from './core-components/nav-bar/nav-bar.component';



@NgModule({
  declarations: [
    NavBarComponent,

  ],
  imports: [
    CommonModule,
    SharedModule
  ],
  exports: [
    NavBarComponent,
  ]
})
export class CoreModule { }
