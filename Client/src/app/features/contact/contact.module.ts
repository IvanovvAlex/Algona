import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ContactFormComponent } from './contact-form/contact-form.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { MapComponent } from './map/map.component';
import { ContactContainerComponent } from './contact-container/contact-container.component';
import { ContactRoutingModule } from './contact-routing.module';
import { CoreModule } from 'src/app/core/core.module';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import {TranslateLoader, TranslateModule} from '@ngx-translate/core';
import {TranslateHttpLoader} from '@ngx-translate/http-loader';

export function HttpLoaderFactory(http: HttpClient) {
    return new TranslateHttpLoader(http);
  }



@NgModule({
    declarations: [
        ContactFormComponent,
        MapComponent,
        ContactContainerComponent,
    ],
    imports: [
        CommonModule,
        SharedModule,
        CoreModule,
        ContactRoutingModule,
        TranslateModule.forChild({
            defaultLanguage: 'en', 
            loader: {
              provide: TranslateLoader,
              useFactory: HttpLoaderFactory,
              deps: [HttpClient]
            }
          })
    ]
})
export class ContactModule { }

