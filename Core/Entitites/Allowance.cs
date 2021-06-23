using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entitites
{
    public partial class Allowance
    {
      
        public int? ALLOWANCE_ID { get; set; }
        public int MIN_VALUE { get; set; }
        [Key]
        public int SEQID { get; set; }
        public int MAX_VALUE { get; set; }
        public string ALLOWANCE_NAME { get; set; }
        public virtual ICollection<EmployeeSalary> EmployeeSalary { get; set; }
    }
}
