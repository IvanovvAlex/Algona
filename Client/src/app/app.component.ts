import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

declare let AOS: any;

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
    title = 'Client';

    constructor(private router: Router) {

    }

    hasRoute() {

        if (this.router.url.match('^[\/{1}]$')) {
            return true
        } else if (this.router.url.includes('/home')) {
            return true
        }
        //  else if (this.router.url.includes('/404')) {
        //     return true
        // } 
        else {
            return false
        }


    }

    ngOnInit(): void {
        AOS.init();
    }
}
