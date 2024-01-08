using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_system_model.Loggers.Authentication
{
    internal class AuthenticationLogger
    {
        public AuthenticationLogger(string name, string accessLevel, string date, string time)
        {
            Name = name;
            AccessLevel = accessLevel;
            Date = date;
            Time = time;
        }

        public string Name { get; }
        public string AccessLevel { get; }
        public string Date { get; }
        public string Time { get; }

        public void LoginLogger()
        {
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("insert into authentication_logger(name, access_level, date, time) values(@1,@2,@3,@4)", con);
            cmd.Parameters.AddWithValue("@1", Name);
            cmd.Parameters.AddWithValue("@2", AccessLevel);
            cmd.Parameters.AddWithValue("@3", Date);
            cmd.Parameters.AddWithValue("@4", Time);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
