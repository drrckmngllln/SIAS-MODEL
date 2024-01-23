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

        
        public List<Levels> GetLevels()
        {
            var list = new List<Levels>();

            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("select * from levels", con);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var level = new Levels
                {
                    id = reader.GetInt32("id"),
                    code = reader.GetString("code"),
                    description = reader.GetString("description"),
                    status = reader.GetString("status")
                };
                list.Add(level);
            }
            con.Close();
            return list;
        }
    }
}
