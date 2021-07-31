import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EmployeedataComponent } from './employeedata/employeedata.component';

const routes: Routes = [
    { path: 'employeedata', component: EmployeedataComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
