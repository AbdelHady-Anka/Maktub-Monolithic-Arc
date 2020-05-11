import { Injectable } from '@angular/core';
import { CanLoad, Route, UrlSegment, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanLoad {
  /**
   *
   */
  constructor(private router: Router) { }
  canLoad(
    route: Route,
    segments: UrlSegment[]): Observable<boolean> | Promise<boolean> | boolean {
    const au = false;
    if (!au) {
      if (segments.length === 0) {
        this.router.navigateByUrl('/auth');
      }
      else {
        this.router.navigateByUrl('/error/notfound');
      }
    }
    return au;
  }
}
