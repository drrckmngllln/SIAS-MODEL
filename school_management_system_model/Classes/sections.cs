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
    internal class sections
    {
        public int id { get; set; }
        public string unique_id { get; set; }
        public string section_code { get; set; }
        public string course_id { get; set; }
        public int year_level { get; set; }
        public string section { get; set; }
        public string semester { get; set; }
        public int number_of_students { get; set; }
        public int max_number_of_students { get; set; }
        public string status { get; set; }
        public string remarks { get; set; }

        public List<sections> GetSections()
        {
            var list = new List<sections>();

            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("select * from sections", con);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var section = new sections
                {
                    id = reader.GetInt32("id"),
                    unique_id = reader.GetString("unique_id"),
                    section_code = reader.GetString("section_code"),
                    course_id = reader.GetString("course_id"),
                    year_level = reader.GetInt32("year_level"),
                    section = reader.GetString("section"),
                    semester = reader.GetString("semester"),
                    number_of_students = reader.GetInt32("number_of_students"),
                    max_number_of_students = reader.GetInt32("max_number_of_students"),
                    status = reader.GetString("status"),
                    remarks = reader.GetString("remarks")
                };
                list.Add(section);
            }
            con.Close();
            return list;
        }

        public DataTable getSections()
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from sections order by id desc", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable getCourses()
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from courses", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public void addSection()
        {
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("insert into sections(section_code, course, year_level, section, number_of_students, max_number_of_students, " +
                "status, remarks, semester, unique_id) values(@1,@2,@3,@4,@5,@6,@7,@8,@9,@10)", con);
            cmd.Parameters.AddWithValue("@1", section_code);
            cmd.Parameters.AddWithValue("@2", course_id);
            cmd.Parameters.AddWithValue("@3", year_level);
            cmd.Parameters.AddWithValue("@4", section);
            cmd.Parameters.AddWithValue("@5", number_of_students);
            cmd.Parameters.AddWithValue("@6", max_number_of_students);
            cmd.Parameters.AddWithValue("@7", status);
            cmd.Parameters.AddWithValue("@8", remarks);
            cmd.Parameters.AddWithValue("@9", semester);
            cmd.Parameters.AddWithValue("@10", unique_id);
            cmd.ExecuteNonQuery();
            con.Close();
           
        }
        
        public void editSection(int id)
        {
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("update sections set section_code=@1, course=@2, year_level=@3, section=@4, number_of_students=@5, " +
                "max_number_of_students=@6, status=@7, remarks=@8, semester=@9, unique_id=@10 where id='"+ id +"'", con);
            cmd.Parameters.AddWithValue("@1", section_code);
            cmd.Parameters.AddWithValue("@2", course_id);
            cmd.Parameters.AddWithValue("@3", year_level);
            cmd.Parameters.AddWithValue("@4", section);
            cmd.Parameters.AddWithValue("@5", number_of_students);
            cmd.Parameters.AddWithValue("@6", max_number_of_students);
            cmd.Parameters.AddWithValue("@7", status);
            cmd.Parameters.AddWithValue("@8", remarks);
            cmd.Parameters.AddWithValue("@9", semester);
            cmd.Parameters.AddWithValue("@10", unique_id);
            cmd.ExecuteNonQuery();
            con.Close();
            
        }
        public DataTable deleteSectionSubjects()
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter();
            da.SelectCommand = new MySqlCommand("delete from section_subjects where section_code='" + section_code + "'", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable deleteData()
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter();
            da.SelectCommand = new MySqlCommand("delete from sections where id='" + id + "'", con);
            var dt = new DataTable();
            da.Fill(dt);
            deleteSectionSubjects();
            return dt;
        }
        
        public DataTable searchRecords(string search)
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from sections where concat(section_code, course) like '%" + search + "%'", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
