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
                var dt = new DataTable();
                da.Fill(dt);
                crv.LocalReport.DataSources.Clear();
                ReportDataSource rpt = new ReportDataSource("DataSet1", dt);
                crv.LocalReport.ReportPath = "C:\\Users\\drrckmngllln\\Documents\\GitHub\\sias_model_mcnpisap\\school_management_system_model\\Reports\\Accounting\\isap_assessment.rdlc";
                crv.LocalReport.DataSources.Add(rpt);
                crv.RefreshReport();
            }
        }
    }
}
