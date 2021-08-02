import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DepartmentComponent } from './Department/department/department.component';
import { EmployeeComponent } from './Employee/employee/employee.component';
import { GradeComponent } from './Grade/grade/grade.component';

const routes: Routes = [
  { path: 'employee', component: EmployeeComponent },
  { path: 'grade', component: GradeComponent },
  { path: 'department', component: DepartmentComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
