using MySql.Data.MySqlClient;
using school_management_system_model.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_system_model.Forms.settings.TuitionFeeDummy
{
    internal class TuitionFeeSetup
    {
        public int id { get; set; }
        public string uid { get; set; }
        public string category { get; set; }
        public string description { get; set; }
        public string campus { get; set; }
        public string level { get; set; }
        public string year_level { get; set; }
        public string semester { get; set; }
        public decimal amount { get; set; }

        public List<Levels> levels { get; set; }

        public DataTable loadRecords(string semester)
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from tuitionfeesetup where semester='" + semester + "'", con);
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
        
        public List<TuitionFeeSetup> GetRecords()
        {
            List<TuitionFeeSetup> data = new List<TuitionFeeSetup>();
            
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("select * from tuitionfeesetup" , con);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var level_id = GetLevels().FirstOrDefault(x => x.id == reader.GetInt32("level_id")).code;
                var campus_id = GetCampuses().FirstOrDefault(x => x.id == reader.GetInt32("campus_id")).code;
                TuitionFeeSetup dataItem = new TuitionFeeSetup
                {
                    
                    id = reader.GetInt32("id"),
                    uid = reader["uid"].ToString(),
                    category = reader["category"].ToString(),
                    description = reader["description"].ToString(),
                    level = level_id,
                    campus = campus_id,
                    year_level = reader["year_level"].ToString(),
                    semester = reader["semester"].ToString(),
                    amount = reader.GetDecimal("amount")
                };
                data.Add(dataItem);
            }
            con.Close();
            return data;
        }
        public List<Levels> GetLevels()
        {
            var data = new List<Levels>();
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("select * from levels", con);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var levelData = new Levels
                {
                    id = reader.GetInt32("id"),
                    code = reader["code"].ToString(),
                    description = reader["description"].ToString(),
                    status = reader["status"].ToString()
                };
                data.Add(levelData);
            }
            return data;
        }
        public List<Campuses> GetCampuses()
        {
            var data = new List<Campuses>();
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("select * from campuses", con);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var campus = new Campuses
                {
                    id = reader.GetInt32("id"),
                    code = reader["code"].ToString(),
                    description = reader["description"].ToString(),
                    status = reader["status"].ToString()
                };
                data.Add(campus);
            }
            con.Close();
            return data;
        }
        public void addRecords()
        {
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("insert into tuitionfeesetup(uid, category, description, campus_id, year_level, semester, amount, level_id) " +
                "values(@1,@2,@3,@4,@5,@6,@7,@8)", con);
            cmd.Parameters.AddWithValue("@1", uid);
            cmd.Parameters.AddWithValue("@2", category);
            cmd.Parameters.AddWithValue("@3", description);
            cmd.Parameters.AddWithValue("@4", campus);
            cmd.Parameters.AddWithValue("@5", year_level);
            cmd.Parameters.AddWithValue("@6", semester);
            cmd.Parameters.AddWithValue("@7", amount);
            cmd.Parameters.AddWithValue("@8", level);
            cmd.ExecuteNonQuery();
            con.Close();
            
        }
        public void editRecords(int id)
        {
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("update tuitionfeesetup set uid=@1, category=@2, description=@3, campus_id=@4, year_level=@5, semester=@6, amount=@7, level_id=@8 " +
                "where id='"+ id +"'", con);
            cmd.Parameters.AddWithValue("@1", uid);
            cmd.Parameters.AddWithValue("@2", category);
            cmd.Parameters.AddWithValue("@3", description);
            cmd.Parameters.AddWithValue("@4", campus);
            cmd.Parameters.AddWithValue("@5", year_level);
            cmd.Parameters.AddWithValue("@6", semester);
            cmd.Parameters.AddWithValue("@7", amount);
            cmd.Parameters.AddWithValue("@8", level);
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
