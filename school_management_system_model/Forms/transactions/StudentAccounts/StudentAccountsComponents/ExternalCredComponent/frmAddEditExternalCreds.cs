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
        public int DataId { get; set; }
        public static frmAddEditExternalCreds instance;
        private readonly string _process;

        public frmAddEditExternalCreds(string process)
        {
            instance = this;
            InitializeComponent();
            _process = process;
        }

        private async void frmAddEditExternalCreds_Load(object sender, EventArgs e)
        {
            if (_process == "Update")
            {
                var creds = await _externalCredRepo.GetByIdAsync(DataId);
                tSchoolYear.Text = creds.school_year;
                tSubjectCode.Text = creds.subject_code;
                tDescriptiveTitle.Text = creds.descriptive_title;
                tPreRequisite.Text = creds.pre_requisite;
                tTotalUnits.Text = creds.total_units.ToString();
                tLectureUnits.Text = creds.lecture_units.ToString();
                tLabUnits.Text = creds.lab_units.ToString();
                tGrade.Text = creds.grade.ToString();
                tRemarks.Text = creds.remarks;
            }
        }

        #region add edit functionality

        private async Task AddEdit()
        {
            if (tSchoolYear.Text == "" || tSubjectCode.Text == "" || tDescriptiveTitle.Text == "" || tPreRequisite.Text == "" ||
                    tTotalUnits.Text == "" || tLectureUnits.Text == "" || tLabUnits.Text == "" || tGrade.Text == "" || tRemarks.Text == "")
            {
                new Classes.Toastr("Warning", "Error, missing fields");
            }
            else
            {
                switch (_process)
                {
                    case "Add":
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
                        break;
                    case "Update":
                        var itemUpdate = new ExternalCredential
                        {
                            id = DataId,
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
                        await _externalCredRepo.UpdateRecords(itemUpdate);
                        Close();
                        break;
                }

            }

        }

        #endregion

        #region event handlers

        private async void btnSave_Click(object sender, EventArgs e)
        {
            await AddEdit();
        }

        private async void frmAddEditExternalCreds_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                await AddEdit();
            }
            else if (e.KeyCode == System.Windows.Forms.Keys.Escape)
            {
                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion
    }
}
