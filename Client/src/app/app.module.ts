// Module imports
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CoreModule } from './core/core.module';
import { SharedModule } from './shared/shared.module';
import { AuthModule } from './auth/auth.module';
import { ReactiveFormsModule } from "@angular/forms";

// Component imports
import { AppComponent } from './app.component';
import { ForUsComponent } from './components-WIP-folder/for-us/for-us.component';
import { HeroComponent } from './components-WIP-folder/hero/hero.component';

import { NotFoundComponent } from './components-WIP-folder/not-found/not-found.component';
import { GarageComponent } from './components-WIP-folder/garage/garage.component';
import { SpeditionRequestComponent } from './components-WIP-folder/spedition-request/spedition-request.component';
import { TransportRequestComponent } from './components-WIP-folder/transport-request/transport-request.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { JobsComponent } from './components-WIP-folder/jobs/jobs.component';
import { JobDetailsComponent } from './components-WIP-folder/job-details/job-details.component';
import { PaginatorComponent } from './components-WIP-folder/paginator/paginator.component';


@NgModule({
    declarations: [
        AppComponent,
        ForUsComponent,
        HeroComponent,
        NotFoundComponent,
        GarageComponent,
        JobsComponent,
        JobDetailsComponent,
        PaginatorComponent
        
    ],
    imports: [
        CoreModule,
        SharedModule,
        BrowserModule,
        AppRoutingModule,
        BrowserAnimationsModule,
        HttpClientModule,
        TransportRequestComponent,
        SpeditionRequestComponent,
        ReactiveFormsModule,
        MatFormFieldModule,
        MatInputModule,
    ],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule { }