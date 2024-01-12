import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { animate, style, transition, trigger } from '@angular/animations';
import { Subscription } from 'rxjs';

import { ApiService } from 'src/app/core/core-services/api-service/api.service';
import { Job } from 'src/app/shared/typization/interfaces';

@Component({
  selector: 'app-jobs',
  templateUrl: './jobs.component.html',
  styleUrls: ['./jobs.component.css'],
  animations: [
    trigger('fade', [
      transition('void => *', [style({ opacity: 0 }), animate(1200)]),
    ]),
  ],
})
export class JobsComponent implements OnInit, OnDestroy {
  jobs!: Job[];
  subscription: Subscription = new Subscription();

  constructor(private apiService: ApiService, private router: Router) {}

  ngOnInit(): void {
    this.subscription = this.apiService.getAvailableJobs().subscribe({
      next: (data) => {
        this.jobs = data;
      },
      error: (err) => {
        this.router.navigate(['/404']);
      },
    });
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }
}
