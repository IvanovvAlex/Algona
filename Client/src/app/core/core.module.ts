// Module Imports
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared/shared.module';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';

// Component imports
import { NavBarComponent } from './core-components/nav-bar/nav-bar.component';
import { FooterComponent } from './core-components/footer/footer.component';

export function HttpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(http);
}

@NgModule({
  declarations: [
    NavBarComponent,
    FooterComponent,

  ],
  imports: [
    CommonModule,
    SharedModule,
    TranslateModule.forChild({
      defaultLanguage: 'en',
      loader: {
        provide: TranslateLoader,
        useFactory: HttpLoaderFactory,
        deps: [HttpClient]
      }
    })
  ],
  exports: [
    NavBarComponent,
    FooterComponent,

  ]
})
export class CoreModule { }
