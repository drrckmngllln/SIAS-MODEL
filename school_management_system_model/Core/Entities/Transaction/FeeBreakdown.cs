using Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_system_model.Core.Entities.Settings
{
    internal class FeeBreakdown
    {
        public int id { get; set; }
        public string id_number { get; set; }
        public string school_year { get; set; }
        public decimal downpayment { get; set; }
        public decimal prelim { get; set; }
        public decimal midterm { get; set; }
        public decimal semi_finals { get; set; }
        public decimal finals { get; set; }
        public decimal total { get; set; }
        public decimal downpayment_original { get; set; }
        public decimal prelim_original { get; set; }
        public decimal midterm_original { get; set; }
        public decimal semi_finals_original { get; set; }
        public decimal finals_original { get; set; }
        public decimal total_original { get; set; }
    }
}
