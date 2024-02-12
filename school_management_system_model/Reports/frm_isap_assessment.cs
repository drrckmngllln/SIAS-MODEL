using Krypton.Toolkit;
using Microsoft.Reporting.WinForms;
using MySql.Data.MySqlClient;
using school_management_system_model.Core.Entities;
using school_management_system_model.Data.Repositories.Transaction;
using school_management_system_model.Data.Repositories.Transaction.StudentAccounts;
using school_management_system_model.Data.Repositories.Transaction.StudentAssessment;
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

namespace school_management_system_model.Reports.Accounting
{
    public partial class frm_isap_assessment : KryptonForm
    {
        StudentAccountRepository _studentAccountRepo = new StudentAccountRepository();
        StudentCourseRepository _studentCourseRepo = new StudentCourseRepository();
        StudentAssessmentRepository _studentAssessmentRepo = new StudentAssessmentRepository();
        StudentSubjectRepository _studentSubjectRepo = new StudentSubjectRepository();
        FeeBreakdownRepository _feeBreakdownRepo = new FeeBreakdownRepository();
        FeeSummaryRepository _feeSummaryRepo = new FeeSummaryRepository();

        public string id_number { get; set; }
        public string school_year { get; set; }
        public string campus { get; set; }
        public frm_isap_assessment()
        {
            InitializeComponent();
        }

        private async void frm_isap_assessment_Load(object sender, EventArgs e)
        {
            await loadRecords();
        }

        

        private async Task loadRecords()
        {
            if (campus == "ISAP")
            {
                var studentAccounts = await _studentAccountRepo.GetAllAsync();
                var student = studentAccounts.Where(x => x.id_number == id_number).ToList();
                var studentAccountDt = student.ToDataTable();

                var studentCourse = await _studentCourseRepo.GetAllAsync();
                var course = studentCourse.Where(x => x.id_number == id_number).ToList();
                var studentCourseDt = course.ToDataTable();

                var studentAssessment = await _studentAssessmentRepo.GetAllAsync();
                var assessment = studentAssessment.Where(x => x.id_number == id_number).ToList();
                var studentAssessmentDT = assessment.ToDataTable();

                var feeBreakdowns = await _feeBreakdownRepo.GetAllAsync();
                var breakdown = feeBreakdowns.Where(x => x.id_number == id_number).ToList();
                var feeBreakdownDt = breakdown.ToDataTable();

                var studentSubjects = await _studentSubjectRepo.GetAllAsync();
                var subjects = studentSubjects.Where(x => x.id_number_id == id_number).ToList();
                var studentSubjectDt = subjects.ToDataTable();

                var feeSummaries = await _feeSummaryRepo.GetAllAsync();
                var summary = feeSummaries.Where(x => x.id_number == id_number).ToList();
                var feeSummaryDt = summary.ToDataTable();

                crv.LocalReport.DataSources.Clear();
                var rpt = new ReportDataSource("StudentAccounts", studentAccountDt);
                var rpt2 = new ReportDataSource("StudentCourse", studentCourseDt);
                var rpt3 = new ReportDataSource("StudentAssessment", studentAssessmentDT);
                var rpt4 = new ReportDataSource("FeeBreakdown", feeBreakdownDt);
                var rpt5 = new ReportDataSource("StudentSubjects", studentSubjectDt);
                var rpt6 = new ReportDataSource("FeeSummary", feeSummaryDt);


                crv.LocalReport.DataSources.Add(rpt);
                crv.LocalReport.DataSources.Add(rpt2);
                crv.LocalReport.DataSources.Add(rpt3);
                crv.LocalReport.DataSources.Add(rpt4);
                crv.LocalReport.DataSources.Add(rpt5);
                crv.LocalReport.DataSources.Add(rpt6);

                crv.LocalReport.ReportPath = Application.StartupPath + @"\Reports\isap_assessment.rdlc";

                crv.SetDisplayMode(DisplayMode.PrintLayout);
                crv.ZoomMode = ZoomMode.Percent;
                crv.ZoomPercent = 100;
                await Task.Delay(1000);
                crv.RefreshReport();
            }
            else if (campus == "MCNP")
            {

                var studentAccounts = await _studentAccountRepo.GetAllAsync();
                var student = studentAccounts.Where(x => x.id_number == id_number).ToList();
                var studentAccountDt = student.ToDataTable();
                
                var studentCourse = await _studentCourseRepo.GetAllAsync();
                var course = studentCourse.Where(x => x.id_number == id_number).ToList();
                var studentCourseDt = course.ToDataTable();

                var studentAssessment = await _studentAssessmentRepo.GetAllAsync();
                var assessment = studentAssessment.Where(x => x.id_number == id_number).ToList();
                var studentAssessmentDT = assessment.ToDataTable();

                var feeBreakdowns = await _feeBreakdownRepo.GetAllAsync();
                var breakdown = feeBreakdowns.Where(x => x.id_number == id_number).ToList();
                var feeBreakdownDt = breakdown.ToDataTable();

                var studentSubjects = await _studentSubjectRepo.GetAllAsync();
                var subjects = studentSubjects.Where(x => x.id_number_id == id_number).ToList();
                var studentSubjectDt = subjects.ToDataTable();

                var feeSummaries = await _feeSummaryRepo.GetAllAsync();
                var summary = feeSummaries.Where(x => x.id_number == id_number).ToList();
                var feeSummaryDt = summary.ToDataTable();

                crv.LocalReport.DataSources.Clear();
                var rpt = new ReportDataSource("StudentAccounts", studentAccountDt);
                var rpt2 = new ReportDataSource("StudentCourse", studentCourseDt);
                var rpt3 = new ReportDataSource("StudentAssessment", studentAssessmentDT);
                var rpt4 = new ReportDataSource("FeeBreakdown", feeBreakdownDt);
                var rpt5 = new ReportDataSource("StudentSubjects", studentSubjectDt);
                var rpt6 = new ReportDataSource("FeeSummary", feeSummaryDt);


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
