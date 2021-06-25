using Core.Entitites;
using System;
using System.Collections.Generic;


namespace HR_DEMO.Models
{
    public class AllowanceViewModel
    {

        public int? ALLOWANCE_ID { get; set; }
        public int MIN_VALUE { get; set; }
        
        public int SEQID { get; set; }
        public int MAX_VALUE { get; set; }
        public string ALLOWANCE_NAME { get; set; }
    }
}
