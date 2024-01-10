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
    public partial class frm_print_receipt_breakdown : Form
    {
        public frm_print_receipt_breakdown(string idNumber, string schoolYear)
        {
            InitializeComponent();
            IdNumber = idNumber;
            SchoolYear = schoolYear;
        }

        public string IdNumber { get; }
        public string SchoolYear { get; }

        private void frm_print_receipt_breakdown_Load(object sender, EventArgs e)
        {

            this.crv.RefreshReport();
            loadRecords();
        }

        private async void loadRecords()
        {
            //await Task.Delay(500);
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from student_accounts where id_number='" + IdNumber + "'", con);
            var studentAccounts = new DataTable();
            da.Fill(studentAccounts);

            da = new MySqlDataAdapter("select * from student_course where id_number='"+ IdNumber +"'", con);
            var studentCourse = new DataTable();
            da.Fill(studentCourse);


            da = new MySqlDataAdapter("select * from assessment_breakdown where id_number='" + IdNumber + "' and school_year='"+ SchoolYear +"'", con);
            var assessmentBreakdown = new DataTable();
            da.Fill(assessmentBreakdown);

            da = new MySqlDataAdapter("select * from fee_breakdown where id_number='" + IdNumber + "' and school_year='" + SchoolYear + "'", con);
            var feeBreakdown = new DataTable();
            da.Fill(feeBreakdown);

            crv.LocalReport.DataSources.Clear();
            var rpt = new ReportDataSource("StudentAccounts", studentAccounts);

            var rpt2 = new ReportDataSource("AssessmentBreakdown", assessmentBreakdown);

            var rpt3 = new ReportDataSource("FeeBreakdown", feeBreakdown);

            var rpt4 = new ReportDataSource("StudentCourse", studentCourse);

            crv.LocalReport.ReportPath = "C:\\Users\\MCNP-ISAP\\Documents\\GitHub\\SIAS-MODEL\\school_management_system_model\\Reports\\Receipts\\isap_assessment_breakdown.rdlc";

            crv.LocalReport.DataSources.Add(rpt);
            crv.LocalReport.DataSources.Add(rpt2);
            crv.LocalReport.DataSources.Add(rpt3);
            crv.LocalReport.DataSources.Add(rpt4);


            crv.SetDisplayMode(DisplayMode.PrintLayout);
            crv.ZoomMode = ZoomMode.Percent;
            crv.ZoomPercent = 100;
            await Task.Delay(1000);
            crv.RefreshReport();
        }
    }
}
