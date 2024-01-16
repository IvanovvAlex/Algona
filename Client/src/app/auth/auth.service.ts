import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  
  constructor(private http: HttpClient) { }

  private url = 'api/Auths'


  login(loginData:any) {
    return this.http.post(`${this.url}/Login`, loginData, { observe: 'response' })
  }

  register(registerData:any) {
    return this.http.post(`${this.url}/Register`, registerData, { observe: 'response' })
  }

}
