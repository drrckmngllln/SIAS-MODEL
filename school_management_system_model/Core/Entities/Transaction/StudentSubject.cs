﻿using MySql.Data.MySqlClient;
using school_management_system_model.Classes;
using school_management_system_model.Reports.Datasets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_system_model.Core.Entities
{
    internal class StudentSubject
    {
        public int id { get; set; }
        public string id_number_id { get; set; }
        public string unique_id { get; set; }
        public string school_year_id { get; set; }
        public string subject_code { get; set; }
        public string descriptive_title { get; set; }
        public string pre_requisite { get; set; }
        public string total_units { get; set; }
        public string lecture_units { get; set; }
        public string lab_units { get; set; }
        public string time { get; set; }
        public string day { get; set; }
        public string room { get; set; }
        public string instructor_id { get; set; }
        public string grade { get; set; }
        public string remarks { get; set; }

    }
}
