import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';
import { animate, style, transition, trigger } from '@angular/animations';

import { ApiService } from 'src/app/core/core-services/api-service/api.service';
import { JobDetails } from 'src/app/shared/typization/interfaces/jobDetails';


@Component({
  selector: 'app-job-details',
  templateUrl: './job-details.component.html',
  styleUrl: './job-details.component.css',
  animations: [
    trigger('fade', [
      transition('void => *', [style({ opacity: 0 }), animate(1200)]),
    ]),
  ],
})
export class JobDetailsComponent implements OnInit, OnDestroy {
  job!: JobDetails;
  subscription: Subscription = new Subscription();

  constructor(
    private apiService: ApiService,
    private activatedRoute: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.activatedRoute.params.subscribe((params) => {
      const jobId = params['id'];

      this.subscription = this.apiService.getJobById(jobId).subscribe({
        next: (data) => {
          this.job = data;
        },
        error: (err) => {
          this.router.navigate(['/404']);
        },
      });
    });
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }
}
