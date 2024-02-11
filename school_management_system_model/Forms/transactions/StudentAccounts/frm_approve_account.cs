using Krypton.Toolkit;
using MySql.Data.MySqlClient;
using school_management_system_model.Classes;
using school_management_system_model.Data.Repositories.Setings;
using school_management_system_model.Data.Repositories.Transaction;
using school_management_system_model.Data.Repositories.Transaction.StudentAccounts;
using school_management_system_model.Reports.Datasets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace school_management_system_model.Forms.transactions.StudentAccounts
{
    public partial class frm_approve_account : KryptonForm
    {
        CourseRepository _courseRepo = new CourseRepository();
        StudentCourseRepository _studentCourseRepo = new StudentCourseRepository();
        CurriculumRepository _curriculumRepo = new CurriculumRepository();
        StudentAccountRepository _studentAccountRepo = new StudentAccountRepository();

        public static frm_approve_account instance;
        public string course { get; set; }
        public string id_number { get; set; }
        public string fullname { get; set; }
        public frm_approve_account()
        {
            instance = this;
            InitializeComponent();
        }

        private async void frm_approve_account_Load(object sender, EventArgs e)
        {
            await loadRecords();
            await LoadCurriculum();

        }
        private async Task loadRecords()
        {
            tName.Text = fullname;
            var a = await _studentCourseRepo.GetAllAsync();
            var studentCourse = a.FirstOrDefault(x => x.id_number.ToString() == id_number).course;
            tCourse.Text = studentCourse;
        }

        private async Task LoadCurriculum()
        {
            tCurriculum.ValueMember = "id";
            tCurriculum.DisplayMember = "code";
            var curriculum = await _curriculumRepo.GetAllAsync();
            var curriculumLoad = curriculum.Where(x => x.course == tCourse.Text).ToList();
            if (curriculumLoad.Count != 0)
            {
                tCurriculum.DataSource = curriculumLoad;
            }
            else
            {
                new Classes.Toastr("Warning", "No Curriculum Saved for this Course!");
            }
        }

        private async Task approveStudent(int idNumber, int curriculum_id)
        {
            try
            {
                await _studentCourseRepo.ApproveStudent(idNumber, curriculum_id);
                await _studentAccountRepo.ApproveStudent(idNumber.ToString());

                new Classes.Toastr("Success", "Student Approved");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnApprove_Click(object sender, EventArgs e)
        {
            if (tCurriculum.Text == "")
            {

                new Classes.Toastr("Error", "Please select a curriculum");
            }
            else
            {
                var studentAccounts = await _studentAccountRepo.GetAllAsync();
                var curriculum = await _curriculumRepo.GetAllAsync();

                var id_number_id = studentAccounts.FirstOrDefault(x => x.id_number == id_number).id;
                var curriculum_id = curriculum.FirstOrDefault(x => x.code == tCurriculum.Text).id;

                await approveStudent(id_number_id, curriculum_id);
            }
        }
    }
}
