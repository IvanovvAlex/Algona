import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { ContactFormData } from 'src/app/shared/typization/interfaces/ContactFormData';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private url = 'api/forus/data'

  constructor(private http: HttpClient) { }

  getData() {
    return this.http.get(this.url, { observe: 'response' });
  }

  sendData(contactFormData: ContactFormData) {
    return this.http.post('api/contact/', contactFormData, { observe: 'response' })
  }

}
