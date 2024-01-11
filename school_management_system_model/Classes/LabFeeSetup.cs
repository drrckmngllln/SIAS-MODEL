using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_system_model.Classes
{
    internal class LabFeeSetup
    {
        public int id { get; set; }
        public string category { get; set; }
        public string description { get; set; }
        public string campus { get; set; }
        public decimal first_year { get; set; }
        public decimal second_year { get; set; }
        public decimal third_year { get; set; }
        public decimal fourth_year { get; set; }

        public string search { get; set; }

        public DataTable loadRecords()
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from lab_fee_setup", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable loadCampuses()
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from campuses", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public void addRecords()
        {
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("insert into lab_fee_setup(category, campus, first_year, second_year, third_year, fourth_year, description) " +
                "values(@1,@2,@3,@4,@5,@6,@7)", con);
            cmd.Parameters.AddWithValue("@1", category);
            cmd.Parameters.AddWithValue("@2", campus);
            cmd.Parameters.AddWithValue("@3", first_year);
            cmd.Parameters.AddWithValue("@4", second_year);
            cmd.Parameters.AddWithValue("@5", third_year);
            cmd.Parameters.AddWithValue("@6", fourth_year);
            cmd.Parameters.AddWithValue("@7", description);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void editRecords()
        {
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("update lab_fee_setup set category=@1, campus=@2, first_year=@3, second_year=@4, third_year=@5, " +
                "fourth_year=@6, description=@7 where id = '" + id + "'", con);
            cmd.Parameters.AddWithValue("@1", category);
            cmd.Parameters.AddWithValue("@2", campus);
            cmd.Parameters.AddWithValue("@3", first_year);
            cmd.Parameters.AddWithValue("@4", second_year);
            cmd.Parameters.AddWithValue("@5", third_year);
            cmd.Parameters.AddWithValue("@6", fourth_year);
            cmd.Parameters.AddWithValue("@7", description);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public DataTable deleteRecords(int id)
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter();
            da.SelectCommand = new MySqlCommand("delete from lab_fee_setup where id ='" + id + "'", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable searchRecords(string search)
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from lab_fee_setup where concat(description) like '%"+ search +"%'", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        
    }
}
