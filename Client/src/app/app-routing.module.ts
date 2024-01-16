import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HeroComponent } from './components-WIP-folder/hero/hero.component';
import { ForUsComponent } from './components-WIP-folder/for-us/for-us.component';
import { ContactFormComponent } from './features/contact/contact-form/contact-form.component';
import { NotFoundComponent } from './components-WIP-folder/not-found/not-found.component';
import { GarageComponent } from './components-WIP-folder/garage/garage.component';
import { SpeditionRequestComponent } from './components-WIP-folder/spedition-request/spedition-request.component';
import { TransportRequestComponent } from './components-WIP-folder/transport-request/transport-request.component';

import { ContactContainerComponent } from './features/contact/contact-container/contact-container.component';
import { JobsComponent } from './components-WIP-folder/jobs/jobs.component';
import { JobDetailsComponent } from './components-WIP-folder/job-details/job-details.component';




const routes: Routes = [
    {
        path: '', pathMatch:'full', redirectTo: 'home',
    },
    {
        path: 'home', component: HeroComponent,
    },
    {
        path: 'about', component: ForUsComponent,
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
        path: 'features',
        loadChildren: () => import('./features/features.module').then(m => m.FeaturesModule),
    },
    {
        path: 'jobs',
        children: [
            {
                path: '', pathMatch: 'full', component: JobsComponent,
            },
            {
                path: 'details/:id', component: JobDetailsComponent,
            },
            {
                path: 'apply/:id', component: NotFoundComponent
            },
        ]
    },
    {
        path: '404', component: NotFoundComponent
    },
    {
        path: '**', redirectTo: '/404'
    }
];

@NgModule({
    imports: [ RouterModule.forRoot(routes, { scrollPositionRestoration: 'enabled' }) ],
    exports: [ RouterModule ]
})
export class AppRoutingModule { }
