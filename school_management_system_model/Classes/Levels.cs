using MySql.Data.MySqlClient;
using school_management_system_model.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_system_model.Forms.settings.TuitionFeeDummy
{
    internal class Levels
    {
        public int id { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public string status { get; set; }

        

    }
}
