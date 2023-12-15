using Krypton.Toolkit;
using school_management_system_model.Classes;
using school_management_system_model.Forms.transactions.StudentAssessment;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        public decimal totalTuitionFee{ get; set; }
        public decimal totalMiscFee{ get; set; }
        public decimal totalLabFee { get; set; }
        public decimal totalOtherFee{ get; set; }
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
                var name = new student_assessment
                {
                    id_number = studentID
                };
                tStudentName.Text = name.getStudentName();

                // Getting Student Course
                tIdNumber.Text = studentID.ToString();
                var studentDetails = new student_assessment
                {
                    id_number = tIdNumber.Text
                };
                var data = studentDetails.getStudentDetails();
                tCourse.Text = data.Rows[0]["course"].ToString();
                tYearLevel.Text = data.Rows[0]["year_level"].ToString();
                tSemester.Text = data.Rows[0]["semester"].ToString();
                tCampus.Text = data.Rows[0]["campus"].ToString();
                
            }
        }

        private void addAssessmentRecords()
        {
            // Loading of Tuition Fee/Unit
            
            var lectureFee = new student_assessment();
            decimal tuitionUnit = 0;
            tuitionUnit = lectureFee.getTuitionFeeUnits(tIdNumber.Text);

            var tuition = new student_assessment();
            var data = tuition.getTuitionFee(tCampus.Text);
            if (tYearLevel.Text == "1")
            {
                dgv.Rows.Add(
                    data.Rows[0]["category"],
                    data.Rows[0]["description"],
                    data.Rows[0]["first_year"],
                    tuitionUnit,
                    tuitionUnit * Convert.ToDecimal(data.Rows[0]["first_year"])
                    );
            }
            else if (tYearLevel.Text == "2")
            {
                dgv.Rows.Add(
                    data.Rows[0]["category"],
                   data.Rows[0]["description"],
                   data.Rows[0]["second_year"],
                   tuitionUnit,
                    tuitionUnit * Convert.ToDecimal(data.Rows[0]["second_year"])
                   );
            }
            else if (tYearLevel.Text == "3")
            {
                dgv.Rows.Add(
                    data.Rows[0]["category"],
                   data.Rows[0]["description"],
                   data.Rows[0]["third_year"],
                   tuitionUnit,
                   tuitionUnit * Convert.ToDecimal(data.Rows[0]["third_year"])
                   );
            }
            else if (tYearLevel.Text == "4")
            {
                dgv.Rows.Add(
                    data.Rows[0]["category"],
                   data.Rows[0]["description"],
                   data.Rows[0]["fourth_year"],
                   tuitionUnit,
                   tuitionUnit * Convert.ToDecimal(data.Rows[0]["fourth_year"])
                   );
            }
            
            
            // Loading of Miscellaneous Fee
            
            var misc = new student_assessment();
            var miscData = misc.getMiscellaneousFee(tCampus.Text);
            foreach(DataRow row in miscData.Rows)
            {
                if (tYearLevel.Text == "1")
                {
                    dgv.Rows.Add(
                        row["category"],
                        row["description"],
                        row["first_year"],
                        1,
                        1 * Convert.ToDecimal(row["first_year"])
                        );
                }
                else if (tYearLevel.Text == "2")
                {
                    dgv.Rows.Add(
                       row["category"],
                       row["description"],
                       row["second_year"],
                       1,
                       1 * Convert.ToDecimal(row["second_year"])
                       );
                }
                else if (tYearLevel.Text == "3")
                {
                    dgv.Rows.Add(
                        row["category"],
                       row["description"],
                       row["third_year"],
                       1,
                       1 * Convert.ToDecimal(row["third_year"])
                       );
                }
                else if (tYearLevel.Text == "4")
                {
                    dgv.Rows.Add(
                        row["category"],
                       row["description"],
                       row["fourth_year"],
                       1,
                       1 * Convert.ToDecimal(row["fourth_year"])
                       );
                }
            }

            // Loading of Lab Fee
            loadLabFee();

            // Loading of Other Fee
            loadOtherFees();
        }

        private void loadOtherFees()
        {
            var other = new student_assessment();
            var otherFee = other.getOtherFee(tCampus.Text);
            foreach (DataRow row in otherFee.Rows)
            {
                if (tYearLevel.Text == "1")
                {
                    dgv.Rows.Add(
                        row["category"],
                        row["description"],
                        row["first_year"],
                        1,
                        1 * Convert.ToDecimal(row["first_year"])
                        );
                }
                else if (tYearLevel.Text == "2")
                {
                    dgv.Rows.Add(
                       row["category"],
                       row["description"],
                       row["second_year"],
                       1,
                       1 * Convert.ToDecimal(row["second_year"])
                       );
                }
                else if (tYearLevel.Text == "3")
                {
                    dgv.Rows.Add(
                        row["category"],
                       row["description"],
                       row["third_year"],
                       1,
                       1 * Convert.ToDecimal(row["third_year"])
                       );
                }
                else if (tYearLevel.Text == "4")
                {
                    dgv.Rows.Add(
                        row["category"],
                       row["description"],
                       row["fourth_year"],
                       1,
                       1 * Convert.ToDecimal(row["fourth_year"])
                       );
                }
            }
        }

        private void loadLabFee()
        {
            var data = new student_assessment();
            var schoolYear = data.getStudentSchoolYear(tIdNumber.Text);
            var enrolledSubjects = data.loadEnrolledSubjects(tIdNumber.Text, schoolYear);
            var labFeeSubjects = data.loadLabFeeSubjects();
            

            foreach(DataRow row in enrolledSubjects.Rows)
            {
                foreach(DataRow rows in labFeeSubjects.Rows)
                {
                    if (rows["subject_code"].ToString() == row["subject_code"].ToString())
                    {
                        var labFee = data.loadLabFee(Convert.ToInt32(rows["lab_fee_id"]));
                        if (tYearLevel.Text == "1")
                        {
                            decimal computation= 1 * Convert.ToDecimal(labFee.Rows[0]["first_year"]);
                            totalLabFee = 0;
                            dgv.Rows.Add(
                                labFee.Rows[0]["category"],
                                labFee.Rows[0]["description"],
                                labFee.Rows[0]["first_year"],
                                1,
                                computation
                                );
                            totalLabFee = computation;
                        }
                        else if (tYearLevel.Text == "2")
                        {
                            decimal computation = 1 * Convert.ToDecimal(labFee.Rows[0]["second_year"]);
                            dgv.Rows.Add(
                                labFee.Rows[0]["category"],
                                labFee.Rows[0]["description"],
                                labFee.Rows[0]["second_year"],
                                1,
                                1 * Convert.ToDecimal(labFee.Rows[0]["second_year"])
                                );
                            totalLabFee = computation;
                        }
                        else if(tYearLevel.Text == "3")
                        {
                            decimal computation = 1 * Convert.ToDecimal(labFee.Rows[0]["third_year"]);
                            dgv.Rows.Add(
                                labFee.Rows[0]["category"],
                                labFee.Rows[0]["description"],
                                labFee.Rows[0]["third_year"],
                                1,
                                1 * Convert.ToDecimal(labFee.Rows[0]["third_year"])
                                );
                            totalLabFee = computation;
                        }
                        else if(tYearLevel.Text == "4")
                        {
                            decimal computation = 1 * Convert.ToDecimal(labFee.Rows[0]["fourth_year"]);
                            dgv.Rows.Add(
                                labFee.Rows[0]["category"],
                                labFee.Rows[0]["description"],
                                labFee.Rows[0]["fourth_year"],
                                1,
                                1 * Convert.ToDecimal(labFee.Rows[0]["fourth_year"])
                                );
                            totalLabFee = computation;
                        }
                    }
                }
            }
        }

        private void loadAssessment()
        {

            var assessment = new student_assessment();
            var data = assessment.loadRecords(schoolYear, tIdNumber.Text);
            if (data.Rows.Count > 0)
            {
                dgv.Columns.Clear();

                dgv.DataSource = data;
                dgv.Columns["id"].Visible = false;
                dgv.Columns["id_number"].Visible = false;
                dgv.Columns["school_year"].Visible = false;
                dgv.Columns["fee_type"].HeaderText = "Fee Type";
                dgv.Columns["amount"].HeaderText = "Amount";
                dgv.Columns["units"].HeaderText = "Units";
                dgv.Columns["computation"].HeaderText = "Computation";
            }
            else
            {
                dgv.Columns.Clear();
                dgv.Columns.Add("category", "Category");
                //dgv.Columns["category"].Visible = false;
                dgv.Columns.Add("fee_type", "Fee Type");
                dgv.Columns.Add("amount", "Amount");
                dgv.Columns.Add("units", "Units");
                dgv.Columns.Add("computation", "Computation");
                addAssessmentRecords();
            }
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

                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.Cells["category"].Value.ToString() == "Tuition Fee")
                    {
                        totalTuitionFee += Convert.ToDecimal(row.Cells["computation"].Value);
                    }
                    else if (row.Cells["category"].Value.ToString() == "Miscellaneous Fee")
                    {
                        totalMiscFee += Convert.ToDecimal(row.Cells["computation"].Value);
                    }
                    else if (row.Cells["category"].Value.ToString() == "Laboratory Fee")
                    {
                        totalLabFee += Convert.ToDecimal(row.Cells["computation"].Value);
                    }
                    else if (row.Cells["category"].Value.ToString() == "Other Fees")
                    {
                        totalOtherFee += Convert.ToDecimal(row.Cells["computation"].Value);
                    }
                }
                loadDiscounts();

                FeeBreakDown();
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
            foreach(DataGridViewRow row in dgv.Rows)
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

            // Saving to Statements of Accounts
            saveStatementsOfAccounts();

            // Saving Fee Breakdown
            saveFeeBreakdown();

            MessageBox.Show("Assessment Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void saveFeeBreakdown()
        {
            var add = new FeeBreakdown
            {
                school_year = tSchoolYear.Text,
                prelim = Convert.ToDecimal(tPrelims.Text),
                downpayment = Convert.ToDecimal(tDownpayment.Text),
                midterms = Convert.ToDecimal(tMidterms.Text),
                semi_finals = Convert.ToDecimal(tSemiFinals.Text),
                finals = Convert.ToDecimal(tFinals.Text),
                total = Convert.ToDecimal(tDownpayment.Text) + Convert.ToDecimal(tPrelims.Text) + Convert.ToDecimal(tMidterms.Text) + Convert.ToDecimal(tSemiFinals.Text) + Convert.ToDecimal(tFinals.Text)
            };
            add.saveRecords(tIdNumber.Text);
        }

        private void FeeBreakDown()
        {
            
            decimal total = 0;
            foreach(DataGridViewRow row in dgv.Rows)
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
            var data = new StatementsOfAccounts
            {
                id_number = tIdNumber.Text,
                school_year = tSchoolYear.Text,
                date = DateTime.Now.ToString("MM-dd-yyyy"),
                course = tCourse.Text,
                year_level = tYearLevel.Text,
                semester = tSemester.Text,
                particulars = "Total Assessment as of: " + tSchoolYear.Text,
                debit = Convert.ToDecimal(tTotal.Text),
                credit = 0,
                balance = Convert.ToDecimal(tTotal.Text),
                cashier_in_charge = "",
            };
            data.saveStatementOfAccount(tIdNumber.Text);
            var discounts = new student_assessment();
            var disc = discounts.loadDiscounts(tIdNumber.Text);
            
            // For the discount
            foreach (DataRow row in disc.Rows)
            {
                var latest = new StatementsOfAccounts();
                var soaLatest = latest.loadLatestSOA(tIdNumber.Text);
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
                    soaDiscount.saveStatementOfAccount(tIdNumber.Text);
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
            totalTuitionFee = 0;
            totalMiscFee = 0;
            totalLabFee = 0;
            totalOtherFee = 0;
            totalFee = 0;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells["category"].Value.ToString() == "Tuition Fee")
                {
                    totalTuitionFee += Convert.ToDecimal(row.Cells["computation"].Value);
                }
                else if (row.Cells["category"].Value.ToString() == "Miscellaneous Fee")
                {
                    totalMiscFee += Convert.ToDecimal(row.Cells["computation"].Value);
                }
                else if (row.Cells["category"].Value.ToString() == "Laboratory Fee")
                {
                    totalLabFee += Convert.ToDecimal(row.Cells["computation"].Value);
                }
                else if (row.Cells["category"].Value.ToString() == "Other Fees")
                {
                    totalOtherFee += Convert.ToDecimal(row.Cells["computation"].Value);
                }
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save this assessment?","Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                saveAssessment();
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
    }
}