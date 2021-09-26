import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class ResourceService {

    _baseUrl:any;

  constructor(private httpClient: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._baseUrl = baseUrl + 'api/Resource';  
   }

  readAll(): Observable<any> {
    return this.httpClient.get(this._baseUrl);
  }

}
