using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace school_management_system_model.Classes
{
    internal class section_subject
    {
        public int id { get; set; }
        public string unique_id { get; set; }
        public string section_code { get; set; }
        public string curriculum { get; set; }
        public string course { get; set; }
        public string year_level { get; set; }
        public string semester { get; set; }
        public string subject_code { get; set; }
        public string descriptive_title { get; set; }
        public decimal total_units { get; set; }
        public decimal lecture_units { get; set; }
        public decimal lab_units { get; set; }
        public string pre_requisite { get; set; }
        public string time { get; set; }
        public string day { get; set; }
        public string room { get; set; }
        public string instructor { get; set; }
        public string status { get; set; }

        public string curriculumCode { get; set; }
        public string search { get; set; }

        public DataTable getData()
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from section_subjects where section_code='" + section_code + "' " +
                "and course='" + course + "' and year_level='" + year_level + "' and semester='" + semester + "'", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public void saveSectionSubjects()
        {
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("insert into section_subjects(unique_id, section_code, curriculum, course, year_level, semester, " +
                "subject_code, descriptive_title, total_units, lecture_units, lab_units, " +
                "pre_requisite, time, day, room, status, instructor) values(@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,@15,@16,@17)", con);
            cmd.Parameters.AddWithValue("@1", unique_id);
            cmd.Parameters.AddWithValue("@2", section_code);
            cmd.Parameters.AddWithValue("@3", curriculum);
            cmd.Parameters.AddWithValue("@4", course);
            cmd.Parameters.AddWithValue("@5", year_level);
            cmd.Parameters.AddWithValue("@6", semester);
            cmd.Parameters.AddWithValue("@7", subject_code);
            cmd.Parameters.AddWithValue("@8", descriptive_title);
            cmd.Parameters.AddWithValue("@9", total_units);
            cmd.Parameters.AddWithValue("@10", lecture_units);
            cmd.Parameters.AddWithValue("@11", lab_units);
            cmd.Parameters.AddWithValue("@12", pre_requisite);
            cmd.Parameters.AddWithValue("@13", time);
            cmd.Parameters.AddWithValue("@14", day);
            cmd.Parameters.AddWithValue("@15", room);
            cmd.Parameters.AddWithValue("@16", status);
            cmd.Parameters.AddWithValue("@17", instructor);
            cmd.ExecuteNonQuery();
            con.Close();
            
        }

        public void updateSectionSubject(int id)
        {
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("update section_subjects set time=@1, day=@2, room=@3, instructor=@4 where id='"+ id +"'", con);
            cmd.Parameters.AddWithValue("@1", time);
            cmd.Parameters.AddWithValue("@2", day);
            cmd.Parameters.AddWithValue("@3", room);
            cmd.Parameters.AddWithValue("@4", instructor);
            cmd.ExecuteNonQuery();
            con.Close();
            
        }
    }
}
