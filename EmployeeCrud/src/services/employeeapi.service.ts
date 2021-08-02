import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable,Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { employeetable } from 'src/models/employeemodel';

@Injectable({
  providedIn: 'root'
})
export class EmployeeapiService {

  constructor(private http: HttpClient) { }

  EmployeeList():Observable<any>{
     return this.http.get(`${environment.apiurl}/api/Employee/EmployeeList`)
  }
  EmployeeListBefore2021():Observable<any>{
    return this.http.get(`${environment.apiurl}/api/Employee/EmployeeHireDateList`)
 }
  EmployeeData(ID:number):Observable<any>{
    return this.http.get(`${environment.apiurl}/api/Employee/EmployeeData/${ID}`)
  }
  CreateEmployee(employeedata:employeetable){
    return this.http.post(`${environment.apiurl}/api/Employee/CreateEmployee`,employeedata);
  }
  UpdateEmployee(employeedata:employeetable){
    return this.http.post(`${environment.apiurl}/api/Employee/UpdateEmployee`,employeedata);
  }
  DeleteEmployee(ID:number):Observable<any>{
    return this.http.delete(`${environment.apiurl}/api/Employee/DeleteEmployee/${ID}`)
  }

  private _listeners= new Subject<any>();
  listen():Observable<any>{
    return this._listeners.asObservable();
  }
  Popupcloselistener(data:string){
    this._listeners.next(data);
  }
}
