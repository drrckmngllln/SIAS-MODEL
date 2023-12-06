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
    public partial class frm_input_grade : KryptonForm
    {
        public string id_number { get; set; }
        public string subject_code { get; set; }
        public frm_input_grade()
        {
            InitializeComponent();
        }

        private void frm_input_grade_Load(object sender, EventArgs e)
        {
            var subject = loadSubject().Rows[0];
            tTitle.Text = subject["subject_code"].ToString();
            tDescriptiveTitle.Text = subject["descriptive_title"].ToString();
            tInsructor.Text = subject["instructor"].ToString();
        }

        private DataTable loadSubject()
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from student_subjects where id_number='" + id_number + "' and subject_code='"+ subject_code +"'", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        private void tGrade_TextChanged(object sender, EventArgs e)
        {
            if (tGrade.Text.Length > 1)
            {
                if (Convert.ToInt32(tGrade.Text) >= 75)
                {
                    tRemarks.Text = "Passed";
                }
                else
                {
                    tRemarks.Text = "Failed";
                }
            }
            
        }

        private void inputGrade(string grade, string remarks)
        {
            if (MessageBox.Show("Confirm grade: " + tGrade.Text, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                
                var con = new MySqlConnection (connection.con());
                con.Open();
                var cmd = new MySqlCommand("update student_subjects set grade='" + grade + "', remarks='" + remarks + "' where id_number='"+ id_number +"' and " +
                    "subject_code='"+ tTitle.Text +"'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Close();
            }
        }

        private void frm_input_grade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tGrade.Text.Length == 0)
                {
                    MessageBox.Show("Error Grade", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (tGrade.Text.Length > 2)
                {
                    MessageBox.Show("Error Grade", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    inputGrade(tGrade.Text, tRemarks.Text);
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void btnEnroll_Click(object sender, EventArgs e)
        {
            if (tGrade.Text.Length == 0)
            {
                MessageBox.Show("Error Grade", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (tGrade.Text.Length > 2)
            {
                MessageBox.Show("Error Grade", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                inputGrade(tGrade.Text, tRemarks.Text);
            }
        }
    }
}
