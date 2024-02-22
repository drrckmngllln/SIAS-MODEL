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

        internal class CashierLogDto
        {
            public int id { get; set; }
            public DateTime date { get; set; }
            public string name { get; set; }
            public string reference_no { get; set; }
            public string particulars { get; set; }
            public string school_year { get; set; }
            public string department { get; set; }
            public string credit { get; set; }
            public string debit { get; set; }
            public string balance { get; set; }
        }

        private async Task loadRecords()
        {
            var logs = await _cashierLogRepo.GetAllAsync();

            var lists = new List<CashierLogDto>();
            foreach (var log in logs)
            {

                var a = new CashierLogDto
                {

                    id = log.id,
                    date = Convert.ToDateTime(log.date),
                    name = log.name,
                    reference_no = log.reference_no,
                    particulars = log.particulars,
                    school_year = log.school_year,
                    department = log.department,
                    credit = log.credit,
                    debit = log.debit,
                    balance = log.balance,
                };
                lists.Add(a);
            }


        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            tFrom.Text = dateTimePicker1.Value.ToString("MM-dd-yyyy");
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            tTo.Text = dateTimePicker2.Value.ToString("MM-dd-yyyy");
        }
    }
}
