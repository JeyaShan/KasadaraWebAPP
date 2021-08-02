import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EmployeeComponent } from './Employee/employee/employee.component';
import { AddEmployeeComponent } from './Employee/add-employee/add-employee.component';
import { DepartmentComponent } from './Department/department/department.component';
import { AdddepartmentComponent } from './Department/adddepartment/adddepartment.component';
import { GradeComponent } from './Grade/grade/grade.component';
import { AddgradeComponent } from './Grade/addgrade/addgrade.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SearchPipe } from './tablesearch.pipe';
import { DatePipe } from '@angular/common';

@NgModule({
  declarations: [
    AppComponent,
    EmployeeComponent,
    AddEmployeeComponent,
    DepartmentComponent,
    AdddepartmentComponent,
    GradeComponent,
    AddgradeComponent,
    SearchPipe,
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,HttpClientModule,FormsModule,ReactiveFormsModule
  ],
  exports: [AppComponent],
  providers: [DatePipe],
  bootstrap: [AppComponent]
})
export class AppModule { }
