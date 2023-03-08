import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { BehaviorSubject } from "rxjs";
import { User } from "src/app/models/user/user.model";

@Injectable()
export class AuthService {
  public loggedIn = new BehaviorSubject<boolean>(this.hasToken());
  headers = new HttpHeaders({
    "x-access-token": localStorage.getItem("token"),
  });

  get isLoggedIn() {
    return this.loggedIn.asObservable();
  }

  /**
   *
   */
  constructor(public http: HttpClient) {}

  hasToken(): boolean {
    return !!localStorage.getItem("token");
  }

  login(user: User) {
    if (user.email !== "" && user.password !== "") {
      console.log(user);
      return this.http.post(CONSTANST.routes.authorization.login, {
        email: user.email,
        password: user.password,
      });
    }
  }

  logout() {
    return this.http.get(CONSTANST.routes.authorization.logout, {
      headers: this.headers,
    });
  }
}
