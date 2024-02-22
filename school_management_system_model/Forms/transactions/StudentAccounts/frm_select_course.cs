using Krypton.Toolkit;
using MySql.Data.MySqlClient;
using school_management_system_model.Classes;
using school_management_system_model.Data.Repositories.Setings;
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
        CourseRepository _courseRepo = new CourseRepository();
        public frm_select_course()
        {
            InitializeComponent();
        }

        private void frm_select_course_Load(object sender, EventArgs e)
        {
            loadCourses();
        }

        private async void loadCourses()
        {
            var courses = await _courseRepo.GetAllAsync();
            dgv.DataSource = courses.ToList();
            dgv.Columns["id"].Visible = false;
            dgv.Columns["code"].HeaderText = "Code";
            dgv.Columns["description"].HeaderText = "Description";
            dgv.Columns["level"].HeaderText = "Level";
            dgv.Columns["campus"].HeaderText = "Campus";
            dgv.Columns["department"].HeaderText = "Department";
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
            var campus = dgv.CurrentRow.Cells["campus"].Value.ToString();

            frm_create_account.instance.course = dgv.CurrentRow.Cells["id"].Value.ToString();
            frm_create_account.instance.campus = dgv.CurrentRow.Cells["campus"].Value.ToString();
            Close();
        }
    }
}
