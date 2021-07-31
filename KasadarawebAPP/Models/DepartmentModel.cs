using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KasadarawebAPP.Models
{
    public class DepartmentModel
    {
        public int StatusID { get; set; }
        public string StatusMessage { get; set; }
        public Departmenttable DepartmentData { get; set; }
    }

    public class DepartmentModelList
    {
        public int StatusID { get; set; }
        public string StatusMessage { get; set; }
        public List<Departmenttable> DepartmentList { get; set; }
    }
}