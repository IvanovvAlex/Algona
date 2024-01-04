// Module Imports
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared/shared.module';


// Component imports
import { NavBarComponent } from './core-components/nav-bar/nav-bar.component';
import { FooterComponent } from './core-components/footer/footer.component';



@NgModule({
  declarations: [
    NavBarComponent,
    FooterComponent,

  ],
  imports: [
    CommonModule,
    SharedModule
  ],
  exports: [
      NavBarComponent,
      FooterComponent
  ]
})
export class CoreModule { }
