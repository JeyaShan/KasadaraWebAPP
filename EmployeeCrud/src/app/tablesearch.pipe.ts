import { Pipe, PipeTransform } from '@angular/core';
@Pipe({
  name: 'TableSearchPipe'
})
export class SearchPipe implements PipeTransform {
  
  transform(value: any, args?: any): any {
    
    if (!args) {
      return value;
    }
    debugger
    return value.filter((val: any) => {
      let rVal = (val.FirstName.toLocaleLowerCase().includes(args)) || (val.HireDate.toLocaleLowerCase().includes(args));
      return rVal;
    })

  }

}