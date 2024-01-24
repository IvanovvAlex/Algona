import { HttpClient } from '@angular/common/http';
import { Injectable, signal } from '@angular/core';
import { Observable } from 'rxjs';
import { RegisterUser, User } from '../shared/typization/interfaces';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  currentUserSignal = signal<User | undefined | null>(undefined);
  
  private devBaseUrl = 'https://localhost:7169';
    
  constructor(private http: HttpClient) { }

    login$(email: string, password: string): Observable<User> {
        return this.http.post<User>(this.devBaseUrl + '/api/Auths/Login', {
            email,
            password,
        });
  }

    register$(registerData: RegisterUser): Observable<User> {
        return this.http.post<User>(
            this.devBaseUrl + '/api/Auths/Register',
            registerData
        );
    }
    
    getUser$(): Observable<User> {
        return this.http.get<User>(this.devBaseUrl + '/api/Auths/User', {
            withCredentials: true,
        });
    }

    logout$(): Observable<void> {
        return this.http.post<void>(
            this.devBaseUrl + '/api/Auths/Logout',
            {},
            { withCredentials: true }
        );
    }
}
