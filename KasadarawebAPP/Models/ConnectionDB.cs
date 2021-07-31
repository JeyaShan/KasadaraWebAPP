using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KasadarawebAPP.Models
{
    public class ConnectionDB :DbContext
    {
        public DbSet<Employeetable> employeetables { get; set; }
        public DbSet<Gradetable> gradetables { get; set; }
        public DbSet<Departmenttable> departmenttables { get; set; }
    }
}