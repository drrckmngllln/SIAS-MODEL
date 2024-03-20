using DocumentFormat.OpenXml.Wordprocessing;
using school_management_system_model.Classes;
using school_management_system_model.Core.Entities;
using school_management_system_model.Core.Helpers;
using school_management_system_model.Data.Repositories.Setings;
using school_management_system_model.Data.Repositories.Transaction.StudentAccounts;
using school_management_system_model.Forms.transactions.StudentAccounts.StudentAccountsComponents;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace school_management_system_model.Forms.transactions.StudentAccounts
{
    public partial class frmStudentAccountModule : Form
    {
        SchoolYearRepository _schoolYearRepo = new SchoolYearRepository();
        StudentAccountRepository _studentAccountRepo = new StudentAccountRepository();

        public int ID { get; set; }

        public bool IsAdd { get; set; }
        public bool IsEdit { get; set; }
        public bool IsDelete { get; set; }
        public bool IsAdministrator { get; set; }
        public string schoolYear { get; set; }
        public bool AdmissionValidator { get; set; }
        public string Email { get; set; }
        public int id_number { get; set; }
        public string fullname { get; set; }

        public static frmStudentAccountModule instance;
        public frmStudentAccountModule(string email)
        {
            instance = this;
            Email = email;
            InitializeComponent();
        }

        private async Task UserCredentials(string email)
        {
            var creds = await new AuthenticationEvaluator().CheckUserCredential(email);
            if (creds != null)
            {
                IsAdd = Convert.ToBoolean(creds.IsAdd);
                IsEdit = Convert.ToBoolean(creds.IsEdit);
                IsDelete = Convert.ToBoolean(creds.IsDelete);
                IsAdministrator = Convert.ToBoolean(creds.IsAdministrator);
            }
        }

        private async Task GetStudentDetailsAndApprove()
        {
            var student = await _studentAccountRepo.GetByIdAsync(frmStudentAccountsList.instance.ID);
            id_number = student.id;
            fullname = student.fullname;

            if (student.status == "Officially Enrolled for School Year: " + tSchoolYear.Text)
            {
                new Classes.Toastr("Warning", "Student Already Approved");
            }
            else if (id_number == 0 && fullname == null)
            {
                new Classes.Toastr("Warning", "No Account Selected");
            }
            else
            {
                ApproveAccount(id_number, fullname);
            }
        }

        private async void frmStudentAccountModule_Load(object sender, EventArgs e)
        {
            OpenStudentAccountMasterList();
            await loadSchoolYears();
            AdmissionScheduleChecker();
            await UserCredentials(Email);
        }

        private void AdmissionScheduleChecker()
        {
            var schedule = new MainRegistrar("Enrollment").ScheduleChecker();
            if (schedule)
            {
                AdmissionValidator = true;
            }

        }

        private async Task CreateAccount()
        {
            var school_year = await _schoolYearRepo.GetByIdAsync(Convert.ToInt32(tSchoolYear.SelectedValue));
            var frm = new frm_create_account
            //(id_number_id, school_year.id.ToString(), school_year.semester);
            {
                School_Year = Convert.ToInt32(tSchoolYear.SelectedValue),
                Semester = school_year.semester
            };
            frm.Text = "Create Account";
            frm.ShowDialog();
            OpenStudentAccountMasterList();
        }

        private async void UpdateAccount()
        {
            var id_number = frmStudentAccountsList.instance.ID;

            var a = await _schoolYearRepo.GetAllAsync();
            var school_year = a.FirstOrDefault(x => x.code == tSchoolYear.Text);
            var frm = new frm_create_account
            //(id_number_id, school_year.id.ToString(), school_year.semester);
            {
                Id_Number = id_number,
                School_Year = Convert.ToInt32(tSchoolYear.SelectedValue),
                Semester = school_year.semester
            };
            frm.Text = "Update Account";
            frm.ShowDialog();
            OpenStudentAccountMasterList();
        }

        private void ApproveAccount(int id_number, string fullname)
        {
            if (AdmissionValidator)
            {
                var frm = new frm_approve_account
                {
                    id_number = id_number,
                    fullname = fullname
                };
                frm.ShowDialog();
                OpenStudentAccountMasterList();
            }
            else
            {
                new Classes.Toastr("Warning", "No Scheduled Enrollment or Adding Schedule");
            }
        }



        private async Task loadSchoolYears()
        {
            var schoolYears = await _schoolYearRepo.GetAllAsync();
            tSchoolYear.ValueMember = "id";
            tSchoolYear.DisplayMember = "code";
            tSchoolYear.DataSource = schoolYears;
            tSchoolYear.Text = schoolYears.SingleOrDefault(x => x.is_current == "Yes").code;
        }

        private void OpenStudentAccountMasterList()
        {
            var frm = new frmStudentAccountsList();
            frm.TopLevel = false;
            panelTask.Controls.Clear();
            panelTask.Controls.Add(frm);
            frm.Show();
        }

        private void ViewStudentSubjects(int idNumberId, int schoolYearId)
        {
            var frm = new frm_view_subjects(idNumberId, schoolYearId);
            frm.TopLevel = false;
            panelTask.Controls.Clear();
            panelTask.Controls.Add(frm);
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void OpenStudentExternalCredentials()
        {
            var frm = new frm_student_external_cred();
            frm_student_external_cred.instance.ID = ID;
            frm.TopLevel = false;
            panelTask.Controls.Clear();
            panelTask.Controls.Add(frm);
            frm.Show();
        }

        private async void btnCreate_Click(object sender, EventArgs e)
        {

            if (btnCreate.Text == " Create Account")
            {
                if (IsAdd || IsAdministrator)
                {
                    if (AdmissionValidator || IsAdministrator)
                    {
                        await CreateAccount();
                    }
                    else
                    {
                        new Classes.Toastr("Error", "No Enrollment Schedule Available");
                    }
                }
                else
                {
                    new Classes.Toastr("Error", "Authorization Denied");
                }
            }
            else if (btnCreate.Text == "Update Account")
            {
                if (IsEdit || IsAdministrator)
                {
                    UpdateAccount();
                }
                else
                {
                    new Classes.Toastr("Error", "Authorization Denied");
                }
            }
        }

        private async void btnApprove_Click(object sender, EventArgs e)
        {
            await GetStudentDetailsAndApprove();

        }

        private void btnSubjects_Click(object sender, EventArgs e)
        {
            if (frmStudentAccountsList.instance.ID == 0)
            {
                new Classes.Toastr("Warning", "Please select a student");
            }
            else
            {
                ViewStudentSubjects(frmStudentAccountsList.instance.ID, Convert.ToInt32(tSchoolYear.SelectedValue));
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            OpenStudentAccountMasterList();
        }

        private void btnExternalCredentials_Click(object sender, EventArgs e)
        {
            ID = frmStudentAccountsList.instance.ID;

            if (ID == 0)
            {
                new Classes.Toastr("Warning", "Please select student");
            }
            else
            {
                OpenStudentExternalCredentials();
            }
        }
    }
}
