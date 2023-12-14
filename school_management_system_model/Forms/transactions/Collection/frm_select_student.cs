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

namespace school_management_system_model.Forms.transactions.Collection
{
    public partial class frm_select_student : KryptonForm
    {
        public frm_select_student()
        {
            InitializeComponent();
        }

        private void frm_select_student_Load(object sender, EventArgs e)
        {
            tTitle.Text = this.Text;
            loadRecords();
        }

        private void loadRecords()
        {
            if (this.Text == "Statements Of Accounts")
            {
                var con = new MySqlConnection(connection.con());
                var da = new MySqlDataAdapter("select id_number, fullname from student_accounts", con);
                var dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
                dgv.Columns["id_number"].HeaderText = "Student Number";
                dgv.Columns["id_number"].Width = 150;
                dgv.Columns["fullname"].HeaderText = "Student Name";
            }
            else if (this.Text == "Fee Collection")
            {
                var con = new MySqlConnection(connection.con());
                var da = new MySqlDataAdapter("select id_number, fullname from student_accounts", con);
                var dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
                dgv.Columns["id_number"].HeaderText = "Student Number";
                dgv.Columns["id_number"].Width = 150;
                dgv.Columns["fullname"].HeaderText = "Student Name";
            }
        }

        private string selectStudentName()
        {
            return dgv.CurrentRow.Cells["fullname"].Value.ToString();
        }
        private string selectIdNumber()
        {
            return dgv.CurrentRow.Cells["id_number"].Value.ToString();
        }

        private void select()
        {
            if (this.Text == "Statements Of Accounts")
            {
                frm_statements_of_accounts.instance.id_number = dgv.CurrentRow.Cells["id_number"].Value.ToString();
                frm_statements_of_accounts.instance.fullname = dgv.CurrentRow.Cells["fullname"].Value.ToString();
                Close();
            }
            else if (this.Text == "Fee Collection")
            {
                frm_fee_collection.instance.id_number = selectIdNumber();
                Close();
            }
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frm_select_student_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                select();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            select();
        }
    }
}
