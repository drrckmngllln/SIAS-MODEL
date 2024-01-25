using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_system_model.Classes
{
    internal class SchoolYear
    {
        public int id { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public string school_year_from { get; set; }
        public string school_year_to { get; set; }
        public string semester { get; set; }
        public string is_current { get; set; }

        public List<SchoolYear> GetSchoolYears()
        {
            var list = new List<SchoolYear>();
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("select * from school_year", con);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var schoolYear = new SchoolYear
                {
                    id = reader.GetInt32("id"),
                    code = reader.GetString("code"),
                    description = reader.GetString("description"),
                    school_year_from = reader.GetString("school_year_from"),
                    school_year_to = reader.GetString("school_year_to"),
                    semester = reader.GetString("semester"),
                    is_current = reader.GetString("is_current")
                };
                list.Add(schoolYear);
            }
            con.Close();
            return list;
        }
    }
}
