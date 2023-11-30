import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HeroComponent } from './components-WIP-folder/hero/hero.component';
import { ForUsComponent } from './components-WIP-folder/for-us/for-us.component';
import { ContactFormComponent } from './components-WIP-folder/contact-form/contact-form.component';
import { NotFoundComponent } from './components-WIP-folder/not-found/not-found.component';
import { GarageComponent } from './components-WIP-folder/garage/garage.component';
import { SpeditionRequestComponent } from './components-WIP-folder/spedition-request/spedition-request.component';
import { TransportRequestComponent } from './components-WIP-folder/transport-request/transport-request.component';
import { JobsComponent } from './components-WIP-folder/jobs/jobs.component';


const routes: Routes = [
    {
        path: '', component: HeroComponent,
    },
    {
        path: 'home', component: HeroComponent,
    },
    {
        path: 'about', component: ForUsComponent,
    },
    {
        path: 'services',
        children: [
            {
                path: 'spedition', component: NotFoundComponent
            },
            {
                path: 'international-transport', component: NotFoundComponent,
            }
        ]

    },
    {
        path: 'vehicles', component: GarageComponent,
    },
    {
        path: 'orders', component: NotFoundComponent,
    },
    {
        path: 'request',
        children: [
            {
                path: 'spedition', component: SpeditionRequestComponent
            },
            {
                path: 'transport', component: TransportRequestComponent,
            }
        ]

    },
    {
        path: 'auth',
        loadChildren: () => import('./auth/auth.module').then(m => m.AuthModule),
    },
    {
        path: 'jobs', component: JobsComponent,
    },
    {
        path: 'contact', component: ContactFormComponent,
    },
    {
        path: '404', component: NotFoundComponent
    },
    {
        path: '**', redirectTo: '/404'
    }
];

@NgModule({
    imports: [ RouterModule.forRoot(routes) ],
    exports: [ RouterModule ]
})
export class AppRoutingModule { }
