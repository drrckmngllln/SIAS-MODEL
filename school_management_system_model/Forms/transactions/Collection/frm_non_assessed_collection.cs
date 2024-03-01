using school_management_system_model.Core.Entities.Transaction;
using school_management_system_model.Core.Helpers;
using school_management_system_model.Data.Repositories.Setings;
using school_management_system_model.Data.Repositories.Transaction;
using school_management_system_model.Data.Repositories.Transaction.StudentAccounts;
using school_management_system_model.Infrastructure.Data.Repositories.Transaction;
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
    public partial class frm_non_assessed_collection : Form
    {
        UserRepository _userRepo = new UserRepository();
        SchoolYearRepository _schoolYearRepo = new SchoolYearRepository();
        StudentAccountRepository _studentAccountRepo = new StudentAccountRepository();
        StudentCourseRepository _studentCourseRepo = new StudentCourseRepository();
        NonAssessmentRepository _NonAssessmentRepo = new NonAssessmentRepository();
        CourseRepository _courseRepo = new CourseRepository();

        private readonly string email;
        public string id_number { get; set; }

        public static frm_non_assessed_collection instance;
        public frm_non_assessed_collection(string email)
        {
            instance = this;
            InitializeComponent();
            this.email = email;

        }

        private async Task CashierInfo()
        {
            var users = await _userRepo.GetAllAsync();
            var cashier = users.FirstOrDefault(x => x.email == email);
            tCashier.Text = cashier.fullname;
        }

        private async Task LoadSchoolYear()
        {
            var schoolYears = await _schoolYearRepo.GetAllAsync();
            tSchoolYear.ValueMember = "id";
            tSchoolYear.DisplayMember = "code";
            tSchoolYear.DataSource = schoolYears;
        }

        private void SetOrNumber()
        {
            int orNumber = 0;
            orNumber = Convert.ToInt32(tOrNumberSet.Text);
            tOrNumber.Text = orNumber.ToString();
            tOrNumberSet.Clear();
        }

        private void incrementORNumber()
        {
            int orNumber = Convert.ToInt32(tOrNumber.Text);
            orNumber++;
            tOrNumber.Text = orNumber.ToString();
        }

        private async Task LoadStudentCredential()
        {
            tIdNumber.Text = id_number.ToString();
            var studentAccounts = await _studentAccountRepo.GetAllAsync();
            var studentCourses = await _studentCourseRepo.GetAllAsync();

            var student = studentAccounts.FirstOrDefault(x => x.id_number == id_number);
            var course = studentCourses.FirstOrDefault(x => x.id_number == id_number);

            tStudentName.Text = student.fullname;
            tCourse.Text = course.course;
            tYearLevel.Text = course.year_level;
            tSemester.Text = course.semester;
            tCampus.Text = course.campus;
            tStatus.Text = student.status;
        }

        private async void frm_non_assessed_collection_Load(object sender, EventArgs e)
        {
            await CashierInfo();
            await LoadSchoolYear();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            SetOrNumber();
        }

        private async void btnSelectStudent_Click(object sender, EventArgs e)
        {
            var frm = new frm_select_student();
            frm.Text = "Non Assessed Collection";
            frm.ShowDialog();
            if (id_number != null)
            {
                await LoadStudentCredential();
                await loadNonAssessment();
            }

        }
        private async Task loadNonAssessment()
        {
            var nonAssessment = await _NonAssessmentRepo.GetAllAsync();
            var soa = nonAssessment.Where(x => x.id_number == id_number && x.school_year == tSchoolYear.Text).ToList();
            dgv.DataSource = soa;

            dgv.Columns["id"].Visible = false;
            dgv.Columns["id_number"].Visible = false;
            dgv.Columns["school_year"].Visible = false;
            dgv.Columns["date"].Visible = false;
            dgv.Columns["course_id"].Visible = false;
            dgv.Columns["year_level"].Visible = false;
            dgv.Columns["semester"].Visible = false;
            dgv.Columns["reference_no"].HeaderText = "OR Numbers";
            dgv.Columns["particulars"].HeaderText = "Particulars";
            dgv.Columns["amount"].HeaderText = "Amount";
            dgv.Columns["cashier_in_charge"].Visible = false;

        }

        private async Task SoaCollection()
        {
            var studentAssessments = await _studentAccountRepo.GetAllAsync();
            var id_number_id = studentAssessments.FirstOrDefault(x => x.id_number == tIdNumber.Text);

            var courses = await _courseRepo.GetAllAsync();
            var course = courses.FirstOrDefault(x => x.code == tCourse.Text);

            var collect = new NonAssessment
            {
                id_number = id_number_id.id.ToString(),
                school_year = tSchoolYear.SelectedValue.ToString(),
                date = DateTime.Now.ToString("yyyy-MM-dddd"),
                course_id = course.id.ToString(),
                year_level = tYearLevel.Text,
                semester = tSemester.Text,
                reference_no = Convert.ToInt32(tOrNumber.Text),
                particulars = tParticulars.Text,
                amount = Convert.ToDecimal(tAmount.Text),
                cashier_in_charge = tCashier.Text
            };
            var result = await _NonAssessmentRepo.AddRecordsAsync(collect);
            new Classes.Toastr("Success", "Fee Collected");
            await loadNonAssessment();

            incrementORNumber();
        }

        private async void btnConfirmPayment_Click(object sender, EventArgs e)
        {
            try
            {
                if (tAmount.Text == "" || tParticulars.Text == "" || tAmountPayable.Text == "" || tOrNumber.Text == "")
                {
                    new Classes.Toastr("Error", "Missing Fields");
                }
                else
                {
                    decimal collection = 0;
                    decimal payable = 0;
                    decimal change = 0;

                    collection = Convert.ToDecimal(tAmount.Text);
                    payable = Convert.ToDecimal(tAmountPayable.Text);

                    if (collection < payable)
                    {
                        new Classes.Toastr("Warning", "Collection must be greater or equal to payable");
                    }
                    else
                    {
                        change = collection - payable;
                        await SoaCollection();

                        string numberToWords = NumberToWords.ConvertToWords(Convert.ToInt32(payable)) + " Pesos Only";

                        //Payment printing
                        var frm = new frm_payment_message(tStudentName.Text, tOrNumber.Text, DateTime.Now.ToString("MM-dd-yyyy"), tAmount.Text, tAmountPayable.Text, change.ToString(), tCashier.Text, numberToWords);
                        frm.Text = "Non Assessed Collection";
                        frm.ShowDialog();

                        txtClear();
                    }
                }
            }
            catch (Exception ex)
            {
                new Classes.Toastr("Warning", ex.Message);
            }

        }

        private void txtClear()
        {
            tIdNumber.Clear();
            tStudentName.Text = "";
            tCourse.Text = "";
            tYearLevel.Text = "";
            tSemester.Text = "";
            tCampus.Text = "";
            tStatus.Text = "";
            tAmount.Clear();
            tAmountPayable.Clear();
            tParticulars.Clear();
            btnSelectStudent.Select();
        }
    }
}
