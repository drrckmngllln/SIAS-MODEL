using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_system_model.Classes
{
    internal class DiscountSetup
    {
        public string code { get; set; }
        public string description { get; set; }
        public int discount_percentage { get; set; }

        public DataTable loadRecords()
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from discount_setup", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public void addRecords()
        {
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("insert into discount_setup(code, description, discount_percentage) " +
                "values(@1,@2,@3)", con);
            cmd.Parameters.AddWithValue("@1", code);
            cmd.Parameters.AddWithValue("@2", description);
            cmd.Parameters.AddWithValue("@3", discount_percentage);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void editRecords(int id)
        {
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("update discount_setup set code=@1, description=@2, discount_percentage=@3 " +
                "where id='"+ id +"'", con);
            cmd.Parameters.AddWithValue("@1", code);
            cmd.Parameters.AddWithValue("@2", description);
            cmd.Parameters.AddWithValue("@3", discount_percentage);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void deleteRecords(int id)
        {
            var con = new MySqlConnection (connection.con());
            con.Open();
            var cmd = new MySqlCommand("delete from discount_setup where id='" + id + "'", con);
            cmd.ExecuteNonQuery();
            con.Close ();
        }
    }
}
