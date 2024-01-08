using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_system_model.Loggers
{
    internal class ActivityLogger
    {
        public ActivityLogger(string name, string accessLevel, string activity, string date, string time)
        {
            Name = name;
            AccessLevel = accessLevel;
            Activity = activity;
            Date = date;
            Time = time;
        }

        public string Name { get; }
        public string AccessLevel { get; }
        public string Activity { get; }
        public string Date { get; }
        public string Time { get; }

        public void activityLogger()
        {
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("insert into activity_logger(name, access_level, activity, date, time) values(@1,@2,@3,@4,@5)", con);
            cmd.Parameters.AddWithValue("@1", Name);
            cmd.Parameters.AddWithValue("@1", AccessLevel);
            cmd.Parameters.AddWithValue("@1", Activity);
            cmd.Parameters.AddWithValue("@1", Date);
            cmd.Parameters.AddWithValue("@1", Time);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
