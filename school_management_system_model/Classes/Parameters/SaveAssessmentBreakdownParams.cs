﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_system_model.Classes.Parameters
{
    internal class SaveAssessmentBreakdownParams
    {
        public string id { get; set; }
        public string id_number { get; set; }
        public string school_year { get; set; }
        public string fee_type { get; set; }
        public decimal amount { get; set; }
    }
}
