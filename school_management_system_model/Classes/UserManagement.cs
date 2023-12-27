using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_system_model.Classes
{
    internal class UserManagement
    {
        public string last_name { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string fullname { get; set; }
        public string employee_id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string access_level { get; set; }
        public int add { get; set; }
        public int edit { get; set; }
        public int delete { get; set; }

        public DataTable loadRecords()
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from users", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable searchRecords(string search)
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from users where concat(fullname, employee_id, email) like '%" + search + "%'", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public void addUser()
        {
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("insert into users(last_name, first_name, middle_name, fullname, employee_id, email, password, access_level, " +
                "is_add, is_edit, is_delete) values(@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11)", con);
            cmd.Parameters.AddWithValue("@1", last_name);
            cmd.Parameters.AddWithValue("@2", first_name);
            cmd.Parameters.AddWithValue("@3", middle_name);
            cmd.Parameters.AddWithValue("@4", fullname);
            cmd.Parameters.AddWithValue("@5", employee_id);
            cmd.Parameters.AddWithValue("@6", email);
            cmd.Parameters.AddWithValue("@7", password);
            cmd.Parameters.AddWithValue("@8", access_level);
            cmd.Parameters.AddWithValue("@9", add);
            cmd.Parameters.AddWithValue("@10", edit);
            cmd.Parameters.AddWithValue("@11", delete);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void editUser(int id)
        {
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("update users set last_name=@1, first_name=@2, middle_name=@3, fullname=@4, employee_id=@5, email=@6, password=@7, " +
                "access_level=@8, is_add=@9, is_edit=@10, is_delete=@11 where id='" + id + "'", con);
            cmd.Parameters.AddWithValue("@1", last_name);
            cmd.Parameters.AddWithValue("@2", first_name);
            cmd.Parameters.AddWithValue("@3", middle_name);
            cmd.Parameters.AddWithValue("@4", fullname);
            cmd.Parameters.AddWithValue("@5", employee_id);
            cmd.Parameters.AddWithValue("@6", email);
            cmd.Parameters.AddWithValue("@7", password);
            cmd.Parameters.AddWithValue("@8", access_level);
            cmd.Parameters.AddWithValue("@9", add);
            cmd.Parameters.AddWithValue("@10", edit);
            cmd.Parameters.AddWithValue("@11", delete);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void deleteUser(int id)
        {
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("delete from users where id='" + id + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
