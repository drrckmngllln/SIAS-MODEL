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
        public int reference_no { get; set; }
        public string particulars { get; set; }
        public decimal debit { get; set; }
        public decimal credit { get; set; }
        public decimal balance { get; set; }
        public string cashier_in_charge { get; set; }

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
    }
}
