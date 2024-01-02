import { Component, OnDestroy, OnInit } from '@angular/core';
import { animate, style, transition, trigger } from '@angular/animations';
import { Subscription, fromEvent } from 'rxjs';

import { photos } from './garage-photos';

@Component({
    selector: 'app-garage',
    templateUrl: './garage.component.html',
    styleUrls: ['./garage.component.css'],
    animations: [
        trigger('fade', [
            transition('void => *', [
                style({ opacity: 0 }),
                animate(1200)])
        ]),
    ]
})
export class GarageComponent implements OnInit, OnDestroy {
    isVisible = false;
    topPosToStartShowing = 50;
    currentPage = 1;
    totalPages?: number;
    paginatedArray?: any[];

    eventSubscription: Subscription = fromEvent(window, 'scroll').subscribe(e => {
        this.checkScroll();
    });

    photos!: string[];

    constructor() { }

    ngOnInit(): void {
        this.photos = photos;
        this.totalPages = this.photos.length / 12
        this.paginatedArray = this.photos.slice(0, 12);
    }

    checkScroll() {
        const scrollPosition = window.scrollY || 0;

        if (scrollPosition >= this.topPosToStartShowing) {
            this.isVisible = true;
        } else {
            this.isVisible = false;
        }
    }

    gotoTop() {
        window.scroll({ top: 0, left: 0, behavior: 'smooth' });
    }

    ngOnDestroy(): void {
        this.eventSubscription.unsubscribe();
    }

    onPageChanged(page: number): void {
        this.currentPage = page;
        if (page === 1) {
            if (this.photos) {
                this.paginatedArray = this.photos?.slice(0, 12);
            }
        } else {
            let startIndex = 12 * (page - 1)
            let endIndex = startIndex + 12
            if (this.photos) {
                this.paginatedArray = this.photos?.slice(startIndex, endIndex);
            }
        }


    }

}
