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
        public string date { get; set; }
        public string name { get; set; }
        public string reference_no { get; set; }
        public string particulars { get; set; }
        public string school_year { get; set; }
        public string department { get; set; }
        public string credit { get; set; }
        public string debit { get; set; }
        public string balance { get; set; }
    }
}
