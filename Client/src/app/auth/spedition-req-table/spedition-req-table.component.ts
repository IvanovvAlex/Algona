import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { ApiService } from 'src/app/core/core-services/api-service/api.service';
import { SpeditionFormDataWithId } from 'src/app/shared/typization/interfaces/speditionFormData';


@Component({
  selector: 'app-spedition-req-table',
  templateUrl: './spedition-req-table.component.html',
  styleUrl: './spedition-req-table.component.css'
})
export class SpeditionReqTableComponent implements OnInit, OnDestroy{

  showEmail: boolean;
  showPallets: boolean;
  showDate: boolean;

  speditionRequests!:SpeditionFormDataWithId[]
  sortedArray!:SpeditionFormDataWithId[]

  currentPage = 1;
  totalPages?: number;
  paginatedArray?: any[];
  
  subscription: Subscription = new Subscription();


  constructor(private apiService: ApiService, private router: Router) {
    this.showEmail = false;
    this.showPallets = false;
    this.showDate = false;
  }

  getData():void {
    this.subscription = this.apiService.getSpeditionRequests().subscribe({
      next: (data) => {
        this.speditionRequests = data;
      },
      error: (err) => {
        this.router.navigate(['/404']);
      },
    });
    this.sortedArray = this.speditionRequests.sort((a, b) => {
      const statusOrder: any = { 'Waiting for approval': 1, 'Approved': 2, 'Complete': 3 };
      return statusOrder[a.status] - statusOrder[b.status];
    })

    this.totalPages = Math.ceil(this.sortedArray.length / 5);
    this.paginatedArray = this.sortedArray.slice(0, 5);
  }

  ngOnInit(): void {
    this.getData()
  }

  onPageChanged(page: number): void {
    this.currentPage = page;
    if (page === 1) {
      if (this.sortedArray) {
        this.paginatedArray = this.sortedArray?.slice(0, 5);
      }
    } else {
      let startIndex = 5 * (page - 1)
      let endIndex = startIndex + 5
      if (this.sortedArray) {
        this.paginatedArray = this.sortedArray?.slice(startIndex, endIndex);
      }
    }


  }

  acceptSpdRequest(id: string, status: string) {
    if (status !== 'Pending') {
      return
    }

    const payload = {
      id,
      status: 'Approved'
    }

    this.apiService.updateSpeditionRequest(payload)
    this.getData()
  }

  completeSpdRequest(id: string, status: string) {
    if (status !== 'Approved') {
      return
    }

    const payload = {
      id,
      status: 'Complete'
    }

    this.apiService.updateSpeditionRequest(payload)
    this.getData()
  }

  rejectSpdRequest(id: string) {
    const confirmed = confirm('are you sure')
    if (!confirmed) {
      return
    }

    const payload = {
      id,
      status: 'Rejected'
    }

    this.apiService.updateSpeditionRequest(payload)
    this.getData()

  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

}
