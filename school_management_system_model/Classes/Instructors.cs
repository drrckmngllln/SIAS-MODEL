using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_system_model.Classes
{
    internal class Instructors
    {
        public int id { get; set; }
        public string fullname { get; set; }
        public string department { get; set; }
        public string position { get; set; }
        public string search { get; set; }

        public DataTable loadRecords()
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from instructors", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable loadDepartments()
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from departments", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable searchRecords()
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from instructors where concat(fullname, department, position) like '%" + search + "%'", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public void addRecords()
        {
            var con = new MySqlConnection( connection.con());
            con.Open();
            var cmd = new MySqlCommand("insert into instructors(fullname, department, position) values(@1,@2,@3)", con);
            cmd.Parameters.AddWithValue("@1", fullname);
            cmd.Parameters.AddWithValue("@2", department);
            cmd.Parameters.AddWithValue("@3", position);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void editRecords()
        {
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("update instructors set fullname=@1, department=@2, position=@3 where id='" +id+ "'", con);
            cmd.Parameters.AddWithValue("@1", fullname);
            cmd.Parameters.AddWithValue("@2", department);
            cmd.Parameters.AddWithValue("@3", position);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public DataTable deleteRecords()
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter();
            da.SelectCommand = new MySqlCommand("delete from instructors where id='" + id + "'", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
