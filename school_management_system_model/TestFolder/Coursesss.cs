using school_management_system_model.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_system_model.TestFolder
{
    internal class Coursesss
    {
        public int id { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        //public Levels level { get; set; }
        public string level_id { get; set; }
        //public Campuses campus { get; set; }
        public string campus_id { get; set; }
        //public Departments deparmtment { get; set; }
        public string department_id { get; set; }
        public decimal max_units { get; set; }
        public string status { get; set; }
    }
}
