import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable, concat } from 'rxjs';
 import { AuthorizeService } from './authorize.service';
import { tap, map, subscribeOn } from 'rxjs/operators';
import { ApplicationPaths, QueryParameterNames } from './api-authorization.constants';

@Injectable({
  providedIn: 'root'
})
export class AuthorizeGuard implements CanActivate {
  constructor(private authorize: AuthorizeService, private router: Router) {
  }
  canActivate(
    _next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {


    return this.authorize.isAuthenticated()
      .pipe(tap(isAuthenticated => this.handleAuthorization(isAuthenticated, state, _next)));


  }

  private handleAuthorization(isAuthenticated: boolean, state: RouterStateSnapshot, _next: ActivatedRouteSnapshot) {



    if (!isAuthenticated) {
      this.router.navigate(ApplicationPaths.LoginPathComponents, {
        queryParams: {
          [QueryParameterNames.ReturnUrl]: state.url
        }
      });
    }

    this.authorize.getUser().subscribe(u => {
      let existeRole = false;
      const authRoles = _next.data.roles;
      if (u.role) {
        authRoles.forEach(i => {
          if (u.role.includes(i)) {
            existeRole = true;
          }
        });
      }

      if (!existeRole) {
        this.router.navigate(ApplicationPaths.LoginPathComponents, {
          queryParams: {
            [QueryParameterNames.ReturnUrl]: state.url
          }
        });
      }
    })
  }
}
