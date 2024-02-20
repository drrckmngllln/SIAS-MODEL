using Krypton.Toolkit;
using MySql.Data.MySqlClient;
using school_management_system_model.Classes.Parameters;
using school_management_system_model.Data.Repositories.Transaction.StudentAccounts;
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
        readonly StudentAccountRepository _studentAccountRepo = new StudentAccountRepository();

        PaginationParams paging = new PaginationParams();
        public frm_select_student()
        {
            InitializeComponent();
        }

        private async void frm_select_student_Load(object sender, EventArgs e)
        {
            tTitle.Text = this.Text;
            await loadRecords();
        }

        private async Task loadRecords()
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
                paging.pageSize = 10;
                var studentAccounts = await _studentAccountRepo.GetAllAsync();
                var student = studentAccounts
                    .Select(x => new
                    {
                        x.id_number,
                        x.fullname
                    })
                    .Skip(paging.pageSize * (paging.pageNumber - 1))
                    .Take(paging.pageSize)
                    .ToList();

                //var con = new MySqlConnection(connection.con());
                //var da = new MySqlDataAdapter("select id_number, fullname from student_accounts", con);
                //var dt = new DataTable();
                //da.Fill(dt);
                dgv.DataSource = student;
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

        private DataTable searchRecords(string search)
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select id_number, fullname from student_accounts where concat(id_number, fullname) like '%" + search + "%'", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        private async void tSearch_TextChanged(object sender, EventArgs e)
        {
            if (tSearch.Text.Length > 2)
            {
                dgv.DataSource = searchRecords(tSearch.Text);
            }
            else if (tSearch.Text.Length == 0)
            {
                await loadRecords();
            }
        }

        private async void btnNext_Click(object sender, EventArgs e)
        {
            paging.pageNumber++;
            tPageSize.Text = paging.pageNumber.ToString();
            await loadRecords();
            if (dgv.Rows.Count < paging.pageSize)
            {
                btnNext.Enabled = false;
            }
            btnPrev.Enabled = true;
        }

        private async void btnPrev_Click(object sender, EventArgs e)
        {
            paging.pageNumber--;
            tPageSize.Text = paging.pageNumber.ToString();
            await loadRecords();
            if (tPageSize.Text == "1")
            {
                btnPrev.Enabled = false;
            }
            btnNext.Enabled = true;
        }
    }
}
