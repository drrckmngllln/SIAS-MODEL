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

namespace school_management_system_model.Reports
{
    public partial class frm_print_receipt : Form
    {
        public frm_print_receipt(string campus, string idNumber)
        {
            InitializeComponent();
            Campus = campus;
            id_number = idNumber;
        }

        public string Campus { get; }
        public string id_number { get; }

        private void frm_print_receipt_Load(object sender, EventArgs e)
        {

            this.crv.RefreshReport();
            loadRecords(Campus);
        }

        private async void loadRecords(string campus)
        {
            //await Task.Delay(500);
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from student_accounts where id_number='" + id_number + "'", con);
            var studentAccounts = new DataTable();
            da.Fill(studentAccounts);

            da = new MySqlDataAdapter("select * from statements_of_accounts where id_number='" + id_number + "' order by id desc", con);
            var statementOfAccounts = new DataTable();
            da.Fill(statementOfAccounts);

            crv.LocalReport.DataSources.Clear();
            var rpt = new ReportDataSource("StudentAccounts", studentAccounts);
            
            var rpt2 = new ReportDataSource("StatementOfAccounts", statementOfAccounts);

            crv.LocalReport.ReportPath = "C:\\Users\\MCNP-ISAP\\Documents\\GitHub\\SIAS-MODEL\\school_management_system_model\\Reports\\Receipts\\isap_receipt.rdlc";

            crv.LocalReport.DataSources.Add(rpt);
            crv.LocalReport.DataSources.Add(rpt2);
            

            crv.SetDisplayMode(DisplayMode.PrintLayout);
            crv.ZoomMode = ZoomMode.Percent;
            crv.ZoomPercent = 100;
            await Task.Delay(1000);
            crv.RefreshReport();
        }
    }
}
