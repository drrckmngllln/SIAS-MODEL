using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_system_model.Classes
{
    internal class FeeSummary
    {
        public string id_number { get; set; }
        public string school_year { get; set; }
        public decimal current_assessment { get; set; }
        public decimal discounts { get; set; }
        public decimal previous_balance { get; set; }
        public decimal current_receivable { get; set; }

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
