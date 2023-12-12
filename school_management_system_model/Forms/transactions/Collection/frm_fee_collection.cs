using school_management_system_model.Classes;
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
    public partial class frm_fee_collection : Form
    {
        public frm_fee_collection()
        {
            InitializeComponent();
        }

        private void frm_fee_collection_Load(object sender, EventArgs e)
        {

        }

        private void loadStudentAccount()
        {
            var data = new FeeCollection();
            var idNumber = data.loadStudentAccounts(tIdNumber.Text);
            tStudentName.Text = idNumber.Rows[0]["fullname"].ToString();
        }
        private void loadStudentCourse()
        {
            var data = new FeeCollection();
            var idNumber = data.loadStudentCourse(tIdNumber.Text);
            tCourse.Text = idNumber.Rows[0]["course"].ToString();
        }
        private void loadStatementOfAccount()
        {
            var data = new FeeCollection();
            var idNumber = data.loadStatementOfAccounts(tIdNumber.Text);
            dgv.DataSource = idNumber;
            dgv.Columns["id"].Visible = false;
            dgv.Columns["id_number"].Visible = false;
            dgv.Columns["date"].HeaderText = "Date";
            dgv.Columns["reference_no"].HeaderText = "OR Number";
            dgv.Columns["particulars"].HeaderText = "Particulars";
            dgv.Columns["debit"].HeaderText = "Debit";
            dgv.Columns["credit"].HeaderText = "Credit";
            dgv.Columns["balance"].HeaderText = "Balance";
            dgv.Columns["cashier_in_charge"].Visible = false;
        }

        private void tSearch_Click(object sender, EventArgs e)
        {
            loadStudentAccount();
            loadStudentCourse();
            loadStatementOfAccount();
        }
    }
}
