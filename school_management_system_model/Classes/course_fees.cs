using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_system_model.Classes
{
    internal class course_fees
    {
        public int id { get; set; }
        public string course_code { get; set; }
        public string course { get; set; }
        public string year_level { get; set; }
        public string fee_type { get; set; }
        public decimal amount { get; set; }
        public string remarks { get; set; }

        public void saveFees()
        {
            var con = new MySqlConnection(connection.con());
            con.Open();
            var sql = "insert into course_fees(course_code, course, year_level, fee_type, amount, remarks) " +
                "values(@1,@2,@3,@4,@5,@6)";
            var cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@1", course_code);
            cmd.Parameters.AddWithValue("@2", course);
            cmd.Parameters.AddWithValue("@3", year_level);
            cmd.Parameters.AddWithValue("@4", fee_type);
            cmd.Parameters.AddWithValue("@5", amount);
            cmd.Parameters.AddWithValue("@6", remarks);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
