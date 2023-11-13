import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription, fromEvent } from 'rxjs';

import { ApiService } from 'src/app/core/core-services/api-service/api.service';

@Component({
  selector: 'app-garage',
  templateUrl: './garage.component.html',
  styleUrls: ['./garage.component.css']
})
export class GarageComponent implements OnInit, OnDestroy {
    isVisible = false;
    topPosToStartShowing = 50;

    eventSubscription = fromEvent(window, 'scroll').subscribe(e => {
        this.checkScroll();
    });

    photos: any = null;
    subscription: Subscription = new Subscription();

    constructor(private apiService: ApiService) { }
    
    ngOnInit(): void {
        this.subscription = this.apiService.getGaragePhotos().subscribe({
            next: data => {
                this.photos = data;
            },
            error: err => console.warn(err.message)
        });
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
        this.subscription.unsubscribe();
        this.eventSubscription.unsubscribe();
    }
}
