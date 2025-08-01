import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { enviroment } from '../../Environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ApiClient {

  UrlRequest: string = enviroment.GlobalApiUrl + "api/Client/";

  constructor(
    private _http: HttpClient   // por DI
  ){}

  getClients(): Observable<Response>{           // emite una peticion de tipo get a la API cargada en la url indicada.
    return this._http.get<Response>(this.UrlRequest);  // la cual recibe un objeto Response
  }

  getClient(id : number): Observable<Response>{
    var url = this.UrlRequest + id;
    return this._http.get<Response>(url);
  }

}
