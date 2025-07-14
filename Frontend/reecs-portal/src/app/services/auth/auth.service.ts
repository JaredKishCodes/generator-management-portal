import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Register } from '../../interfaces/register';
import { Observable } from 'rxjs';
import { Login } from '../../interfaces/login';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http:HttpClient) { }

  apiUrl : string = "https://localhost:7162/api/account"

  public register(user:Register):Observable<any>{
    return this.http.post<any>(`${this.apiUrl}/register`,user);
  }

  public login(creds: Login):Observable<any>{
    return this.http.post<any>(`${this.apiUrl}/login`,creds);
  }
}
