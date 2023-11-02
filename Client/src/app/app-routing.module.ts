import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HeroComponent } from './components-WIP-folder/hero/hero.component';
import { ForUsComponent } from './components-WIP-folder/for-us/for-us.component';
import { ContactFormComponent } from './components-WIP-folder/contact-form/contact-form.component';
import { NotFoundComponent } from './components-WIP-folder/not-found/not-found.component';


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
        path: 'vehicles', component: NotFoundComponent,
    },
    {
        path: 'orders', component: NotFoundComponent,
    },
    {
        path: 'request', component: NotFoundComponent,
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
