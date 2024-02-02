import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared/shared.module';
import { AuthRoutingModule } from './auth-routing/auth-routing.module';
import { LoginComponent } from './login/login.component';
import { ReactiveFormsModule } from '@angular/forms';
import { CoreModule } from '../core/core.module';
import { RegisterComponent } from './register/register.component';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';
import { ResetPasswordComponent } from './reset-password/reset-password.component';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import {TranslateLoader, TranslateModule} from '@ngx-translate/core';
import {TranslateHttpLoader} from '@ngx-translate/http-loader';
import { AdminComponent } from './admin/admin.component';
import { AdminRequestPageComponent } from './admin-request-page/admin-request-page.component';
import { SpeditionReqTableComponent } from './spedition-req-table/spedition-req-table.component';
import { TransportReqTableComponent } from './transport-req-table/transport-req-table.component';


export function HttpLoaderFactory(http: HttpClient) {
    return new TranslateHttpLoader(http);
  }


@NgModule({
    declarations: [
        LoginComponent,
        RegisterComponent,
        ForgotPasswordComponent,
        ResetPasswordComponent,
        AdminComponent,
        AdminRequestPageComponent,
        SpeditionReqTableComponent,
        TransportReqTableComponent
    ],
    imports: [
        CommonModule,
        CoreModule,
        SharedModule,
        AuthRoutingModule,
        ReactiveFormsModule,
        TranslateModule.forChild({
            defaultLanguage: 'en', 
            loader: {
              provide: TranslateLoader,
              useFactory: HttpLoaderFactory,
              deps: [HttpClient]
            }
          })
    ],
})
export class AuthModule { }
