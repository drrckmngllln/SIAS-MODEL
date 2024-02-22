using MySql.Data.MySqlClient;
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
        public string fullname { get; set; }
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

        public List<SaveStudentAccountsParams> GetStudentAccounts()
        {
            var students = new List<SaveStudentAccountsParams>();

            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("select * from student_accounts", con);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var list = new SaveStudentAccountsParams
                {
                    id = reader.GetInt32("id"),
                    id_number = reader["id_number"].ToString(),
                    sy_enrolled = reader["sy_enrolled"].ToString(),
                    school_year = reader["school_year"].ToString(),
                    fullname = reader["fullname"].ToString(),
                    last_name = reader["last_name"].ToString(),
                    first_name = reader["first_name"].ToString(),
                    middle_name = reader["middle_name"].ToString(),
                    gender = reader["gender"].ToString(),
                    civil_status = reader["civil_status"].ToString(),
                    date_of_birth = reader["date_of_birth"].ToString(),
                    place_of_birth = reader["place_of_birth"].ToString(),
                    nationality = reader["nationality"].ToString(),
                    religion = reader["religion"].ToString(),
                    status = reader["status"].ToString(),
                    contact_no = reader["contact_no"].ToString(),
                    email = reader["email"].ToString(),
                    elem = reader["elem"].ToString(),
                    jhs = reader["jhs"].ToString(),
                    shs = reader["shs"].ToString(),
                    elem_year = reader["elem_year"].ToString(),
                    jhs_year = reader["jhs_year"].ToString(),
                    shs_year = reader["shs_year"].ToString(),
                    mother_name = reader["mother_name"].ToString(),
                    father_name = reader["father_name"].ToString(),
                    home_address = reader["home_address"].ToString(),
                    f_occupation = reader["f_occupation"].ToString(),
                    m_occupation = reader["m_occupation"].ToString(),
                    type_of_student = reader["type_of_student"].ToString(),
                    date_of_admission = reader["date_of_admission"].ToString(),
                };
                students.Add(list);
            }
            return students;
        }
    }
}
