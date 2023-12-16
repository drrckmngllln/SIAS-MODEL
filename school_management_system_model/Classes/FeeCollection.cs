using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_system_model.Classes
{
    internal class FeeCollection
    {
        public string id_number { get; set; }
        public string date { get; set; }
        public string school_year { get; set; }
        public string course { get; set; }
        public string year_level { get; set; }
        public string semester { get; set; }
        public int reference_no { get; set; }
        public string particulars { get; set; }
        public decimal debit { get; set; }
        public decimal credit { get; set; }
        public decimal balance { get; set; }
        public string cashier_in_charge { get; set; }

        public decimal downpayment { get; set; }
        public decimal prelim { get; set; }
        public decimal midterm { get; set; }
        public decimal semi_finals { get; set; }
        public decimal finals { get; set; }
        public decimal total { get; set; }

        public DataTable loadStudentAccounts(string idNumber)
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from student_accounts where id_number='" + idNumber + "'", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable loadStudentCourse(string idNumber)
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from student_course where id_number='" + idNumber + "'", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable loadStatementOfAccounts(string idNumber)
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from statements_of_accounts where id_number='" + idNumber + "'", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable loadFeeBreakdown(string idNumber)
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from fee_breakdown where id_number='"+ idNumber +"'", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable loadSchoolYear()
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from school_year", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public int getReferenceNo()
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from reference_number_setup order by id desc", con);
            var dt = new DataTable();
            da.Fill(dt);
            return Convert.ToInt32(dt.Rows[0]["reference_number"]);
        }
        public void incrementReferenceNo(int referenceNumber)
        {
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("update reference_number_setup set reference_number='" + referenceNumber + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public DataTable getLatestSoa(string idNumber, string schoolYear)
        {
            var con =new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from statements_of_accounts where id_number='" + idNumber + "' and school_year='" + schoolYear + "' order by id desc", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public void soaCollection(string idNumber)
        {
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("insert into statements_of_accounts(id_number, school_year, date, reference_no, particulars, debit, credit, balance, cashier_in_charge, " +
                "course, year_level, semester) " +
                "values(@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12)", con);
            cmd.Parameters.AddWithValue("@1", idNumber);
            cmd.Parameters.AddWithValue("@2", school_year);
            cmd.Parameters.AddWithValue("@3", date);
            cmd.Parameters.AddWithValue("@4", reference_no);
            cmd.Parameters.AddWithValue("@5", particulars);
            cmd.Parameters.AddWithValue("@6", debit);
            cmd.Parameters.AddWithValue("@7", credit);
            cmd.Parameters.AddWithValue("@8", balance);
            cmd.Parameters.AddWithValue("@9", cashier_in_charge);
            cmd.Parameters.AddWithValue("@10", course);
            cmd.Parameters.AddWithValue("@11", year_level);
            cmd.Parameters.AddWithValue("@12", semester);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void feeBreakdownSave(string idNumber, string schoolYear)
        {
            var con = new MySqlConnection (connection.con());
            con.Open();
            var cmd = new MySqlCommand("update fee_breakdown set downpayment=@1, prelim=@2, midterm=@3, semi_finals=@4, finals=@5, total=@6 " +
                "where id_number='" + idNumber + "' and school_year='" + schoolYear + "'", con);
            cmd.Parameters.AddWithValue("@1", downpayment);
            cmd.Parameters.AddWithValue("@2", prelim);
            cmd.Parameters.AddWithValue("@3", midterm);
            cmd.Parameters.AddWithValue("@4", semi_finals);
            cmd.Parameters.AddWithValue("@5", finals);
            cmd.Parameters.AddWithValue("@6", total);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void StudentStatusChange(string idNumber, string schoolYear)
        {
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("update student_accounts set status='Officially Enrolled for School Year "+schoolYear+"' where id_number='" + idNumber + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
