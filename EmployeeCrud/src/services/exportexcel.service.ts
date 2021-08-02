import { Injectable } from '@angular/core';
import * as FileSaver from 'file-saver';
import * as XLSX from 'xlsx';
// import { Workbook } from 'exceljs';
const EXCEL_TYPE = 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=UTF-8';
const EXCEL_EXTENSION = '.xlsx';
@Injectable({
  providedIn: 'root'
})
export class ExportexcelService {
  excelHeaders:string[]=[];
  templateToExcel:any[]=[];
  storearray:any[] =[];
  constructor() { }

  EmployeeList(json:any)
  {
    
    this.excelHeaders=[];
    
    this.excelHeaders=["ID","First Name","Middle Name","Last Name","Manager ID","Hire Date","Salary"];
    
    this.storearray=[];
    this.storearray.push(this.excelHeaders);
    
    for (var i = 0; i < json.length; i++) {
      this.storearray.push([json[i].ID,json[i].FirstName,json[i].MiddleName,json[i].LastName,
        json[i].ManagerID,json[i].HireDate,json[i].Salary]
      );
    }
    this.templateToExcel =this.storearray;
   
    var wscols = [
      {wch:30},
      {wch:40},
      {wch:40},
      {wch:40},
      {wch:40},
      {wch:40},
      {wch:40},
      
      
  ];
  var cell = {
    font: {sz: 14, bold: true }
};
  const worksheet: XLSX.WorkSheet = XLSX.utils.aoa_to_sheet(this.templateToExcel);
    worksheet["!cols"]=wscols;
    worksheet[0]=cell;
    const workbook: XLSX.WorkBook = { Sheets: { 'data': worksheet }, SheetNames: ['data'] };
    const excelBuffer: any = XLSX.write(workbook, { bookType: 'xlsx', type: 'array' });
    
    this.saveAsExcelFile(excelBuffer, 'EmployeeList');
  
  }

  private saveAsExcelFile(buffer: any, fileName: string): void {
    const data: Blob = new Blob([buffer], {
      type: EXCEL_TYPE
    });
    
    
    FileSaver.saveAs(data, fileName + '_export_' + new Date().getTime() + EXCEL_EXTENSION);
  }
}
