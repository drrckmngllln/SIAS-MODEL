using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_system_model.Classes
{
    internal class FeeBreakdowns
    {
        public int id { get; set; }
        public string id_number { get; set; }
        public string school_year { get; set; }
        public decimal downpayment { get; set; }
        public decimal prelim { get; set; }
        public decimal midterm { get; set; }
        public decimal semi_finals { get; set; }
        public decimal finals { get; set; }
        public decimal total { get; set; }

        public decimal downpayment_original { get; set; }
        public decimal prelim_original { get; set; }
        public decimal midterm_original { get; set; }
        public decimal semi_finals_original { get; set; }
        public decimal finals_original { get; set; }
        public decimal total_original { get; set; }

        public List<FeeBreakdowns> GetFeeBreakdowns()
        {
            var list = new List<FeeBreakdowns>();
            using (var con = new MySqlConnection(connection.con()))
            {
                con.Open();
                var sql = "select * from fee_breakdown";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var id_number_id = new StudentAccount().GetStudentAccounts().FirstOrDefault(x => x.id == reader.GetInt32("id_number_id"));
                            var school_year_id = new SchoolYear().GetSchoolYears().FirstOrDefault(x => x.id == reader.GetInt32("school_year_id"));
                            if (id_number_id != null && school_year_id != null)
                            {
                                var feeBreakdown = new FeeBreakdowns
                                {
                                    id = reader.GetInt32("id"),
                                    id_number = id_number_id.id_number,
                                    school_year = school_year_id.code,
                                    downpayment = reader.GetDecimal("downpayment"),
                                    prelim = reader.GetDecimal("prelim"),
                                    midterm = reader.GetDecimal("midterm"),
                                    semi_finals = reader.GetDecimal("semi_finals"),
                                    finals = reader.GetDecimal("finals"),
                                    downpayment_original = reader.GetDecimal("downpayment_original"),
                                    prelim_original = reader.GetDecimal("prelim_original"),
                                    midterm_original = reader.GetDecimal("midterm_original"),
                                    semi_finals_original = reader.GetDecimal("semi_finals_original"),
                                    finals_original = reader.GetDecimal("finals_original"),
                                    total_original = reader.GetDecimal("total_original")
                                };
                                list.Add(feeBreakdown);
                            }
                        }
                    }
                }
                con.Close();
                return list;
            }
        }

        public void saveRecords(string idNumber)
        {
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("insert into fee_breakdown(id_number, school_year,prelim, midterm, semi_finals, finals, total, prelim_original, midterm_original, semi_finals_original,finals_original, " +
                "total_original, downpayment, downpayment_original) values(@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14)", con);
            cmd.Parameters.AddWithValue("@1", idNumber);
            cmd.Parameters.AddWithValue("@2", school_year);
            cmd.Parameters.AddWithValue("@3", prelim);
            cmd.Parameters.AddWithValue("@4", midterm);
            cmd.Parameters.AddWithValue("@5", semi_finals);
            cmd.Parameters.AddWithValue("@6", finals);
            cmd.Parameters.AddWithValue("@7", total);
            cmd.Parameters.AddWithValue("@8", prelim);
            cmd.Parameters.AddWithValue("@9", midterm);
            cmd.Parameters.AddWithValue("@10", semi_finals);
            cmd.Parameters.AddWithValue("@11", finals);
            cmd.Parameters.AddWithValue("@12", total);
            cmd.Parameters.AddWithValue("@13", downpayment);
            cmd.Parameters.AddWithValue("@14", downpayment);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
