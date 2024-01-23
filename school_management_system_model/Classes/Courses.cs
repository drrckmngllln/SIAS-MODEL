using MySql.Data.MySqlClient;
using school_management_system_model.Forms.settings.TuitionFeeDummy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_system_model.Classes
{
    internal class Courses
    {
        public int id { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public string level_id { get; set; }
        public string campus_id { get; set; }
        public string department_id { get; set; }
        public string max_units { get; set; }
        public string status { get; set; }

        public List<Courses> GetCourses()
        {
            var list = new List<Courses>();
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("select * from courses", con);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var level = new Levels().GetLevels().FirstOrDefault(x => x.id == reader.GetInt32("level_id")).code;
                var campus = new Campuses().GetCampuses().FirstOrDefault(x => x.id == reader.GetInt32("campus_id")).code;
                var course = new Courses
                {
                    id = reader.GetInt32("id"),
                    code = reader.GetString("code"),
                    description = reader.GetString("description"),
                    level_id = level,
                    campus_id = reader.GetString("campus_id"),
                    department_id = reader.GetString("department_id"),
                    max_units = reader.GetString("max_units"),
                    status = reader.GetString("status")
                };
                list.Add(course);
            }
            con.Close();
            return list;
        }
    }
}
