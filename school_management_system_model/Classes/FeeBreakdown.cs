using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_system_model.Classes
{
    internal class FeeBreakdown
    {
        public string school_year { get; set; }
        public decimal downpayment { get; set; }
        public decimal prelim { get; set; }
        public decimal midterms { get; set; }
        public decimal semi_finals { get; set; }
        public decimal finals { get; set; }
        public decimal total { get; set; }

        public void saveRecords(string idNumber)
        {
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("insert into fee_breakdown(id_number, school_year,prelim, midterm, semi_finals, finals, total, prelim_original, midterm_original, semi_finals_original,finals_original, " +
                "total_original, downpayment, downpayment_original) values(@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14)", con);
            cmd.Parameters.AddWithValue("@1", idNumber);
            cmd.Parameters.AddWithValue("@2", school_year);
            cmd.Parameters.AddWithValue("@3", prelim);
            cmd.Parameters.AddWithValue("@4", midterms);
            cmd.Parameters.AddWithValue("@5", semi_finals);
            cmd.Parameters.AddWithValue("@6", finals);
            cmd.Parameters.AddWithValue("@7", total);
            cmd.Parameters.AddWithValue("@8", prelim);
            cmd.Parameters.AddWithValue("@9", midterms);
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
