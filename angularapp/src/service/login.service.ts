import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Observable } from 'rxjs';
import { LoginModel } from 'src/app/login/login.component';


@Injectable({
  providedIn: 'root'
})
export class LoginService {
private readonly URL: string = 'https://8080-cedbbfbbfdcbcaabbdcbdedafdfcabbbcaaa.project.examly.io/api/Login/Token';
  jwtHelperService = new JwtHelperService();
  constructor(private http: HttpClient) { }
  Create(data:any): Observable<any> {
    console.log("hi"+data);
    return this.http.post<LoginModel>(this.URL, data);
  }
  settoken(token: string) {
    localStorage.setItem("access token", token)
    var role = this.loadcurrentuser();
    return role;
  }
  loadcurrentuser() {
    const token = localStorage.getItem("access token");
    const userInfo = token != null ? this.jwtHelperService.decodeToken(token) : null;
    console.log(userInfo);
    var str = JSON.stringify(userInfo);
    var j = JSON.parse(str)
    var role = j.role
    return role;
  }
}