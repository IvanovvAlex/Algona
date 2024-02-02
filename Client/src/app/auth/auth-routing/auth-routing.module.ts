import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';

import { LoginComponent } from '../login/login.component';
import { RegisterComponent } from '../register/register.component';
import { ForgotPasswordComponent } from '../forgot-password/forgot-password.component';
import { ResetPasswordComponent } from '../reset-password/reset-password.component';
import { AdminComponent } from '../admin/admin.component';
import { AdminGuard } from '../auth.guard';


const routes: Routes = [
    {
        path: 'login', component: LoginComponent
    },
    {
        path: 'register', component: RegisterComponent
    },
    {
        path: 'forgottenPassword', component: ForgotPasswordComponent
    },
    {
        path: 'resetPassword', component: ResetPasswordComponent 
    },
    {
        path: 'admin', component: AdminComponent, canActivate: [AdminGuard] 
    },
    {
        path: 'admin-tables', component: AdminComponent, canActivate: [AdminGuard] 
    }


];

@NgModule({
    declarations: [],
    imports: [
        CommonModule,
        RouterModule.forChild(routes)
    ],
    exports: [
        RouterModule
    ]
})
export class AuthRoutingModule { }
