import { Injectable } from "@angular/core";
import {
  ActivatedRouteSnapshot,
  CanActivate,
  RouterStateSnapshot,
  UrlTree,
} from "@angular/router";
import { Observable } from "rxjs";

@Injectable()
export class AuthGuardService implements CanActivate {
  canActivate(): boolean {
    return false;
  }
}
