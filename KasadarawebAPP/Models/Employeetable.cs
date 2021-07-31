using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KasadarawebAPP.Models
{
    [Table("Employee")]
    public class Employeetable
    {
        [Key]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int ManagerID { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
      
    }
}