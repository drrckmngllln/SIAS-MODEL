using school_management_system_model.Data.Repositories.Setings;
using school_management_system_model.Data.Repositories.Transaction.StudentAccounts;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace school_management_system_model.Forms.Reports.Registrar.MasterlistOfStudentEnrolled
{
    public partial class frmMasterlistOfStudentChildModule : Form
    {
        StudentAccountRepository _studentAccountRepo = new StudentAccountRepository();
        CourseRepository _courseRepo = new CourseRepository();


        public static frmMasterlistOfStudentChildModule instance;
        public frmMasterlistOfStudentChildModule()
        {
            instance = this;
            InitializeComponent();
        }

        private async void frmMasterlistOfStudentChildModule_Load(object sender, EventArgs e)
        {
            await loadRecords();
            tTotal.Text = dgv.Rows.Count.ToString();
        }

        private async Task loadRecords()
        {
            var students = await _studentAccountRepo.GetStudentAccountDtoAsync();
            dgv.DataSource = students;
            dgv.Columns["Id"].Visible = false;
            dgv.Columns["name"].HeaderText = "Student Name";
            dgv.Columns["gender"].HeaderText = "Gender";
            dgv.Columns["course"].HeaderText = "Course";
            dgv.Columns["section"].HeaderText = "Section";
            dgv.Columns["year_level"].HeaderText = "Year Level";
        }

        public async Task enableCourse()
        {
            if (tCourse.Visible == false)
            {
                var courses = await _courseRepo.GetAllAsync();
                tCourse.ValueMember = "id";
                tCourse.DisplayMember = "code";
                tCourse.DataSource = courses;
                tCourse.Visible = true;
                await filterByCourse();
            }
            else
            {
                tCourse.Visible = false;
                await loadRecords();
            }
        }

        public async Task enableYearLevel()
        {
            if (tYearLevel.Visible == false)
            {
                tYearLevel.Visible = true;
                await filterByYearLevel();
            }
            else { tYearLevel.Visible = false; await loadRecords(); }
        }

        public async Task enableGender()
        {
            if (tGender.Visible == false)
            {
                tGender.Visible = true;
                await filterByGender();
            }
            else
            {
                tGender.Visible = false;
                await loadRecords();
            }
        }

        private async Task filterByCourse()
        {
            var students = await _studentAccountRepo.GetStudentAccountDtoAsync();
            var studentByCourse = students.Where(x => x.course == tCourse.Text).ToList();
            dgv.DataSource = studentByCourse;
        }

        private async Task filterByYearLevel()
        {
            var students = await _studentAccountRepo.GetStudentAccountDtoAsync();
            var studentByYearLevel = students.Where(x => x.year_level == tYearLevel.Text).ToList();
            dgv.DataSource = studentByYearLevel;
        }

        private async Task filterByGender()
        {
            var students = await _studentAccountRepo.GetStudentAccountDtoAsync();
            var studentByGender = students.Where(x => x.gender == tGender.Text).ToList();
            dgv.DataSource = studentByGender;
        }

        private async void tCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            await filterByCourse();
        }

        private async void tYearLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            await filterByYearLevel();
        }

        private async void tGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            await filterByGender();
        }
    }
}
