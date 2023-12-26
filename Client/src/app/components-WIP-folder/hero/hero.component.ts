import { Component } from '@angular/core';
import { animate, style, transition, trigger } from '@angular/animations';

@Component({
    selector: 'app-hero',
    templateUrl: './hero.component.html',
    styleUrls: [ './hero.component.css' ],
    animations: [
        trigger('fade', [
            transition('void => *', [
                style({ opacity: 0 }),
                animate(1200) ])
        ]),
    ]
})
export class HeroComponent {

}
