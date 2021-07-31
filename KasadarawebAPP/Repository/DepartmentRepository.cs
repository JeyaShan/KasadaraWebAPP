using KasadarawebAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KasadarawebAPP.Repository
{
    public interface IDepartmentRepository
    {
        StatusModel CreateDepartment(Departmenttable dep);
        StatusModel UpdateDepartment(Departmenttable dep);
        StatusModel DeleteDepartment(int ID);
        DepartmentModel DepartmentData(int ID);
        DepartmentModelList DepartmentList();
    }
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ConnectionDB _connectionDB;

        public DepartmentRepository(ConnectionDB connectionDB)
        {
            _connectionDB = connectionDB;
        }

        public StatusModel CreateDepartment(Departmenttable dep)
        {
            StatusModel sm = new StatusModel();
            try
            {
                _connectionDB.departmenttables.Add(new Departmenttable { Location= dep.Location, Name=dep.Name  });
                _connectionDB.SaveChanges();
                sm.StatusID = 200;
                sm.StatusMessage = "Department Created Successfully";
            }
            catch(Exception ex)
            {
                sm.StatusID = 500;
                sm.StatusMessage = "Department Created Error "+ ex.Message;
            }
            return sm;

        }

        public StatusModel DeleteDepartment(int ID)
        {
            StatusModel sm = new StatusModel();
            try
            {
                var IdentityDepartment = _connectionDB.departmenttables.Where(x => x.ID == ID).FirstOrDefault();
                if (IdentityDepartment != null)
                {
                    _connectionDB.departmenttables.Remove(IdentityDepartment);
                    _connectionDB.SaveChanges();
                    sm.StatusID = 200;
                    sm.StatusMessage = "Department Deleted Successfully";
                }
                else
                {
                    sm.StatusID = 208;
                    sm.StatusMessage = "Department Not Found";
                }
                
            }
            catch (Exception ex)
            {
                sm.StatusID = 500;
                sm.StatusMessage = "Department Delete Error "+ ex.Message;
            }
            return sm;
        }

        public DepartmentModel DepartmentData(int ID)
        {
            DepartmentModel sm = new DepartmentModel();
            try
            {
                sm.DepartmentData = new Departmenttable();
                sm.DepartmentData = (from dep in _connectionDB.departmenttables.AsEnumerable()
                                     where dep.ID == ID
                                     select new Departmenttable
                                     {
                                         ID=dep.ID,
                                         Location=dep.Location,
                                         Name =dep.Name
                                     }).FirstOrDefault();

                sm.StatusID = 200;
                sm.StatusMessage = "";
            }
            catch (Exception ex)
            {
                sm.StatusID = 500;
                sm.StatusMessage = "";
            }
            return sm;
        }

        public DepartmentModelList DepartmentList()
        {
            DepartmentModelList sm = new DepartmentModelList();
            try
            {
                sm.DepartmentList = new List<Departmenttable>();
                sm.DepartmentList = (from dep in _connectionDB.departmenttables.AsEnumerable()
                                     select new Departmenttable
                                     {
                                         ID = dep.ID,
                                         Location = dep.Location,
                                         Name = dep.Name
                                     }).ToList();
                sm.StatusID = 200;
                sm.StatusMessage = "Department List";
            }
            catch (Exception ex)
            {
                sm.StatusID = 500;
                sm.StatusMessage = "Department List Error "+ ex.Message;
            }
            return sm;
        }

        public StatusModel UpdateDepartment(Departmenttable dep)
        {
            StatusModel sm = new StatusModel();
            try
            {
                var IdentityDepartment = _connectionDB.departmenttables.Where(x => x.ID == dep.ID).FirstOrDefault();
                if (IdentityDepartment != null)
                {
                    IdentityDepartment.Name = dep.Name;
                    IdentityDepartment.Location = dep.Location;
                    _connectionDB.SaveChanges();
                    sm.StatusID = 200;
                    sm.StatusMessage = "Department Update Successfully";
                }
                else
                {
                    sm.StatusID = 208;
                    sm.StatusMessage = "Department Not Found";
                }
                
            }
            catch (Exception ex)
            {
                sm.StatusID = 500;
                sm.StatusMessage = "Department Update Error "+ ex.Message;
            }
            return sm;
        }
    }
}