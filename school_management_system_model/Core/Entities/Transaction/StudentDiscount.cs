using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_system_model.Core.Entities.Transaction
{
    internal class StudentDiscount
    {
        public int id { get; set; }
        public string id_number { get; set; }
        public string code { get; set; }
        public string discount_target { get; set; }
        public string description { get; set; }
        public int discount_percentage { get; set; }
    }
}
