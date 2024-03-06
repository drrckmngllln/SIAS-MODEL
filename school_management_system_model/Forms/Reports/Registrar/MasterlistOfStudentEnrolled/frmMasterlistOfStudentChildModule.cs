using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using school_management_system_model.Core.Extensions;
using school_management_system_model.Data.Repositories.Setings;
using school_management_system_model.Data.Repositories.Transaction.StudentAccounts;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace school_management_system_model.Forms.Reports.Registrar.MasterlistOfStudentEnrolled
{
    public partial class frmMasterlistOfStudentChildModule : Form
    {
        StudentAccountRepository _studentAccountRepo = new StudentAccountRepository();
        CourseRepository _courseRepo = new CourseRepository();

        DataSet ds = new DataSet();
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
            ds = new DataSet();
            ds = students.ToDataSet();
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
            ds = studentByCourse.ToDataSet();
            dgv.DataSource = studentByCourse;
        }

        private async Task filterByYearLevel()
        {
            var students = await _studentAccountRepo.GetStudentAccountDtoAsync();
            var studentByYearLevel = students.Where(x => x.year_level == tYearLevel.Text).ToList();
            ds = studentByYearLevel.ToDataSet();
            dgv.DataSource = studentByYearLevel;
        }

        private async Task filterByGender()
        {
            var students = await _studentAccountRepo.GetStudentAccountDtoAsync();
            var studentByGender = students.Where(x => x.gender == tGender.Text).ToList();
            ds = studentByGender.ToDataSet();
            dgv.DataSource = studentByGender;
        }

        public void ExcelExport()
        {

            var sfd = new SaveFileDialog();
            sfd.Filter = "Excel Workboook|*.xlsx";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var workbook = new XLWorkbook();
                    workbook.Worksheets.Add(ds);
                    workbook.SaveAs(sfd.FileName);
                    MessageBox.Show("successfully saved");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
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
