import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {map} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http : HttpClient) { }

  getProduct()
  {
    return this.http.get<any>('https://localhost:7024/api/Product/Read')
    .pipe(map((res:any)=>{
      return res;
    }))
  }
}
