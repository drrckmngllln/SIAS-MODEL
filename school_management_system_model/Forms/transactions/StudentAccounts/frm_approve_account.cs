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
    public partial class frm_approve_account : KryptonForm
    {
        public static frm_approve_account instance;
        public string course { get; set; }
        public string id_number { get; set; }
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
            var da = new MySqlDataAdapter("select course from student_course where id_number='" + id_number + "'", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt.Rows[0]["course"].ToString();
        }

        private void loadRecords()
        {
            tName.Text = fullname;
            tCourse.Text = course;
            course = loadStudentCourse();
            tCourse.Text = course;

            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from curriculums where course='" + course + "'", con);
            var dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                tCurriculum.Items.Add(dr["code"]);
            }
        }

        private void approveStudent(string idNumber)
        {
            try
            {
                var con = new MySqlConnection(connection.con());
                con.Open();
                var cmd = new MySqlCommand("update student_course set curriculum='" + tCurriculum.Text + "' where id_number='" + idNumber + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();

                con.Open();
                cmd = new MySqlCommand("update student_accounts set status='For Enrollment' where id_number='" + idNumber + "'", con);
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
                approveStudent(id_number);
            }
        }
    }
}
