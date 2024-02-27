using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_system_model.Core.Entities.Transaction
{
    internal class NonAssessment
    {
       public int id { get; set; }
        public string id_number { get; set; }
        public string school_year { get; set; }
        public string date { get; set; }
        public string course_id { get; set; }
        public string year_level { get; set;}
        public string semester { get; set; }
        public int reference_no { get; set; }
        public string particulars { get; set; }
        public decimal amount { get; set; }
        public string cashier_in_charge { get; set; }
       
    }
}
