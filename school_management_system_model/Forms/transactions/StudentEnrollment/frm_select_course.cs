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

namespace school_management_system_model.Forms.transactions.StudentEnrollment
{
    public partial class frm_select_course : Form
    {
        public frm_select_course()
        {
            InitializeComponent();
        }

        private void frm_select_course_Load(object sender, EventArgs e)
        {
            loadRecords();
        }

        private void loadRecords()
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select code, description from courses", con);
            var dt = new DataTable();
            da.Fill(dt);
            dgv.DataSource = dt;
            
            dgv.Columns["code"].HeaderText = "Code";
            dgv.Columns["description"].HeaderText = "Description";
        }

        private DataTable searchRecords(string search)
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select code, description from courses where concat(code, description) like '%" + search + "%'", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        private void tSearch_TextChanged(object sender, EventArgs e)
        {
            if (tSearch.Text.Length > 2)
            {
                
                dgv.DataSource = searchRecords(tSearch.Text);
            }
            else if (tSearch.Text.Length == 0)
            {
                loadRecords();
            }
        }

        public string selectCourse()
        {
            return dgv.CurrentRow.Cells["code"].Value.ToString();
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            frm_student_enrollment.instance.course = selectCourse();
            Close();
        }
    }
}
