import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { departmenttable } from 'src/models/departmentmodel';
@Injectable({
  providedIn: 'root'
})
export class DepartmentapiService {

  constructor(private http: HttpClient) { }

  DepartmentList():Observable<any>{
    return this.http.get(`${environment.apiurl}/api/Department/DepartmentList`)
 }
 
 DepartmentData(ID:number):Observable<any>{
   return this.http.get(`${environment.apiurl}/api/Department/DepartmentData/${ID}`)
 }
 CreateDepartment(departmentdatadata:departmenttable){
   return this.http.post(`${environment.apiurl}/api/Department/CreateDepartment`,departmentdatadata);
 }
 UpdateDepartment(departmentdatadata:departmenttable){
   return this.http.post(`${environment.apiurl}/api/Department/UpdateDepartment`,departmentdatadata);
 }
 DeleteDepartment(ID:number):Observable<any>{
   return this.http.delete(`${environment.apiurl}/api/Department/DeleteDepartment/${ID}`)
 }
}
