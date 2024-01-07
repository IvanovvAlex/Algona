import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared/shared.module';
import { FeatureRoutingModule } from './feature-routing/feature-routing.module';




@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    SharedModule,
    FeatureRoutingModule,
  ],
  exports: [
    FeatureRoutingModule
  ]
})
export class FeaturesModule { }
