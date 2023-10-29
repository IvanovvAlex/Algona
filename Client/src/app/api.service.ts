import { Injectable } from '@angular/core';
import { HttpClient } from  '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private url = 'api/forus/data'

  constructor(private http: HttpClient) { }

  getData() {
    return this.http.get(this.url, {observe: 'response'});
  }
}
