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
        private readonly string name;
        private readonly string orNumber;
        private readonly string date;
        private readonly string cashAmount;
        private readonly string amountPaid;
        private readonly string change;
        private readonly string cashierInCharge;
        private readonly string amountInWords;

        public frm_payment_message(string name, string orNumber, string date, string cashAmount, string amountPaid, string change,
            string cashierInCharge, string amountInWords)
        {
            InitializeComponent();
            this.name = name;
            this.orNumber = orNumber;
            this.date = date;
            this.cashAmount = cashAmount;
            this.amountPaid = amountPaid;
            this.change = change;
            this.cashierInCharge = cashierInCharge;
            this.amountInWords = amountInWords;
        }

        private void frm_payment_message_Load(object sender, EventArgs e)
        {

            this.crv.RefreshReport();
            loadChange();
            loadRecords();
        }

        private void loadChange()
        {
            tChange.Text = change.ToString();
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


                crv.LocalReport.DataSources.Clear();
                //var rpt = new ReportDataSource("StudentAccounts", studentAccountDt);

                //var rpt2 = new ReportDataSource("StatementOfAccounts", soaDt);

                crv.LocalReport.ReportPath = Application.StartupPath + @"\Reports\isap_receipt.rdlc";

                var nameParams = new ReportParameterCollection();
                nameParams.Add(new ReportParameter("Name", name));

                var orNumberParams = new ReportParameterCollection();
                orNumberParams.Add(new ReportParameter("OrNumber", orNumber));

                var datParams = new ReportParameterCollection();
                datParams.Add(new ReportParameter("Date", date));

                var cashAmountParams = new ReportParameterCollection();
                cashAmountParams.Add(new ReportParameter("CashAmount", cashAmount));

                var amountPaidParams = new ReportParameterCollection();
                amountPaidParams.Add(new ReportParameter("AmountPaid", amountPaid));

                var changeParams = new ReportParameterCollection();
                changeParams.Add(new ReportParameter("Change", change));

                var cashierInChargeParams = new ReportParameterCollection();
                cashierInChargeParams.Add(new ReportParameter("CashierInCharge", cashierInCharge));

                var amountInWordParams = new ReportParameterCollection();
                amountInWordParams.Add(new ReportParameter("AmountInWords", amountInWords));


                crv.LocalReport.SetParameters(nameParams);
                crv.LocalReport.SetParameters(orNumberParams);
                crv.LocalReport.SetParameters(datParams);
                crv.LocalReport.SetParameters(cashAmountParams);
                crv.LocalReport.SetParameters(amountPaidParams);
                crv.LocalReport.SetParameters(changeParams);
                crv.LocalReport.SetParameters(cashierInChargeParams);
                crv.LocalReport.SetParameters(amountInWordParams);

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
                //var studentAccounts = await _studentAccountRepo.GetAllAsync();
                //var student = studentAccounts.Where(x => x.id_number == IdNumber).ToList();
                //var studentAccountDt = student.ToDataTable();

                //var statementOfAccounts = await _statementOfAccountRepo.GetAllAsync();
                //var soa = statementOfAccounts.Where(x => x.id_number == student.FirstOrDefault().id.ToString()).ToList();
                //var soaDt = soa.ToDataTable();


                //crv.LocalReport.DataSources.Clear();
                //var rpt = new ReportDataSource("StudentAccounts", studentAccountDt);

                //var rpt2 = new ReportDataSource("StatementOfAccounts", soaDt);
                //crv.LocalReport.ReportPath = Application.StartupPath + @"\Reports\isap_receipt.rdlc";

                //var changeParams = new ReportParameterCollection();
                //changeParams.Add(new ReportParameter("ChangeParams", tChange.Text));

                //var paymentTenderedParams = new ReportParameterCollection();
                //paymentTenderedParams.Add(new ReportParameter("PaymentTenderedParams", paymentTendered));

                //var remainingBalanceParams = new ReportParameterCollection();
                //remainingBalanceParams.Add(new ReportParameter("RemainingBalanceParams", remainingBalance));

                //crv.LocalReport.SetParameters(changeParams);
                //crv.LocalReport.SetParameters(paymentTenderedParams);
                //crv.LocalReport.SetParameters(changeParams);

                //crv.SetDisplayMode(DisplayMode.PrintLayout);
                //crv.ZoomMode = ZoomMode.Percent;
                //crv.ZoomPercent = 100;
                //await Task.Delay(1000);
                //crv.RefreshReport();
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
