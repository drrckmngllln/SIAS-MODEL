using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_system_model.Core.Entities.Transaction
{
    internal class FeeSummary
    {
        public int id { get; set; }
        public string id_number { get; set; }
        public string school_year { get; set; }
        public decimal current_assessment { get; set; }
        public decimal discounts { get; set; }
        public decimal previous_balance { get; set; }
        public decimal current_receivable { get; set; }
    }
}
