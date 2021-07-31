import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ApiserviceService {

  constructor(private http: HttpClient) { }
  
  EmployeeData():Observable<any>{
    
      return this.http.get(`${environment.apiurl}/api/Employee/EmployeeList`)
  }
}
