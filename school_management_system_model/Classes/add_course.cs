using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using school_management_system_model.Forms.transactions;
using System.Data;

namespace school_management_system_model.Classes
{
    internal class add_course
    {
        public int id { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public string level { get; set; }
        public string campus { get; set; }
        public string department { get; set; }
        public string status { get; set; }
        public string search { get; set; }
        public string curriculum { get; set; }
        public string semester { get; set; }

        public void loadRecords()
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from courses where status='Active'", con);
            da.Fill(frm_add_courses.instance.dt);
        }
        public void searchRecords()
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from courses where concat(code, " +
                "description, level, campus, department) like '%" + search + "%'", con);
            da.Fill(frm_add_courses.instance.dt);
        }
        public void selectCourse()
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from courses where code='" + code + "'", con);
            var dt = new DataTable();
            da.Fill(dt);
            frm_student_enrollment.instance.course = dt.Rows[0]["code"].ToString();
        }
        public void loadCurriculum()
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from curriculums where course='" + curriculum + "'", con);
            da.Fill(frm_student_enrollment.instance.dt);
        }
        public void loadCurriculumSubjects()
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from curriculum_subjects where curriculum='" + curriculum + "' " +
                "and semester='" + semester + "'", con);
            da.Fill(frm_student_enrollment.instance.dt);
        }
    }
}
