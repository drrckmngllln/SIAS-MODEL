using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Mozilla;
using school_management_system_model.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace school_management_system_model.Forms.transactions.Classes
{
    internal class student_accounts
    {
        public int id { get; set; }
        public string semester {  get; set; }
        public string id_number { get; set; }
        public string full_name { get; set; }
        public string last_name { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string gender { get; set; }
        public string civil_status { get; set; }
        public DateTime date_of_birth { get; set; }
        public string place_of_birth { get; set; }
        public string nationality { get; set; }
        public string religion { get; set; }
        public string status { get; set; }
        public string search { get; set; }

        
        
        public void loadRecords()
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from student_accounts order by id desc", con);
            frm_student_application.instance.dt.Clear();
            da.Fill(frm_student_application.instance.dt);
        }

        public void searchRecords()
        {
            var con = new MySqlConnection (connection.con());
            var da = new MySqlDataAdapter("select * from student_accounts where concat(id_number, fullname) like '%"+ search +"%'", con);
            frm_student_application.instance.dt.Clear();
            da.Fill(frm_student_application.instance.dt);
        }
        public void addRecords()
        {
            try
            {
                var con = new MySqlConnection(connection.con());
                con.Open();
                var cmd = new MySqlCommand("insert into student_accounts(id_number, fullname, last_name, first_name, middle_name, " +
                    "gender, civil_status, date_of_birth, place_of_birth, nationality, religion, status, semester) " +
                    "values(@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13)", con);
                cmd.Parameters.AddWithValue("@1", id_number);
                cmd.Parameters.AddWithValue("@2", full_name);
                cmd.Parameters.AddWithValue("@3", last_name);
                cmd.Parameters.AddWithValue("@4", first_name);
                cmd.Parameters.AddWithValue("@5", middle_name);
                cmd.Parameters.AddWithValue("@6", gender);
                cmd.Parameters.AddWithValue("@7", civil_status);
                cmd.Parameters.AddWithValue("@8", date_of_birth);
                cmd.Parameters.AddWithValue("@9", place_of_birth);
                cmd.Parameters.AddWithValue("@10", nationality);
                cmd.Parameters.AddWithValue("@11", religion);
                cmd.Parameters.AddWithValue("@12", status);
                cmd.Parameters.AddWithValue("@13", semester);
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        public void editRecords()
        {
            try
            {
                var con = new MySqlConnection(connection.con());
                con.Open();
                var cmd = new MySqlCommand("update student_accounts set id_number=@1, fullname=@2, last_name=@3, firstname=@4, " +
                    "middle_name=@5, gender=@6, civil_status=@7, date_of_birth=@8, place_of_birth=@9, nationality=@10, " +
                    "religion=@11, status=@12, semester=@13 where id_number='"+ id_number +"'", con);
                cmd.Parameters.AddWithValue("@1", id_number);
                cmd.Parameters.AddWithValue("@2", full_name);
                cmd.Parameters.AddWithValue("@3", last_name);
                cmd.Parameters.AddWithValue("@4", first_name);
                cmd.Parameters.AddWithValue("@5", middle_name);
                cmd.Parameters.AddWithValue("@6", gender);
                cmd.Parameters.AddWithValue("@7", civil_status);
                cmd.Parameters.AddWithValue("@8", date_of_birth);
                cmd.Parameters.AddWithValue("@9", place_of_birth);
                cmd.Parameters.AddWithValue("@10", nationality);
                cmd.Parameters.AddWithValue("@11", religion);
                cmd.Parameters.AddWithValue("@12", status);
                cmd.Parameters.AddWithValue("@13", semester);
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void approveAccount()
        {
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("update student_accounts set status='For Enrollment' where id_number='" + id_number + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Student Account Approved!");

            con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from student_course where id_number='" + id_number + "'", con);
            var dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count == 0)
            {
                con = new MySqlConnection(connection.con());
                con.Open();
                cmd = new MySqlCommand("insert into student_course(id_number, year_level) values('" + id_number + "','1')", con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                
                var data = new student_course
                {
                    id_number = dt.Rows[0]["id_number"].ToString(),
                    course = dt.Rows[0]["course"].ToString(),
                    curriculum = dt.Rows[0]["curriculum"].ToString(),
                    year_level = dt.Rows[0]["year_level"].ToString(),
                    section = dt.Rows[0]["section"].ToString(),
                };
            }
        }
        public void changeStatus()
        {
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("update student_accounts set status='" + status + "' where id_number='" + id_number + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
