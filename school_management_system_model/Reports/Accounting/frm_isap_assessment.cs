﻿using Krypton.Toolkit;
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

        private void loadRecords()
        {
            if (campus == "ISAP")
            {
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

                crv.LocalReport.DataSources.Clear();
                var rpt = new ReportDataSource("StudentAccounts", studentAccounts);
                var rpt2 = new ReportDataSource("StudentCourse", studentCourse);
                var rpt3 = new ReportDataSource("StudentAssessment", studentAssessment);
                var rpt4 = new ReportDataSource("FeeBreakdown", feeBreakdown);
                crv.LocalReport.ReportPath = "C:\\Users\\drrckmngllln\\Documents\\GitHub\\sias_model_mcnpisap\\school_management_system_model\\Reports\\Accounting\\isap_assessment.rdlc";

                crv.LocalReport.DataSources.Add(rpt);
                crv.LocalReport.DataSources.Add(rpt2);
                crv.LocalReport.DataSources.Add(rpt3);
                crv.LocalReport.DataSources.Add(rpt4);

                crv.SetDisplayMode(DisplayMode.PrintLayout);
                crv.ZoomMode = ZoomMode.Percent;
                crv.ZoomPercent = 100;
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
