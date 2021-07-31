using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KasadarawebAPP.Models
{
    public class GradeModel
    {
        public int StatusID { get; set; }
        public string StatusMessage { get; set; }
        public Gradetable GradeData { get; set; }
    }
    public class GradeModelList
    {
        public int StatusID { get; set; }
        public string StatusMessage { get; set; }
        public List<Gradetable> GradeList { get; set; }
    }
    
}