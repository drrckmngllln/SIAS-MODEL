using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_system_model.Classes
{
    internal class AdmissionSchedule
    {
        public string code { get; set; }
        public string description { get; set; }
        public string schedule_from { get; set; }
        public string schedule_to { get; set; }

        public DataTable loadRecords()
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from admission_schedule order by id desc", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable searchRecords(string search)
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from admission_schedule where concat(code, description) like '%" + search + "%'", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public void AddRecords()
        {
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("insert into admission_schedule(code, description, schedule_from, schedule_to) values(@1,@2,@3,@4)", con);
            cmd.Parameters.AddWithValue("@1", code);
            cmd.Parameters.AddWithValue("@2", description);
            cmd.Parameters.AddWithValue("@3", schedule_from);
            cmd.Parameters.AddWithValue("@4", schedule_to);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void EditRecords(int id)
        {
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("update admission_schedule set code=@1, description=@2, schedule_from=@3, schedule_to=@4 " +
                "where id='"+ id +"'", con);
            cmd.Parameters.AddWithValue("@1", code);
            cmd.Parameters.AddWithValue("@2", description);
            cmd.Parameters.AddWithValue("@3", schedule_from);
            cmd.Parameters.AddWithValue("@4", schedule_to);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void DeleteRecords(int id)
        {
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("delete from admission schedule where id='" + id + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
