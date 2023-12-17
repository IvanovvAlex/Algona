import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { ActivatedRoute } from '@angular/router';
import { ApiService } from 'src/app/core/core-services/api-service/api.service';
import { JobDetails } from 'src/app/shared/typization/interfaces/jobDetails';


//TODO: Remove this array; Use only for demo/testing purposes
export const jobs: JobDetails[] = [
  {
      id: 't6t7tuvhghy78y7ftu',
      title: 'Truck driver',
      description: 'Our company is seeking a dedicated and experienced international driver to join our team. As an international driver, you will be responsible for transporting goods and materials across different countries and ensuring timely and safe deliveries.',
      responsibilities: ['Safely operate and maneuver various types of commercial vehicles for international transportation',
        'Transport goods and materials to different destinations across borders',
        'Adhere strictly to traffic laws, regulations, and company policies',
        'Maintain vehicle cleanliness, perform routine inspections, and report any issues or malfunctions',
        'Ensure accurate documentation and timely completion of delivery schedules',
        'Communicate effectively with dispatchers and logistics teams'],
      requirements: ['Valid commercial driver`s license (CDL) with a clean driving record',
      'Proven experience as an international driver or similar role',
      'Knowledge of international driving regulations and customs procedures',
      'Ability to handle long-distance travel and work flexible hours',
      'Excellent communication skills and proficiency in English',
      'Strong attention to detail and commitment to safety protocols',
      'Physical capability to load and unload goods when required'],
      benefits: ['Competitive salary based on experience',
        'Health and retirement benefits',
        'Opportunities for career growth and professional development',
        'Well-maintained and modern fleet of vehicles',
        'Supportive work environment and teamwork-oriented culture'],
      deadline: '31.12.2023'
  },
  {
      id: 't6t7tuvhg99sgy7ftu',
      title: 'Transportation Dispatcher',
      description: 'Our company is currently seeking a skilled and detail-oriented Transportation Dispatcher to join our team. As a Transportation Dispatcher, you will play a crucial role in coordinating and managing the logistics of transportation operations.',
      responsibilities: ['Coordinate and schedule transportation services for efficient delivery of goods and materials',
       'Communicate effectively with drivers, customers, and suppliers to ensure timely pickups and deliveries',
        'Monitor and track shipments, resolving any issues or discrepancies that may arise',
        'Maintain accurate records of transportation activities, including schedules, routes, and delivery confirmations',
        'Collaborate with the logistics team to optimize transportation routes and improve overall efficiency',
        'Respond promptly to any changes in transportation plans or emergencies to minimize disruptions'],
      requirements: ['Proven experience as a Transportation Dispatcher or in a similar role within the logistics industry',
        'Strong organizational and multitasking skills with the ability to prioritize tasks effectively',
        'Excellent communication skills, both verbal and written',
        'Proficiency in using transportation management systems (TMS) and GPS tracking software',
        'Knowledge of transportation regulations, routes, and geographical areas',
        'Ability to work under pressure in a fast-paced environment and adapt to changing situations',
        'Attention to detail and problem-solving skills'],
      benefits: ['Competitive salary based on experience and qualifications',
        'Health insurance and retirement benefits',
        'Opportunities for career growth and professional development',
        'Collaborative and dynamic work environment'],
      deadline: '31.12.2023'
  },
]



@Component({
  selector: 'app-job-details',
  templateUrl: './job-details.component.html',
  styleUrl: './job-details.component.css'
})
export class JobDetailsComponent implements OnInit, OnDestroy {
//TODO: Remove this array; Use only for demo/testing purposes
dummyJobs: JobDetails[] = jobs;
  
job: JobDetails | undefined;
subscription: Subscription = new Subscription();

constructor (private apiService: ApiService, private router: ActivatedRoute) {}

ngOnInit(): void {
    this.router.params.subscribe(params => {
      const jobId = params['id'];


      this.subscription = this.apiService.getJobById(jobId).subscribe({
        next: data => {
        this.job = data;
      },
      error: err => {
        //TODO: Remove this array; Uncomment line below
        this.job = this.dummyJobs.find(job => job.id === jobId);
        //this.router.navigate([ '/404' ]);
      }
    })  
    })  
}

ngOnDestroy(): void {
  this.subscription.unsubscribe();
}
}
