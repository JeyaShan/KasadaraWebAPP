using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KasadarawebAPP.Models
{
    public class EmployeeModel
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
    }

    public class EmployeeData
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int ManagerID { get; set; }
        public string HireDate { get; set; }
        public string Salary { get; set; }
    }

    public class EmployeeListModel
    {
        public int StatusID { get; set; }
        public string StatusMessage { get; set; }
        public List<EmployeeData> EmployeeList { get; set; }
    }

    public class EmployeeDataModel
    {
        public int StatusID { get; set; }
        public string StatusMessage { get; set; }
        public EmployeeData EmployeeData { get; set; }
    }
}