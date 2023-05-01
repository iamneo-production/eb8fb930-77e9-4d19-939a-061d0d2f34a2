import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserModel } from 'src/app/signup/signup.component';
const URL:any='https://8080-cedbbfbbfdcbcaabbdcbdedafdfcabbbcaaa.project.examly.io/api/SignUp/SignUp';
@Injectable({
  providedIn: 'root'
})
export class SignupService {
  constructor(private http:HttpClient) { }

  Create(data:UserModel):Observable<any>
 {
    return this.http.post(URL,data, {responseType : 'text'});
  }
}
