using KasadarawebAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace KasadarawebAPP.Repository
{
    public interface IEmployeeRepository
    {
        EmployeeModel value();

        StatusModel CreateEmployee(Employeetable emp);
        StatusModel UpdateEmployee(Employeetable emp);
        StatusModel DeleteEmployee(int ID);
        EmployeeDataModel EmployeeData(int ID);
        EmployeeListModel EmployeeList();
        EmployeeListModel EmployeeDateHireList();
    }

    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ConnectionDB _connectionDB;

        public EmployeeRepository(ConnectionDB connectionDB)
        {
            _connectionDB = connectionDB;
        }


        public StatusModel CreateEmployee(Employeetable emp)
        {
            StatusModel sm = new StatusModel();
            try
            {
                _connectionDB.employeetables.Add(new Employeetable {
                 FirstName=emp.FirstName, HireDate=emp.HireDate,
                 LastName=emp.LastName, ManagerID=emp.ManagerID, MiddleName=emp.MiddleName,
                 Salary=emp.Salary});

                _connectionDB.SaveChanges();

                sm.StatusID = 200;
                sm.StatusMessage = "Employee Created Successfully";
            }
            catch(Exception ex)
            {
                sm.StatusID = 500;
                sm.StatusMessage = "Employee Created Error "+ex.Message;
            }
            return sm;
        }

        public StatusModel DeleteEmployee(int ID)
        {
            StatusModel sm = new StatusModel();
            try
            {
                var IdentityEmployee = _connectionDB.employeetables.Where(x => x.ID == ID).FirstOrDefault();
                if (IdentityEmployee != null)
                {
                    _connectionDB.employeetables.Remove(IdentityEmployee);
                    _connectionDB.SaveChanges();
                }
                else
                {
                    sm.StatusID = 208;
                    sm.StatusMessage = "Employee Not Found";
                }

                sm.StatusID = 200;
                sm.StatusMessage = "Employee Deleted Successfully";
            }
            catch (Exception ex)
            {
                sm.StatusID = 500;
                sm.StatusMessage = "Employee Delete Error"+ex.Message;
            }
            return sm;
        }

        public EmployeeDataModel EmployeeData(int ID)
        {
            EmployeeDataModel data = new EmployeeDataModel();
            try
            {
                data.EmployeeData = new Employeetable();
                data.EmployeeData = (from emp in _connectionDB.employeetables.AsEnumerable()
                                     where emp.ID == ID
                                     select new Employeetable {
                                          FirstName=emp.FirstName,
                                           ID=emp.ID,
                                            HireDate= emp.HireDate,
                                             LastName=emp.LastName,
                                              ManagerID=emp.ManagerID,
                                               MiddleName=emp.MiddleName,
                                                Salary=emp.Salary

            }).FirstOrDefault();


                data.StatusID = 200;
                data.StatusMessage = "Employee Data";
            }
            catch (Exception ex)
            {
                data.StatusID = 500;
                data.StatusMessage = "Employee Data Error "+ ex.Message;
            }
            return data;
        }

        public EmployeeListModel EmployeeDateHireList()
        {
            EmployeeListModel data = new EmployeeListModel();
            try
            {
                data.EmployeeList = new List<EmployeeData>();
                data.EmployeeList = (from emp in _connectionDB.employeetables.AsEnumerable()
                                     where emp.HireDate < Convert.ToDateTime("2021-01-01")
                                     select new EmployeeData
                                     {
                                         FirstName = emp.FirstName,
                                         ID = emp.ID,
                                         HireDate = emp.HireDate.ToString("dd MMMM yyyy"),
                                         LastName = emp.LastName,
                                         ManagerID = emp.ManagerID,
                                         MiddleName = emp.MiddleName,
                                         Salary = emp.Salary.ToString("0.00")

                                     }).ToList();


                data.StatusID = 200;
                data.StatusMessage = "Employee Hire List";
            }
            catch (Exception ex)
            {
                data.StatusID = 500;
                data.StatusMessage = "Employee Hire List Error " + ex.Message;
            }
            return data;
        }

        public EmployeeListModel EmployeeList()
        {
            EmployeeListModel data = new EmployeeListModel();
            try
            {
                data.EmployeeList = new List<EmployeeData>();
                data.EmployeeList = (from emp in _connectionDB.employeetables.AsEnumerable()
                                     select new EmployeeData
                                     {
                                         FirstName = emp.FirstName,
                                         ID = emp.ID,
                                         HireDate = emp.HireDate.ToString("dd MMMM yyyy"),
                                         LastName = emp.LastName,
                                         ManagerID = emp.ManagerID,
                                         MiddleName = emp.MiddleName,
                                         Salary = emp.Salary.ToString("0.00")

                                     }).ToList();


                data.StatusID = 200;
                data.StatusMessage = "Employee List";
            }
            catch (Exception ex)
            {
                data.StatusID = 500;
                data.StatusMessage = "Employee List Error " + ex.Message;
            }
            return data;
        }

        public StatusModel UpdateEmployee(Employeetable emp)
        {
            StatusModel sm = new StatusModel();
            try
            {
                var IdentityEmployee = _connectionDB.employeetables.Where(x => x.ID == emp.ID).FirstOrDefault();
                if (IdentityEmployee != null)
                {
                    IdentityEmployee.HireDate = emp.HireDate;
                    IdentityEmployee.LastName = emp.LastName;
                    IdentityEmployee.FirstName = emp.FirstName;
                    IdentityEmployee.MiddleName = emp.MiddleName;
                    IdentityEmployee.ManagerID = emp.ManagerID;
                    IdentityEmployee.Salary = emp.Salary;

                    _connectionDB.SaveChanges();
                    sm.StatusID = 200;
                    sm.StatusMessage = "Employee Updated Successfully";
                }
                else
                {
                    sm.StatusID = 208;
                    sm.StatusMessage = "Employee Not Found";
                }
               
            }
            catch (Exception ex)
            {
                sm.StatusID = 500;
                sm.StatusMessage = "Employee Update Error "+ex.Message;
            }
            return sm;
        }

        public  EmployeeModel value()
        {
            EmployeeModel emp = new EmployeeModel();
            emp.EmployeeID = 1;
            emp.EmployeeName = "Hello World";
            return emp;
        }
    }
}