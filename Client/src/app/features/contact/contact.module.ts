import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ContactFormComponent } from './contact-form/contact-form.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { MapComponent } from './map/map.component';
import { ContactContainerComponent } from './contact-container/contact-container.component';
import { ContactRoutingModule } from './contact-routing.module';



@NgModule({
  declarations: [
    ContactFormComponent,
    MapComponent,
    ContactContainerComponent,
  ],
  imports: [
    CommonModule,
    SharedModule,
    ContactRoutingModule,
  ]
})
export class ContactModule { }

