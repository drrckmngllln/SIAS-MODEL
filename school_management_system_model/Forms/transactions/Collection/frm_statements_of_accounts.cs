using school_management_system_model.Classes;
using school_management_system_model.Data.Repositories.Setings;
using school_management_system_model.Data.Repositories.Transaction;
using school_management_system_model.Infrastructure.Data.Repositories.Transaction;
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
    public partial class frm_statements_of_accounts : Form
    {
        StudentCourseRepository _studentCourseRepo = new StudentCourseRepository();
        StatementOfAccountsRepository _statementOfAccountsRepo = new StatementOfAccountsRepository();
        SchoolYearRepository _schoolYearRepo = new SchoolYearRepository();


        public static frm_statements_of_accounts instance;
        public string fullname { get; set; }
        public string id_number { get; set; }
        public frm_statements_of_accounts()
        {
            instance = this;
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var frm = new frm_select_student();
            frm.Text = "Statements Of Accounts";
            frm.ShowDialog();
            if (id_number != null)
            {
                tStudentName.Text = fullname.ToString();
                await loadStudentRecords();
                await loadRecords();
            }
        }

        private async Task loadStudentRecords()
        {
            var studentCourses = await _studentCourseRepo.GetAllAsync();
            var data = studentCourses.FirstOrDefault(x => x.id_number == id_number);

            tIdNumber.Text = data.id_number;
            tCourse.Text = data.course;
            tCampus.Text = data.campus;
            tYearLevel.Text = data.year_level;
            tSemester.Text = data.semester;
        }

        private async Task loadSchoolYear()
        {
            var schoolYear = await _schoolYearRepo.GetAllAsync();

            cmbSchoolYear.ValueMember = "id";
            cmbSchoolYear.DisplayMember = "code";
            cmbSchoolYear.DataSource = schoolYear;
        }

        private async Task loadRecords()
        {
            var data = await _statementOfAccountsRepo.GetAllAsync();
            var soa = data.Where(x =>  x.id_number == id_number)
                .ToList();
            dgv.DataSource = soa;
            dgv.Columns["id"].Visible = false;
            dgv.Columns["id_number"].Visible = false;
            dgv.Columns["date"].HeaderText = "Date";
            dgv.Columns["reference_no"].HeaderText = "OR Number";
            dgv.Columns["particulars"].HeaderText = "Particulars";
            //dgv.Columns["particulars"].Width = 150;
            dgv.Columns["debit"].HeaderText = "Debit";
            dgv.Columns["credit"].HeaderText = "Credit";
            dgv.Columns["balance"].HeaderText = "Balance";
            dgv.Columns["cashier_in_charge"].Visible = false;
            dgv.Columns["school_year"].Visible = false;
            dgv.Columns["course"].Visible = false;
            dgv.Columns["year_level"].Visible = false;
            dgv.Columns["semester"].Visible = false;

        }

        private async void tSearch_TextChanged(object sender, EventArgs e)
        {
            if (tSearch.Text.Length > 2)
            {
                var data = await _statementOfAccountsRepo.GetAllAsync();
                var search = data.Where(x => x.id_number.ToLower().Contains(tSearch.Text.ToLower())).ToList();
                dgv.DataSource = search;
            }
            else if (tSearch.Text.Length == 0)
            {
                await loadRecords();
            }
        }

        private async void frm_statements_of_accounts_Load(object sender, EventArgs e)
        {
            await loadSchoolYear();
        }

        private async void cmbSchoolYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            await loadRecords();
        }
    }
}
