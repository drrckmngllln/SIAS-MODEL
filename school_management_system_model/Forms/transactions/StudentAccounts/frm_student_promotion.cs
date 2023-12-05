using Krypton.Toolkit;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace school_management_system_model.Forms.transactions.StudentAccounts
{
    public partial class frm_student_promotion : KryptonForm
    {
        public static frm_student_promotion instance;
        public string id_number { get; set; }
        public string fullname { get; set; }
        public string school_year { get; set; }
        public frm_student_promotion()
        {
            instance = this;
            InitializeComponent();
        }

        private void frm_student_promotion_Load(object sender, EventArgs e)
        {
            tTitle.Text = id_number + ": " + fullname;
            loadRecords();
            var course = loadCourse(id_number);

            tCourse.Text = course.Rows[0]["course"].ToString();
            tYearLevel.Text = course.Rows[0]["year_level"].ToString();
            tCampus.Text = course.Rows[0]["campus"].ToString();
            tSemester.Text = course.Rows[0]["semester"].ToString();
            tSchoolYear.Text = school_year;
        }

        private DataTable loadCourse(string idNumber)
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from student_course where id_number='" + idNumber + "'", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        private void loadRecords()
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from school_year", con);
            var dt = new DataTable();
            da.Fill(dt);
            dgv.DataSource = dt;
            dgv.Columns["id"].Visible = false;
            dgv.Columns["code"].HeaderText = "Code";
            dgv.Columns["description"].HeaderText = "Description";
            dgv.Columns["description"].Width = 300;
            dgv.Columns["school_year_from"].HeaderText = "School Year Range From";
            dgv.Columns["school_year_to"].HeaderText = "School Year Range To";
            dgv.Columns["semester"].HeaderText = "Semester";
            dgv.Columns["is_current"].Visible = false;
        }

        private void promoteStudent(string idNumber)
        {
            // Incrementing Year Level
            int yearLevel = 0;
            yearLevel = Convert.ToInt32(tYearLevel.Text);
            yearLevel++;
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("update student_course set year_level='" + yearLevel + "', section='', semester='1' where id_number='" + idNumber + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();

            // Incrementing School Year
            string schoolYear = dgv.CurrentRow.Cells["code"].Value.ToString();
            if (tSchoolYear.Text == schoolYear)
            {
                MessageBox.Show("Error, School Year");
            }
            else
            {
                con = new MySqlConnection(connection.con());
                con.Open();
                cmd = new MySqlCommand("update student_accounts set school_year='" + schoolYear + "', status='For Enrollment' where id_number='"+ idNumber +"'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Student Promoted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void frm_student_promotion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                promoteStudent(id_number);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void btnPromoteStudent_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to promote this student!", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) 
            {
                promoteStudent(id_number);
                Close();
            }

            
        }
    }
}
