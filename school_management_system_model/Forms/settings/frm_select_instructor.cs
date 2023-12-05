using Krypton.Toolkit;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace school_management_system_model.Forms.settings
{
    public partial class frm_select_instructor : KryptonForm
    {
        public frm_select_instructor()
        {
            InitializeComponent();
        }

        private void frm_select_instructor_Load(object sender, EventArgs e)
        {
            loadRecords();
        }

        private void loadRecords()
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from instructors", con);
            var dt = new DataTable();
            da.Fill(dt);
            dgv.DataSource = dt;
            dgv.Columns["id"].Visible = false;
            dgv.Columns["fullname"].HeaderText = "Full Name";
            dgv.Columns["department"].HeaderText = "Department";
            dgv.Columns["position"].HeaderText = "Position";
        }

        private void selectInstructor()
        {
            frm_section_subjects.instance.instructor = dgv.CurrentRow.Cells["fullname"].Value.ToString();
            this.Close();
        }

        private void tSearch_TextChanged(object sender, EventArgs e)
        {
            if (tSearch.Text.Length > 2)
            {
                var con = new MySqlConnection(connection.con());
                var da = new MySqlDataAdapter("select * from instructors where concat(fullname, department, position) like '%"+ tSearch.Text +"%'", con);
                var dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
                dgv.Columns["fullname"].HeaderText = "Full Name";
                dgv.Columns["department"].HeaderText = "Department";
                dgv.Columns["position"].HeaderText = "Position";
            }
            else if (tSearch.Text.Length == 0)
            {
                loadRecords();
            }
        }

        private void frm_select_instructor_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                selectInstructor();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
