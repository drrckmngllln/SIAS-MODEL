using Microsoft.Reporting.Map.WebForms.BingMaps;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_system_model.Core.Entities
{
    internal class SectionSubjects
    {
        public int id { get; set; }
        public string unique_id { get; set; }
        public string section_code { get; set; }
        public string curriculum { get; set; }
        public string year_level { get; set; }
        public string semester { get; set; }
        public string subject_code { get; set; }
        public string descriptive_title { get; set; }
        public decimal total_units { get; set; }
        public decimal lecture_units { get; set; }
        public decimal lab_units { get; set; }
        public string pre_requisite { get; set; }
        public string time { get; set; }
        public string day { get; set; }
        public string room { get; set; }
        public string instructor { get; set; }

    }
}
