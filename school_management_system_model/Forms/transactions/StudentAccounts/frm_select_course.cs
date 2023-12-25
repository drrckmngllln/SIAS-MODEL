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
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select code, description, level, campus from courses", con);
            var dt = new DataTable();
            da.Fill(dt);
            dgv.DataSource = dt;
            dgv.Columns["code"].HeaderText = "Code";
            dgv.Columns["description"].HeaderText = "Description";
            dgv.Columns["description"].Width = 350;
            dgv.Columns["campus"].HeaderText = "Campus";
            dgv.Columns["level"].HeaderText = "Level";
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
            frm_create_account.instance.course = dgv.CurrentRow.Cells["code"].Value.ToString();
            frm_create_account.instance.campus = dgv.CurrentRow.Cells["campus"].Value.ToString();
            Close();
        }
    }
}
