// Module imports
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule } from  '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CoreModule } from './core/core.module';
import { SharedModule } from './shared/shared.module';
import { AuthModule } from './auth/auth.module';

// Component imports
import { AppComponent } from './app.component';
import { ForUsComponent } from './components-WIP-folder/for-us/for-us.component';
import { HeroComponent } from './components-WIP-folder/hero/hero.component';
import { ContactFormComponent } from './components-WIP-folder/contact-form/contact-form.component';
import { NotFoundComponent } from './components-WIP-folder/not-found/not-found.component';
import { GarageComponent } from './components-WIP-folder/garage/garage.component';

@NgModule({
    declarations: [
        AppComponent,
        ForUsComponent,
        HeroComponent,
        ContactFormComponent,
        NotFoundComponent,
        GarageComponent
    ],
    imports: [
        AuthModule,
        CoreModule,
        SharedModule,
        BrowserModule,
        AppRoutingModule,
        BrowserAnimationsModule,
        HttpClientModule
    ],
    providers: [],
    bootstrap: [ AppComponent ]
})
export class AppModule { }