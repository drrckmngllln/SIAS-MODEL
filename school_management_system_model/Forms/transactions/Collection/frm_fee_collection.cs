using school_management_system_model.Core.Entities.Settings;
using school_management_system_model.Core.Entities.Transaction;
using school_management_system_model.Core.Helpers;
using school_management_system_model.Data.Repositories.Setings;
using school_management_system_model.Data.Repositories.Transaction;
using school_management_system_model.Data.Repositories.Transaction.StudentAccounts;
using school_management_system_model.Infrastructure.Data.Repositories;
using school_management_system_model.Infrastructure.Data.Repositories.Transaction;
using school_management_system_model.Reports;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace school_management_system_model.Forms.transactions.Collection
{
    public partial class frm_fee_collection : Form
    {
        StudentAccountRepository _studentAccountRepo = new StudentAccountRepository();
        SchoolYearRepository _schoolYearRepo = new SchoolYearRepository();
        StudentCourseRepository _studentCourseRepo = new StudentCourseRepository();
        StatementOfAccountsRepository _statementOfAccountsRepo = new StatementOfAccountsRepository();
        FeeBreakdownRepository _feeBreakdownRepo = new FeeBreakdownRepository();
        AssessmentBreakdownRepository _assessmentBreakdownRepo = new AssessmentBreakdownRepository();
        CourseRepository _courseRepo = new CourseRepository();
        private readonly UserRepository _userRepo = new UserRepository();
        private readonly CashierLogRepository _cashierLogRepo = new CashierLogRepository();

        public string Department { get; set; }

       
        public static frm_fee_collection instance;
        private readonly string _email;

        public string id_number { get; set; }
        public int OrNumber { get; set; }

        public string Cashier { get; set; }


        public frm_fee_collection(string email)
        {
            instance = this;
            InitializeComponent();
            _email = email;
        }
        

        private async void frm_fee_collection_Load(object sender, EventArgs e)
        {
            loadFeeBreakdownDGV();
            loadAssessmentBreakdownDGV();
            await loadSchoolYear();
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

        
        private async Task loadSchoolYear()
        {
            var schoolYears = await _schoolYearRepo.GetAllAsync();
            tSchoolYear.ValueMember = "id";
            tSchoolYear.DisplayMember = "code";
            tSchoolYear.DataSource = schoolYears.Where(x => x.is_current == "Yes").ToList();
        }

        private async Task loadStudentAccount()
        {

            var studentAccounts = await _studentAccountRepo.GetAllAsync();
            var student = studentAccounts.FirstOrDefault(x => x.id_number == tIdNumber.Text);
            tStudentName.Text = student.fullname;
            tStatus.Text = student.status;
        }
        private async Task loadStudentCourse()
        {
            var studentCourses = await _studentCourseRepo.GetAllAsync();
            var course = studentCourses.FirstOrDefault(x => x.id_number == tIdNumber.Text);

            tCourse.Text = course.course;
            tYearLevel.Text = course.year_level;
            tSemester.Text = course.semester;
            tCampus.Text = course.campus;
        }
        private async Task loadStatementOfAccount()
        {
            var statementOfAccounts = await _statementOfAccountsRepo.GetAllAsync();
            var soa = statementOfAccounts
                .Where(x => x.id_number == tIdNumber.Text && x.school_year == tSchoolYear.Text)
                .ToList();

            dgv.DataSource = soa;
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

        private async Task loadFeeBreakdown()
        {
            var feeBreakdowns = await _feeBreakdownRepo.GetAllAsync();
            var feeBreakdown = feeBreakdowns.Where(x => x.id_number == tIdNumber.Text && x.school_year == tSchoolYear.Text).ToList();

            var dt = feeBreakdown.ToDataTable();

            dgvFeeBreakdown.Rows.Clear();

            string[] term = { "Downpayment", "Prelims", "Midterms", "Semi-Finals", "Finals" };

            for (int i = 0; i < 5; i++)
            {
                dgvFeeBreakdown.Rows.Add(term[i], dt.Rows[0][i + 3]);
            }
        }

        private async Task loadRecords()
        {
            await loadStudentAccount();
            await loadStudentCourse();
            await loadStatementOfAccount();
            await loadFeeBreakdown();
            await loadAssessmentBreakdown();
            await loadAmountPayable();
            try
            {
            }
            catch (Exception ex)
            {
                new Classes.Toastr("Warning", ex.Message);
                tAmount.Clear();
                tAmount.Select();
            }
        }

        private async Task loadAssessmentBreakdown()
        {
            dgvAssessmentBreakdown.Rows.Clear();
            var assessmentBreakdowns = await _assessmentBreakdownRepo.GetAllAsync();
            var breakdown = assessmentBreakdowns
                .Where(x => x.id_number == tIdNumber.Text && x.school_year == tSchoolYear.Text)
                .ToList();

            foreach (var items in breakdown)
            {
                dgvAssessmentBreakdown.Rows.Add(items.fee_type, items.amount);
            }
        }

        private void tSearch_Click(object sender, EventArgs e)
        {

        }

        private async Task soaCollection()
        {
            int referenceNo = 0;

            referenceNo = OrNumber;

            var studentAccounts = await _studentAccountRepo.GetAllAsync();
            var id_number_id = studentAccounts.FirstOrDefault(x => x.id_number == tIdNumber.Text);

            var schoolYears = await _schoolYearRepo.GetAllAsync();
            var school_year_id = schoolYears.FirstOrDefault(x => x.code == tSchoolYear.Text);

            var courses = await _courseRepo.GetAllAsync();
            var course_id = courses.FirstOrDefault(x => x.code == tCourse.Text);

            var statementsOfAccounts = await _statementOfAccountsRepo.GetAllAsync();
            var soaLatest = statementsOfAccounts
                .Where(x => x.id_number == tIdNumber.Text && x.school_year == tSchoolYear.Text)
                .ToList();
            var dt = soaLatest.ToDataTable();

            var lastrow = dt.Rows.Count - 1;

            decimal latestBalance = Convert.ToDecimal(dt.Rows[lastrow]["balance"]);
            decimal latestCredit = cPayment.Checked ? Convert.ToDecimal(tAmount.Text) : Convert.ToDecimal(tAmountPayable.Text);
            string latestParticulars = tParticulars.Text;



            var collect = new StatementOfAccount
            {
                id_number = id_number_id.id.ToString(),
                school_year = school_year_id.id.ToString(),
                date = DateTime.Now.ToString("MM-dd-yyyy"),
                course = course_id.id.ToString(),
                year_level = tYearLevel.Text,
                semester = tSemester.Text,
                reference_no = referenceNo,
                particulars = latestParticulars,
                debit = latestBalance,
                credit = latestCredit,
                balance = latestBalance - latestCredit,
                cashier_in_charge = Cashier
            };
            await _statementOfAccountsRepo.AddRecordsAsync(collect);

            var cashierLog = new CashierLog
            {
                date = DateTime.Now,
                name = Cashier,
                reference_no = referenceNo.ToString(),
                particulars = latestParticulars,
                school_year = school_year_id.id.ToString(),
                department = Department,
                debit = latestBalance,
                credit = latestCredit,
                balance = latestBalance - latestCredit
            };
            await _cashierLogRepo.AddRecords(cashierLog);

            
        }

        private async Task assessmentBreakdownComputation()
        {
            await Task.Delay(10);
            decimal amount = Convert.ToDecimal(tAmount.Text);
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

        private async Task feeBreakdownComputation()
        {
            await Task.Delay(10);
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

        private async Task feeBreakDownSave()
        {
            await feeBreakdownComputation();


            var totalBreakdown =
                Convert.ToDecimal(dgvFeeBreakdown.Rows[0].Cells["amount"].Value) +
                Convert.ToDecimal(dgvFeeBreakdown.Rows[1].Cells["amount"].Value) +
                Convert.ToDecimal(dgvFeeBreakdown.Rows[2].Cells["amount"].Value) +
                Convert.ToDecimal(dgvFeeBreakdown.Rows[3].Cells["amount"].Value) +
                Convert.ToDecimal(dgvFeeBreakdown.Rows[4].Cells["amount"].Value);

            var feeBreakdowns = await _feeBreakdownRepo.GetAllAsync();
            var studentAccounts = await _studentAccountRepo.GetAllAsync();
            var schoolYears = await _schoolYearRepo.GetAllAsync();


            var id_number_id = studentAccounts.FirstOrDefault(x => x.id_number == tIdNumber.Text);
            var school_year_id = schoolYears.FirstOrDefault(x => x.code == tSchoolYear.Text);

            var feeBreakdown = new FeeBreakdown
            {
                id_number = id_number_id.id.ToString(),
                school_year = school_year_id.id.ToString(),
                downpayment = Convert.ToDecimal(dgvFeeBreakdown.Rows[0].Cells["amount"].Value),
                prelim = Convert.ToDecimal(dgvFeeBreakdown.Rows[1].Cells["amount"].Value),
                midterm = Convert.ToDecimal(dgvFeeBreakdown.Rows[2].Cells["amount"].Value),
                semi_finals = Convert.ToDecimal(dgvFeeBreakdown.Rows[3].Cells["amount"].Value),
                finals = Convert.ToDecimal(dgvFeeBreakdown.Rows[4].Cells["amount"].Value),
                total = totalBreakdown
            };
            await _feeBreakdownRepo.UpdateRecordsAsync(feeBreakdown);
            //await loadFeeBreakdown();
        }

        private async Task assessmentBreakdownSave()
        {
            await assessmentBreakdownComputation();

            var studentAccounts = await _studentAccountRepo.GetAllAsync();
            var id_number_id = studentAccounts.FirstOrDefault(x => x.id_number == tIdNumber.Text);

            var schoolYears = await _schoolYearRepo.GetAllAsync();
            var school_year_id = schoolYears.FirstOrDefault(x => x.code == tSchoolYear.Text);

            foreach (DataGridViewRow row in dgvAssessmentBreakdown.Rows)
            {
                var parameter = new AssessmentBreakdown
                {
                    id_number = id_number_id.id.ToString(),
                    school_year = school_year_id.id.ToString(),
                    fee_type = row.Cells["fee_type"].Value.ToString(),
                    amount = Convert.ToDecimal(row.Cells["amount"].Value)
                };
                await _assessmentBreakdownRepo.UpdateRecordsAsync(parameter);
            }
        }

        private void GetCashierOrNumberAndDepartment()
        {
            Cashier = frm_collection_module.instance.CashierInCharge;
            OrNumber = frm_collection_module.instance.OrNumber;
            Department = frm_collection_module.instance.Department;
        }

        private async Task LoadStudentCredentialBySearch()
        {
            id_number = tIdNumber.Text;
            var student = await _studentAccountRepo.GetStudentDetailAsync(id_number);

            tIdNumber.Text = id_number;
            tStudentName.Text = student.name;
            tCourse.Text = student.course;
            tYearLevel.Text = student.year_level;
            tSemester.Text = student.semester;
            tCampus.Text = student.campus;
            tStatus.Text = student.status;
        }


        private async void btnConfirmPayment_Click(object sender, EventArgs e)
        {
            GetCashierOrNumberAndDepartment();
            btnConfirmPayment.Enabled = false;
            btnConfirmPayment.Text = "Please Wait...";
            if (tAmount.Text == "" && tParticulars.Text == "")
            {
                new Classes.Toastr("Error", "Missing Fields");
            }
            else if (OrNumber == 0)
            {
                new Classes.Toastr("Error", "Please set Or Number");
            }
            else
            {
                decimal collection = 0;
                decimal payable = 0;
                decimal change = 0;
                if (tAmount.Text == "" || tAmountPayable.Text == "" || tParticulars.Text == "")
                {
                    new Classes.Toastr("Warning", "Fields Missing");
                }
                else
                {
                    try
                    {
                        collection = Convert.ToDecimal(tAmount.Text);
                        payable = Convert.ToDecimal(tAmountPayable.Text);
                        if (collection < 500 && (decimal)dgvFeeBreakdown.Rows[0].Cells["amount"].Value > 0)
                        {
                            new Classes.Toastr("Error", "Payment amount not accepted!");
                        }
                        else if (cPayment.Checked)
                        {
                            if (MessageBox.Show("Confirm Payment: " + tAmount.Text + ", Particulars: " + tParticulars.Text, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                await soaCollection();
                                await feeBreakDownSave();
                                await assessmentBreakdownSave();

                                var studentAccounts = await _studentAccountRepo.GetAllAsync();
                                var student = studentAccounts.FirstOrDefault(x => x.id_number == tIdNumber.Text);

                                string numberToWords = NumberToWords.ConvertToWords(Convert.ToInt32(collection)) + " Pesos Only";


                                if (student.status == "Accounting")
                                {
                                    await _studentAccountRepo.StudentOfficiallyEnroll(student.id.ToString(), "Officially Enrolled for School Year: " + tSchoolYear.Text);
                                }

                                new Classes.Toastr("Success", "Payment Collected");
                               

                                // for printing
                                var frm = new frm_payment_message(tStudentName.Text, OrNumber.ToString(), DateTime.Now.ToString("MM-dd-yyyy"), tAmount.Text, tAmountPayable.Text, 
                                    change.ToString(), Cashier, numberToWords);
                                frm.Text = "Fee Collection";
                                frm.Show();

                                await loadRecords();
                                frm_collection_module.instance.incrementOrNumber();
                            }
                        }
                        else
                        {
                            change = collection - payable;

                            if (change < 0)
                            {
                                new Classes.Toastr("Error", "Payment not accepted, please provide higher than the payable");
                            }
                            else
                            {
                                if (MessageBox.Show("Confirm Payment: " + tAmountPayable.Text + ", Particulars: " + tParticulars.Text, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {

                                    await soaCollection();
                                    await feeBreakDownSave();
                                    await assessmentBreakdownSave();


                                    var studentAccounts = await _studentAccountRepo.GetAllAsync();
                                    var student = studentAccounts.FirstOrDefault(x => x.id_number == tIdNumber.Text);

                                    //display latest soa balance
                                    var lastRow = dgv.Rows.Count - 1;
                                    var remainingBalance = dgv.Rows[lastRow].Cells["balance"].ToString();

                                    string numberToWords = NumberToWords.ConvertToWords(Convert.ToInt32(payable)) + " Pesos Only";


                                    if (student.status == "Accounting")
                                    {
                                        await _studentAccountRepo.StudentOfficiallyEnroll(student.id.ToString(), "Officially Enrolled for School Year: " + tSchoolYear.Text);
                                    }

                                    new Classes.Toastr("Success", "Payment Collected");
                                    
                                    var frm = new frm_payment_message(tStudentName.Text, OrNumber.ToString(), DateTime.Now.ToString("MM-dd-yyyy"), tAmount.Text, tAmountPayable.Text,
                                    change.ToString(), Cashier, numberToWords);
                                    frm.Text = "Fee Collection";
                                    frm.ShowDialog();
                                    await loadRecords();
                                    frm_collection_module.instance.incrementOrNumber();

                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        new Classes.Toastr("Error", ex.Message);
                    }

                }
                tAmount.Clear();
                tParticulars.Clear();
                btnConfirmPayment.Enabled = true;
                btnConfirmPayment.Text = "Confirm Payment";
                
            }




        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var frm = new frm_select_student();
            frm.Text = "Fee Collection";
            frm.ShowDialog();
            if (id_number != null)
            {
                dgvFeeBreakdown.Rows.Clear();
                dgvAssessmentBreakdown.Rows.Clear();
                tIdNumber.Text = id_number;
                await loadRecords();

            }
        }

        private async Task loadAmountPayable()
        {
            await Task.Delay(50);
            foreach (DataGridViewRow row in dgvFeeBreakdown.Rows)
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


        private async void frm_fee_collection_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                await LoadStudentCredentialBySearch();
            }
        }
    }
}
