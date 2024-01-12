using Krypton.Toolkit;
using Microsoft.Reporting.WinForms;
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
    public partial class frm_payment_message : KryptonForm
    {
        public frm_payment_message(string idNumber, decimal change)
        {
            InitializeComponent();
            IdNumber = idNumber;
            Change = change;
        }

        public string IdNumber { get; }
        public decimal Change { get; }

        private void frm_payment_message_Load(object sender, EventArgs e)
        {

            this.crv.RefreshReport();
            loadChange();
            loadRecords();
        }

        private void loadChange()
        {
            tChange.Text = Change.ToString();
        }

        private async void loadRecords()
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from student_accounts where id_number='" + IdNumber + "'", con);
            var studentAccounts = new DataTable();
            da.Fill(studentAccounts);

            da = new MySqlDataAdapter("select * from statements_of_accounts where id_number='" + IdNumber + "' order by id desc", con);
            var statementOfAccounts = new DataTable();
            da.Fill(statementOfAccounts);

            crv.LocalReport.DataSources.Clear();
            var rpt = new ReportDataSource("StudentAccounts", studentAccounts);

            var rpt2 = new ReportDataSource("StatementOfAccounts", statementOfAccounts);

            crv.LocalReport.ReportPath = Application.StartupPath + @"\Reports\isap_receipt.rdlc";

            var changeParams = new ReportParameterCollection();
            changeParams.Add(new ReportParameter("ChangeParams", tChange.Text));

            crv.LocalReport.SetParameters(changeParams);
            crv.LocalReport.DataSources.Add(rpt);
            crv.LocalReport.DataSources.Add(rpt2);




            crv.SetDisplayMode(DisplayMode.PrintLayout);
            crv.ZoomMode = ZoomMode.Percent;
            crv.ZoomPercent = 100;
            await Task.Delay(1000);
            crv.RefreshReport();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void printReceipt()
        {
            crv.PrintDialog();
        }

        private void btnConfirmPayment_Click(object sender, EventArgs e)
        {
            printReceipt();
        }

        private void frm_payment_message_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                printReceipt();
            }
        }
    }
}
