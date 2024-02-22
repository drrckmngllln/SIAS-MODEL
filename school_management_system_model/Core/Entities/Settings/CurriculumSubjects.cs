using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace school_management_system_model.Core.Entities
{
    internal class CurriculumSubjects
    {
        public int id { get; set; }
        public string uid { get; set; }
        public string curriculum { get; set; }
        public string year_level { get; set; }
        public string semester { get; set; }
        public string code { get; set; }
        public string descriptive_title { get; set; }
        public string total_units { get; set; }
        public string lecture_units { get; set; }
        public string lab_units { get; set; }
        public string pre_requisite { get; set; }
        public string total_hrs_per_week { get; set; }
    }
}
