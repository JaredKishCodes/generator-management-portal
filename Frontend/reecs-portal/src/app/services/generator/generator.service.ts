import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Gen } from '../../interfaces/generator';

@Injectable({
  providedIn: 'root'
})
export class GeneratorService {

  constructor(private http: HttpClient) { }

  apiUrl = "https://localhost:7162/api/Generator";

  getAllGenerators(): Observable<Gen[]> {
    return this.http.get<Gen[]>(this.apiUrl);
  }

  createGenerator(gen: Gen): Observable<Gen> {
    return this.http.post<Gen>("https://localhost:7162/api/Generator", gen);
  }

  updateGenerator(genCode: number, gen : Gen): Observable<Gen> { 
  return this.http.put<Gen>(`https://localhost:7162/api/Generator/${genCode}`, gen);
}
  deleteGenerator(genCode:number): Observable<Gen> { 
  return this.http.delete<Gen>(`https://localhost:7162/api/Generator/${genCode}`);
}
}
