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
        public string department_id { get; set; }
        public string position { get; set; }

        public List<Instructors> GetInstructors()
        {
            //var list = new List<Instructors>();
            //var con = new MySqlConnection(connection.con());
            //con.Open();
            //var cmd = new MySqlCommand("select * from instructors", con);
            //var reader = cmd.ExecuteReader();
            //while (reader.Read())
            //{
            //    var department = new Departments().GetDepartments().FirstOrDefault(x => x.id == reader.GetInt32("department_id"));
            //    var instructors = new Instructors
            //    {
            //        id = reader.GetInt32("id"),
            //        fullname = reader.GetString("fullname"),
            //        department_id = department.code,
            //        position = reader.GetString("position"),
            //    };
            //    list.Add(instructors);
            //}
            //con.Close();
            //return list;
            return null;
        }

        public void addRecords()
        {
            var con = new MySqlConnection( connection.con());
            con.Open();
            var cmd = new MySqlCommand("insert into instructors(fullname, department_id, position) values(@1,@2,@3)", con);
            cmd.Parameters.AddWithValue("@1", fullname);
            cmd.Parameters.AddWithValue("@2", department_id);
            cmd.Parameters.AddWithValue("@3", position);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void editRecords()
        {
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("update instructors set fullname=@1, department_id=@2, position=@3 where id='" +id+ "'", con);
            cmd.Parameters.AddWithValue("@1", fullname);
            cmd.Parameters.AddWithValue("@2", department_id);
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
