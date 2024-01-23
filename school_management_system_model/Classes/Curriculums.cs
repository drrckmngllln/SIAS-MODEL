
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_system_model.Classes
{
    internal class Curriculums 
    {
        public int id { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public string campus { get; set; }
        public string course { get; set; }
        public string effective { get; set; }
        public string expires { get; set; }
        public string status { get; set; }

        public List<Curriculums> GetCurriculums()
        {
            var list = new List<Curriculums>();
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("select * from curriculums", con);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var curriculum = new Curriculums
                {
                    id = reader.GetInt32("id"),
                    code = reader.GetString("code"),
                    description = reader.GetString("description"),
                    campus = reader.GetString("campus"),
                    course = reader.GetString("course"),
                    effective = reader.GetString("effective"),
                    expires = reader.GetString("expires"),
                    status = reader.GetString("status")
                };
                list.Add(curriculum);
            }
            con.Close();
            return list;
        }

        public DataTable loadRecords()
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from curriculums", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public void addRecords()
        {
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("insert into curriculums(code, description, campus, course, effective, expires, status) " +
                "values(@1,@2,@3,@4,@5,@6,@7)", con);
            cmd.Parameters.AddWithValue("@1", code);
            cmd.Parameters.AddWithValue("@2", description);
            cmd.Parameters.AddWithValue("@3", campus);
            cmd.Parameters.AddWithValue("@4", course);
            cmd.Parameters.AddWithValue("@5", effective);
            cmd.Parameters.AddWithValue("@6", expires);
            cmd.Parameters.AddWithValue("@7", status);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void editRecords(string id)
        {
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("update curriculums set code=@1, description=@2, campus=@3, course=@4, effective=@5, expires=@6, " +
                "status=@7 where id='" + id + "'", con);
            cmd.Parameters.AddWithValue("@1", code);
            cmd.Parameters.AddWithValue("@2", description);
            cmd.Parameters.AddWithValue("@3", campus);
            cmd.Parameters.AddWithValue("@4", course);
            cmd.Parameters.AddWithValue("@5", effective);
            cmd.Parameters.AddWithValue("@6", expires);
            cmd.Parameters.AddWithValue("@7", status);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void deleteRecords(string id)
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter();
            da.SelectCommand = new MySqlCommand("delete from curriculums where id='" + id + "'", con);
            var dt = new DataTable();
            da.Fill(dt);
        }
        public DataTable searchRecords(string search)
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from curriculums where concat(code, description, campus, course) like '%" + search + "%'", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
