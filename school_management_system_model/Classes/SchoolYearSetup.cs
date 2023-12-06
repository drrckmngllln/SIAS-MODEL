using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace school_management_system_model.Classes
{
    internal class SchoolYearSetup
    {
        public int id { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public string semester { get; set; }
        public string is_current { get; set; }

        public DataTable loadRecords()
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from school_year order by id desc", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public void addRecords()
        {
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("insert into school_year(code, description, school_year_from, school_year_to, semester, is_current) " +
                "values(@1,@2,@3,@4,@5,@6)", con);
            cmd.Parameters.AddWithValue("@1", code);
            cmd.Parameters.AddWithValue("@2", description);
            cmd.Parameters.AddWithValue("@3", from);
            cmd.Parameters.AddWithValue("@4", to);
            cmd.Parameters.AddWithValue("@5", semester);
            cmd.Parameters.AddWithValue("@6", is_current);
            cmd.ExecuteNonQuery();
            con.Close();
            
        }
        public void EditRecords(int id)
        {
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("update school_year set code=@1, description=@2, school_year_from=@3, " +
                "school_year_to=@4, semester=@5, is_current=@6 where id='" + id +"'", con);
            cmd.Parameters.AddWithValue("@1", code);
            cmd.Parameters.AddWithValue("@2", description);
            cmd.Parameters.AddWithValue("@3", from);
            cmd.Parameters.AddWithValue("@4", to);
            cmd.Parameters.AddWithValue("@5", semester);
            cmd.Parameters.AddWithValue("@6", is_current);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public DataTable searchRecords(string search)
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from school_year where concat(code, description) " +
                "like '%" + search + "%' order by id desc", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public void deleteRecords(int id)
        {
            var con = new MySqlConnection (connection.con());
            con.Open();
            var cmd = new MySqlCommand("delete from school_year where id='" + id + "'", con);
            cmd.ExecuteNonQuery ();
            con.Close();
        }
    }
}
