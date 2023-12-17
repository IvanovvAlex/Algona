import { Component, OnInit } from '@angular/core';

declare let AOS: any;

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: [ './app.component.css' ]
})
export class AppComponent implements OnInit {
    title = 'Client';

    ngOnInit(): void {
        AOS.init();
    }
}
