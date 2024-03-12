using school_management_system_model.Classes.Parameters;
using school_management_system_model.Core.Dtos;
using school_management_system_model.Data.Repositories.Transaction.StudentAccounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace school_management_system_model.Forms.transactions.StudentAccounts.StudentAccountsComponents
{
    public partial class frmStudentAccountsList : Form
    {
        StudentAccountRepository _studentAccountRepo = new StudentAccountRepository();
        PaginationParams paging = new PaginationParams();

        public int ID { get; set; }
        public static frmStudentAccountsList instance;
        public frmStudentAccountsList()
        {
            instance = this;
            InitializeComponent();
        }

        private async void frmStudentAccountsList_Load(object sender, EventArgs e)
        {
            await loadRecords(tSearch.Text);
        }


        private async Task loadRecords(string search)
        {
            paging.PageSize = 10;
            var students = await _studentAccountRepo.GetStudentAccountsMain();
            if (string.IsNullOrEmpty(search))
            {
                var items = students
                    .Skip(paging.PageSize * (paging.pageNumber - 1))
                    .Take(paging.PageSize)
                    .ToList();
                dgv.DataSource = items;
            }
            else
            {
                var items = students.Where(x => x.name.ToLower().Contains(search))
                .Skip(paging.PageSize * (paging.pageNumber - 1))
                .Take(paging.pageNumber)
                .ToList();
                dgv.DataSource = items;
            }
            dgv.Columns["id"].Visible = false;
            dgv.Columns["name"].HeaderText = "Student Name";
            dgv.Columns["gender"].HeaderText = "Gender";
            dgv.Columns["type_of_student"].HeaderText = "Type of Student";
            dgv.Columns["admission_date"].HeaderText = "Admission Date";
            dgv.Columns["status"].HeaderText = "Status";
            dgv.Columns["name"].Width = 350;
        }



        private async void frmStudentAccountsList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                await loadRecords(tSearch.Text);
            }
        }

        private async void btnNext_Click(object sender, EventArgs e)
        {
            btnPrev.Enabled = true;
            paging.pageNumber++;
            tPageNumber.Text = paging.pageNumber.ToString();
            await loadRecords(tSearch.Text);

            if (dgv.Rows.Count < paging.PageSize)
            {
                btnNext.Enabled = false;
            }
        }

        private async void btnPrev_Click(object sender, EventArgs e)
        {
            btnNext.Enabled = true;
            paging.pageNumber--;
            tPageNumber.Text = paging.pageNumber.ToString();
            await loadRecords(tSearch.Text);
            if (tPageNumber.Text == "1")
            {
                btnPrev.Enabled = false;
            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value.ToString());
        }

        private async void tSearch_TextChanged(object sender, EventArgs e)
        {
            if (tSearch.Text.Length > 3)
            {
                await loadRecords(tSearch.Text);
            }
            else if (tSearch.Text.Length == 0)
            {
                await loadRecords(tSearch.Text);
            }
        }
    }
}
