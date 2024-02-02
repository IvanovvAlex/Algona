// Module imports
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import {TranslateLoader, TranslateModule} from '@ngx-translate/core';
import {TranslateHttpLoader} from '@ngx-translate/http-loader';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CoreModule } from './core/core.module';
import { SharedModule } from './shared/shared.module';
import { ReactiveFormsModule } from "@angular/forms";
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { NgOptimizedImage } from '@angular/common';

// Component imports
import { AppComponent } from './app.component';
import { ForUsComponent } from './components-WIP-folder/for-us/for-us.component';
import { HeroComponent } from './components-WIP-folder/hero/hero.component';
import { NotFoundComponent } from './components-WIP-folder/not-found/not-found.component';
import { GarageComponent } from './components-WIP-folder/garage/garage.component';
import { SpeditionRequestComponent } from './components-WIP-folder/spedition-request/spedition-request.component';
import { TransportRequestComponent } from './components-WIP-folder/transport-request/transport-request.component';
import { JobsComponent } from './components-WIP-folder/jobs/jobs.component';
import { JobDetailsComponent } from './components-WIP-folder/job-details/job-details.component';

//Providers
import { apiInterceptorProvider } from './interceptors/api.interceptor';



export function HttpLoaderFactory(http: HttpClient) {
    return new TranslateHttpLoader(http);
  }


@NgModule({
  declarations: [
    AppComponent,
    ForUsComponent,
    HeroComponent,
    NotFoundComponent,
    GarageComponent,
    TransportRequestComponent,
    SpeditionRequestComponent,
    JobsComponent,
    JobDetailsComponent,

  ],
  imports: [
    CoreModule,
    SharedModule,
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    TranslateModule.forRoot({
      defaultLanguage: 'en',
      loader: {
        provide: TranslateLoader,
        useFactory: HttpLoaderFactory,
        deps: [HttpClient],
      },
    }),
    NgOptimizedImage,
  ],
  providers: [ apiInterceptorProvider ],
  bootstrap: [AppComponent],
})
export class AppModule {}