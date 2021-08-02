import { Component, OnInit} from '@angular/core';
import { NgbModal, NgbModalConfig } from '@ng-bootstrap/ng-bootstrap';
import {employeedata} from 'src/models/employeemodel'
import { EmployeeapiService } from 'src/services/employeeapi.service';
import { ExportexcelService } from 'src/services/exportexcel.service';
import { AddEmployeeComponent } from '../add-employee/add-employee.component';



@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})


export class EmployeeComponent implements OnInit {
  Employeelisttoggleheading:string='';
  toggleval:number=0;
  deleteemployeeid:number=0;
  deleteemployeename:string='';
  employeelist:employeedata[]=[];
  Searchtext="";
  page = 1;
  pageSize = 4;
  collectionSize = 0;
  constructor(private apiservice:EmployeeapiService,private modalService: NgbModal,
    config: NgbModalConfig,private exportexcel:ExportexcelService) 
  {
    config.backdrop = 'static';
    this.apiservice.listen().subscribe(data=>{
       if(this.toggleval==0){
        this.apiservice.EmployeeList().subscribe(data=>{
          this.employeelist=data.EmployeeList;
          this.collectionSize=this.employeelist.length;
          console.log(this.employeelist);
        })
       }
       else{
        this.apiservice.EmployeeListBefore2021().subscribe(data=>{
          this.employeelist=data.EmployeeList;
          this.collectionSize=this.employeelist.length;
          console.log(this.employeelist);
        })
       }
    })
  }
  
  ngOnInit(): void {
    this.Employeelisttoggleheading='Employee List  Switch to HireDate Before 2021';
    this.toggleval=0;
    this.apiservice.EmployeeList().subscribe(data=>{
      this.employeelist=data.EmployeeList;
      this.collectionSize=this.employeelist.length;
        console.log(this.employeelist);
    })

  }

  open() {
    const modalRef = this.modalService.open(AddEmployeeComponent, {size: 'lg', windowClass: 'modal-xl'});
    modalRef.componentInstance.ID = 0;
    
  }
  Editemployee(ID:number){
    const modalRef = this.modalService.open(AddEmployeeComponent, {size: 'lg', windowClass: 'modal-xl'});
    modalRef.componentInstance.ID = ID;
  }

  
  
  Deleteemployee(ID:number,content:any,empname:string){
    this.deleteemployeeid=ID;
    this.deleteemployeename=empname;
    this.modalService.open(content, { size: 'lg' });
  }
  DeleteConfirm(){
       if(this.deleteemployeeid>0){
        this.apiservice.DeleteEmployee(this.deleteemployeeid).subscribe(data=>{
              if(data.StatusID==200){
                   alert(data.StatusMessage);
                   this.apiservice.EmployeeList().subscribe(data=>{
                    this.employeelist=data.EmployeeList;
                    this.collectionSize=this.employeelist.length;
                    console.log(this.employeelist);
                  })
              }
              else if(data.StatusID==500){
                alert(data.StatusMessage)
              }
              this.modalService.dismissAll();
        })
      }
    
  }
  ExportExcel(){
             this.exportexcel.EmployeeList(this.employeelist);
  }

  Toggleclick(){
          if(this.toggleval===0){
            this.toggleval=1;
            this.Employeelisttoggleheading='HireDate Before 2021 Employee List  Switch to  All Employee List';
            

            this.apiservice.EmployeeListBefore2021().subscribe(data=>{
              this.employeelist=data.EmployeeList;
              this.collectionSize=this.employeelist.length;
              console.log(this.employeelist);
            })
          }
          else{
            this.Employeelisttoggleheading='All Employee List  Switch to HireDate Before 2021';
            this.toggleval=0;
            this.apiservice.EmployeeList().subscribe(data=>{
              this.employeelist=data.EmployeeList;
              this.collectionSize=this.employeelist.length;
              console.log(this.employeelist);
            })
          }
  }

}
