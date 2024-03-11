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
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace school_management_system_model.Forms.transactions.StudentDiscounts
{
    public partial class frm_select_student : KryptonForm
    {
        private readonly StudentAccountRepository _studentAccountRepo = new StudentAccountRepository();

        PaginationParams paging = new PaginationParams();

        public frm_select_student()
        {
            InitializeComponent();
        }

        private async void frm_select_student_Load(object sender, EventArgs e)
        {
            await loadRecords();
        }

        private async Task loadRecords()
        {
            paging.PageSize = 10;
            var studentAccounts = await _studentAccountRepo.GetAllAsync();

            var students = studentAccounts.Skip(paging.PageSize * (paging.pageNumber - 1)).Take(paging.pageNumber).ToList();

            //var con = new MySqlConnection(connection.con());
            //var da = new MySqlDataAdapter("select * from student_accounts", con);
            //var dt = new DataTable();
            //da.Fill(dt);
            //dgv.DataSource = dt;

            dgv.DataSource = students;
            dgv.Columns["id"].Visible = false;
            dgv.Columns["id_number"].HeaderText = "Student Number";
            dgv.Columns["sy_enrolled"].Visible = false;
            dgv.Columns["type_of_student"].Visible = false;
            dgv.Columns["date_of_admission"].Visible = false;
            dgv.Columns["school_year_id"].Visible = false;
            dgv.Columns["fullname"].HeaderText = "Student Name";
            dgv.Columns["last_name"].Visible = false;
            dgv.Columns["first_name"].Visible = false;
            dgv.Columns["middle_name"].Visible = false;
            dgv.Columns["gender"].Visible = false;
            dgv.Columns["civil_status"].Visible = false;
            dgv.Columns["date_of_birth"].Visible = false;
            dgv.Columns["place_of_birth"].Visible = false;
            dgv.Columns["nationality"].Visible = false;
            dgv.Columns["religion"].Visible = false;
            dgv.Columns["status"].Visible = false;
            dgv.Columns["status"].Visible = false;
            dgv.Columns["contact_no"].Visible = false;
            dgv.Columns["email"].Visible = false;
            dgv.Columns["elem"].Visible = false;
            dgv.Columns["jhs"].Visible = false;
            dgv.Columns["shs"].Visible = false;
            dgv.Columns["elem_year"].Visible = false;
            dgv.Columns["jhs_year"].Visible = false;
            dgv.Columns["shs_year"].Visible = false;
            dgv.Columns["mother_name"].Visible = false;
            dgv.Columns["mother_no"].Visible = false;
            dgv.Columns["father_name"].Visible = false;
            dgv.Columns["father_no"].Visible = false;
            dgv.Columns["home_address"].Visible = false;
            dgv.Columns["m_occupation"].Visible = false;
            dgv.Columns["f_occupation"].Visible = false;


        }

        private string selectStudentName()
        {
            return dgv.CurrentRow.Cells["fullname"].Value.ToString();
        }
        private string selectStudentId()
        {
            return dgv.CurrentRow.Cells["id_number"].Value.ToString();
        }

        private void frm_select_student_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                frm_student_discounts.instance.idNumber = selectStudentId();
                frm_student_discounts.instance.fullname = selectStudentName();
                Close();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private async Task searchRecords(string search)
        {
            var studentAccounts = await _studentAccountRepo.GetAllAsync();

            var searchAccount = studentAccounts
                .Where(x => x.fullname.ToLower().Contains(search) || x.id_number.ToLower().Contains(search))
                .ToList();

            dgv.DataSource = searchAccount;

            //var con = new MySqlConnection(connection.con());
            //var da = new MySqlDataAdapter("select * from student_accounts where concat(id_number, fullname) " +
            //    "like '%" + search + "%'", con);
            //var dt = new DataTable();
            //da.Fill(dt);
        }

        private async void tSearch_TextChanged(object sender, EventArgs e)
        {
            if (tSearch.Text.Length > 2)
            {
                await searchRecords(tSearch.Text);
            }
            else if (tSearch.Text.Length == 0)
            {
                await loadRecords();
            }
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnNext_Click(object sender, EventArgs e)
        {
            paging.pageNumber++;
            tPageSize.Text = paging.pageNumber.ToString();
            await loadRecords();
            if (dgv.Rows.Count < paging.PageSize)
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

        private void btnSelect_Click(object sender, EventArgs e)
        {
            frm_student_discounts.instance.idNumber = selectStudentId();
            frm_student_discounts.instance.fullname = selectStudentName();
            Close();
        }
    }
}
