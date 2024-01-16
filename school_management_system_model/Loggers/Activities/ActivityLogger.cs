using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_system_model.Loggers
{
    public class ActivityLogger
    {
        
        public string Name { get; set; }
        public string AccessLevel { get; set; }
        public string Activity { get; set; }
        public string Date { get; } = DateTime.Now.ToString("mm-dd-yyyy");
        public string Time { get; } = DateTime.Now.ToString("hh:mm:ss tt");

        public void activityLogger(string email, string activity)
        {
            var con = new MySqlConnection(connection.con());

            var da = new MySqlDataAdapter("select * from users where email='" + email + "'", con);
            var dt = new DataTable();
            da.Fill(dt);
            Name = dt.Rows[0]["fullname"].ToString();
            AccessLevel = dt.Rows[0]["access_level"].ToString();


            con.Open();
            var cmd = new MySqlCommand("insert into activity_logger(name, access_level, activity, date, time) values(@1,@2,@3,@4,@5)", con);
            cmd.Parameters.AddWithValue("@1", Name);
            cmd.Parameters.AddWithValue("@2", AccessLevel);
            cmd.Parameters.AddWithValue("@3", activity);
            cmd.Parameters.AddWithValue("@4", Date);
            cmd.Parameters.AddWithValue("@5", Time);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
