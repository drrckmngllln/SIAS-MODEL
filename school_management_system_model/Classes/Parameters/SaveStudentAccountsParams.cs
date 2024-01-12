using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_system_model.Classes.Parameters
{
    internal class SaveStudentAccountsParams
    {
        public int id { get; set; }
        public string semester { get; set; }
        public string id_number { get; set; }
        public string sy_enrolled { get; set; }
        public string school_year { get; set; }
        public string full_name { get; set; }
        public string last_name { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string gender { get; set; }
        public string civil_status { get; set; }
        public string date_of_birth { get; set; }
        public string place_of_birth { get; set; }
        public string nationality { get; set; }
        public string religion { get; set; }
        public string status { get; set; }

        public string contact_no { get; set; }
        public string email { get; set; }

        public string elem { get; set; }
        public string jhs { get; set; }
        public string shs { get; set; }
        public string elem_year { get; set; }
        public string jhs_year { get; set; }
        public string shs_year { get; set; }
        public string mother_name { get; set; }

        public string mother_no { get; set; }
        public string father_name { get; set; }
        public string father_no { get; set; }

        public string home_address { get; set; }

        public string f_occupation { get; set; }
        public string m_occupation { get; set; }

        public string type_of_student { get; set; }

        public string date_of_admission { get; set; }

        public string course { get; set; }
        public string campus { get; set; }
    }
}
