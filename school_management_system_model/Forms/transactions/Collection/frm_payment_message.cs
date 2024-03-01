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
        private readonly string _name;
        private readonly string _orNumber;
        private readonly string _date;
        private readonly string _cashAmount;
        private readonly string _amountPaid;
        private readonly string _change;
        private readonly string _cashierInCharge;
        private readonly string _amountInWords;

        public frm_payment_message(string name, string orNumber, string date, string cashAmount, string amountPaid, string change,
            string cashierInCharge, string amountInWords)
        {
            InitializeComponent();
            _name = name;
            _orNumber = orNumber;
            _date = date;
            _cashAmount = cashAmount;
            _amountPaid = amountPaid;
            _change = change;
            _cashierInCharge = cashierInCharge;
            _amountInWords = amountInWords;
        }

        private void frm_payment_message_Load(object sender, EventArgs e)
        {

            this.crv.RefreshReport();
            loadChange();
            loadRecords();
        }

        private void loadChange()
        {
            tChange.Text = _change.ToString();
        }

        private async void loadRecords()
        {
            if (this.Text == "Fee Collection")
            {
                crv.LocalReport.DataSources.Clear();

                crv.LocalReport.ReportPath = Application.StartupPath + @"\Reports\isap_receipt.rdlc";

                var nameParams = new ReportParameterCollection();
                nameParams.Add(new ReportParameter("Name", _name));

                var orNumberParams = new ReportParameterCollection();
                orNumberParams.Add(new ReportParameter("OrNumber", _orNumber));

                var datParams = new ReportParameterCollection();
                datParams.Add(new ReportParameter("Date", _date));

                var cashAmountParams = new ReportParameterCollection();
                cashAmountParams.Add(new ReportParameter("CashAmount", _cashAmount));

                var amountPaidParams = new ReportParameterCollection();
                amountPaidParams.Add(new ReportParameter("AmountPaid", _amountPaid));

                var changeParams = new ReportParameterCollection();
                changeParams.Add(new ReportParameter("Change", _change));

                var cashierInChargeParams = new ReportParameterCollection();
                cashierInChargeParams.Add(new ReportParameter("CashierInCharge", _cashierInCharge));

                var amountInWordParams = new ReportParameterCollection();
                amountInWordParams.Add(new ReportParameter("AmountInWords", _amountInWords));


                crv.LocalReport.SetParameters(nameParams);
                crv.LocalReport.SetParameters(orNumberParams);
                crv.LocalReport.SetParameters(datParams);
                crv.LocalReport.SetParameters(cashAmountParams);
                crv.LocalReport.SetParameters(amountPaidParams);
                crv.LocalReport.SetParameters(changeParams);
                crv.LocalReport.SetParameters(cashierInChargeParams);
                crv.LocalReport.SetParameters(amountInWordParams);

                crv.SetDisplayMode(DisplayMode.PrintLayout);
                crv.ZoomMode = ZoomMode.Percent;
                crv.ZoomPercent = 100;
                await Task.Delay(1000);
                crv.RefreshReport();
            }
            else if (this.Text == "Non Assessed Collection")
            {
                crv.LocalReport.ReportPath = Application.StartupPath + @"\Reports\isap_receipt.rdlc";

                var nameParams = new ReportParameterCollection();
                nameParams.Add(new ReportParameter("Name", _name));

                var orNumberParams = new ReportParameterCollection();
                orNumberParams.Add(new ReportParameter("OrNumber", _orNumber));

                var datParams = new ReportParameterCollection();
                datParams.Add(new ReportParameter("Date", _date));

                var cashAmountParams = new ReportParameterCollection();
                cashAmountParams.Add(new ReportParameter("CashAmount", _cashAmount));

                var amountPaidParams = new ReportParameterCollection();
                amountPaidParams.Add(new ReportParameter("AmountPaid", _amountPaid));

                var changeParams = new ReportParameterCollection();
                changeParams.Add(new ReportParameter("Change", _change));

                var cashierInChargeParams = new ReportParameterCollection();
                cashierInChargeParams.Add(new ReportParameter("CashierInCharge", _cashierInCharge));

                var amountInWordParams = new ReportParameterCollection();
                amountInWordParams.Add(new ReportParameter("AmountInWords", _amountInWords));


                crv.LocalReport.SetParameters(nameParams);
                crv.LocalReport.SetParameters(orNumberParams);
                crv.LocalReport.SetParameters(datParams);
                crv.LocalReport.SetParameters(cashAmountParams);
                crv.LocalReport.SetParameters(amountPaidParams);
                crv.LocalReport.SetParameters(changeParams);
                crv.LocalReport.SetParameters(cashierInChargeParams);
                crv.LocalReport.SetParameters(amountInWordParams);

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
