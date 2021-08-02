import { DatePipe } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { employeetable } from 'src/models/employeemodel';
import { EmployeeapiService } from 'src/services/employeeapi.service';


@Component({
  selector: 'app-add-employee',
  templateUrl: './add-employee.component.html',
  styleUrls: ['./add-employee.component.css']
})
export class AddEmployeeComponent implements OnInit {
  heading:string='';
  submitbuttontext:string='';
  Employeeformgroup!: FormGroup;
  EmployeeData!:employeetable;
  EmployeeResponseMessage!:EmployeeSuccessdata;
  EmployeevalidID:number=0;
  
  constructor(private modalService: NgbModal,private apiservice:EmployeeapiService,private datePipe: DatePipe) { 
    
  }
  @Input() ID:number=0;
  

  ngOnInit(): void {

    this.Employeeformgroup =new FormGroup({
      ID:new FormControl(0),
      FirstName:new FormControl('',[Validators.required]),
      MiddleName:new FormControl(''),
      LastName:new FormControl('',[Validators.required]),
      ManagerID:new FormControl(0),
      HireDate:new FormControl(new Date,[Validators.required]),
      Salary:new FormControl(0,[Validators.required]),
     });

    if(this.ID==0){
     this.heading= "Add Employee";
     this.submitbuttontext="Save";
    }
   else {      

     this.apiservice.EmployeeData(this.ID).subscribe(data=>{
       debugger;
       if(data.StatusID==200){
        this.EmployeeData=data.EmployeeData;
        this.EmployeevalidID=this.EmployeeData.ID;
        this.Employeeformgroup.setValue({
          ID: this.EmployeeData.ID, 
          FirstName: this.EmployeeData.FirstName,
          MiddleName: this.EmployeeData.MiddleName, 
          LastName: this.EmployeeData.LastName,
          ManagerID: this.EmployeeData.ManagerID, 
          HireDate: this.datePipe.transform(this.EmployeeData.HireDate,"yyyy-MM-dd"),
          Salary: this.EmployeeData.Salary
        });
       }
       else if(data.StatusID==500){
               alert('Error');
       }
        

     })

     this.heading="Edit Employee"
     this.submitbuttontext="Update";
   }
   
  }
  close(){
        this.modalService.dismissAll();
  }

  
  
SubmitEmployee(){
  
  if(this.Employeeformgroup.valid) {
    if(this.Employeeformgroup.controls['Salary'].value>0){
      debugger;
      if(this.EmployeevalidID===0){
        this.apiservice.CreateEmployee(this.Employeeformgroup.value).subscribe(data=>{
               alert('Employee create Successfully');
          console.log(data);
          this.apiservice.Popupcloselistener('popupclose');
          this.modalService.dismissAll();
    })
    }
    else{
          this.apiservice.UpdateEmployee(this.Employeeformgroup.value).subscribe(data=>{
            alert('Employee Updated Successfully');
            console.log(data);
            this.apiservice.Popupcloselistener('popupclose');
            this.modalService.dismissAll();
          })
    }
      
  }
  else{
     alert('Please enter Salary')
  }
      
  }
  else{
    alert('Please check form data')
  }
}

}
export class EmployeeSuccessdata{
  StatusID:number=0;
  StatusMessage:string='';
}
