using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_system_model.Classes
{
    internal class OtherFeesSetup
    {
        public string category { get; set; }
        public string description { get; set; }
        public string campus { get; set; }
        public decimal first_year { get; set; }
        public decimal second_year { get; set; }
        public decimal third_year { get; set; }
        public decimal fourth_year { get; set; }

        public DataTable loadRecords()
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from other_fees", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable searchRecords(string search)
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from other_fees where concat(description) like '%" + search + "%'", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable loadCampus()
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from campuses", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public void deleteRecords(int id)
        {
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("delete from other_fees where id='" + id + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void addRecords()
        {
            var con = new MySqlConnection (connection.con());
            con.Open();
            var cmd = new MySqlCommand("insert into other_fees(category, description, campus, first_year, second_year, third_year, fourth_year) " +
                "values(@1,@2,@3,@4,@5,@6,@7)", con);
            cmd.Parameters.AddWithValue("@1", category);
            cmd.Parameters.AddWithValue("@2", description);
            cmd.Parameters.AddWithValue("@3", campus);
            cmd.Parameters.AddWithValue("@4", first_year);
            cmd.Parameters.AddWithValue("@5", second_year);
            cmd.Parameters.AddWithValue("@6", third_year);
            cmd.Parameters.AddWithValue("@7", fourth_year);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void editRecords(int id)
        {
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("update other_fees set category=@1, description=@2, campus=@3, first_year=@4, second_year=@5, third_year=@6, fourth_year=@7 " +
                "where id='"+ id +"'", con);
            cmd.Parameters.AddWithValue("@1", category);
            cmd.Parameters.AddWithValue("@2", description);
            cmd.Parameters.AddWithValue("@3", campus);
            cmd.Parameters.AddWithValue("@4", first_year);
            cmd.Parameters.AddWithValue("@5", second_year);
            cmd.Parameters.AddWithValue("@6", third_year);
            cmd.Parameters.AddWithValue("@7", fourth_year);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
