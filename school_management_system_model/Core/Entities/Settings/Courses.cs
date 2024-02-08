using MySql.Data.MySqlClient;
using school_management_system_model.Forms.settings.TuitionFeeDummy;
using System.Collections.Generic;
using System.Linq;

namespace school_management_system_model.Core.Entities
{
    internal class Courses
    {
        public int id { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public string level { get; set; }
        public string campus { get; set; }
        public string department { get; set; }
        public string max_units { get; set; }
        public string status { get; set; }
    }
}
