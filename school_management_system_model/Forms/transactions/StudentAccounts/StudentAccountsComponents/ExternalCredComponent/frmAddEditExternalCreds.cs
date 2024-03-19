using Krypton.Toolkit;
using school_management_system_model.Core.Entities.Transaction;
using school_management_system_model.Infrastructure.Data.Repositories.Transaction;
using System;
using System.Threading.Tasks;

namespace school_management_system_model.Forms.transactions.StudentAccounts.StudentAccountsComponents.ExternalCredComponent
{
    public partial class frmAddEditExternalCreds : KryptonForm
    {
        ExternalCredentialsRepository _externalCredRepo = new ExternalCredentialsRepository();

        public int ID { get; set; }
        public static frmAddEditExternalCreds instance;
        private readonly string _process;

        public frmAddEditExternalCreds(string process)
        {
            instance = this;
            InitializeComponent();
            _process = process;
        }

        private void frmAddEditExternalCreds_Load(object sender, EventArgs e)
        {

        }

        private async Task AddEdit()
        {
            if (_process == "Add")
            {
                if (tSchoolYear.Text == "" || tSubjectCode.Text == "" || tDescriptiveTitle.Text == "" || tPreRequisite.Text == "" || 
                    tTotalUnits.Text == "" || tLectureUnits.Text == "" || tLabUnits.Text == "" || tGrade.Text == "" || tRemarks.Text == "")
                {
                    new Classes.Toastr("Warning", "Error, missing fields");
                }
                else
                {
                    var item = new ExternalCredential
                    {
                        id_number = ID.ToString(),
                        unique_id = ID + tSchoolYear.Text + tSubjectCode.Text + tDescriptiveTitle.Text,
                        school_year = tSchoolYear.Text,
                        subject_code = tSubjectCode.Text,
                        descriptive_title = tDescriptiveTitle.Text,
                        pre_requisite = tPreRequisite.Text,
                        total_units = Convert.ToDecimal(tTotalUnits.Text),
                        lecture_units = Convert.ToDecimal(tTotalUnits.Text),
                        lab_units = Convert.ToDecimal(tLabUnits.Text),
                        grade = Convert.ToDecimal(tGrade.Text),
                        remarks = tRemarks.Text
                    };
                    await _externalCredRepo.AddRecords(item);
                    Close();
                }
            }
            else if (_process == "Update")
            {

            }
        }
    }
}
