import { Component, OnInit } from '@angular/core';
import { ApiserviceService } from '../apiservice.service';



@Component({
  selector: 'app-employeedata',
  templateUrl: './employeedata.component.html',
  styleUrls: ['./employeedata.component.css']
})
export class EmployeedataComponent implements OnInit {

  EmployeeData:any[]=[];
  constructor(private apiservice:ApiserviceService) { }

  ngOnInit() {
     this.apiservice.EmployeeData().subscribe(x=>{
       console.log(x)
       this.EmployeeData= x.EmployeeList
     })



  }

}
