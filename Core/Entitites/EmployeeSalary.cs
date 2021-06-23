using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entitites
{
    public partial class EmployeeSalary
    {

        public int? ALLOWANCE_ID { get; set; }
        public int EMP_ID { get; set; }
        public int SEQ_ID { get; set; }
        public int ALLOWANCE_AMT { get; set; }
        public Employee Employee { get; set; }
        public Allowance Allowance { get; set; }

    }
}
