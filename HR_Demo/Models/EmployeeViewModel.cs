using Core.Entitites;
using System;
using System.Collections.Generic;

namespace HR_DEMO.Models
{
    public class EmployeeViewModel
    {
       
        public int SEQ_ID { get; set; }
        public int? EMP_ID { get; set; }
        public int? DEPARTMENT_ID { get; set; }
        public DateTime? DOB { get; set; }
        public string EMP_NAME { get; set; }
        public int? COUNTRY_ID { get; set; }
        public string CONTRACT_TYPE { get; set; }
        public int? POSITION_ID { get; set; }

        public  List<EmployeeSalary> EmployeeSalary { get; set; }

        public List<AllowanceViewModel> Allowance { get; set; }
    }
}
