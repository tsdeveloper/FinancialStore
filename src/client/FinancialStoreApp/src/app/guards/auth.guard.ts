import { Injectable } from "@angular/core";
import {
  ActivatedRouteSnapshot,
  CanActivate,
  Router,
  RouterStateSnapshot,
  UrlTree,
} from "@angular/router";
import { map, Observable, take, tap } from "rxjs";
import { AuthService } from "../services/utils/auth.service";

@Injectable()
export class AuthGuardService implements CanActivate {

  /**
   *
   */
  constructor(private authService: AuthService,
    private router: Router) { }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ):
    Observable<boolean> {
    return this.authService.isLoggedIn.pipe(
      take(1),
      map((isLoggedIn: boolean) => !!isLoggedIn),
      tap(authenticated => {
        if (!authenticated) {
          this.router.navigate(['/login']);
          return false;
        }
        return true;
      }),);
  }
}
