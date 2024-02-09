using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_system_model.Core.Entities.Settings
{
    internal class Discount
    {
        public int id { get; set; }
        public string code { get; set; }
        public string discount_target { get; set; }
        public string description { get; set; }
        public int discount_percentage { get; set; }
    }
}
