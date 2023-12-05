using Krypton.Toolkit;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_system_model.Classes
{
    internal class StudentAccount
    {
        public int id { get; set; }
        public string semester { get; set; }
        public string id_number { get; set; }
        public string school_year { get; set; }
        public string full_name { get; set; }
        public string last_name { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string gender { get; set; }
        public string civil_status { get; set; }
        public string date_of_birth { get; set; }
        public string place_of_birth { get; set; }
        public string nationality { get; set; }
        public string religion { get; set; }
        public string status { get; set; }

        public DataTable loadRecords(string schoolYear)
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from student_accounts where school_year='" + schoolYear + "' " +
                "order by id desc", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable loadUpdateRecord(int id)
        {
            var con = new MySqlConnection (connection.con());
            var da = new MySqlDataAdapter("select * from student_accounts where id='" + id + "'", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public string schoolYearPreSet()
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from school_year where is_current='Yes'", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt.Rows[0]["code"].ToString();
        }
        public int countStudent(string schoolYear)
        {
            var con = new MySqlConnection (connection.con());
            var da = new MySqlDataAdapter("select * from student_accounts where school_year='" + schoolYear + "'", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt.Rows.Count;
        }
        public string loadSemester(string schoolYear)
        {
            var con = new MySqlConnection( connection.con());
            var da = new MySqlDataAdapter("select * from school_year where code='" + schoolYear + "'", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt.Rows[0]["semester"].ToString();
        }
        public void addRecord()
        {
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("insert into student_accounts(id_number, school_year, fullname, last_name, " +
                "first_name, middle_name, gender, civil_status, date_of_birth, place_of_birth, nationality, " +
                "religion, status) values(@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13)", con);
            cmd.Parameters.AddWithValue("@1", id_number);
            cmd.Parameters.AddWithValue("@2", school_year);
            cmd.Parameters.AddWithValue("@3", full_name);
            cmd.Parameters.AddWithValue("@4", last_name);
            cmd.Parameters.AddWithValue("@5", first_name);
            cmd.Parameters.AddWithValue("@6", middle_name);
            cmd.Parameters.AddWithValue("@7", gender);
            cmd.Parameters.AddWithValue("@8", civil_status);
            cmd.Parameters.AddWithValue("@9", date_of_birth);
            cmd.Parameters.AddWithValue("@10", place_of_birth);
            cmd.Parameters.AddWithValue("@11", nationality);
            cmd.Parameters.AddWithValue("@12", religion);
            cmd.Parameters.AddWithValue("@13", status);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void editRecord(string idNumber)
        {
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("update student_accounts set id_number=@1, school_year=@2, fullname=@3, " +
                "last_name=@4, first_name=@5, middle_name=@6, gender=@7, civil_status=@8, date_of_birth=@9, " +
                "place_of_birth=@10, nationality=@11, religion=@12, status=@13 where id_number='"+ idNumber +"'", con);
            cmd.Parameters.AddWithValue("@1", id_number);
            cmd.Parameters.AddWithValue("@2", school_year);
            cmd.Parameters.AddWithValue("@3", full_name);
            cmd.Parameters.AddWithValue("@4", last_name);
            cmd.Parameters.AddWithValue("@5", first_name);
            cmd.Parameters.AddWithValue("@6", middle_name);
            cmd.Parameters.AddWithValue("@7", gender);
            cmd.Parameters.AddWithValue("@8", civil_status);
            cmd.Parameters.AddWithValue("@9", date_of_birth);
            cmd.Parameters.AddWithValue("@10", place_of_birth);
            cmd.Parameters.AddWithValue("@11", nationality);
            cmd.Parameters.AddWithValue("@12", religion);
            cmd.Parameters.AddWithValue("@13", status);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public DataTable searchRecords(string search)
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from student_accounts where concat(fullname, id_number) " +
                "like '%" + search + "%'", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public void approveStudent(string idNumber)
        {
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("update student_accounts set Status='For Enrollment' " +
                "where id_number='" + idNumber + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();

            // Inserting the id Number to the student Course
            con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from student_course where id_number='" + idNumber + "'", con);
            var dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count == 0)
            {
                con = new MySqlConnection(connection.con());
                con.Open();
                cmd = new MySqlCommand("insert into student_course(id_number) values('" + idNumber + "')", con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
