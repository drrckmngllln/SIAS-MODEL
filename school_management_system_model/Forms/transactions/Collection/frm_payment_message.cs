using Krypton.Toolkit;
using Microsoft.Reporting.WinForms;
using MySql.Data.MySqlClient;
using school_management_system_model.Data.Repositories.Transaction.StudentAccounts;
using school_management_system_model.Infrastructure.Data.Repositories;
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
    public partial class frm_payment_message : KryptonForm
    {
        StudentAccountRepository _studentAccountRepo = new StudentAccountRepository();
        StatementOfAccountsRepository _statementOfAccountRepo = new StatementOfAccountsRepository();
        private readonly string paymentTendered;
        private readonly string remainingBalance;

        public frm_payment_message(string idNumber, decimal change, string cashier, string paymentTendered, string remainingBalance)
        {
            InitializeComponent();
            IdNumber = idNumber;
            Change = change;
            this.paymentTendered = paymentTendered;
            this.remainingBalance = remainingBalance;
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
            if (this.Text == "Fee Collection")
            {
                //var studentAccounts = await _studentAccountRepo.GetAllAsync();
                //var student = studentAccounts.Where(x => x.id_number == IdNumber).ToList();
                //var studentAccountDt = student.ToDataTable();

                //var statementOfAccounts = await _statementOfAccountRepo.GetAllAsync();
                //var soa = statementOfAccounts.Where(x => x.id_number == student.FirstOrDefault().id.ToString()).ToList();
                //var soaDt = soa.ToDataTable();


                //crv.LocalReport.DataSources.Clear();
                //var rpt = new ReportDataSource("StudentAccounts", studentAccountDt);

                //var rpt2 = new ReportDataSource("StatementOfAccounts", soaDt);

                crv.LocalReport.ReportPath = Application.StartupPath + @"\Reports\isap_receipt.rdlc";

                var changeParams = new ReportParameterCollection();
                changeParams.Add(new ReportParameter("ChangeParams", tChange.Text));

                var paymentTenderedParams = new ReportParameterCollection();
                paymentTenderedParams.Add(new ReportParameter("PaymentTenderedParams", paymentTendered));

                var remainingBalanceParams = new ReportParameterCollection();
                remainingBalanceParams.Add(new ReportParameter("RemainingBalanceParams", remainingBalance));

                crv.LocalReport.SetParameters(changeParams);
                crv.LocalReport.SetParameters(paymentTenderedParams);
                crv.LocalReport.SetParameters(changeParams);
                //crv.LocalReport.DataSources.Add(rpt);
                //crv.LocalReport.DataSources.Add(rpt2);




                crv.SetDisplayMode(DisplayMode.PrintLayout);
                crv.ZoomMode = ZoomMode.Percent;
                crv.ZoomPercent = 100;
                await Task.Delay(1000);
                crv.RefreshReport();
            }
            else if (this.Text == "Non Assessed Collection")
            {
                crv.LocalReport.ReportPath = Application.StartupPath + @"\Reports\isap_receipt.rdlc";

                var changeParams = new ReportParameterCollection();
                changeParams.Add(new ReportParameter("ChangeParams", tChange.Text));

                var paymentTenderedParams = new ReportParameterCollection();
                paymentTenderedParams.Add(new ReportParameter("PaymentTenderedParams", paymentTendered));

                var remainingBalanceParams = new ReportParameterCollection();
                remainingBalanceParams.Add(new ReportParameter("RemainingBalanceParams", remainingBalance));

                crv.LocalReport.SetParameters(changeParams);
                crv.LocalReport.SetParameters(paymentTenderedParams);
                crv.LocalReport.SetParameters(changeParams);

                crv.SetDisplayMode(DisplayMode.PrintLayout);
                crv.ZoomMode = ZoomMode.Percent;
                crv.ZoomPercent = 100;
                await Task.Delay(1000);
                crv.RefreshReport();
            }
            
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
