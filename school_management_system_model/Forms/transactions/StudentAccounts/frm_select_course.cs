using Krypton.Toolkit;
using MySql.Data.MySqlClient;
using school_management_system_model.Classes;
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
    public partial class frm_select_course : KryptonForm
    {
        public frm_select_course()
        {
            InitializeComponent();
        }

        private void frm_select_course_Load(object sender, EventArgs e)
        {
            loadCourses();
        }

        private void loadCourses()
        {
            var courses = new Courses().GetCourses();
            dgv.DataSource = courses.ToList();
            dgv.Columns["id"].Visible = false;
            dgv.Columns["code"].HeaderText = "Code";
            dgv.Columns["description"].HeaderText = "Description";
            dgv.Columns["level_id"].HeaderText = "Level";
            dgv.Columns["campus_id"].HeaderText = "Campus";
            dgv.Columns["department_id"].HeaderText = "Department";
            dgv.Columns["max_units"].HeaderText = "Max Units";
            dgv.Columns["status"].Visible = false;
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private DataTable searchRecords(string search)
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from courses where concat(code, description) like '%" + search + "%'", con);
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
                loadCourses();
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            var course = (int)dgv.CurrentRow.Cells["id"].Value;
            var campus = dgv.CurrentRow.Cells["campus_id"].Value.ToString();

            frm_create_account.instance.course = dgv.CurrentRow.Cells["id"].Value.ToString();
            frm_create_account.instance.campus = dgv.CurrentRow.Cells["campus_id"].Value.ToString();
            Close();
        }
    }
}
