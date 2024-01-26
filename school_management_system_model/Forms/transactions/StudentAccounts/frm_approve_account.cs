using Krypton.Toolkit;
using MySql.Data.MySqlClient;
using school_management_system_model.Classes;
using school_management_system_model.Reports.Datasets;
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
    public partial class frm_approve_account : KryptonForm
    {
        public static frm_approve_account instance;
        public string course { get; set; }
        public string id_number_id { get; set; }
        public string fullname { get; set; }
        public frm_approve_account()
        {
            instance = this;
            InitializeComponent();
        }

        private void frm_approve_account_Load(object sender, EventArgs e)
        {
            loadRecords();
            
        }

        private string loadStudentCourse()
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select course_id from student_course where id_number_id='" + id_number_id + "'", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt.Rows[0]["course_id"].ToString();
        }

        private void loadRecords()
        {
            var studentCourse = loadStudentCourse();
            tName.Text = fullname;
            course = new Courses().GetCourses().FirstOrDefault(x => x.id.ToString() == studentCourse).code;
            tCourse.Text = course;

            tCurriculum.ValueMember = "id";
            tCurriculum.DisplayMember = "code";
            tCurriculum.DataSource = new Curriculums().GetCurriculums()
                .Where(x => x.course_id == tCourse.Text)
                .ToList();
        }

        private void approveStudent(string idNumber)
        {
            try
            {
                var con = new MySqlConnection(connection.con());
                con.Open();
                var cmd = new MySqlCommand("update student_course set curriculum_id='" + tCurriculum.SelectedValue.ToString() + "' where id_number_id='" + idNumber + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();

                con.Open();
                cmd = new MySqlCommand("update student_accounts set status='For Enrollment' where id='" + idNumber + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                
                new Classes.Toastr("Success", "Student Approved");


                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (tCurriculum.Text == "")
            {
                
                new Classes.Toastr("Error", "Please select a curriculum");
            }
            else
            {
                approveStudent(id_number_id);
            }
        }
    }
}
