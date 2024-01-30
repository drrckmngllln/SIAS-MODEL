using Krypton.Toolkit;
using Microsoft.ReportingServices.Diagnostics.Internal;
using school_management_system_model.Classes;
using school_management_system_model.Classes.Parameters;
using school_management_system_model.Forms.transactions.StudentAssessment;
using school_management_system_model.Reports.Accounting;
using school_management_system_model.Reports.Datasets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace school_management_system_model.Forms.transactions
{
    public partial class frm_student_assessment : Form
    {
        public static frm_student_assessment instance;
        public string studentID { get; set; }
        public string schoolYear { get; set; }
        public decimal totalUnits { get; set; }
        public decimal totalTuitionFee { get; set; }
        public decimal totalMiscFee { get; set; }
        public decimal totalLabFee { get; set; }
        public decimal totalOtherFee { get; set; }
        public decimal totalFee { get; set; }
        public decimal labFee { get; set; }
        public decimal totalDiscount { get; set; }
        public string labFeeCategory { get; set; }

        public frm_student_assessment()
        {
            instance = this;
            InitializeComponent();
        }

        private void frm_student_assessment_Load(object sender, EventArgs e)
        {
            loadRecords();
        }

        private void loadRecords()
        {
            dgv.Columns.Add("category", "Category");
            //dgv.Columns["category"].Visible = false;
            dgv.Columns.Add("fee_type", "Fee Type");
            dgv.Columns.Add("amount", "Amount");
            dgv.Columns.Add("units", "Units");
            dgv.Columns.Add("computation", "Computation");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var frm = new frm_select_student();
            frm.Text = "Select Student";
            frm.ShowDialog();
            if (studentID != null)
            {
                // Getting Student Name

                var studentName = new StudentAccount().GetStudentAccounts()
                    .FirstOrDefault(x => x.id_number == studentID);
                tStudentName.Text = studentName.fullname;

                // Getting Student Course

                var studentCourse = new student_course().GetStudentCourses()
                    .FirstOrDefault(x => x.id_number_id == studentID);

                tIdNumber.Text = studentID.ToString();
                tCourse.Text = studentCourse.course_id.ToString();
                tYearLevel.Text = studentCourse.year_level;
                tSemester.Text = studentCourse.semester;
                tCampus.Text = studentCourse.campus_id;
            }
        }

        private void loadTuitionFeePerUnit()
        {

            var getStudentTuitionFee = new StudentSubject().GetStudentSubjects()
                .Where(x => x.id_number_id == tIdNumber.Text && x.school_year_id == tSchoolYear.Text)
                .ToList();
            decimal tuitionFee = 0;
            foreach (var item in getStudentTuitionFee)
            {
                tuitionFee += Convert.ToDecimal(item.lecture_units);
            }

            int yearLevel = Convert.ToInt32(tYearLevel.Text);

            var tuitionFeeSetup = new TuitionFeeSetup().GetTuitionFeeSetups()
                .FirstOrDefault(x => x.campus == tCampus.Text && x.year_level == tYearLevel.Text);

            if (tuitionFeeSetup == null)
            {
                new Classes.Toastr("Warning", "No Tuition Fee Set");
            }
            else
            {
                dgv.Rows.Add(tuitionFeeSetup.category, tuitionFeeSetup.description, tuitionFeeSetup.amount, tuitionFee, tuitionFee * tuitionFeeSetup.amount);
            }
        }

        private void loadMiscFeePerUnit()
        {
            var getMiscFeeSetup = new MiscellaneousFeeSetup().GetMiscellaneousFeeSetups()
                .Where(x => x.campus == tCampus.Text && x.year_level == tYearLevel.Text).ToList();

            if (getMiscFeeSetup != null)
            {
                foreach (var item in getMiscFeeSetup)
                {
                    dgv.Rows.Add(item.category, item.description, item.amount, 1, 1 * item.amount);
                }
            }
            else
            {
                new Classes.Toastr("Warning", "No Miscellaneous Fee Set");
            }

            var getOtherFeeSetup = new OtherFeesSetup().GetOtherFeesSetups()
            .Where(x => x.category == tCampus.Text && x.year_level == tYearLevel.Text).ToList();

            if (getOtherFeeSetup != null)
            {
                foreach (var item in getOtherFeeSetup)
                {
                    dgv.Rows.Add(item.category, item.description, item.amount, 1, item.amount * 1);
                }
            }
            else
            {
                new Classes.Toastr("Warning", "No Other Fee Set");
            }
        }

        private void addAssessmentRecords()
        {
            // Loading of Tuition Fee/Unit
            loadTuitionFeePerUnit();
            // Loading of Miscellaneous Fee
            loadMiscFeePerUnit();
            // Loading of Lab Fee
            loadLabFee();
            // Loading of Other Fee
            loadOtherFees();
        }

        private void loadOtherFees()
        {
            var otherFees = new OtherFeesSetup().GetOtherFeesSetups()
                .Where(x => x.campus == tCampus.Text && x.year_level == tYearLevel.Text).ToList();

            foreach (var item in otherFees)
            {
                dgv.Rows.Add(item.category, item.description, item.amount, 1, item.amount * 1);
            }
        }

        private void loadLabFee()
        {
            var studentSubjects = new StudentSubject().GetStudentSubjects()
                .Where(x => x.id_number_id == tIdNumber.Text && x.school_year_id == tSchoolYear.Text).ToList();

            var labFeeSubjects = new LabFeeSubjects().GetLabFeeSubjects().ToList();
            if (labFeeSubjects != null)
            {
                foreach (var studentSubjectItem in studentSubjects)
                {
                    foreach (var labFeeSubjectItems in labFeeSubjects)
                    {
                        var labFee = new LabFeeSetup().GetLabFeeSetups()
                            .FirstOrDefault(x => x.category == labFeeSubjectItems.lab_fee);
                        if (studentSubjectItem.subject_code == labFeeSubjectItems.subject_code)
                        {
                            decimal unitsComputation = Convert.ToDecimal(studentSubjectItem.lab_units) * Convert.ToDecimal(labFee.amount);
                            try
                            {
                                dgv.Rows.Add(labFee.category, labFee.description, labFee.amount, unitsComputation);
                            }
                            catch (Exception ex)
                            {
                                new Classes.Toastr("Warning", ex.Message);
                            }
                        }
                    }
                }
            }

            

            //var data = new student_assessment();
            //var schoolYear = data.getStudentSchoolYear(tIdNumber.Text);
            //var enrolledSubjects = data.loadEnrolledSubjects(tIdNumber.Text, schoolYear);
            //var labFeeSubjects = data.loadLabFeeSubjects();


            //foreach (DataRow row in enrolledSubjects.Rows)
            //{
            //    foreach (DataRow rows in labFeeSubjects.Rows)
            //    {
            //        if (rows["subject_code"].ToString() == row["subject_code"].ToString())
            //        {
            //            var labFee = data.loadLabFee(Convert.ToInt32(rows["lab_fee_id"]));
            //            if (tYearLevel.Text == "1")
            //            {
            //                decimal computation = 1 * Convert.ToDecimal(labFee.Rows[0]["first_year"]);
            //                totalLabFee = 0;
            //                dgv.Rows.Add(
            //                    labFee.Rows[0]["category"],
            //                    labFee.Rows[0]["description"],
            //                    labFee.Rows[0]["first_year"],
            //                    1,
            //                    computation
            //                    );
            //                totalLabFee = computation;
            //            }
            //            else if (tYearLevel.Text == "2")
            //            {
            //                decimal computation = 1 * Convert.ToDecimal(labFee.Rows[0]["second_year"]);
            //                dgv.Rows.Add(
            //                    labFee.Rows[0]["category"],
            //                    labFee.Rows[0]["description"],
            //                    labFee.Rows[0]["second_year"],
            //                    1,
            //                    1 * Convert.ToDecimal(labFee.Rows[0]["second_year"])
            //                    );
            //                totalLabFee = computation;
            //            }
            //            else if (tYearLevel.Text == "3")
            //            {
            //                decimal computation = 1 * Convert.ToDecimal(labFee.Rows[0]["third_year"]);
            //                dgv.Rows.Add(
            //                    labFee.Rows[0]["category"],
            //                    labFee.Rows[0]["description"],
            //                    labFee.Rows[0]["third_year"],
            //                    1,
            //                    1 * Convert.ToDecimal(labFee.Rows[0]["third_year"])
            //                    );
            //                totalLabFee = computation;
            //            }
            //            else if (tYearLevel.Text == "4")
            //            {
            //                decimal computation = 1 * Convert.ToDecimal(labFee.Rows[0]["fourth_year"]);
            //                dgv.Rows.Add(
            //                    labFee.Rows[0]["category"],
            //                    labFee.Rows[0]["description"],
            //                    labFee.Rows[0]["fourth_year"],
            //                    1,
            //                    1 * Convert.ToDecimal(labFee.Rows[0]["fourth_year"])
            //                    );
            //                totalLabFee = computation;
            //            }
            //        }
            //    }
            //}
        }

        private void loadAssessment()
        {
            addAssessmentRecords();

            //var assessment = new student_assessment();
            //var data = assessment.loadRecords(schoolYear, tIdNumber.Text);
            //if (data.Rows.Count > 0)
            //{
            //    //MessageBox.Show("Student Already Assessed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    new Classes.Toastr("Warning", "Student Already Assessed");
            //}
            //else
            //{
            //    dgv.Columns.Clear();
            //dgv.Columns.Add("category", "Category");
            ////dgv.Columns["category"].Visible = false;
            //dgv.Columns.Add("fee_type", "Fee Type");
            //dgv.Columns.Add("amount", "Amount");
            //dgv.Columns.Add("units", "Units");
            //dgv.Columns.Add("computation", "Computation");
            //addAssessmentRecords();
            //}
        }

        private void addLabFee()
        {
            dgv.Rows.Add(labFeeCategory, labFee, 1, 1 * labFee);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var frm = new frm_select_student();
            frm.Text = "Select School Year";
            frm.ShowDialog();
            if (schoolYear != null)
            {
                dgv.Rows.Clear();
                // Loading the assessment
                tSchoolYear.Text = schoolYear.ToString();
                loadAssessment();

                //foreach (DataGridViewRow row in dgv.Rows)
                //{
                //    if (row.Cells["category"].Value.ToString() == "Tuition Fee")
                //    {
                //        totalTuitionFee += Convert.ToDecimal(row.Cells["computation"].Value);
                //    }
                //    else if (row.Cells["category"].Value.ToString() == "Miscellaneous Fee")
                //    {
                //        totalMiscFee += Convert.ToDecimal(row.Cells["computation"].Value);
                //    }
                //    else if (row.Cells["category"].Value.ToString() == "Laboratory Fee")
                //    {
                //        totalLabFee += Convert.ToDecimal(row.Cells["computation"].Value);
                //    }
                //    else if (row.Cells["category"].Value.ToString() == "Other Fees")
                //    {
                //        totalOtherFee += Convert.ToDecimal(row.Cells["computation"].Value);
                //    }
                //}
                //loadDiscounts();

                //FeeBreakDown();
            }
        }

        private void totalTimer_Tick(object sender, EventArgs e)
        {

            tuitionFeeTotal.Text = totalTuitionFee.ToString();
            miscellaneousFeeTotal.Text = totalMiscFee.ToString();
            otherFeesTotal.Text = totalOtherFee.ToString();
            labFeeTotal.Text = totalLabFee.ToString();
            discountTotal.Text = totalDiscount.ToString();
            totalFee = totalTuitionFee + totalMiscFee + totalLabFee + totalOtherFee;
            tTotal.Text = totalFee.ToString();
            computeAssessment();
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            var frm = new frm_select_student();
            frm.Text = "Select Lab Fee";
            frm_select_student.instance.campus = tCampus.Text;
            frm_select_student.instance.yearLevel = tYearLevel.Text;
            frm.ShowDialog();
            if (labFeeCategory != null)
            {
                addLabFee();
            }
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            var frm = new frm_view_subjects();
            frm.Text = "View Subjects";
            frm_view_subjects.instance.id_number = tIdNumber.Text;
            frm.ShowDialog();
        }

        private void kryptonButton6_Click(object sender, EventArgs e)
        {
            int unit = 0;
            unit = Convert.ToInt32(dgv.CurrentRow.Cells["units"].Value);
            unit++;
            dgv.CurrentRow.Cells["units"].Value = unit;
            dgv.CurrentRow.Cells["computation"].Value = unit * Convert.ToDecimal(dgv.CurrentRow.Cells["amount"].Value);
        }

        private void kryptonButton5_Click(object sender, EventArgs e)
        {
            dgv.Rows.Remove(dgv.CurrentRow);

            computeAssessment();
        }

        private void saveAssessment()
        {

            // Save to Student Assessment
            saveStudentAssessment();

            // Saving Fee Summary
            saveFeeSummary();

            // Saving to Statements of Accounts
            saveStatementsOfAccounts();

            // Saving Fee Breakdown
            saveFeeBreakdown();

            // Saving Assessment Breakdown
            saveAssessmentBreakdown();


            MessageBox.Show("Assessment Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            printAssessment();

        }

        private void saveAssessmentBreakdown()
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                var parameter = new SaveAssessmentBreakdownParams
                {
                    id_number = tIdNumber.Text,
                    school_year = tSchoolYear.Text,
                    fee_type = row.Cells["fee_type"].Value.ToString(),
                    amount = Convert.ToDecimal(row.Cells["computation"].Value)
                };
                var assessmentBreakdown = new student_assessment();
                assessmentBreakdown.saveAssessmentBreakdown(
                    parameter.id_number,
                    parameter.school_year,
                    parameter.fee_type,
                    parameter.amount
                    );
            }
        }

        private void saveStudentAssessment()
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                var assessment = new student_assessment
                {
                    id_number = tIdNumber.Text,
                    school_year = tSchoolYear.Text,
                    fee_type = row.Cells["fee_type"].Value.ToString(),
                    amount = Convert.ToDecimal(row.Cells["amount"].Value),
                    units = Convert.ToInt32(row.Cells["units"].Value),
                    computation = Convert.ToDecimal(row.Cells["computation"].Value)
                };
                assessment.saveAssessment(tIdNumber.Text);
            }
        }

        private void saveFeeSummary()
        {
            //var data = new FeeSummary
            //{
            //    id_number = tIdNumber.Text
            //};
            //decimal previousBalance = data.loadPreviousBalance();
            //decimal currentAssessment = Convert.ToDecimal(tTotal.Text);
            //decimal discounts = Convert.ToDecimal(discountTotal.Text);

            //var add = new FeeSummary
            //{
            //    id_number = tIdNumber.Text,
            //    school_year = tSchoolYear.Text,
            //    current_assessment = currentAssessment,
            //    discounts = discounts,
            //    previous_balance = previousBalance,
            //    current_receivable = (currentAssessment + previousBalance) - discounts
            //};
            //add.saveFeeSummary();
        }

        private void saveFeeBreakdown()
        {
            //var add = new FeeBreakdown
            //{
            //    school_year = tSchoolYear.Text,
            //    prelim = Convert.ToDecimal(tPrelims.Text),
            //    downpayment = Convert.ToDecimal(tDownpayment.Text),
            //    midterms = Convert.ToDecimal(tMidterms.Text),
            //    semi_finals = Convert.ToDecimal(tSemiFinals.Text),
            //    finals = Convert.ToDecimal(tFinals.Text),
            //    total = Convert.ToDecimal(tDownpayment.Text) + Convert.ToDecimal(tPrelims.Text) + Convert.ToDecimal(tMidterms.Text) + Convert.ToDecimal(tSemiFinals.Text) + Convert.ToDecimal(tFinals.Text)
            //};
            //add.saveRecords(tIdNumber.Text);
        }

        private void FeeBreakDown()
        {

            decimal total = 0;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                total += (decimal)row.Cells["computation"].Value;
            }
            total -= totalDiscount;

            decimal downpayment = total * Convert.ToDecimal(0.20);
            decimal prelim = total * Convert.ToDecimal(0.20);
            decimal midterm = total * Convert.ToDecimal(0.20);
            decimal semiFinal = total * Convert.ToDecimal(0.20);
            decimal finals = total * Convert.ToDecimal(0.20);

            tDownpayment.Text = downpayment.ToString();
            tPrelims.Text = prelim.ToString();
            tMidterms.Text = midterm.ToString();
            tSemiFinals.Text = semiFinal.ToString();
            tFinals.Text = finals.ToString();
        }

        private void saveStatementsOfAccounts()
        {
            // Checking for Previous Assessment if there are negatives
            var dataBalance = new student_assessment();
            var balance = dataBalance.checkPreviousSoa(tIdNumber.Text);
            if (balance.Rows.Count > 0)
            {
                var previousBalance = Convert.ToDecimal(balance.Rows[0]["balance"]);
                var debitCurrent = Convert.ToDecimal(tTotal.Text);
                var data = new StatementsOfAccounts
                {
                    id_number = tIdNumber.Text,
                    school_year = schoolYear,
                    date = DateTime.Now.ToString("MM-dd-yyyy"),
                    course = tCourse.Text,
                    year_level = tYearLevel.Text,
                    semester = tSemester.Text,
                    particulars = "Total Assessment as of: " + tSchoolYear.Text,
                    debit = debitCurrent,
                    credit = previousBalance,
                    balance = debitCurrent + previousBalance,
                    cashier_in_charge = ""
                };
                data.saveStatementOfAccount(tIdNumber.Text, tSchoolYear.Text);

                var discounts = new student_assessment();
                var disc = discounts.loadDiscounts(tIdNumber.Text);

                // For the discount
                foreach (DataRow row in disc.Rows)
                {
                    var latest = new StatementsOfAccounts();
                    var soaLatest = latest.loadLatestSOA(tIdNumber.Text, tSchoolYear.Text);
                    decimal debit = Convert.ToDecimal(soaLatest.Rows[0]["balance"]);
                    if (row["discount_target"].ToString() == "Tuition Fee")
                    {
                        var computation = (Convert.ToDecimal(row["discount_percentage"]) / 100) * totalTuitionFee;
                        var soaDiscount = new StatementsOfAccounts
                        {
                            id_number = tIdNumber.Text,
                            course = tCourse.Text,
                            year_level = tYearLevel.Text,
                            semester = tSemester.Text,
                            school_year = schoolYear,
                            particulars = row["description"].ToString(),
                            debit = debit,
                            credit = computation,
                            balance = debit - computation,
                            cashier_in_charge = ""
                        };
                        soaDiscount.saveStatementOfAccount(tIdNumber.Text, tSchoolYear.Text);
                    }
                }
            }
            else if (balance.Rows.Count == 0)
            {
                var data = new StatementsOfAccounts
                {
                    id_number = tIdNumber.Text,
                    school_year = schoolYear,
                    date = DateTime.Now.ToString("MM-dd-yyyy"),
                    course = tCourse.Text,
                    year_level = tYearLevel.Text,
                    semester = tSemester.Text,
                    particulars = "Total Assessment as of: " + schoolYear,
                    debit = Convert.ToDecimal(tTotal.Text),
                    credit = 0,
                    balance = Convert.ToDecimal(tTotal.Text),
                    cashier_in_charge = "",
                };
                data.saveStatementOfAccount(tIdNumber.Text, tSchoolYear.Text);
                var discounts = new student_assessment();
                var disc = discounts.loadDiscounts(tIdNumber.Text);

                // For the discount
                foreach (DataRow row in disc.Rows)
                {
                    var latest = new StatementsOfAccounts();
                    var soaLatest = latest.loadLatestSOA(tIdNumber.Text, tSchoolYear.Text);
                    decimal debit = Convert.ToDecimal(soaLatest.Rows[0]["balance"]);
                    if (row["discount_target"].ToString() == "Tuition Fee")
                    {
                        var computation = (Convert.ToDecimal(row["discount_percentage"]) / 100) * totalTuitionFee;
                        var soaDiscount = new StatementsOfAccounts
                        {
                            id_number = tIdNumber.Text,
                            course = tCourse.Text,
                            year_level = tYearLevel.Text,
                            semester = tSemester.Text,
                            particulars = row["description"].ToString(),
                            debit = debit,
                            credit = computation,
                            balance = debit - computation,
                            cashier_in_charge = ""
                        };
                        soaDiscount.saveStatementOfAccount(tIdNumber.Text, tSchoolYear.Text);
                    }
                }
            }
        }

        private void loadDiscounts()
        {
            // Loading the discount of the student
            var data = new student_assessment();
            var studentDiscounts = data.loadDiscounts(tIdNumber.Text);
            decimal initialBreakdown = 0;
            foreach (DataRow row in studentDiscounts.Rows)
            {
                if (row["discount_target"].ToString() == "Tuition Fee")
                {
                    initialBreakdown = totalTuitionFee;

                    decimal amount = (Convert.ToDecimal(row["discount_percentage"]) / 100) * initialBreakdown;
                    decimal computation = (Convert.ToDecimal(row["discount_percentage"]) / 100) * initialBreakdown;
                    totalDiscount += computation;
                }
                else if (row["discount_target"].ToString() == "Miscellaneous Fee")
                {
                    initialBreakdown = totalTuitionFee;
                    decimal amount = (Convert.ToDecimal(row["discount_percentage"]) / 100) * initialBreakdown;
                    decimal computation = (Convert.ToDecimal(row["discount_percentage"]) / 100) * initialBreakdown;
                    totalDiscount += computation;
                }
                else if (row["discount_target"].ToString() == "Laboratory Fee")
                {
                    initialBreakdown = totalTuitionFee;
                    decimal amount = (Convert.ToDecimal(row["discount_percentage"]) / 100) * initialBreakdown;
                    decimal computation = (Convert.ToDecimal(row["discount_percentage"]) / 100) * initialBreakdown;
                    totalDiscount += computation;
                }
                else if (row["discount_target"].ToString() == "Other Fee")
                {
                    initialBreakdown = totalTuitionFee;
                    decimal amount = (Convert.ToDecimal(row["discount_percentage"]) / 100) * initialBreakdown;
                    decimal computation = (Convert.ToDecimal(row["discount_percentage"]) / 100) * initialBreakdown;
                    totalDiscount += computation;
                }
            }
        }
        private void computeAssessment()
        {
            //totalTuitionFee = 0;
            //totalMiscFee = 0;
            //totalLabFee = 0;
            //totalOtherFee = 0;
            //totalFee = 0;
            //foreach (DataGridViewRow row in dgv.Rows)
            //{
            //    if (row.Cells["category"].Value.ToString() == "Tuition Fee")
            //    {
            //        totalTuitionFee += Convert.ToDecimal(row.Cells["computation"].Value);
            //    }
            //    else if (row.Cells["category"].Value.ToString() == "Miscellaneous Fee")
            //    {
            //        totalMiscFee += Convert.ToDecimal(row.Cells["computation"].Value);
            //    }
            //    else if (row.Cells["category"].Value.ToString() == "Laboratory Fee")
            //    {
            //        totalLabFee += Convert.ToDecimal(row.Cells["computation"].Value);
            //    }
            //    else if (row.Cells["category"].Value.ToString() == "Other Fees")
            //    {
            //        totalOtherFee += Convert.ToDecimal(row.Cells["computation"].Value);
            //    }
            //}
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (tIdNumber.Text == "")
            {
                MessageBox.Show("Please select Student and school year", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to save this assessment?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    saveAssessment();
                }
            }
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            computeAssessment();
        }

        private void kryptonButton3_Click_1(object sender, EventArgs e)
        {
            var frm = new frm_view_discount
            {
                id_number = tIdNumber.Text
            };
            frm.ShowDialog();
        }

        private void kryptonButton6_Click_1(object sender, EventArgs e)
        {
            printAssessment();
        }

        private void printAssessment()
        {
            var frm = new frm_isap_assessment
            {
                id_number = tIdNumber.Text,
                school_year = tSchoolYear.Text,
                campus = tCampus.Text,
            };
            frm.ShowDialog();
        }

        private void tSemester_TextChanged(object sender, EventArgs e)
        {

        }
    }
}