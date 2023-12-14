using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_system_model.Classes
{
    internal class StatementsOfAccounts
    {
        public string id_number { get; set; }
        public string school_year { get; set; }
        public string date { get; set; }
        public string course { get; set; }
        public string year_level { get; set; }
        public string semester { get; set; }
        public int reference_no { get; set; }
        public string particulars { get; set; }
        public decimal debit { get; set; }
        public decimal credit { get; set; }
        public decimal balance { get; set; }
        public string cashier_in_charge { get; set; }

        public int referenceNumber()
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from reference_number_setup order by id desc", con);
            var dt = new DataTable();
            da.Fill(dt);
            return Convert.ToInt32(dt.Rows[0]["reference_number"]) + 1;
        }
        public void incrementReferenceNumber(int referenceNumber)
        {
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("update reference_number_setup set reference_number='" + referenceNumber + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void saveStatementOfAccount(string idNumber)
        {
            reference_no = referenceNumber();
            incrementReferenceNumber(reference_no);
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("insert into statements_of_accounts(id_number, date, reference_no, particulars, debit, credit, balance, cashier_in_charge, school_year) " +
                "values(@1,@2,@3,@4,@5,@6,@7,@8,@9)", con);
            cmd.Parameters.AddWithValue("@1", idNumber);
            cmd.Parameters.AddWithValue("@2", DateTime.Now.ToString("MM-dd-yyyy"));
            cmd.Parameters.AddWithValue("@3", reference_no);
            cmd.Parameters.AddWithValue("@4", particulars);
            cmd.Parameters.AddWithValue("@5", debit);
            cmd.Parameters.AddWithValue("@6", credit);
            cmd.Parameters.AddWithValue("@7", balance);
            cmd.Parameters.AddWithValue("@8", cashier_in_charge);
            cmd.Parameters.AddWithValue("@9", school_year);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public DataTable loadLatestSOA(string idNumber)
        {
            var con = new MySqlConnection (connection.con());
            var da = new MySqlDataAdapter("select * from statements_of_accounts where id_number='" + idNumber + "' order by id desc", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable loadStudentRecords(string idNumber)
        {
            var con = new MySqlConnection (connection.con());
            var da = new MySqlDataAdapter("select * from student_course where id_number='" + idNumber + "'", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable searchRecords(string idNumber, string search)
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from statements_of_accounts where concat(date, reference_no, particulars) like '%"+ search +"%' and id_number='"+ idNumber +"'", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
