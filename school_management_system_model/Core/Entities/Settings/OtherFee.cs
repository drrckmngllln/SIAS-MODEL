using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_system_model.Core.Entities.Settings
{
    internal class OtherFee
    {
        public int id { get; set; }
        public string uid { get; set; }
        public string category { get; set; }
        public string description { get; set; }
        public string campus { get; set; }
        public string level { get; set; }
        public string year_level { get; set; }
        public string semester { get; set; }
        public decimal amount { get; set; }
    }
}
