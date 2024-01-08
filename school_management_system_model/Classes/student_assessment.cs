using MySql.Data.MySqlClient;
using school_management_system_model.Forms.transactions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace school_management_system_model.Classes
{
    internal class student_assessment
    {
        public string id_number { get; set; }
        public string school_year { get; set; }
        public string fullname { get; set; }
        public string course { get; set; }
        public string year_level { get; set; }
        public string semester { get; set; }
        public string campus { get; set; }
        public string fee_type { get; set; }
        public decimal amount { get; set; }
        public int units { get; set; }
        public decimal computation { get; set; }

        public DataTable loadRecords(string schoolYear, string id_number)
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from student_assessment where school_year='" + schoolYear + "' and id_number='"+ id_number +"'", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public decimal getTuitionFeeUnits(string idNumber, string schoolYear)
        {
            var con = new MySqlConnection (connection.con());
            var da = new MySqlDataAdapter("select * from student_subjects where id_number='" + idNumber + "' and school_year='" + schoolYear + "'", con);
            var dt = new DataTable();
            da.Fill(dt);
            decimal total = 0;
            foreach(DataRow row in dt.Rows)
            {
                total += Convert.ToDecimal(row["lecture_units"]);
            }
            return total;
        }

        public DataTable getStudentDetails()
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from student_course where id_number='" + id_number + "'", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public string getStudentName()
        {
            var con = new MySqlConnection( connection.con());
            var da = new MySqlDataAdapter("select * from student_accounts where id_number='" + id_number + "'", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt.Rows[0]["fullname"].ToString();
        }
        public DataTable getTuitionFee(string campus)
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from tuition_fee_setup where campus='" + campus + "'", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable getMiscellaneousFee(string campus)
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from miscellaneous_fee_setup where campus='"+ campus +"'", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable getOtherFee(string campus)
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from other_fees where campus='" + campus + "'", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public void saveAssessment(string idNumber)
        {
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("insert into student_assessment(id_number, school_year, fee_type, amount, units, computation) " +
                "values(@1,@2,@3,@4,@5,@6)", con);
            cmd.Parameters.AddWithValue("@1", id_number);
            cmd.Parameters.AddWithValue("@2", school_year);
            cmd.Parameters.AddWithValue("@3", fee_type);
            cmd.Parameters.AddWithValue("@4", amount);
            cmd.Parameters.AddWithValue("@5", units);
            cmd.Parameters.AddWithValue("@6", computation);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public DataTable loadDiscounts(string idNumber)
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from student_discounts where id_number='" + idNumber + "'", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable loadEnrolledSubjects(string idNumber, string schoolYear)
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from student_subjects where id_number='" + idNumber + "' and school_year='" + schoolYear + "'", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public string getStudentSchoolYear(string idNumber)
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from student_accounts where id_number='"+ idNumber +"'", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt.Rows[0]["school_year"].ToString();
        }
        public DataTable loadLabFeeSubjects()
        {
            var con = new MySqlConnection (connection.con());
            var da = new MySqlDataAdapter("select * from lab_fee_subjects", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable loadLabFee(int id)
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from lab_fee_setup where id='" + id + "'", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        
        public DataTable checkPreviousSoa(string idNumber)
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from statements_of_accounts where id_number='" + idNumber + "' order by id desc", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public void saveAssessmentBreakdown(string id_number, string school_year, string fee_type, decimal amount)
        {
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("insert into assessment_breakdown(id_number, school_year, fee_type, amount) values(@1,@2,@3,@4)", con);
            cmd.Parameters.AddWithValue("@1", id_number);
            cmd.Parameters.AddWithValue("@2", school_year);
            cmd.Parameters.AddWithValue("@3", fee_type);
            cmd.Parameters.AddWithValue("@4", amount);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
