using school_management_system_model.Data.Repositories.Setings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace school_management_system_model.Forms.transactions.Cashier
{
    public partial class frm_select_cashier : Form
    {
        UserRepository _userRepo = new UserRepository();
        public frm_select_cashier()
        {
            InitializeComponent();
        }

        private async void frm_select_cashier_Load(object sender, EventArgs e)
        {
            await loadRecords();
        }

        private async Task loadRecords()
        {
            var users = await _userRepo.GetAllAsync();
            var cashier = users.Where(x => x.access_level == "Cashier").ToList();
            dgv.DataSource = cashier.Select(x => new
            {
                x.last_name, x.first_name, x.middle_name
            }).ToList();
            dgv.Columns["last_name"].HeaderText = "Last Name";
            dgv.Columns["first_name"].HeaderText = "First Name";
            dgv.Columns["middle_name"].HeaderText = "Middle Name";
        }

        private string selectName()
        {
            var cashierName = dgv.CurrentRow.Cells["last_name"].Value.ToString() + ", "
                + dgv.CurrentRow.Cells["first_name"].Value.ToString()  + " "
                + dgv.CurrentRow.Cells["middle_name"].Value.ToString();
            return cashierName;
        }

        private void frm_select_cashier_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                frm_cashier_logs.instance.CashierName = selectName();
                Close();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            frm_cashier_logs.instance.CashierName = selectName();
            Close();
        }
    }
}
