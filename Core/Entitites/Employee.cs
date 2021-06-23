using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entitites
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeeSalary = new HashSet<EmployeeSalary>();
        }
        [Key]
        public int SEQ_ID { get; set; }
        public int? EMP_ID { get; set; }
        public int? DEPARTMENT_ID { get; set; }
        public DateTime? DOB { get; set; }
        public string EMP_NAME { get; set; }
        public int? COUNTRY_ID { get; set; }
        public string CONTRACT_TYPE { get; set; }
        public int? POSITION_ID { get; set; }

        public virtual ICollection<EmployeeSalary> EmployeeSalary { get; set; }
    }
}
