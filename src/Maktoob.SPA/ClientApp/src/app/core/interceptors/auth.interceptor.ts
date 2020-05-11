import { Injectable, Inject } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { switchMap, filter, take, finalize } from 'rxjs/operators';
import { IAuthFacade } from '../facades/auth.facade';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

  private AUTH_HEADER = "Authorization";

  constructor(
    private authFacade: IAuthFacade,
    @Inject('API_BASE_URL') private API_BASE_URL
  ) { }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<unknown>> {

    if (
      request.url.startsWith(this.API_BASE_URL + 'auth')
      &&
      !(request.url.endsWith('SignOut') || request.url.endsWith('IsAuthorized'))
    ) {
      return next.handle(request);
    }

    if (this.authFacade.IsTokenExpired()) {
      this.authFacade.TokenRequiredUpdate();
    }

    return this.authFacade.TokenExpired$.pipe(
      filter(expired => !expired), // pass if and only if the token doesn't expire
      take(1), // to complete the request
      switchMap(_ => {
        request = this.addAuthorizationToken(request);
        return next.handle(request)
      })
    );
  }

  private addAuthorizationToken(request: HttpRequest<any>): HttpRequest<any> {
    // If we do not have a token yet then we should not set the header.
    // Here we could first retrieve the token from where we store it.
    const token = this.authFacade.GetAccessToken();
    if (!token) {
      return request;
    }
    // If you are calling an outside domain then do not add the token.
    if (!request.url.match(/\//)) {
      return request;
    }

    return request.clone({
      headers: request.headers.set(this.AUTH_HEADER, "Bearer " + token)
    });
  }
}
