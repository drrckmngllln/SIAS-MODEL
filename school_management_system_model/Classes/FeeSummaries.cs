using MySql.Data.MySqlClient;
using school_management_system_model.Data.Repositories.Transaction.StudentAccounts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_system_model.Classes
{
    internal class FeeSummaries
    {
        public int id { get; set; }
        public string id_number { get; set; }
        public string school_year { get; set; }
        public decimal current_assessment { get; set; }
        public decimal discounts { get; set; }
        public decimal previous_balance { get; set; }
        public decimal current_receivable { get; set; }

        public async Task<List<FeeSummaries>> GetFeeSummaries()
        {
            var _studentAccountRepo = new StudentAccountRepository();
            var list = new List<FeeSummaries>();
            using (var con = new MySqlConnection(connection.con()))
            {
                await con.OpenAsync();
                var sql = "select * from fee_summary";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var a = await _studentAccountRepo.GetAllAsync();
                            var id_number_id = a.FirstOrDefault(x => x.id == reader.GetInt32("id_number_id"));
                            var school_year_id = new SchoolYear().GetSchoolYears().FirstOrDefault(x => x.id == reader.GetInt32("school_year_id"));
                            if (id_number_id != null && school_year_id != null)
                            {
                                var feeSummary = new FeeSummaries
                                {
                                    id = reader.GetInt32("id"),
                                    id_number = id_number_id.id_number,
                                    school_year = school_year_id.code,
                                    current_assessment = reader.GetDecimal("current_assessment"),
                                    discounts = reader.GetDecimal("discounts"),
                                    previous_balance = reader.GetDecimal("previous_balance"),
                                    current_receivable = reader.GetDecimal("current_receivable")
                                };
                                list.Add(feeSummary);
                            }
                        }
                    }
                }
                await con.CloseAsync();
                return list;
            }
        }

        public void saveFeeSummary()
        {
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("insert into fee_summary(id_number, school_year, current_assessment, discounts, previous_balance, current_receivable) " +
                "values(@1,@2,@3,@4,@5,@6)", con);
            cmd.Parameters.AddWithValue("@1", id_number);
            cmd.Parameters.AddWithValue("@2", school_year);
            cmd.Parameters.AddWithValue("@3", current_assessment);
            cmd.Parameters.AddWithValue("@4", discounts);
            cmd.Parameters.AddWithValue("@5", previous_balance);
            cmd.Parameters.AddWithValue("@6", current_receivable);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public decimal loadPreviousBalance()
        {
            var con = new MySqlConnection (connection.con());
            var da = new MySqlDataAdapter("select * from statements_of_accounts where id_number='" + id_number + "' order by id desc", con);
            var dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0 )
            {
                return Convert.ToDecimal(dt.Rows[0]["balance"]);
            }
            else
            {
                return 0;
            }
        }
    }
}
