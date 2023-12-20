using Krypton.Toolkit;
using Microsoft.Reporting.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace school_management_system_model.Reports.Accounting
{
    public partial class frm_print_assessment : KryptonForm
    {
        public string id_number { get; set; }
        public string school_year { get; set; }
        public frm_print_assessment()
        {
            InitializeComponent();
        }

        private void frm_print_assessment_Load(object sender, EventArgs e)
        {

            this.crv.RefreshReport();
            loadRecords();
        }

        private void loadRecords()
        {
            if (this.Text == "ISAP Assessment")
            {
                var con = new MySqlConnection(connection.con());
                var da = new MySqlDataAdapter("select * from student_accounts where id_number='"+ id_number +"'", con);
                var ds = new DataTable();
                da.Fill(ds);

                da = new MySqlDataAdapter("select * from student_course where id_number='"+ id_number +"'", con);
                var dt = new DataTable();
                da.Fill(dt);

                crv.LocalReport.DataSources.Clear();
                ReportDataSource rpt = new ReportDataSource("DataSet1", ds);
                var rpt2 = new ReportDataSource("DataSet2", dt);
                crv.LocalReport.ReportPath = "C:\\Users\\MCNP-ISAP\\Documents\\GitHub\\SIAS-MODEL\\school_management_system_model\\Reports\\Accounting\\isap_assessment.rdlc";
                crv.LocalReport.DataSources.Add(rpt);
                crv.LocalReport.DataSources.Add(rpt2);

                crv.RefreshReport();
            }
            else if (this.Text == "ISAP Student Schedule")
            {
                var dataset1 = new DataSet();
                var con = new MySqlConnection(connection.con());
                var da = new MySqlDataAdapter("select * from student_accounts where id_number='" + id_number + "'", con);
                var studentAccounts = new DataTable();
                da.Fill(studentAccounts);


                da = new MySqlDataAdapter("select * from student_course where id_number='" + id_number + "'", con);
                var studentCourse = new DataTable();
                da.Fill(studentCourse);

                da = new MySqlDataAdapter("select * from student_subjects where id_number='" + id_number + "' and school_year='" + school_year + "'", con);
                var studentSubjects = new DataTable();
                da.Fill(studentSubjects);

                crv.LocalReport.DataSources.Clear();
                var rpt = new ReportDataSource("StudentAccounts", studentAccounts);
                var rpt2 = new ReportDataSource("StudentCourse", studentCourse);
                var rpt3 = new ReportDataSource("StudentSubjects", studentSubjects);
                crv.LocalReport.ReportPath = "C:\\Users\\MCNP-ISAP\\Documents\\GitHub\\SIAS-MODEL\\school_management_system_model\\Reports\\Registrar\\isap_schedule.rdlc";
                
                crv.LocalReport.DataSources.Add(rpt);
                crv.LocalReport.DataSources.Add(rpt2);
                crv.LocalReport.DataSources.Add(rpt3);

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
    }
}
