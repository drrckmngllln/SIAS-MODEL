using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_system_model.Core.Entities.Transaction
{
    internal class CashierLog
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public string name { get; set; }
        public string reference_no { get; set; }
        public string particulars { get; set; }
        public string school_year { get; set; }
        public string department { get; set; }
        public decimal credit { get; set; }
        public decimal debit { get; set; }
        public decimal balance { get; set; }

    }
}
