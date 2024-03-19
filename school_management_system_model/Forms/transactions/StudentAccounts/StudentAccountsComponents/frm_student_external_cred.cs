using school_management_system_model.Data.Repositories.Transaction.StudentAccounts;
using school_management_system_model.Forms.transactions.StudentAccounts.StudentAccountsComponents.ExternalCredComponent;
using school_management_system_model.Infrastructure.Data.Repositories.Transaction;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace school_management_system_model.Forms.transactions.StudentAccounts.StudentAccountsComponents
{
    public partial class frm_student_external_cred : Form
    {
        StudentAccountRepository _studentAccountRepo = new StudentAccountRepository();
        ExternalCredentialsRepository _externalCredRepo = new ExternalCredentialsRepository();

        public int ID { get; set; }

        public static frm_student_external_cred instance;
        public frm_student_external_cred()
        {
            instance = this;
            InitializeComponent();
        }

        private async void frm_student_external_cred_Load(object sender, EventArgs e)
        {
            await loadStudentDetails();
            await loadRecords();
        }

        public async Task loadRecords()
        {
            var externalCreds = await _externalCredRepo.GetByIdNumberAsync(ID);
            dgv.DataSource = externalCreds;
            dgv.Columns["id"].Visible = false;
            dgv.Columns["id_number"].Visible = false;
            dgv.Columns["unique_id"].Visible = false;
            dgv.Columns["school_year"].HeaderText = "School Year";
            dgv.Columns["subject_code"].HeaderText = "Subject Code";
            dgv.Columns["descriptive_title"].HeaderText = "Descriptive Title";
            dgv.Columns["pre_requisite"].HeaderText = "Pre Requisite";
            dgv.Columns["total_units"].HeaderText = "Total Units";
            dgv.Columns["lecture_units"].HeaderText = "Lecture Units";
            dgv.Columns["lab_units"].HeaderText = "Lab Units";
            dgv.Columns["grade"].HeaderText = "Grade";
            dgv.Columns["remarks"].HeaderText = "Remarks";

        }

        public async Task loadStudentDetails()
        {
            var student = await _studentAccountRepo.GetMainByIdAsync(ID);
            tIdNumber.Text = student.id_number;
            tStudentName.Text = student.name;
            tGender.Text = student.gender;
            tCourse.Text = student.course;
            tTypeOfStudent.Text = student.type_of_student;
            tAdmissionDate.Text = student.admission_date;
            tStatus.Text = student.status;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var frm = new frmAddEditExternalCreds("Add");
            frmAddEditExternalCreds.instance.ID = ID;
            frm.Text = "Add New Subjects";
            frm.ShowDialog();
        }
    }
}
