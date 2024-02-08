using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_system_model.Classes
{
    internal class LabFeeSubjects
    {
        public int id { get; set; }
        public string lab_fee { get; set; }
        public string subject_code { get; set; }
        public string descriptive_title { get; set; }

        public async Task<List<LabFeeSubjects>> GetLabFeeSubjects()
        {
            var list = new List<LabFeeSubjects>();
            using (var con = new MySqlConnection(connection.con()))
            {
                con.Open();
                var sql = "select * from lab_fee_subjects";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var lab_fee_id = await new LabFeeSetup().GetLabFeeSetups();
                            var a = lab_fee_id
                                .FirstOrDefault(x => x.id == reader.GetInt32("lab_fee_id"));
                            if (lab_fee_id != null)
                            {
                                var labFeeSubjects = new LabFeeSubjects
                                {
                                    id = reader.GetInt32("id"),
                                    lab_fee = a.description,
                                    subject_code = reader.GetString("subject_code"),
                                    descriptive_title = reader.GetString("descriptive_title")
                                };
                                list.Add(labFeeSubjects);
                            }
                            
                        }
                    }
                }
                con.Close();
                return list;
            }
        }

        public void AddRecords()
        {
            using (var con = new MySqlConnection(connection.con()))
            {
                con.Open();
                var sql = "insert into lab_fee_subjects(lab_fee_id, subject_code, descriptive_title) " +
                    "values(@1,@2,@3)";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@1", lab_fee);
                    cmd.Parameters.AddWithValue("@2", subject_code);
                    cmd.Parameters.AddWithValue("@3", descriptive_title);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }
    }
}
