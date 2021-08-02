import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import {gradetable} from 'src/models/grade'
@Injectable({
  providedIn: 'root'
})
export class GradeapiService {

  constructor(private http: HttpClient) { }

  GradeList():Observable<any>{
    return this.http.get(`${environment.apiurl}/api/Grade/GradeList`)
 }
 
 GradeData(ID:number):Observable<any>{
   return this.http.get(`${environment.apiurl}/api/Grade/GradeData/${ID}`)
 }
 CreateGrade(gradedata:gradetable){
   return this.http.post(`${environment.apiurl}/api/Grade/CreateGrade`,gradedata);
 }
 UpdateGrade(gradedata:gradetable){
   return this.http.post(`${environment.apiurl}/api/Grade/UpdateGrade`,gradedata);
 }
 DeleteGrade(ID:number):Observable<any>{
   return this.http.delete(`${environment.apiurl}/api/Grade/DeleteGrade/${ID}`)
 }
}
