using KasadarawebAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KasadarawebAPP.Repository
{
    public interface IGradeRepository
    {
        StatusModel CreateGrade(Gradetable grade);
        StatusModel DeleteGrade(int ID);
        StatusModel UpdateGrade(Gradetable grade);
        GradeModel GradeData(int ID);
        GradeModelList GradeList();
    }
    public class GradeRepository : IGradeRepository
    {
        private readonly ConnectionDB _connectionDB;

        public GradeRepository(ConnectionDB connectionDB)
        {
            _connectionDB = connectionDB;
        }

        public StatusModel CreateGrade(Gradetable grade)
        {
            StatusModel sm = new StatusModel();
            try
            {
                _connectionDB.gradetables.Add(new Gradetable
                { MaxSalary = grade.MaxSalary, MinSalary = grade.MinSalary });
                _connectionDB.SaveChanges();
                sm.StatusID = 200;
                sm.StatusMessage = "Grade Created Successfully";
            }
            catch(Exception ex)
            {
                sm.StatusID = 500;
                sm.StatusMessage = "Grade Created Error "+ ex.Message;
            }
            return sm;
        }

        public StatusModel DeleteGrade(int ID)
        {
            StatusModel sm = new StatusModel();
            try
            {
                var IdentityGrade = _connectionDB.gradetables.Where(x => x.ID == ID).FirstOrDefault();
                if (IdentityGrade != null)
                {
                    _connectionDB.gradetables.Remove(IdentityGrade);
                    _connectionDB.SaveChanges();
                    sm.StatusID = 200;
                    sm.StatusMessage = "Grade Deleted Successfully";
                }
                else
                {
                    sm.StatusID = 208;
                    sm.StatusMessage = "Grade Not Found";
                }
            }
            catch (Exception ex)
            {
                sm.StatusID = 500;
                sm.StatusMessage = "Grade Deleted Error " + ex.Message;
            }
            return sm;
        }

        public GradeModel GradeData(int ID)
        {
            GradeModel sm = new GradeModel();
            try
            {
                sm.GradeData = new Gradetable();
                sm.GradeData = (from grade in _connectionDB.gradetables.AsEnumerable()
                                where grade.ID == ID
                                select new Gradetable {
                                 ID=grade.ID, MaxSalary=grade.MaxSalary,MinSalary=grade.MinSalary}).FirstOrDefault();

                sm.StatusID = 200;
                sm.StatusMessage = "Grade Data";
            }
            catch (Exception ex)
            {
                sm.StatusID = 500;
                sm.StatusMessage = "Grade Data Error " + ex.Message;
            }
            return sm;
        }

        public GradeModelList GradeList()
        {
            GradeModelList sm = new GradeModelList();
            try
            {
                sm.GradeList = new List<Gradetable>();
                sm.GradeList = (from grade in _connectionDB.gradetables.AsEnumerable()
                                select new Gradetable
                                {
                                    ID = grade.ID,
                                    MaxSalary = grade.MaxSalary,
                                    MinSalary = grade.MinSalary
                                }).ToList();

                sm.StatusID = 200;
                sm.StatusMessage = "Grade List";
            }
            catch (Exception ex)
            {
                sm.StatusID = 500;
                sm.StatusMessage = "Grade List Error " + ex.Message;
            }
            return sm;
        }

        public StatusModel UpdateGrade(Gradetable grade)
        {
            StatusModel sm = new StatusModel();
            try
            {
                var IdentityGrade = _connectionDB.gradetables.Where(x => x.ID == grade.ID).FirstOrDefault();
                if (IdentityGrade != null)
                {
                    IdentityGrade.MaxSalary = grade.MaxSalary;
                    IdentityGrade.MinSalary = grade.MinSalary;
                    _connectionDB.SaveChanges();
                    sm.StatusID = 200;
                    sm.StatusMessage = "Grade Updated Successfully";
                }
                else
                {
                    sm.StatusID = 208;
                    sm.StatusMessage = "Grade Not Found";
                }
            }
            catch (Exception ex)
            {
                sm.StatusID = 500;
                sm.StatusMessage = "Grade Update Error "+ex.Message;
            }
            return sm;
        }
    }
}