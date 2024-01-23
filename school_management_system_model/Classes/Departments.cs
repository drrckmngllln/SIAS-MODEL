using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_system_model.Classes
{
    internal class Departments
    {
        public int id { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public string campus_id { get; set; }

        public List<Departments> GetDepartments()
        {
            var list = new List<Departments>();

            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("select * from departments", con);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var campus = new Campuses().GetCampuses().FirstOrDefault(x => x.id == reader.GetInt32("campus_id")).code;
                var departments = new Departments
                {
                    id = reader.GetInt32("id"),
                    code = reader.GetString("code"),
                    description = reader.GetString("description"),
                    campus_id = campus
                };
                list.Add(departments);
            }
            con.Close();
            return list;
        }
    }
}
