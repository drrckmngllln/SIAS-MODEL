using MySql.Data.MySqlClient;
using school_management_system_model.Forms.settings.TuitionFeeDummy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_system_model.Classes
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

        public List<TuitionFeeSetup> GetTuitionFeeSetups()
        {
            var list = new List<TuitionFeeSetup>();
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("select * from tuition_fee_setup", con);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var campus_id = new Campuses().GetCampuses().FirstOrDefault(x => x.id == reader.GetInt32("campus_id"));
                var level_id = new Levels().GetLevels().FirstOrDefault(x => x.id == reader.GetInt32("level_id"));
                var tfee = new TuitionFeeSetup
                {
                    id = reader.GetInt32("id"),
                    uid = reader.GetString("uid"),
                    category = reader.GetString("category"),
                    description = reader.GetString("description"),
                    campus = campus_id.code,
                    level = level_id.code,
                    year_level = reader.GetString("year_level"),
                    semester = reader.GetString("semester"),
                    amount = reader.GetDecimal("amount")
                };
                list.Add(tfee);
            }
            con.Close();
            return list;
        }

        public void AddRecords()
        {
            using (var con = new MySqlConnection(connection.con()))
            {
                con.Open();
                var sql = "insert into tuition_fee_setup(uid, category, description, campus_id, level_id, year_level, semester, amount) " +
                    "values(@1,@2,@3,@4,@5,@6,@7,@8)";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@1", uid);
                    cmd.Parameters.AddWithValue("@2", category);
                    cmd.Parameters.AddWithValue("@3", description);
                    cmd.Parameters.AddWithValue("@4", campus);
                    cmd.Parameters.AddWithValue("@5", level);
                    cmd.Parameters.AddWithValue("@6", year_level);
                    cmd.Parameters.AddWithValue("@7", semester);
                    cmd.Parameters.AddWithValue("@8", amount);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public void EditRecords(int id)
        {
            using (var con = new MySqlConnection(connection.con()))
            {
                con.Open();
                var sql = "update tuition_fee_setup set uid=@1, category=@2, description=@3, campus_id=@4, level_id=@5, year_level=@6, semester=@7, " +
                    "amount=@8 where id='" + id + "'";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@1", uid);
                    cmd.Parameters.AddWithValue("@2", category);
                    cmd.Parameters.AddWithValue("@3", description);
                    cmd.Parameters.AddWithValue("@4", campus);
                    cmd.Parameters.AddWithValue("@5", level);
                    cmd.Parameters.AddWithValue("@6", year_level);
                    cmd.Parameters.AddWithValue("@7", semester);
                    cmd.Parameters.AddWithValue("@8", amount);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public void DeleteRecords(int id)
        {
            using (var con = new MySqlConnection(connection.con()))
            {
                con.Open();
                var sql = "delete from tuition_fee_setup where id='" + id + "'";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }
    }
}
