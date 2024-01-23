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
        
        
        public DataTable loadCourses()
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from courses", con);
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
        public DataTable loadUpdateCourseRecord(string idNumber)
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from student_course where id_number='" + idNumber + "'", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable schoolYearPreSet()
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from school_year where is_current='Yes'", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public int countStudent(string schoolYear)
        {
            var con = new MySqlConnection (connection.con());
            var da = new MySqlDataAdapter("select * from student_accounts where sy_enrolled='" + schoolYear + "'", con);
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
        public void addRecord(SaveStudentAccountsParams parameter)
        {
            
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("insert into student_accounts(id_number, school_year, fullname, last_name, " +
                "first_name, middle_name, gender, civil_status, date_of_birth, place_of_birth, nationality, " +
                "religion, status,sy_enrolled, contact_no, email, elem, jhs, shs, elem_year,jhs_year, shs_year,mother_name,mother_no,father_name,father_no,home_address,m_occupation,f_occupation, type_of_student, date_of_admission) " +
                "values(@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,@16,@17,@18,@19,@20,@21,@22,@23,@24,@25,@26,@27,@28,@29,@30,@31,@32)", con);
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

            // Saving Student Course
            var IdNumber = new SaveStudentAccountsParams().GetStudentAccounts().FirstOrDefault(x => x.id_number == parameter.id_number).id;
            var course = new Courses().GetCourses().FirstOrDefault(x => x.code == parameter.course).id;
            var campus = new Campuses().GetCampuses().FirstOrDefault(x => x.code == parameter.campus).id;

            con.Open();
            cmd = new MySqlCommand("insert into student_course(id_number_id, course_id, campus_id, semester) values(@1,@2,@3,@4)", con);
            cmd.Parameters.AddWithValue("@1", IdNumber);
            cmd.Parameters.AddWithValue("@2", course);
            cmd.Parameters.AddWithValue("@3", campus);
            cmd.Parameters.AddWithValue("@4", parameter.semester);
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
            var cmd = new MySqlCommand("update student_accounts set Status='Accounting' " +
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
