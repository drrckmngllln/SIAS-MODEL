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

namespace school_management_system_model.Reports.Accounting
{
    public partial class frm_isap_assessment : KryptonForm
    {
        public string id_number { get; set; }
        public string school_year { get; set; }
        public string campus { get; set; }
        public frm_isap_assessment()
        {
            InitializeComponent();
        }

        private void frm_isap_assessment_Load(object sender, EventArgs e)
        {
            loadRecords();
        }

        

        private async void loadRecords()
        {
            if (campus == "ISAP")
            {
                await Task.Delay(500);
                var con = new MySqlConnection(connection.con());
                var da = new MySqlDataAdapter("select * from student_accounts where id_number='" + id_number + "'", con);
                var studentAccounts = new DataTable();
                da.Fill(studentAccounts);


                da = new MySqlDataAdapter("select * from student_course where id_number='" + id_number + "'", con);
                var studentCourse = new DataTable();
                da.Fill(studentCourse);

                da = new MySqlDataAdapter("select * from student_assessment where id_number='"+ id_number +"' and school_year='"+ school_year +"'", con);
                var studentAssessment = new DataTable();
                da.Fill(studentAssessment);

                da = new MySqlDataAdapter("select * from fee_breakdown where id_number='" + id_number + "' and school_year='" + school_year + "'", con);
                var feeBreakdown = new DataTable();
                da.Fill(feeBreakdown);

                da = new MySqlDataAdapter("select * from student_subjects where id_number='" + id_number + "' and school_year='" + school_year + "'", con);
                var studentSubjects = new DataTable();
                da.Fill(studentSubjects);

                da = new MySqlDataAdapter("select * from fee_summary where id_number='" + id_number + "' and school_year='" + school_year + "'", con);
                var feeSummary = new DataTable();
                da.Fill(feeSummary);

                crv.LocalReport.DataSources.Clear();
                var rpt = new ReportDataSource("StudentAccounts", studentAccounts);
                var rpt2 = new ReportDataSource("StudentCourse", studentCourse);
                var rpt3 = new ReportDataSource("StudentAssessment", studentAssessment);
                var rpt4 = new ReportDataSource("FeeBreakdown", feeBreakdown);
                var rpt5 = new ReportDataSource("StudentSubjects", studentSubjects);
                var rpt6 = new ReportDataSource("FeeSummary", feeSummary);

                crv.LocalReport.ReportPath = Application.StartupPath + @"\Reports\isap_assessment.rdlc";

                crv.LocalReport.DataSources.Add(rpt);
                crv.LocalReport.DataSources.Add(rpt2);
                crv.LocalReport.DataSources.Add(rpt3);
                crv.LocalReport.DataSources.Add(rpt4);
                crv.LocalReport.DataSources.Add(rpt5);
                crv.LocalReport.DataSources.Add(rpt6);


                crv.SetDisplayMode(DisplayMode.PrintLayout);
                crv.ZoomMode = ZoomMode.Percent;
                crv.ZoomPercent = 100;
                await Task.Delay(1000);
                crv.RefreshReport();
            }
            else if (campus == "MCNP")
            {
                await Task.Delay(500);
                var con = new MySqlConnection(connection.con());
                var da = new MySqlDataAdapter("select * from student_accounts where id_number='" + id_number + "'", con);
                var studentAccounts = new DataTable();
                da.Fill(studentAccounts);


                da = new MySqlDataAdapter("select * from student_course where id_number='" + id_number + "'", con);
                var studentCourse = new DataTable();
                da.Fill(studentCourse);

                da = new MySqlDataAdapter("select * from student_assessment where id_number='" + id_number + "' and school_year='" + school_year + "'", con);
                var studentAssessment = new DataTable();
                da.Fill(studentAssessment);

                da = new MySqlDataAdapter("select * from fee_breakdown where id_number='" + id_number + "' and school_year='" + school_year + "'", con);
                var feeBreakdown = new DataTable();
                da.Fill(feeBreakdown);

                da = new MySqlDataAdapter("select * from student_subjects where id_number='" + id_number + "' and school_year='" + school_year + "'", con);
                var studentSubjects = new DataTable();
                da.Fill(studentSubjects);

                da = new MySqlDataAdapter("select * from fee_summary where id_number='" + id_number + "' and school_year='" + school_year + "'", con);
                var feeSummary = new DataTable();
                da.Fill(feeSummary);

                crv.LocalReport.DataSources.Clear();
                var rpt = new ReportDataSource("StudentAccounts", studentAccounts);
                var rpt2 = new ReportDataSource("StudentCourse", studentCourse);
                var rpt3 = new ReportDataSource("StudentAssessment", studentAssessment);
                var rpt4 = new ReportDataSource("FeeBreakdown", feeBreakdown);
                var rpt5 = new ReportDataSource("StudentSubjects", studentSubjects);
                var rpt6 = new ReportDataSource("FeeSummary", feeSummary);


                crv.LocalReport.DataSources.Add(rpt);
                crv.LocalReport.DataSources.Add(rpt2);
                crv.LocalReport.DataSources.Add(rpt3);
                crv.LocalReport.DataSources.Add(rpt4);
                crv.LocalReport.DataSources.Add(rpt5);
                crv.LocalReport.DataSources.Add(rpt6);

                crv.LocalReport.ReportPath = Application.StartupPath + @"\Reports\mcnp_assessment.rdlc";

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

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            crv.PrintDialog();
        }

        private void printDocument()
        {
            crv.PrintDialog();
        }

        private void frm_isap_assessment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                printDocument();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
    }
}
