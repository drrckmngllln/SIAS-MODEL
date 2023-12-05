using MySql.Data.MySqlClient;
using school_management_system_model.Forms.settings;
using System.Data;

namespace school_management_system_model.Classes
{
    internal class MiscellaneousFeeSetup
    {
        public int id { get; set; }
        public string category { get; set; }
        public string campus { get; set; }
        public decimal first_year { get; set; }
        public decimal second_year { get; set; }
        public decimal third_year { get; set; }
        public decimal fourth_year { get; set; }
        public string remarks { get; set; }
        public string search { get; set; }


        public DataTable loadRecords()
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from miscellaneous_fee_setup", con);
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
        
        public void AddRecords()
        {
            var con = new MySqlConnection(connection.con());
            con.Open();
            var sql = "insert into miscellaneous_fee_setup(category, campus, first_year, second_year, third_year, fourth_year) values(@1,@2,@3,@4,@5,@6)";
            var cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@1", category);
            cmd.Parameters.AddWithValue("@2", campus);
            cmd.Parameters.AddWithValue("@3", first_year);
            cmd.Parameters.AddWithValue("@4", second_year);
            cmd.Parameters.AddWithValue("@5", third_year);
            cmd.Parameters.AddWithValue("@6", fourth_year);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void editRecords()
        {
            var con = new MySqlConnection(connection.con());
            con.Open();
            var sql = "update miscellaneous_fee_setup set category=@1, campus=@2, first_year=@3, second_year=@4, third_year=@5, fourth_year=@6 where id='"+ id +"'";
            var cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@1", category);
            cmd.Parameters.AddWithValue("@2", campus);
            cmd.Parameters.AddWithValue("@3", first_year);
            cmd.Parameters.AddWithValue("@4", second_year);
            cmd.Parameters.AddWithValue("@5", third_year);
            cmd.Parameters.AddWithValue("@6", fourth_year);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Close();
        }
        public void deleteRecords()
        {
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("delete from miscellaneous_fee_setup where id='" + id + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void searchRecords()
        {
            var con = new MySqlConnection(connection.con());
            var sql = "select * from miscellaneous_fee_setup where concat(category, campus) like '%" + search + "%'";
            var da = new MySqlDataAdapter(sql, con);
            da.Fill(frm_miscellaneous_setup.instance.dt);
        }
    }
}
