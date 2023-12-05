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

namespace school_management_system_model.Forms.transactions
{
    public partial class frm_select_school_year : KryptonForm
    {
        public frm_select_school_year()
        {
            InitializeComponent();
        }

        private void frm_select_school_year_Load(object sender, EventArgs e)
        {
            loadRecords();
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
            dgv.Columns["description"].Width = 250;
            dgv.Columns["school_year_from"].Visible = false;
            dgv.Columns["school_year_to"].Visible = false;
            dgv.Columns["semester"].Visible = false;
            dgv.Columns["is_current"].HeaderText = "Default";
        }

        private DataTable searchRecords(string search)
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from school_year where concat(code, description) " +
                "like '%" + search + "%'", con);
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

        private string selectSchoolYear()
        {
            return dgv.CurrentRow.Cells["code"].Value.ToString();
        }

        private void frm_select_school_year_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                frm_student_accounts.instance.schoolYear = selectSchoolYear();
                Close();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
    }
}
