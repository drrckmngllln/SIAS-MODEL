using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_system_model.Core.Entities
{
    internal class Sections
    {
        public int id { get; set; }
        public string unique_id { get; set; }
        public string section_code { get; set; }
        public string course { get; set; }
        public int year_level { get; set; }
        public string section { get; set; }
        public string semester { get; set; }
        public int number_of_students { get; set; }
        public int max_number_of_students { get; set; }
        public string status { get; set; }
        public string remarks { get; set; }
    }
}
