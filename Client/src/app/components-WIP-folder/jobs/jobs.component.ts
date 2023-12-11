import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';

import { ApiService } from 'src/app/core/core-services/api-service/api.service';
import { Job } from 'src/app/shared/typization/interfaces';

//TODO: Remove this array; Use only for demo/testing purposes
export const jobs: Job[] = [
    {
        id: 't6t7tuvhghy78y7ftu',
        title: 'Truck driver',
        location: 'Sofia, Bulgaria',
        fullTime: true,
        fixedSalary: true,
        bonuses: true,
        insurance: true,
        payedLeave: true,
        createdAt: new Date()
    },
    {
        id: 't6t7tuvhg99sgy7ftu',
        title: 'Transportation Dispatcher',
        location: 'Sofia, Bulgaria',
        fullTime: true,
        fixedSalary: true,
        bonuses: true,
        insurance: true,
        payedLeave: true,
        createdAt: new Date()
    },
]

@Component({
  selector: 'app-jobs',
  templateUrl: './jobs.component.html',
  styleUrls: ['./jobs.component.css']
})
export class JobsComponent implements OnInit, OnDestroy {
    //TODO: Remove this array; Use only for demo/testing purposes
    dummyJobs: Job[] = jobs;

    jobs!: Job[];
    subscription: Subscription = new Subscription();

    constructor(private apiService: ApiService, private router: Router) { }

    ngOnInit(): void {
        this.subscription = this.apiService.getAvailableJobs().subscribe({
            next: data => {
                this.jobs = data
            },
            error: err => {
                //TODO: Remove this array; Uncomment line below
                this.jobs = this.dummyJobs;
                //this.router.navigate([ '/404' ]);
            }
        });
    }

    ngOnDestroy(): void {
        this.subscription.unsubscribe();
    }
}
