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
            try
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
            catch
            {
                MessageBox.Show("Student not yet enrolled any subject", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
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
            // Incrementing School Year
            string schoolYear = dgv.CurrentRow.Cells["code"].Value.ToString();
            if (tSchoolYear.Text == schoolYear)
            {
                MessageBox.Show("Error, School Year");
            }
            else
            {
                // Incrementing Year Level Or Semester
                int studentYearLevel = 0;
                int studentSemester = 0;
                

                studentYearLevel = Convert.ToInt32(tYearLevel.Text);
                studentSemester = Convert.ToInt32(tSemester.Text);

                if (studentSemester < 3)
                {
                    studentSemester++;
                    var con = new MySqlConnection(connection.con());
                    con.Open();
                    var cmd = new MySqlCommand("update student_course set semester='" + studentSemester + "', section='' where id_number='" + idNumber + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    con.Open();
                    cmd = new MySqlCommand("update student_accounts set school_year='" + schoolYear + "' where id_number='" + idNumber + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                else if (studentSemester == 3)
                {
                    studentYearLevel++;
                    var con = new MySqlConnection(connection.con());
                    con.Open();
                    var cmd = new MySqlCommand("update student_course set semester='1', year_level='"+ studentYearLevel +"', " +
                        "section='' where id_number='" + idNumber + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    con.Open();
                    cmd = new MySqlCommand("update student_accounts set school_year='" + schoolYear + "' where id_number='" + idNumber + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
               
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
