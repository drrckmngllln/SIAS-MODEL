using DocumentFormat.OpenXml.Wordprocessing;
using school_management_system_model.Classes;
using school_management_system_model.Core.Entities;
using school_management_system_model.Core.Helpers;
using school_management_system_model.Data.Repositories.Setings;
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

        public bool IsAdd { get; set; }
        public bool IsEdit { get; set; }
        public bool IsDelete { get; set; }
        public bool IsAdministrator { get; set; }
        public string schoolYear { get; set; }
        public bool AdmissionValidator { get; set; }
        public string Email { get; set; }
        public frmStudentAccountModule(string email)
        {
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

        private void CreateAccount()
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

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (btnCreate.Text == "Create Account")
            {
                if (IsAdd || IsAdministrator)
                {
                    if (AdmissionValidator || IsAdministrator)
                    {
                        CreateAccount();
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
    }
}
