import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { ContactFormData } from 'src/app/shared/typization/interfaces/ContactFormData';
import { Observable } from 'rxjs';
import { Job } from 'src/app/shared/typization/interfaces';
import { JobDetails } from 'src/app/shared/typization/interfaces/jobDetails';

@Injectable({
    providedIn: 'root'
})
export class ApiService {

    private url = 'api/forus/data'

    constructor(private http: HttpClient) { }

    getData() {
        return this.http.get(this.url, { observe: 'response' });
    }

    sendContactData(contactFormData: ContactFormData) {
        return this.http.post('api/Contacts/', contactFormData, { observe: 'response' })
    }

    getGaragePhotos() {
        return this.http.get('api/garage/photos');
    }

    getAvailableJobs(): Observable<Job[]> {
        return this.http.get<Job[]>('/api/Jobs/Index');
    }

    getJobById(jobId:string): Observable<JobDetails> {
        return this.http.get<JobDetails>(`/api/Jobs/details/${jobId}`);
    }
}
