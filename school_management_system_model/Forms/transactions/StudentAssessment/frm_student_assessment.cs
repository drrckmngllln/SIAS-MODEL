using school_management_system_model.Core.Entities.Settings;
using school_management_system_model.Core.Entities.Transaction;
using school_management_system_model.Data.Repositories.Setings;
using school_management_system_model.Data.Repositories.Transaction;
using school_management_system_model.Data.Repositories.Transaction.StudentAccounts;
using school_management_system_model.Data.Repositories.Transaction.StudentAssessment;
using school_management_system_model.Forms.transactions.StudentAssessment;
using school_management_system_model.Infrastructure.Data.Repositories;
using school_management_system_model.Infrastructure.Data.Repositories.Transaction;
using school_management_system_model.Reports.Accounting;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace school_management_system_model.Forms.transactions
{
    public partial class frm_student_assessment : Form
    {
        StudentAccountRepository _studentAccountRepo = new StudentAccountRepository();
        StudentSubjectRepository _studentSubjectRepo = new StudentSubjectRepository();
        StudentCourseRepository _studentCourseRepo = new StudentCourseRepository();
        CourseRepository _courseRepo = new CourseRepository();
        CampusRepository _campusRepo = new CampusRepository();
        SchoolYearRepository _schoolYearRepo = new SchoolYearRepository();
        MiscFeeRepository _miscFeeRepo = new MiscFeeRepository();
        TuitionFeeRepository _tuitionFeeRepo = new TuitionFeeRepository();
        LabFeeSubjectRepository _labFeeSubjectRepo = new LabFeeSubjectRepository();
        LabFeeRepository _labFeeRepo = new LabFeeRepository();
        OtherFeeRepository _otherFeeRepo = new OtherFeeRepository();
        FeeBreakdownRepository _feeBreakdownRepo = new FeeBreakdownRepository();
        FeeSummaryRepository _feeSummaryRepo = new FeeSummaryRepository();
        StatementOfAccountsRepository _statementOfAccountsRepo = new StatementOfAccountsRepository();
        StudentDiscountRepository _studentDiscountRepo = new StudentDiscountRepository();
        AssessmentBreakdownRepository _assessmentBreakdownRepo = new AssessmentBreakdownRepository();



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

        private async void button1_Click(object sender, EventArgs e)
        {
            var frm = new frm_select_student();
            frm.Text = "Select Student";
            frm.ShowDialog();
            if (studentID != null)
            {
                // Getting Student Name

                var a = await _studentAccountRepo.GetAllAsync();
                var studentName = a.FirstOrDefault(x => x.id_number == studentID);
                tStudentName.Text = studentName.fullname;

                // Getting Student Course

                var studentCourses = await _studentCourseRepo.GetAllAsync();
                var studentCourse = studentCourses.FirstOrDefault(x => x.id_number == studentID);

                tIdNumber.Text = studentID.ToString();
                tCourse.Text = studentCourse.course.ToString();
                tYearLevel.Text = studentCourse.year_level;
                tSemester.Text = studentCourse.semester;
                tCampus.Text = studentCourse.campus;
            }
        }

        private async Task loadTuitionFeePerUnit()
        {
            var a = await _studentSubjectRepo.GetAllAsync();
            var getStudentTuitionFee = a
                .Where(x => x.id_number_id == tIdNumber.Text && x.school_year_id == tSchoolYear.Text)
                .ToList();
            decimal tuitionFee = 0;
            foreach (var item in getStudentTuitionFee)
            {
                tuitionFee += Convert.ToDecimal(item.lecture_units);
            }

            int yearLevel = Convert.ToInt32(tYearLevel.Text);

            var tuitionFeeSetup = await _tuitionFeeRepo.GetAllAsync();
            var b = tuitionFeeSetup
                .FirstOrDefault(x => x.campus == tCampus.Text && x.year_level == tYearLevel.Text);

            if (b == null)
            {
                new Classes.Toastr("Warning", "No Tuition Fee Set");
            }
            else
            {
                dgv.Rows.Add(b.category, b.description, b.amount, tuitionFee, tuitionFee * b.amount);
            }
        }

        private async Task loadMiscFeePerUnit()
        {
            var getMiscFeeSetup = await _miscFeeRepo.GetAllAsync();
            var a = getMiscFeeSetup
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
        }

        private async Task addAssessmentRecords()
        {
            // Loading of Tuition Fee/Unit
            await loadTuitionFeePerUnit();
            // Loading of Miscellaneous Fee
            await loadMiscFeePerUnit();
            // Loading of Lab Fee
            await loadLabFee();
            // Loading of Other Fee
            await loadOtherFees();
            // Loading of Fee Breakdown
            await FeeBreakDown();
        }

        private async Task loadOtherFees()
        {
            var otherFees = await _otherFeeRepo.GetAllAsync();
            var a = otherFees
                .Where(x => x.campus == tCampus.Text && x.year_level == tYearLevel.Text).ToList();

            foreach (var item in a)
            {
                dgv.Rows.Add(item.category, item.description, item.amount, 1, item.amount * 1);
            }
        }

        private async Task loadLabFee()
        {
            var a = await _studentSubjectRepo.GetAllAsync();
            var studentSubjects = a
                .Where(x => x.id_number_id == tIdNumber.Text && x.school_year_id == tSchoolYear.Text).ToList();

            var labFeeSubjects = await _labFeeSubjectRepo.GetAllAsync();
            if (labFeeSubjects != null)
            {
                foreach (var studentSubjectItem in studentSubjects)
                {
                    foreach (var labFeeSubjectItems in labFeeSubjects)
                    {
                        var labFee = await _labFeeRepo.GetAllAsync();
                        var b = labFee
                            .FirstOrDefault(x => x.description == labFeeSubjectItems.lab_fee);

                        if (b != null)
                        {
                            if (studentSubjectItem.subject_code == labFeeSubjectItems.subject_code)
                            {
                                decimal unitsComputation = Convert.ToDecimal(studentSubjectItem.lab_units) * Convert.ToDecimal(b.amount);
                                unitsComputation = Math.Round(unitsComputation, 2);
                                if (unitsComputation != 0)
                                {
                                    dgv.Rows.Add(b.category, b.description, b.amount, studentSubjectItem.lab_units, unitsComputation);
                                }
                            }
                        }
                    }
                }
            }
        }

        private async Task loadAssessment()
        {
            await addAssessmentRecords();
        }

        private void addLabFee()
        {
            dgv.Rows.Add(labFeeCategory, labFee, 1, 1 * labFee);
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            var frm = new frm_select_student();
            frm.Text = "Select School Year";
            frm.ShowDialog();
            if (schoolYear != null)
            {
                dgv.Rows.Clear();
                // Loading the assessment
                tSchoolYear.Text = schoolYear.ToString();
                await loadAssessment();

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
                    else if (row.Cells["category"].Value.ToString() == "Other Fee")
                    {
                        totalOtherFee += Convert.ToDecimal(row.Cells["computation"].Value);
                    }
                }
                await loadDiscounts();


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

        private async Task saveAssessment()
        {

            // Save to Student Assessment
            await saveStudentAssessment();

            // Saving Fee Summary
            await saveFeeSummary();

            // Saving to Statements of Accounts
            await saveStatementsOfAccounts();

            // Saving Fee Breakdown
            await saveFeeBreakdown();

            // Saving Assessment Breakdown
            await saveAssessmentBreakdown();

            new Classes.Toastr("Success", "Assessment Saved");

            printAssessment();

        }

        private async Task saveAssessmentBreakdown()
        {
            var a = await _studentAccountRepo.GetAllAsync();
            var id_number_id = a
                .FirstOrDefault(x => x.id_number == tIdNumber.Text);

            var b = await _schoolYearRepo.GetAllAsync();
            var school_year_id = b
                .FirstOrDefault(x => x.code == tSchoolYear.Text);

            foreach (DataGridViewRow row in dgv.Rows)
            {
                var assessmentBreakdown = new AssessmentBreakdown
                {
                    id_number = id_number_id.id.ToString(),
                    school_year = school_year_id.id.ToString(),
                    fee_type = row.Cells["fee_type"].Value.ToString(),
                    amount = Convert.ToDecimal(row.Cells["computation"].Value)
                };
                await _assessmentBreakdownRepo.AddRecords(assessmentBreakdown);
            }
        }

        private async Task saveStudentAssessment()
        {
            var a = await _studentAccountRepo.GetAllAsync();
            var id_number_id = a.FirstOrDefault(x => x.id_number == tIdNumber.Text);

            var b = await _schoolYearRepo.GetAllAsync();
            var school_year_id = b.FirstOrDefault(x => x.code == tSchoolYear.Text);
            if (id_number_id != null && school_year_id != null)
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {

                    var savingStudentAssessment = new StudentAssessments
                    {
                        id_number = id_number_id.id.ToString(),
                        school_year = school_year_id.id.ToString(),
                        fee_type = row.Cells["fee_type"].Value.ToString(),
                        units = Convert.ToDecimal(row.Cells["units"].Value),
                        computation = Convert.ToDecimal(row.Cells["computation"].Value)
                    };
                    savingStudentAssessment.SaveStudentAssessment();
                }
            }

        }

        private async Task saveFeeSummary()
        {
            var statementsOfAccounts = await _statementOfAccountsRepo.GetAllAsync();
            var soa = statementsOfAccounts
                .Where(x => x.id_number == tIdNumber.Text)
                .OrderByDescending(x => x.id)
                .ToList();

            var dt = soa.ToDataTable();

            if (dt.Rows.Count != 0)
            {
                decimal previousBalance = Convert.ToDecimal(dt.Rows[0]["balance"]);
                var studentAccounts = await _studentAccountRepo.GetAllAsync();
                var id_number_id = studentAccounts.FirstOrDefault(x => x.id_number == tIdNumber.Text).id;

                var schoolYears = await _schoolYearRepo.GetAllAsync();
                var school_year_id = schoolYears.FirstOrDefault(x => x.code == tSchoolYear.Text).id;

                var saveFeeSummary = new FeeSummary
                {
                    id_number = id_number_id.ToString(),
                    school_year = school_year_id.ToString(),
                    current_assessment = Convert.ToDecimal(tTotal.Text),
                    discounts = Convert.ToDecimal(totalDiscount),
                    previous_balance = previousBalance,
                    current_receivable = Convert.ToDecimal(tTotal.Text) + previousBalance
                };
                await _feeSummaryRepo.AddRecords(saveFeeSummary);
            }
            else
            {
                var studentAccounts = await _studentAccountRepo.GetAllAsync();
                var id_number_id = studentAccounts.FirstOrDefault(x => x.id_number == tIdNumber.Text).id;

                var schoolYears = await _schoolYearRepo.GetAllAsync();
                var school_year_id = schoolYears.FirstOrDefault(x => x.code == tSchoolYear.Text).id;

                var saveFeeSummary = new FeeSummary
                {
                    id_number = id_number_id.ToString(),
                    school_year = school_year_id.ToString(),
                    current_assessment = Convert.ToDecimal(tTotal.Text),
                    discounts = Convert.ToDecimal(totalDiscount),
                    previous_balance = 0,
                    current_receivable = Convert.ToDecimal(tTotal.Text)
                };
                await _feeSummaryRepo.AddRecords(saveFeeSummary);
            }
        }

        private async Task saveFeeBreakdown()
        {
            var a = await _studentAccountRepo.GetAllAsync();
            var id_number = a.FirstOrDefault(x => x.id_number == tIdNumber.Text);

            var b = await _schoolYearRepo.GetAllAsync();
            var school_year = b.FirstOrDefault(x => x.code == tSchoolYear.Text);
            var add = new FeeBreakdown
            {
                id_number = id_number.id.ToString(),
                school_year = school_year.id.ToString(),
                prelim = Convert.ToDecimal(tPrelims.Text),
                downpayment = Convert.ToDecimal(tDownpayment.Text),
                midterm = Convert.ToDecimal(tMidterms.Text),
                semi_finals = Convert.ToDecimal(tSemiFinals.Text),
                finals = Convert.ToDecimal(tFinals.Text),
                total = Convert.ToDecimal(tDownpayment.Text) + Convert.ToDecimal(tPrelims.Text) + Convert.ToDecimal(tMidterms.Text) + Convert.ToDecimal(tSemiFinals.Text) + Convert.ToDecimal(tFinals.Text)
            };
            await _feeBreakdownRepo.AddRecords(add);
        }

        private async Task FeeBreakDown()
        {
            decimal total = 0;

            await Task.Run(() =>
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    total += (decimal)row.Cells["computation"].Value;
                }
                total -= totalDiscount;


            });
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

        private async Task saveStatementsOfAccounts()
        {
            var dataBalance = await _statementOfAccountsRepo.GetAllAsync();
            var b = dataBalance
                .Where(x => x.school_year == tSchoolYear.Text && x.id_number == tIdNumber.Text)
                .OrderByDescending(x => x.id)
                .ToList();

            var a = await _studentAccountRepo.GetAllAsync();
            var id_number_id = a
                .FirstOrDefault(x => x.id_number == tIdNumber.Text);

            var c = await _courseRepo.GetAllAsync();
            var course_id = c
                .FirstOrDefault(x => x.code == tCourse.Text);

            var d = await _schoolYearRepo.GetAllAsync();
            var school_year_id = d
                .FirstOrDefault(x => x.code == tSchoolYear.Text);

            if (dataBalance == null)
            {
                var soa = await _statementOfAccountsRepo.GetAllAsync();
                var e = soa
                    .OrderByDescending(x => x.id)
                    .FirstOrDefault(x => x.school_year == tSchoolYear.Text && x.id_number == tIdNumber.Text);
                var previousBalance = Convert.ToDecimal(e.balance);
                var currentDebit = Convert.ToDecimal(tTotal.Text);

                var SaveSOA = new StatementOfAccount
                {
                    id_number = id_number_id.id.ToString(),
                    school_year = school_year_id.id.ToString(),
                    date = DateTime.Now.ToString("MM-dd-yyyy"),
                    course = course_id.id.ToString(),
                    year_level = tYearLevel.Text,
                    semester = tSemester.Text,
                    particulars = "Total Assessment as of:" + tSchoolYear.Text,
                    debit = currentDebit,
                    credit = previousBalance,
                    balance = currentDebit + previousBalance,
                    // Name of Cashier
                    cashier_in_charge = ""
                };
                await _statementOfAccountsRepo.AddRecords(SaveSOA);

                // For the discounts if any
                var discounts = await _studentDiscountRepo.GetAllAsync();
                var f = discounts
                    .Where(x => x.id_number == tIdNumber.Text)
                    .ToList();
                if (discounts != null)
                {
                    foreach (var discount in f)
                    {
                        if (discount.discount_target == "Tuition Fee")
                        {
                            var discountPercentage = Convert.ToDecimal(discount.discount_percentage);
                            var computation = (discountPercentage / 100) * totalTuitionFee;

                            var debit = await _statementOfAccountsRepo.GetAllAsync();
                            decimal g = debit
                                .FirstOrDefault(x => x.id_number == tIdNumber.Text && x.school_year == tSchoolYear.Text).balance;

                            var saveSoaDiscount = new StatementOfAccount
                            {
                                id_number = id_number_id.id.ToString(),
                                course = course_id.id.ToString(),
                                year_level = tYearLevel.Text,
                                semester = tSemester.Text,
                                school_year = school_year_id.id.ToString(),
                                particulars = discount.description,
                                debit = currentDebit,
                                credit = computation,
                                balance = g - computation,
                                // Cashier in charge assignment
                                cashier_in_charge = ""
                            };
                            await _statementOfAccountsRepo.AddRecords(saveSoaDiscount);
                        }
                    }
                }
            }
            else
            {
                var currentDebit = Convert.ToDecimal(tTotal.Text);

                var data = new StatementOfAccount
                {
                    id_number = id_number_id.id.ToString(),
                    school_year = school_year_id.id.ToString(),
                    date = DateTime.Now.ToString("MM-dd-yyyy"),
                    course = course_id.id.ToString(),
                    year_level = tYearLevel.Text,
                    semester = tSemester.Text,
                    particulars = "Total Assessment as of: " + tSchoolYear.Text,
                    debit = Convert.ToDecimal(tTotal.Text),
                    credit = 0,
                    balance = Convert.ToDecimal(tTotal.Text),
                    // Cashier in charge
                    cashier_in_charge = ""
                };
                await _statementOfAccountsRepo.AddRecords(data);

                var discounts = await _studentDiscountRepo.GetAllAsync();
                var g = discounts
                    .Where(x => x.id_number == tIdNumber.Text)
                    .ToList();
                if (c != null)
                {
                    foreach (var discount in g)
                    {
                        if (discount.discount_target == "Tuition Fee")
                        {
                            var discountPercentage = Convert.ToDecimal(discount.discount_percentage);
                            var computation = (discountPercentage / 100) * totalTuitionFee;

                            var e = await _statementOfAccountsRepo.GetAllAsync();
                            decimal debit = e
                                .FirstOrDefault(x => x.id_number == tIdNumber.Text && x.school_year == tSchoolYear.Text).balance;

                            var saveSoaDiscount = new StatementOfAccount
                            {
                                id_number = id_number_id.id.ToString(),
                                course = course_id.id.ToString(),
                                year_level = tYearLevel.Text,
                                semester = tSemester.Text,
                                school_year = school_year_id.id.ToString(),
                                particulars = discount.description,
                                debit = currentDebit,
                                credit = computation,
                                balance = debit - computation,
                                // Cashier in charge assignment
                                cashier_in_charge = ""
                            };
                            await _statementOfAccountsRepo.AddRecords(saveSoaDiscount);
                        }
                    }
                }

            }
        }

        private async Task loadDiscounts()
        {
            // Loading the discount of the student
            var a = await _studentDiscountRepo.GetAllAsync();
            var getStudentDiscount = a
                .Where(x => x.id_number == tIdNumber.Text);

            if (getStudentDiscount != null)
            {
                decimal initialBreakdown = 0;

                foreach (var item in getStudentDiscount)
                {
                    if (item.discount_target == "Tuition Fee")
                    {
                        initialBreakdown = totalTuitionFee + totalLabFee;
                        decimal computation = (Convert.ToDecimal(item.discount_percentage) / 100) * initialBreakdown;
                        totalDiscount += computation;
                    }
                    else if (item.discount_target == "Miscellaneous Fee")
                    {
                        initialBreakdown = totalMiscFee;
                        decimal computation = (Convert.ToDecimal(item.discount_percentage) / 100) * initialBreakdown;
                        totalDiscount += computation;
                    }
                    else if (item.discount_target == "Other Fee")
                    {
                        initialBreakdown = totalOtherFee;
                        decimal computation = (Convert.ToDecimal(item.discount_percentage) / 100) * initialBreakdown;
                        totalDiscount += computation;
                    }
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
                else if (row.Cells["category"].Value.ToString() == "Other Fee")
                {
                    totalOtherFee += Convert.ToDecimal(row.Cells["computation"].Value);
                }
            }
        }

        private async void btn_save_Click(object sender, EventArgs e)
        {
            if (tIdNumber.Text == "")
            {
                MessageBox.Show("Please select Student and school year", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to save this assessment?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    await saveAssessment();
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
            //var a = await _studentAccountRepo.GetAllAsync();
            //var id_number_id = a
            //    .FirstOrDefault(x => x.id_number == tIdNumber.Text);

            //var b = await _schoolYearRepo.GetAllAsync();
            //var school_year_id = b
            //    .FirstOrDefault(x => x.code == tSchoolYear.Text);

            //var c = await _campusRepo.GetAllAsync();
            //var campus_id = c
            //    .FirstOrDefault(x => x.code == tCampus.Text);

            var frm = new frm_isap_assessment
            {
                id_number = tIdNumber.Text,
                school_year = tSchoolYear.Text,
                campus = tCampus.Text,
            };
            frm.ShowDialog();
            //if (id_number_id != null && school_year_id != null && campus_id != null)
            //{
            //}
        }
    }
}