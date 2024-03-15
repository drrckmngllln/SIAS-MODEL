using Krypton.Toolkit;
using school_management_system_model.Classes.Parameters;
using school_management_system_model.Core.Entities;
using school_management_system_model.Data.Repositories.Setings;
using school_management_system_model.Data.Repositories.Setings.Section;
using school_management_system_model.Data.Repositories.Transaction.StudentAccounts;
using school_management_system_model.Data.Repositories.Transaction.StudentAssessment;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace school_management_system_model.Forms.transactions.StudentAccounts
{
    public partial class frm_add_subject : KryptonForm
    {
        StudentSubjectRepository _studentSubjectRepo = new StudentSubjectRepository();
        SectionSubjectRepository _sectionSubjectsRepo = new SectionSubjectRepository();
        StudentAccountRepository _studentAccountRepo = new StudentAccountRepository();
        SchoolYearRepository _schoolYearRepo = new SchoolYearRepository();  


        public int idnumber { get; set; }
        public int schoolyear { get; set; }

        PaginationParams paging = new PaginationParams();

        public static frm_add_subject instance;
        public frm_add_subject()
        {
            instance = this;
            InitializeComponent();
        }

        private void frm_add_subject_Load(object sender, EventArgs e)
        {
            loadRecords();
        }

        private async void loadRecords()
        {
            tLoading.Visible = true;
            await Task.Delay(100);
            tLoading.Visible = false;
            paging.PageSize = 10;
            var sectionSubjects = await _sectionSubjectsRepo.GetAllAsync();
            sectionSubjects.Skip(paging.PageSize * (paging.pageNumber - 1))
            .Take(paging.PageSize).ToList();

            
            dgv.DataSource = sectionSubjects;
            dgv.Columns["id"].Visible = false;
            dgv.Columns["unique_id"].Visible = false;
            dgv.Columns["section_code"].HeaderText = "Section";
            dgv.Columns["curriculum"].HeaderText = "Curriculum";
            dgv.Columns["year_level"].HeaderText = "Year Level";
            dgv.Columns["semester"].HeaderText = "Semester";
            dgv.Columns["subject_code"].HeaderText = "Subject Code";
            dgv.Columns["descriptive_title"].HeaderText = "Descriptive Title";
            dgv.Columns["descriptive_title"].Width = 350;
            dgv.Columns["total_units"].HeaderText = "Total Units";
            dgv.Columns["lecture_units"].HeaderText = "Lecture Units";
            dgv.Columns["lab_units"].HeaderText = "Lab Units";
            dgv.Columns["pre_requisite"].HeaderText = "Pre Requisite";
            dgv.Columns["time"].HeaderText = "Time";
            dgv.Columns["day"].HeaderText = "Day";
            dgv.Columns["room"].HeaderText = "Room";
            dgv.Columns["instructor"].HeaderText = "Instructor";
            dgv.Columns["instructor"].Width = 250;
        }
        private async void searchRecords(string search)
        {
            var sectionSubjects = await _sectionSubjectsRepo.GetAllAsync();
            var searchSection = sectionSubjects.Where(x => x.subject_code.ToLower().Contains(search) || x.descriptive_title.ToLower().Contains(search)).ToList();

            dgv.DataSource = searchSection;
        }
        private void selectSubject()
        {
            int id = Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value);
            frm_student_enrollment.instance.Id = id;
            this.Close();
        }
        private void frm_select_subject_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                selectSubject();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tTime.Text = dgv.CurrentRow.Cells["time"].Value.ToString();
            tDay.Text = dgv.CurrentRow.Cells["day"].Value.ToString();
            tRoom.Text = dgv.CurrentRow.Cells["room"].Value.ToString();
            tInstructor.Text = dgv.CurrentRow.Cells["instructor"].Value.ToString();
        }
        private void frm_add_subject_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                addrecords(idnumber, schoolyear);
            }
            else if (e.KeyCode == Keys.Escape)

            {
                Close();
            }
        }

        private async void addrecords(int idnumber, int schoolyear)
        {
            var subjectcode = dgv.CurrentRow.Cells["subject_code"].Value.ToString();
            var curriculum = dgv.CurrentRow.Cells["curriculum"].Value.ToString();
            var yearlevel = dgv.CurrentRow.Cells["year_level"].Value.ToString();
            var semester = dgv.CurrentRow.Cells["semester"].Value.ToString();
            var sectioncode = dgv.CurrentRow.Cells["section_code"].Value.ToString();
            var descriptivetitle = dgv.CurrentRow.Cells["descriptive_title"].Value.ToString();
            var lectureunits = Convert.ToDecimal(dgv.CurrentRow.Cells["lecture_units"].Value.ToString());
            var totalunits = Convert.ToDecimal(dgv.CurrentRow.Cells["total_units"].Value.ToString());
            var labunits = Convert.ToDecimal(dgv.CurrentRow.Cells["lab_units"].Value.ToString());
            var prerequisite = dgv.CurrentRow.Cells["pre_requisite"].Value.ToString();
            var time = dgv.CurrentRow.Cells["time"].Value.ToString();
            var day = dgv.CurrentRow.Cells["day"].Value.ToString();
            var room = dgv.CurrentRow.Cells["room"].Value.ToString();
            var instructor = dgv.CurrentRow.Cells["instructor"].Value.ToString();

            var id_number_id = await _studentAccountRepo.GetByIdAsync(idnumber);

            var school_year_id = await _schoolYearRepo.GetByIdAsync(schoolyear);

            var add = new StudentSubject
            {
                id_number_id = id_number_id.id.ToString(),
                unique_id = id_number_id.id.ToString() + "-" + school_year_id.id.ToString() + "-" + subjectcode.ToString(),
                school_year_id = school_year_id.id.ToString(),
                subject_code = subjectcode,
                descriptive_title = descriptivetitle,
                lecture_units = lectureunits.ToString(),
                pre_requisite = prerequisite,
                lab_units = labunits.ToString(),
                total_units = totalunits.ToString(),
                time = time,
                day = day,
                room = room,
                instructor_id = instructor,
                grade = "No Grade",
                remarks = "N/A"
            };
            await _studentSubjectRepo.AddSubjectAsync(add);
            new Classes.Toastr("Success", "Subject Added Successfully");
            Close();


        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void btnPrev_Click(object sender, EventArgs e)
        {
            tLoading.Visible = true;
            await Task.Delay(100);
            tLoading.Visible = false;
            if (paging.pageNumber == 1)
            {
                btnPrev.Enabled = false;
            }
            else
            {
                paging.pageNumber--;
                tPageNumber.Text = paging.pageNumber.ToString();
                loadRecords();
                btnNext.Enabled = true;
            }
        }

        private async void btnNext_Click(object sender, EventArgs e)
        {
            tLoading.Visible = true;
            await Task.Delay(100);
            tLoading.Visible = false;
            if (dgv.Rows.Count < paging.PageSize)
            {
                btnNext.Enabled = false;
            }
            else
            {
                paging.pageNumber++;
                tPageNumber.Text = paging.pageNumber.ToString();
                loadRecords();
                btnPrev.Enabled = true;
            }
        }

        private void btnAddSubject_Click(object sender, EventArgs e)
        {
            addrecords(idnumber, schoolyear);
            loadRecords();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tSearch_TextChanged(object sender, EventArgs e)
        {
            if (tSearch.Text.Length > 2)
            {
                searchRecords(tSearch.Text);
            }
            else if (tSearch.Text.Length == 0) loadRecords();
        }
    }
}
