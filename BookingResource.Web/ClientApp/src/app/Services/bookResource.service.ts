import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class BookResourceService {

    _baseUrl:any;

  constructor(private httpClient: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._baseUrl = baseUrl + 'api/Booking';  
   }


  create(data): Observable<any> {
    return this.httpClient.post(this._baseUrl, data,{responseType: 'text'});
  }
}
