import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

//interface
import { ISearch } from '../../interfaces/search.interface';
import { IBill } from '../../interfaces/bill.interface';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  baseUrl = "http://localhost:5057/api";

  constructor(private _http:HttpClient) { }

   //listar
  public getBills(objReq: ISearch): Observable<IBill>{
    return this._http.post<IBill>(this.baseUrl + "/Bill/List", objReq)
  }

  public updateBill(objReq: any): Observable<any> {
    return this._http.post(this.baseUrl + "/Bill/ChangeState", objReq)
  }

}
