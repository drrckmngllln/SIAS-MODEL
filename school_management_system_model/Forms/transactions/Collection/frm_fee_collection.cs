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
        public static frm_fee_collection instance;
        public string id_number { get; set; }
        public frm_fee_collection()
        {
            instance = this;
            InitializeComponent();
        }

        private void frm_fee_collection_Load(object sender, EventArgs e)
        {
            loadSchoolYear();
        }

        private void loadSchoolYear()
        {
            var schoolYear = new FeeCollection();
            var data = schoolYear.loadSchoolYear();
            foreach(DataRow row in data.Rows)
            {
                tSchoolYear.Items.Add(row["code"]);
                if (row["is_current"].ToString() == "Yes")
                {
                    tSchoolYear.Text = row["code"].ToString();
                }
            }
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
            tYearLevel.Text = idNumber.Rows[0]["year_level"].ToString();
            tSemester.Text = idNumber.Rows[0]["semester"].ToString();
        }
        private void loadStatementOfAccount()
        {
            var data = new FeeCollection();
            var idNumber = data.loadStatementOfAccounts(tIdNumber.Text);
            dgv.DataSource = idNumber;
            dgv.Columns["id"].Visible = false;
            dgv.Columns["id_number"].Visible = false;
            dgv.Columns["date"].HeaderText = "Date";
            dgv.Columns["year_level"].Visible = false;
            dgv.Columns["semester"].Visible = false;
            dgv.Columns["school_year"].Visible = false;
            dgv.Columns["course"].Visible = false;
            dgv.Columns["reference_no"].HeaderText = "OR Number";
            dgv.Columns["particulars"].HeaderText = "Particulars";
            dgv.Columns["debit"].HeaderText = "Debit";
            dgv.Columns["credit"].HeaderText = "Credit";
            dgv.Columns["balance"].HeaderText = "Balance";
            dgv.Columns["cashier_in_charge"].Visible = false;
        }

        private void loadFeeBreakdown()
        {
            var data = new FeeCollection();
            var idNumber = data.loadFeeBreakdown(tIdNumber.Text);

            dgvFeeBreakdown.Columns.Add("term", "Term");
            dgvFeeBreakdown.Columns.Add("amount", "Amount");

            string[] term = { "Downpayment", "Prelims", "Midterms", "Semi-Finals", "Finals" };

            for (int i = 0;i < 5; i++)
            {
                dgvFeeBreakdown.Rows.Add(term[i], idNumber.Rows[0][i + 3]);
            }
        }

        private void loadRecords()
        {
            try
            {
                loadStudentAccount();
                loadStudentCourse();
                loadStatementOfAccount();
                loadFeeBreakdown();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tAmount.Clear();
                tAmount.Select();
            }
        }

        private void tSearch_Click(object sender, EventArgs e)
        {
            var frm = new frm_select_student();
            frm.Text = "Fee Collection";
            frm.ShowDialog();
            if (id_number != null)
            {
                tIdNumber.Text = id_number;
                loadRecords();
            }
        }

        private void soaCollection()
        {
            int referenceNo = 0;
            var data = new FeeCollection();
            referenceNo = data.getReferenceNo();
            referenceNo++;

            var soa = new FeeCollection();
            var latestSoa = soa.getLatestSoa(tIdNumber.Text, tSchoolYear.Text);
            decimal latestBalance = Convert.ToDecimal(latestSoa.Rows[0]["balance"]);
            decimal latestCredit = Convert.ToDecimal(tAmount.Text);
            string latestParticulars = tParticulars.Text;

            var collect = new FeeCollection
            {
                school_year = tSchoolYear.Text,
                date = DateTime.Now.ToString("MM-dd-yyyy"),
                course = tCourse.Text,
                year_level = tYearLevel.Text,
                semester = tSemester.Text,
                reference_no = referenceNo,
                particulars = latestParticulars,
                debit = latestBalance,
                credit = latestCredit,
                balance = latestBalance - latestCredit,
                cashier_in_charge = ""
            };
            collect.soaCollection(tIdNumber.Text);
            MessageBox.Show("Fee Collected", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            var referenceNumberIncrement = new FeeCollection();
            referenceNumberIncrement.incrementReferenceNo(referenceNo);
            loadStatementOfAccount();
        }

        private void feeBreakdownCollection()
        {
            decimal amount = Convert.ToDecimal(tAmount.Text);

            foreach(DataGridViewRow row in dgvFeeBreakdown.Rows)
            {
                decimal y = Convert.ToDecimal(row.Cells["amount"].Value);
                if (y > 0)
                {
                    y -= amount;
                    amount -= y;
                    row.Cells["amount"].Value = y;
                }
            }
        }

        private void btnConfirmPayment_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm Payment: " + tAmount.Text + ", Particulars: " + tParticulars.Text, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                soaCollection();
            }
            try
            {
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            feeBreakdownCollection();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            feeBreakdownCollection();
        }
    }
}
