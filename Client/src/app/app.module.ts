import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './material.module';
import { ForUsComponent } from './for-us/for-us.component';

import { HttpClientModule } from  '@angular/common/http';
import { HeroComponent } from './hero/hero.component';

@NgModule({
    declarations: [
        AppComponent,
        NavBarComponent,
        ForUsComponent,
        HeroComponent
    ],
    imports: [
        BrowserModule,
        AppRoutingModule,
        BrowserAnimationsModule,
        MaterialModule,
        HttpClientModule
    ],
    providers: [],
    bootstrap: [ AppComponent ]
})
export class AppModule { }