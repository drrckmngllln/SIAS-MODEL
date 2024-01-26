using Krypton.Toolkit;
using MySql.Data.MySqlClient;
using school_management_system_model.Classes.Parameters;
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
        public string id_number { get; set; }
        public string sy_enrolled { get; set; }
        public string school_year_id { get; set; }
        public string fullname { get; set; }
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
        public string contact_no { get; set; }
        public string email { get; set; }
        public string elem { get; set; }
        public string jhs { get; set; }
        public string shs { get; set; }
        public string elem_year { get; set; }
        public string jhs_year { get; set; }
        public string shs_year { get; set; }
        public string mother_name { get; set; }
        public string mother_no { get; set; }
        public string father_name { get; set; }
        public string father_no { get; set; }
        public string home_address { get; set; }
        public string m_occupation { get; set; }
        public string f_occupation { get; set; }
        public string type_of_student { get; set; }
        public string date_of_admission { get; set; }

        public List<StudentAccount> GetStudentAccounts()
        {
            var list = new List<StudentAccount>();
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("select * from student_accounts", con);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var school_year = new SchoolYear().GetSchoolYears().FirstOrDefault(x => x.id == reader.GetInt32("school_year"));
                var student = new StudentAccount
                {
                    id = reader.GetInt32("id"),
                    id_number = reader.GetString("id_number"),
                    sy_enrolled = reader.GetString("sy_enrolled"),
                    school_year_id = school_year.code,
                    fullname = reader.GetString("fullname"),
                    last_name = reader.GetString("last_name"),
                    first_name = reader.GetString("first_name"),
                    middle_name = reader.GetString("middle_name"),
                    gender = reader.GetString("gender"),
                    civil_status = reader.GetString("civil_status"),
                    date_of_birth = reader.GetString("date_of_birth"),
                    place_of_birth = reader.GetString("place_of_birth"),
                    nationality = reader.GetString("nationality"),
                    religion = reader.GetString("religion"),
                    status = reader.GetString("status"),
                    contact_no = reader.GetString("contact_no"),
                    email = reader.GetString("email"),
                    elem = reader.GetString("elem"),
                    jhs = reader.GetString("jhs"),
                    shs = reader.GetString("shs"),
                    elem_year = reader.GetString("elem_year"),
                    jhs_year = reader.GetString("jhs_year"),
                    shs_year = reader.GetString("shs_year"),
                    mother_name = reader.GetString("mother_name"),
                    mother_no = reader.GetString("mother_no"),
                    father_name = reader.GetString("father_name"),
                    father_no = reader.GetString("father_no"),
                    home_address = reader.GetString("home_address"),
                    m_occupation = reader.GetString("m_occupation"),
                    f_occupation = reader.GetString("f_occupation"),
                    type_of_student = reader.GetString("type_of_student"),
                    date_of_admission = reader.GetString("date_of_admission"),
                };
                list.Add(student);
            }
            con.Close();
            return list;
        }

        
        public void AddStudentAccount()
        {
            
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("insert into student_accounts(id_number, school_year, fullname, last_name, " +
                "first_name, middle_name, gender, civil_status, date_of_birth, place_of_birth, nationality, " +
                "religion, status,sy_enrolled, contact_no, email, elem, jhs, shs, elem_year,jhs_year, shs_year,mother_name,mother_no,father_name,father_no,home_address,m_occupation,f_occupation, type_of_student, date_of_admission) " +
                "values(@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,@16,@17,@18,@19,@20,@21,@22,@23,@24,@25,@26,@27,@28,@29,@30,@31,@32)", con);
            cmd.Parameters.AddWithValue("@1", id_number);
            cmd.Parameters.AddWithValue("@2", school_year_id);
            cmd.Parameters.AddWithValue("@3", fullname);
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
            cmd.Parameters.AddWithValue("@14", sy_enrolled);
            cmd.Parameters.AddWithValue("@16", contact_no);
            cmd.Parameters.AddWithValue("@17", email);
            cmd.Parameters.AddWithValue("@18", elem);
            cmd.Parameters.AddWithValue("@19", jhs);
            cmd.Parameters.AddWithValue("@20", shs);
            cmd.Parameters.AddWithValue("@21", elem_year);
            cmd.Parameters.AddWithValue("@22", jhs_year);
            cmd.Parameters.AddWithValue("@23", shs_year);
            cmd.Parameters.AddWithValue("@24", mother_name);
            cmd.Parameters.AddWithValue("@25", mother_no);
            cmd.Parameters.AddWithValue("@26", father_name);
            cmd.Parameters.AddWithValue("@27", father_no);
            cmd.Parameters.AddWithValue("@28", home_address);
            cmd.Parameters.AddWithValue("@29", m_occupation);
            cmd.Parameters.AddWithValue("@30", f_occupation);
            cmd.Parameters.AddWithValue("@31", type_of_student);
            cmd.Parameters.AddWithValue("@32", date_of_admission);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        

        public void editRecord(SaveStudentAccountsParams parameter)
        {
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("update student_accounts set id_number=@1, school_year=@2, fullname=@3, " +
                "last_name=@4, first_name=@5, middle_name=@6, gender=@7, civil_status=@8, date_of_birth=@9, " +
                "place_of_birth=@10, nationality=@11, religion=@12, status=@13, sy_enrolled=@14, contact_no=@16, " +
                "email=@17, elem=@18, jhs=@19, shs=@20, elem_year=@21, jhs_year=@22, shs_year=@23,mother_name=@24," +
                "mother_no=@25, father_name=@26,father_no=@27,home_address=@28, m_occupation=@29, f_occupation=@30, type_of_student= @31, date_of_admission=@32 where id_number='"+ parameter.id_number +"'", con);
            cmd.Parameters.AddWithValue("@1", parameter.id_number);
            cmd.Parameters.AddWithValue("@2", parameter.school_year);
            cmd.Parameters.AddWithValue("@3", parameter.fullname);
            cmd.Parameters.AddWithValue("@4", parameter.last_name);
            cmd.Parameters.AddWithValue("@5", parameter.first_name);
            cmd.Parameters.AddWithValue("@6", parameter.middle_name);
            cmd.Parameters.AddWithValue("@7", parameter.gender);
            cmd.Parameters.AddWithValue("@8", parameter.civil_status);
            cmd.Parameters.AddWithValue("@9", parameter.date_of_birth);
            cmd.Parameters.AddWithValue("@10", parameter.place_of_birth);
            cmd.Parameters.AddWithValue("@11", parameter.nationality);
            cmd.Parameters.AddWithValue("@12", parameter.religion);
            cmd.Parameters.AddWithValue("@13", parameter.status);
            cmd.Parameters.AddWithValue("@14", parameter.sy_enrolled);
            cmd.Parameters.AddWithValue("@16", parameter.contact_no);
            cmd.Parameters.AddWithValue("@17", parameter.email);
            cmd.Parameters.AddWithValue("@18", parameter.elem);
            cmd.Parameters.AddWithValue("@19", parameter.jhs);
            cmd.Parameters.AddWithValue("@20", parameter.shs);
            cmd.Parameters.AddWithValue("@21", parameter.elem_year);
            cmd.Parameters.AddWithValue("@22", parameter.jhs_year);
            cmd.Parameters.AddWithValue("@23", parameter.shs_year);
            cmd.Parameters.AddWithValue("@24", parameter.mother_name);
            cmd.Parameters.AddWithValue("@25", parameter.mother_no);
            cmd.Parameters.AddWithValue("@26", parameter.father_name);
            cmd.Parameters.AddWithValue("@27", parameter.father_no);
            cmd.Parameters.AddWithValue("@28", parameter.home_address);
            cmd.Parameters.AddWithValue("@29", parameter.m_occupation);
            cmd.Parameters.AddWithValue("@30", parameter.f_occupation);
            cmd.Parameters.AddWithValue("@31", parameter.type_of_student);
            cmd.Parameters.AddWithValue("@32", parameter.date_of_admission);
            cmd.ExecuteNonQuery();
            con.Close();

            con.Open();
            cmd = new MySqlCommand("update student_course set course='" + parameter.course + "', campus='" + parameter.campus + "' where id_number='" + parameter.id_number + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void ApproveStudent(string idNumber)
        {
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("update student_accounts set Status='Accounting' " +
                "where id_number='" + idNumber + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();

            //// Inserting the id Number to the student Course
            //con = new MySqlConnection(connection.con());
            //var da = new MySqlDataAdapter("select * from student_course where id_number='" + idNumber + "'", con);
            //var dt = new DataTable();
            //da.Fill(dt);
            //if (dt.Rows.Count == 0)
            //{
            //    con = new MySqlConnection(connection.con());
            //    con.Open();
            //    cmd = new MySqlCommand("insert into student_course(id_number) values('" + idNumber + "')", con);
            //    cmd.ExecuteNonQuery();
            //    con.Close();
            //}
        }




        //public DataTable loadCourses()
        //{
        //    var con = new MySqlConnection(connection.con());
        //    var da = new MySqlDataAdapter("select * from courses", con);
        //    var dt = new DataTable();
        //    da.Fill(dt);
        //    return dt;
        //}
        //public DataTable loadUpdateRecord(int id)
        //{
        //    var con = new MySqlConnection (connection.con());
        //    var da = new MySqlDataAdapter("select * from student_accounts where id='" + id + "'", con);
        //    var dt = new DataTable();
        //    da.Fill(dt);
        //    return dt;
        //}
        //public DataTable loadUpdateCourseRecord(string idNumber)
        //{
        //    var con = new MySqlConnection(connection.con());
        //    var da = new MySqlDataAdapter("select * from student_course where id_number='" + idNumber + "'", con);
        //    var dt = new DataTable();
        //    da.Fill(dt);
        //    return dt;
        //}
        //public DataTable schoolYearPreSet()
        //{
        //    var con = new MySqlConnection(connection.con());
        //    var da = new MySqlDataAdapter("select * from school_year where is_current='Yes'", con);
        //    var dt = new DataTable();
        //    da.Fill(dt);
        //    return dt;
        //}
        //public int countStudent(string schoolYear)
        //{
        //    var con = new MySqlConnection (connection.con());
        //    var da = new MySqlDataAdapter("select * from student_accounts where sy_enrolled='" + schoolYear + "'", con);
        //    var dt = new DataTable();
        //    da.Fill(dt);
        //    return dt.Rows.Count;
        //}
        //public string loadSemester(string schoolYear)
        //{
        //    var con = new MySqlConnection( connection.con());
        //    var da = new MySqlDataAdapter("select * from school_year where code='" + schoolYear + "'", con);
        //    var dt = new DataTable();
        //    da.Fill(dt);
        //    return dt.Rows[0]["semester"].ToString();
        //}
    }
}
