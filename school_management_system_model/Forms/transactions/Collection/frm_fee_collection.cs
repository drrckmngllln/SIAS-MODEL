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
            loadFeeBreakdownDGV();
            loadSchoolYear();
        }

        private void loadFeeBreakdownDGV()
        {
            dgvFeeBreakdown.Columns.Add("term", "Term");
            dgvFeeBreakdown.Columns.Add("amount", "Amount");
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
            tStatus.Text = idNumber.Rows[0]["status"].ToString();
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

        private void feeBreakdownComputation()
        {
            decimal amount = amount = Convert.ToDecimal(tAmount.Text);
            decimal fee = 0;
            decimal result = 0;

            foreach (DataGridViewRow row in dgvFeeBreakdown.Rows)
            {
                fee = Convert.ToDecimal(row.Cells["amount"].Value);
                if (amount > fee)
                {

                    result = amount - fee;
                    row.Cells["amount"].Value = 0;
                    amount = result;
                }
                else if (amount <= fee)
                {
                    result = fee - amount;
                    row.Cells["amount"].Value = result;
                    amount = 0;

                    var term = Convert.ToDecimal(row.Cells["amount"].Value);
                    if (term != 0 && amount != 0)
                    {
                        amount -= term;
                        row.Cells["amount"].Value = amount;
                    }

                }
            }
        }

        private void feeBreakDownSave()
        {
            feeBreakdownComputation();

            var totalBreakdown = 
                Convert.ToDecimal(dgvFeeBreakdown.Rows[0].Cells["amount"].Value) +
                Convert.ToDecimal(dgvFeeBreakdown.Rows[1].Cells["amount"].Value) +
                Convert.ToDecimal(dgvFeeBreakdown.Rows[2].Cells["amount"].Value) +
                Convert.ToDecimal(dgvFeeBreakdown.Rows[3].Cells["amount"].Value) +
                Convert.ToDecimal(dgvFeeBreakdown.Rows[4].Cells["amount"].Value);


            var feeBreakdown = new FeeCollection
            {
                downpayment = Convert.ToDecimal(dgvFeeBreakdown.Rows[0].Cells["amount"].Value),
                prelim = Convert.ToDecimal(dgvFeeBreakdown.Rows[1].Cells["amount"].Value),
                midterm = Convert.ToDecimal(dgvFeeBreakdown.Rows[2].Cells["amount"].Value),
                semi_finals = Convert.ToDecimal(dgvFeeBreakdown.Rows[3].Cells["amount"].Value),
                finals = Convert.ToDecimal(dgvFeeBreakdown.Rows[4].Cells["amount"].Value),
                total = totalBreakdown
            };
            feeBreakdown.feeBreakdownSave(tIdNumber.Text, tSchoolYear.Text);
            //loadFeeBreakdown();
        }

        private void btnConfirmPayment_Click(object sender, EventArgs e)
        {
            decimal collection = Convert.ToDecimal(tAmount.Text);
            if (collection < 500)
            {
                MessageBox.Show("Error, Payment amount not accepted!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Confirm Payment: " + tAmount.Text + ", Particulars: " + tParticulars.Text, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    soaCollection();
                    feeBreakDownSave();

                    var data = new FeeCollection();
                    var studentStatus = data.loadStudentAccounts(tIdNumber.Text);

                    if (studentStatus.Rows[0]["status"].ToString() == "Accounting")
                    {
                        var changeStatus = new FeeCollection();
                        changeStatus.StudentStatusChange(tIdNumber.Text, tSchoolYear.Text);
                    }
                }
            }

            try
            {
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

       
    }
}
