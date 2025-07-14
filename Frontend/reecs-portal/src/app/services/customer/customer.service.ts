import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ICustomer } from '../../interfaces/ICustomer';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  apiUrl : string = 'https://localhost:7162/api/Customer';
  constructor(private http: HttpClient) { }

  getAllCustomers():Observable<ICustomer[]>{
   return this.http.get<ICustomer[]>(`${this.apiUrl}`);
  }
  
  createCustomer(customer : ICustomer) : Observable<ICustomer>{
    return this.http.post<ICustomer>(`${this.apiUrl}`,customer);
  }

  updateCustomer(custCode:number,customer:ICustomer): Observable<ICustomer>{
    return this.http.put<ICustomer>(`${this.apiUrl}/${custCode}`,customer);
  }

  deleteCustomer(custCode:number): Observable<boolean>{
    return this.http.delete<boolean>(`${this.apiUrl}/${custCode}`);
  }
}
