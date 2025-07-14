import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ICustomerRequest } from '../../interfaces/Customer/ICustomerRequest';
import { ICustomerResponse } from '../../interfaces/Customer/ICustomerResponse';
import { IUpdateCustomerRequest } from '../../interfaces/Customer/IUpdateCustomerRequest';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  apiUrl : string = 'https://localhost:7162/api/Customer';
  constructor(private http: HttpClient) { }

  getAllCustomers():Observable<ICustomerResponse[]>{
   return this.http.get<ICustomerResponse[]>(`${this.apiUrl}`);
  }
  
  createCustomer(customer : ICustomerRequest) : Observable<ICustomerResponse>{
    return this.http.post<ICustomerResponse>(`${this.apiUrl}`,customer);
  }

  updateCustomer(custCode:number,customer:IUpdateCustomerRequest): Observable<ICustomerResponse>{
    return this.http.put<ICustomerResponse>(`${this.apiUrl}/${custCode}`,customer);
  }

  deleteCustomer(custCode:number): Observable<boolean>{
    return this.http.delete<boolean>(`${this.apiUrl}/${custCode}`);
  }
}
