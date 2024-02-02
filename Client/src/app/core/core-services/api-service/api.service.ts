import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { ContactFormData } from 'src/app/shared/typization/interfaces/ContactFormData';
import { Observable } from 'rxjs';
import { Job } from 'src/app/shared/typization/interfaces';
import { JobDetails } from 'src/app/shared/typization/interfaces/jobDetails';
import { TransportFormData, TransportFormDataWithId } from 'src/app/shared/typization/interfaces/transportFormData';
import { SpeditionFormData, SpeditionFormDataWithId } from 'src/app/shared/typization/interfaces/speditionFormData';

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
        return this.http.post('api/Contacts/Send', contactFormData, { observe: 'response' })
    }

    getGaragePhotos() {
        return this.http.get('api/garage/photos');
    }

    getAvailableJobs(): Observable<Job[]> {
        return this.http.get<Job[]>('/api/Jobs/Index');
    }

    getJobById(jobId: string): Observable<JobDetails> {
        return this.http.get<JobDetails>(`/api/Jobs/details/${jobId}`);
    }




    getTransportRequests(): Observable<TransportFormDataWithId[]> {
        return this.http.get<TransportFormDataWithId[]>('/api/Transports/All');
    }

    getSpeditionRequests(): Observable<SpeditionFormDataWithId[]> {
        return this.http.get<SpeditionFormDataWithId[]>('/api/Speditions/All');
    }

    sendTransportRequest(transportData: TransportFormData) {
        return this.http.post('/api/Transports/Add', transportData, { observe: 'response' })
    }

    updateTransportRequest(updateData: any) {
        return this.http.post('/api/Transports/Send', updateData, { observe: 'response' })
    }

    sendSpeditionRequest(speditionData: SpeditionFormData) {
        return this.http.post('/api/Speditions/Add', speditionData, { observe: 'response' })
    }

    updateSpeditionRequest(updateData: any) {
        return this.http.post('/api/Speditions/Send', updateData, { observe: 'response' })
    }
}
