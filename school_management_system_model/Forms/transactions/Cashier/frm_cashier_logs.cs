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

        public frm_cashier_logs()
        {
            InitializeComponent();
        }

        
        private async Task loadRecords()
        {
            var logs = await _cashierLogRepo.GetAllAsync();

            
        }
        private void frm_cashier_logs_Load(object sender, EventArgs e)
        {
            tFrom.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void tDateSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tDateSet.Text == "Daily")
            {
                tTo.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
            else if (tDateSet.Text == "Weekly")
            {
                tTo.Text = DateTime.Now.AddDays(7).ToString("yyyy-MM-dd");
            }
            else if (tDateSet.Text == "Monthly")
            {
                tTo.Text = DateTime.Now.AddMonths(1).ToString("yyyy-MM-dd");
            }
            else if (tDateSet.Text == "Yearly")
            {
                tTo.Text = DateTime.Now.AddYears(1).ToString("yyyy-MM-dd");
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            var frm = new frm_select_cashier();
            frm.Text = "Select Cashier";
            frm.ShowDialog();
        }
    }
}
