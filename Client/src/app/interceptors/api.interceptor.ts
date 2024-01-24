import { Injectable, Provider } from '@angular/core';
import {
  HTTP_INTERCEPTORS,
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthService } from '../auth/auth.service';

@Injectable()
export class ApiInterceptor implements HttpInterceptor {
  token!: string;
  constructor(private authService: AuthService) {}

  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    this.token = localStorage.getItem('token') ?? '';
    req = req.clone({
      setHeaders: {
        Authorization: this.token ? `${this.token}` : '',
      },
    });

    return next.handle(req);
  }
}

export const apiInterceptorProvider: Provider = {
  provide: HTTP_INTERCEPTORS,
  useClass: ApiInterceptor,
  multi: true,
};
