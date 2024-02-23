using school_management_system_model.Data.Repositories.Setings;
using school_management_system_model.Infrastructure.Data.Repositories.Transaction;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace school_management_system_model.Forms.transactions.Cashier
{
    public partial class frm_cashier_logs : Form
    {
        UserRepository _userRepo = new UserRepository();
        CashierLogRepository _cashierLogRepo = new CashierLogRepository();

        public static frm_cashier_logs instance;
        public string CashierName { get; set; }

        public frm_cashier_logs()
        {
            instance = this;
            InitializeComponent();
        }

        
        private async Task loadRecords()
        {
            DateTime startDate;
            DateTime endDate;
            var a = DateTime.TryParseExact(tFrom.Text, "yyyy-MM-dd", null, DateTimeStyles.None, out startDate);
            var b = DateTime.TryParseExact(tTo.Text, "yyyy-MM-dd", null, DateTimeStyles.None, out endDate);
            if (tName.Text == "ALL")
            {
                var logs = await _cashierLogRepo.GetAllAsync();
                var logsWithDate = logs.Where(x => x.date <= startDate && x.date <= endDate).ToList();
                dgv.DataSource = logsWithDate;
                dgv.Columns["id"].Visible = false;
                dgv.Columns["date"].Visible = false;
                dgv.Columns["name"].HeaderText = "Cashier Name";
                dgv.Columns["reference_no"].HeaderText = "Reference No";
                dgv.Columns["particulars"].HeaderText = "Particulars";
                dgv.Columns["school_year"].HeaderText = "School Year";
                dgv.Columns["department"].HeaderText = "Department";
                dgv.Columns["credit"].HeaderText = "Credit";
                dgv.Columns["debit"].HeaderText = "Debit";
                dgv.Columns["balance"].HeaderText = "Balance";
            }
            else
            {
                var logs = await _cashierLogRepo.GetAllAsync();
                var logsWithDateAndName = logs.Where(x => x.date <= startDate && x.date <= endDate && x.name ==  tName.Text).ToList();
                dgv.DataSource = logsWithDateAndName;
                dgv.Columns["id"].Visible = false;
                dgv.Columns["date"].Visible = false;
                dgv.Columns["name"].HeaderText = "Cashier Name";
                dgv.Columns["reference_no"].HeaderText = "Reference No";
                dgv.Columns["particulars"].HeaderText = "Particulars";
                dgv.Columns["school_year"].HeaderText = "School Year";
                dgv.Columns["department"].HeaderText = "Department";
                dgv.Columns["credit"].HeaderText = "Credit";
                dgv.Columns["debit"].HeaderText = "Debit";
                dgv.Columns["balance"].HeaderText = "Balance";
            }
        }
        private void frm_cashier_logs_Load(object sender, EventArgs e)
        {
            tFrom.Text = DateTime.Now.ToString("yyyy-MM-dd");
            
        }

        private async void tDateSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tDateSet.Text == "Daily")
            {
                tTo.Text = DateTime.Now.ToString("yyyy-MM-dd");
                await loadRecords();
            }
            else if (tDateSet.Text == "Weekly")
            {
                tTo.Text = DateTime.Now.AddDays(7).ToString("yyyy-MM-dd");
                await loadRecords();
            }
            else if (tDateSet.Text == "Monthly")
            {
                tTo.Text = DateTime.Now.AddMonths(1).ToString("yyyy-MM-dd");
                await loadRecords();

            }
            else if (tDateSet.Text == "Yearly")
            {
                tTo.Text = DateTime.Now.AddYears(1).ToString("yyyy-MM-dd");
                await loadRecords();

            }
        }

        private async void btnSelect_Click(object sender, EventArgs e)
        {
            var frm = new frm_select_cashier();
            frm.Text = "Select Cashier";
            frm.ShowDialog();
            if (CashierName != null)
            {
                tName.Text = CashierName;
            }
        }
    }
}
