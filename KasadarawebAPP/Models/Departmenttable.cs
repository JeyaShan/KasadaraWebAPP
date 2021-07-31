using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KasadarawebAPP.Models
{
    [Table("Department")]
    public class Departmenttable
    {
       [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        
    }
}