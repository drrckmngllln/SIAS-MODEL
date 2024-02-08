using MySql.Data.MySqlClient;
using school_management_system_model.Data.Repositories.Setings;
using school_management_system_model.Data.Repositories.Transaction.StudentAccounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_system_model.Classes
{
    internal class AssessmentBreakdowns
    {
        public int id { get; set; }
        public string id_number { get; set; }
        public string school_year { get; set; }
        public string fee_type { get; set; }
        public decimal amount { get; set; }

        public async Task<List<AssessmentBreakdowns>> GetAssessmentBreakdowns()
        {
            var _studentAccountRepo = new StudentAccountRepository();
            var _schoolYearRepo = new SchoolYearRepository();
            var list = new List<AssessmentBreakdowns>();

            using (var con = new MySqlConnection(connection.con()))
            {
                await con.OpenAsync();
                var sql = "select * from assessment_breakdown";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var a = await _studentAccountRepo.GetAllAsync();
                            var id_number_id = a.FirstOrDefault(x => x.id == reader.GetInt32("id_number_id"));

                            var c = await _schoolYearRepo.GetAllAsync();
                            var school_year_id = c.FirstOrDefault(x => x.id == reader.GetInt32("school_year_id"));

                            if (id_number_id != null && school_year_id != null)
                            {
                                var assessmentBreakdown = new AssessmentBreakdowns
                                {
                                    id = reader.GetInt32("id"),
                                    id_number = reader.GetString("id"),
                                    school_year = reader.GetString("school_year"),
                                    fee_type = reader.GetString("fee_type"),
                                    amount = reader.GetDecimal("amount")
                                };
                                list.Add(assessmentBreakdown);
                            }
                        }
                    }
                }
                await con.CloseAsync();
                return list;
            }
        }

        public void SaveRecords()
        {
            using (var con = new MySqlConnection(connection.con()))
            {
                con.Open();
                var sql = "insert into assessment_breakdown(id_number_id, school_year_id, fee_type, amount) " +
                    "values(@1,@2,@3,@4)";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@1", id_number);
                    cmd.Parameters.AddWithValue("@2", school_year);
                    cmd.Parameters.AddWithValue("@3", fee_type);
                    cmd.Parameters.AddWithValue("@4", amount);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }
    }
}
