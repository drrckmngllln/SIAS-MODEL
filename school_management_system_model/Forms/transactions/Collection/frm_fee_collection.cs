using school_management_system_model.Classes;
using school_management_system_model.Classes.Parameters;
using school_management_system_model.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace school_management_system_model.Forms.transactions.Collection
{
    public partial class frm_fee_collection : Form
    {
        public static frm_fee_collection instance;
        public string id_number { get; set; }

        school_management_system_model.Classes.Toastr Toastr = new school_management_system_model.Classes.Toastr();
        public frm_fee_collection()
        {
            instance = this;
            InitializeComponent();
        }

        private void frm_fee_collection_Load(object sender, EventArgs e)
        {
            loadFeeBreakdownDGV();
            loadAssessmentBreakdownDGV();
            loadSchoolYear();
        }

        private void loadFeeBreakdownDGV()
        {
            dgvFeeBreakdown.Columns.Add("term", "Term");
            dgvFeeBreakdown.Columns.Add("amount", "Amount");

           
        }
        private void loadAssessmentBreakdownDGV()
        {
            dgvAssessmentBreakdown.Columns.Add("fee_type", "Fee Type");
            dgvAssessmentBreakdown.Columns.Add("amount", "Amount");

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
            tCampus.Text = idNumber.Rows[0]["campus"].ToString();
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
                loadAssessmentBreakdown();
                loadAmountPayable();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tAmount.Clear();
                tAmount.Select();
            }
        }

        private void loadAssessmentBreakdown()
        {
            var data = new FeeCollection().loadAssessmentBreakdown(tIdNumber.Text, tSchoolYear.Text);
            foreach (DataRow row in data.Rows)
            {
                dgvAssessmentBreakdown.Rows.Add(row["fee_type"].ToString(), row["amount"].ToString());
            }
        }

        private void tSearch_Click(object sender, EventArgs e)
        {
            
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
            decimal latestCredit = cPayment.Checked ? Convert.ToDecimal(tAmount.Text) : Convert.ToDecimal(tAmountPayable.Text);
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
            var referenceNumberIncrement = new FeeCollection();
            referenceNumberIncrement.incrementReferenceNo(referenceNo);
            loadStatementOfAccount();
        }
        private void assessmentBreakdownComputation()
        {
            decimal amount = amount = Convert.ToDecimal(tAmount.Text);
            decimal fee = 0;
            decimal result = 0;

            foreach (DataGridViewRow row in dgvAssessmentBreakdown.Rows)
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

        private void assessmentBreakdownSave()
        {
            assessmentBreakdownComputation();

            foreach (DataGridViewRow row in dgvAssessmentBreakdown.Rows)
            {
                var parameter = new SaveAssessmentBreakdownParams
                {
                    id_number = tIdNumber.Text,
                    fee_type = row.Cells["fee_type"].Value.ToString(),
                    amount = Convert.ToDecimal(row.Cells["amount"].Value)
                };
                var x = new FeeCollection();
                x.assessmentBreakdownSave(parameter.id_number, parameter.amount, parameter.fee_type);
            }
        }

        

        private void btnConfirmPayment_Click(object sender, EventArgs e)
        {
            if (tAmount.Text == "")
            {
                Toastr.toast("Error", "Missing Fields");
            }
            else
            {
                decimal collection = Convert.ToDecimal(tAmount.Text);
                decimal payable = Convert.ToDecimal(tAmountPayable.Text);
                decimal change = 0;
                if (collection < 500 && (decimal)dgvFeeBreakdown.Rows[0].Cells["amount"].Value > 0)
                {
                    Toastr.toast("Error", "Payment amount not accepted!");
                }
                else if (cPayment.Checked)
                {
                    if (MessageBox.Show("Confirm Payment: " + tAmount.Text + ", Particulars: " + tParticulars.Text, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        soaCollection();
                        feeBreakDownSave();
                        assessmentBreakdownSave();

                        var data = new FeeCollection();
                        var studentStatus = data.loadStudentAccounts(tIdNumber.Text);

                        if (studentStatus.Rows[0]["status"].ToString() == "Accounting")
                        {
                            var changeStatus = new FeeCollection();
                            changeStatus.StudentStatusChange(tIdNumber.Text, tSchoolYear.Text);
                        }

                        var frm = new frm_payment_message(tIdNumber.Text, 0);
                        frm.ShowDialog();
                    }
                }
                else
                {
                    change = collection - payable;

                    if (change < 0)
                    {
                        Toastr.toast("Error", "Payment not accepted, please provide higher than the payable");
                    }
                    else
                    {
                        soaCollection();
                        feeBreakDownSave();
                        assessmentBreakdownSave();

                        var data = new FeeCollection();
                        var studentStatus = data.loadStudentAccounts(tIdNumber.Text);

                        if (studentStatus.Rows[0]["status"].ToString() == "Accounting")
                        {
                            var changeStatus = new FeeCollection();
                            changeStatus.StudentStatusChange(tIdNumber.Text, tSchoolYear.Text);
                        }

                        var frm = new frm_payment_message(tIdNumber.Text, change);
                        frm.ShowDialog();
                    }
                }
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var frm = new frm_select_student();
            frm.Text = "Fee Collection";
            frm.ShowDialog();
            if (id_number != null)
            {
                dgvFeeBreakdown.Rows.Clear();
                dgvAssessmentBreakdown.Rows.Clear();
                tIdNumber.Text = id_number;
                loadRecords();
                
            }
        }

        private void loadAmountPayable()
        {
            decimal amount = 0;
            foreach (DataGridViewRow row in dgvFeeBreakdown.Rows )
            {
                if ((decimal)row.Cells["amount"].Value > 0)
                {
                    tAmountPayable.Text = row.Cells["amount"].Value.ToString();
                    break;
                }
            }
        }

        private void tPrint_Click(object sender, EventArgs e)
        {
            var frm = new frm_print_receipt(tCampus.Text, tIdNumber.Text);
            frm.Text = "ISAP";
            frm.ShowDialog();

            var frm2 = new frm_print_receipt_breakdown(tIdNumber.Text, tSchoolYear.Text);
            frm.Text = "ISAP";
            frm2.ShowDialog();
        }
    }
}
