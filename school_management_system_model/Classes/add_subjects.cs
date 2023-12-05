using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_system_model.Classes
{
    internal class add_subjects
    {
        MySqlConnection con = new MySqlConnection(connection.con());
        public string id_number {  get; set; }
        public string unique_id { get; set; }
        public string school_year { get; set; }
        public string subject_code { get; set; }
        public string descriptive_title { get; set; }
        public string pre_requisite {  get; set; }
        public string total_units { get; set; }
        public string lecture_units { get; set; }
        public string lab_units { get; set; }
        public string time { get; set; }
        public string day { get; set; }
        public string room { get; set; }
        public string instructor { get; set; }

        //section incrementation
        public string section_code { get; set; }
        public int number_of_students { get; set; }
        public int max_number_of_students { get; set; }
        public string course { get; set; }
        public string year_level { get; set; }
        public string semester { get; set; }

        public void saveStudentSubjects()
        {
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("insert into student_subjects(id_number, unique_id, subject_code, descriptive_title, pre_requisite, " +
                "total_units, lecture_units, lab_units, time, day, room, instructor, school_year) " +
                "values(@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13)", con);
            cmd.Parameters.AddWithValue("@1", id_number);
            cmd.Parameters.AddWithValue("@2", unique_id);
            cmd.Parameters.AddWithValue("@3", subject_code);
            cmd.Parameters.AddWithValue("@4", descriptive_title);
            cmd.Parameters.AddWithValue("@5", pre_requisite);
            cmd.Parameters.AddWithValue("@6", total_units);
            cmd.Parameters.AddWithValue("@7", lecture_units);
            cmd.Parameters.AddWithValue("@8", lab_units);
            cmd.Parameters.AddWithValue("@9", time);
            cmd.Parameters.AddWithValue("@10", day);
            cmd.Parameters.AddWithValue("@11", room);
            cmd.Parameters.AddWithValue("@12", instructor);
            cmd.Parameters.AddWithValue("@13", school_year);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public string CheckMaximum()
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from sections where section_code='" + section_code + "' and " +
                "course='"+ course +"' and year_level='"+ year_level +"' and semester='"+ semester +"'", con);
            var dt = new DataTable();
            da.Fill(dt);

            number_of_students = Convert.ToInt32(dt.Rows[0]["number_of_students"].ToString());
            max_number_of_students = Convert.ToInt32(dt.Rows[0]["max_number_of_students"].ToString());

            if (number_of_students < max_number_of_students)
            {
                return "Available";
            }
            else
            {
                return "Full";
            }
        }
        public void disableFullSubject()
        {
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("update sections set status='Full' where section_code='"+ section_code +"' and " +
                "course='"+ course +"' and year_level='"+ year_level +"' and semester='"+ semester +"'", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public int numberOfStudents()
        {
            var da = new MySqlDataAdapter("select * from sections where section_code='" + section_code + "' and " +
                "course='" + course + "' and year_level='" + year_level + "' and semester='" + semester + "'", con);
            var dt = new DataTable();
            da.Fill(dt);
            return Convert.ToInt32(dt.Rows[0]["number_of_students"].ToString());
        }
        public void incrementSection()
        {
            int num = 0;
            num = numberOfStudents();
            num++;
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("update sections set number_of_students='" + num + "' " +
                "where section_code='" + section_code + "' and course='" + course + "' and year_level='" + year_level + "' and " +
                "semester='" + semester + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            
        }
    }
}
