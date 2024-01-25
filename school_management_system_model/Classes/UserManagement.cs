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
        public int id { get; set; }
        public string last_name { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string fullname { get; set; }
        public string employee_id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string access_level { get; set; }
        public string department { get; set; }
        public int add { get; set; }
        public int edit { get; set; }
        public int delete { get; set; }
        public int administrator { get; set; }

        public async Task<List<UserManagement>> GetUserManagementsAsync()
        {
            var list = new List<UserManagement>();
            var con = new MySqlConnection(connection.con());
            await con.OpenAsync();
            var cmd = new MySqlCommand("select * from users", con);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var user = new UserManagement
                {
                    id = reader.GetInt32("id"),
                    last_name = reader.GetString("last_name"),
                    first_name = reader.GetString("first_name"),
                    middle_name = reader.GetString("middle_name"),
                    fullname = reader.GetString("fullname"),
                    employee_id = reader.GetString("employee_id"),
                    email = reader.GetString("email"),
                    password = reader.GetString("password"),
                    department = reader.GetString("department"),
                    access_level = reader.GetString("access_level"),
                    add = reader.GetInt32("is_add"),
                    edit = reader.GetInt32("is_edit"),
                    delete = reader.GetInt32("is_delete"),
                    administrator = reader.GetInt32("is_administrator"),
                };
                list.Add(user);
            }
            await con.CloseAsync();
            return list;
        }
        public DataTable loadRecords(string department)
        {
            DataTable result;
            if (department == "All")
            {
                var con = new MySqlConnection(connection.con());
                var da = new MySqlDataAdapter("select * from users", con);
                var dt = new DataTable();
                da.Fill(dt);
                result =  dt;
            }
            else
            {
                var con = new MySqlConnection(connection.con());
                var da = new MySqlDataAdapter("select * from users where department='" + department + "'", con);
                var dt = new DataTable();
                da.Fill(dt);
                result =  dt;
            }
            return result;
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
                "is_add, is_edit, is_delete, department, is_administrator) values(@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13)", con);
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
            cmd.Parameters.AddWithValue("@12", department);
            cmd.Parameters.AddWithValue("@13", administrator);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void editUser(int id)
        {
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("update users set last_name=@1, first_name=@2, middle_name=@3, fullname=@4, employee_id=@5, email=@6, password=@7, " +
                "access_level=@8, is_add=@9, is_edit=@10, is_delete=@11, department=@12, is_administrator=@13 where id='" + id + "'", con);
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
            cmd.Parameters.AddWithValue("@12", department);
            cmd.Parameters.AddWithValue("@13", administrator);

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
