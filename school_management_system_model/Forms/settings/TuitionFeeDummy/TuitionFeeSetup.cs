using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_system_model.Forms.settings.TuitionFeeDummy
{
    internal class TuitionFeeSetup
    {
        public string uid { get; set; }
        public string category { get; set; }
        public string description { get; set; }
        public string campus { get; set; }
        public string year_level { get; set; }
        public string semester { get; set; }
        public decimal amount { get; set; }
        public DataTable loadRecords(string semester)
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from tuitionfeesetup where semester='" + semester + "'", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public void addRecords()
        {
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("insert into tuitionfeesetup(uid, category, description, campus, year_level, semester, amount) " +
                "values(@1,@2,@3,@4,@5,@6,@7)", con);
            cmd.Parameters.AddWithValue("@1", uid);
            cmd.Parameters.AddWithValue("@2", category);
            cmd.Parameters.AddWithValue("@3", description);
            cmd.Parameters.AddWithValue("@4", campus);
            cmd.Parameters.AddWithValue("@5", year_level);
            cmd.Parameters.AddWithValue("@6", semester);
            cmd.Parameters.AddWithValue("@7", amount);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void editRecords(int id)
        {
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("update tuitionfeesetup set uid=@1, category=@2, description=@3, campus=@4, year_level=@5, semester=@6, amount=@7 " +
                "where id='"+ id +"'", con);
            cmd.Parameters.AddWithValue("@1", uid);
            cmd.Parameters.AddWithValue("@2", category);
            cmd.Parameters.AddWithValue("@3", description);
            cmd.Parameters.AddWithValue("@4", campus);
            cmd.Parameters.AddWithValue("@5", year_level);
            cmd.Parameters.AddWithValue("@6", semester);
            cmd.Parameters.AddWithValue("@7", amount);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void deleteRecords(int id)
        {
            var con = new MySqlConnection (connection.con());
            con.Open();
            var cmd = new MySqlCommand("delete from tuitionfeesetup where id='" + id + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public DataTable searchRecords(string search)
        {
            var con = new MySqlConnection (connection.con());
            var da = new MySqlDataAdapter("select * from tuitionfeesetup where concat(category, description) like '%" + search + "%'", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
