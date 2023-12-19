using Krypton.Toolkit;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Cmp;
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
            loadSchoolYear();
        }

        private void loadSchoolYear()
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select code from school_year order by id desc", con);
            var dt = new DataTable();
            da.Fill(dt);

            foreach(DataRow row in dt.Rows)
            {
                tSchoolYear.Items.Add(row["code"]);
            }
        }

        private string studentSchoolYear()
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from student_accounts where id_number='" + id_number + "'", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt.Rows[0]["school_year"].ToString();
        }

        private void selectSchoolYear()
        {
            var status = studentSchoolYear();
            if (status == tSchoolYear.Text)
            {
                MessageBox.Show("School Year Already Selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var con = new MySqlConnection(connection.con());
                con.Open();
                var cmd = new MySqlCommand("update student_accounts set school_year='" + tSchoolYear.Text + "', status='For Enrollment' where id_number='" + id_number + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Student Promoted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frm_student_promotion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                selectSchoolYear();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void btnPromoteStudent_Click(object sender, EventArgs e)
        {
            selectSchoolYear();
        }
    }
}
