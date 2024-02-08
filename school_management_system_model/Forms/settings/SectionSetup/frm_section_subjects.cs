using Krypton.Toolkit;
using school_management_system_model.Classes;
using school_management_system_model.Core.Entities;
using school_management_system_model.Data.Repositories.Setings.Section;
using school_management_system_model.Loggers;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace school_management_system_model.Forms.settings
{
    public partial class frm_section_subjects : KryptonForm
    {
        SectionSubjectRepository _sectionSubjectRepo = new SectionSubjectRepository();
        SectionRepository _sectionRepo = new SectionRepository();


        public static frm_section_subjects instance;

        public string Section_Code { get; }

        public string Email { get; }
        public string instructor { get; set; }

        public frm_section_subjects(string section_code, string email)
        {
            instance = this;
            InitializeComponent();
            Section_Code = section_code;
            Email = email;
        }

        private async void frm_section_subjects_Load(object sender, EventArgs e)
        {
            tLoading.Visible = true;
            await Task.Delay(500);
            tLoading.Visible = false;
            loadSections();
            loadRecords();
        }

        private async void loadRecords()
        {
            //x.semester == tSemester.Text && 
            var sectionSubjects = await _sectionSubjectRepo.GetAllAsync();
            var data = sectionSubjects.Where(x => x.section_code == tSectionCode.Text).ToList();

            if (data != null)
            {
                dgv.DataSource = data;
                dgv.Columns["id"].Visible = false;
                dgv.Columns["unique_id"].Visible = false;
                dgv.Columns["section_code"].Visible = false;
                dgv.Columns["year_level"].Visible = false;
                dgv.Columns["semester"].Visible = false;
                dgv.Columns["subject_code"].HeaderText = "Subject Code";
                dgv.Columns["descriptive_title"].HeaderText = "Descriptive Title";
                dgv.Columns["total_units"].HeaderText = "Total Units";
                dgv.Columns["lecture_units"].HeaderText = "Lecture Units";
                dgv.Columns["lab_units"].HeaderText = "Lab Units";
                dgv.Columns["pre_requisite"].HeaderText = "Pre Requisite";
                dgv.Columns["time"].HeaderText = "Time";
                dgv.Columns["day"].HeaderText = "Day";
                dgv.Columns["room"].HeaderText = "Room";
                dgv.Columns["instructor"].HeaderText = "Instructor";

                dgv.Columns["descriptive_title"].Width = 400;
                dgv.Columns["instructor"].Width = 350;
                dgv.Columns["time"].Width = 300;
            }



            tLoading.Visible = false;
        }

        private async void loadSections()
        {
            //var section = await _sectionRepo.GetAllAsync();
            //var a = section.FirstOrDefault(x => x.section_code == Section_Code);
            //tSectionCode.Text = Section_Code;
            //tCourse.Text = a.course;
            //tYearLevel.Text = a.year_level.ToString();
            //tSemester.Text = a.semester;

            //if (dgv.Rows.Count == 0)
            //{
            //    var curriculum = new Curriculums().GetCurriculums().Where(x => x.course_id == tCourse.Text).ToList();
            //    tCurriculum.DataSource = curriculum;
            //    tCurriculum.ValueMember = "id";
            //    tCurriculum.DisplayMember = "code";
            //}
            //else
            //{
            //    tCurriculum.Text = dgv.Rows[0].Cells["curriculum"].Value.ToString();
            //}
        }

        private async void btn_save_Click(object sender, EventArgs e)
        {
            //if (btn_save.Text == "Add Subject")
            //{
            //    var curriculum_id = new Curriculums().GetCurriculums().FirstOrDefault(x => x.code == tCurriculum.Text);

            //    var section_id = await _sectionRepo.GetAllAsync();
            //    var a = section_id.FirstOrDefault(x => x.section_code == tSectionCode.Text);
            //    var frm = new frm_section_subject_add(Email);
            //    frm_section_subject_add.instance.curriculum_id = curriculum_id.id.ToString();
            //    frm_section_subject_add.instance.sectionCode = tSectionCode.Text;
            //    frm_section_subject_add.instance.course = tCourse.Text;
            //    frm_section_subject_add.instance.year_level = tYearLevel.Text;
            //    frm_section_subject_add.instance.semester = tSemester.Text;
            //    frm.Text = "Subjects";
            //    frm.ShowDialog();
            //    loadRecords();
            //}
            //else if (btn_save.Text == "Update Subject")
            //{

            //    var update = new SectionSubjects
            //    {
            //        id = Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value.ToString()),
            //        time = tTime.Text,
            //        day = tDay.Text,
            //        room = tRoom.Text,
            //        instructor = instructor
            //    };
            //    await _sectionSubjectRepo.UpdateRecords(update);

            //    new Classes.Toastr("Information", "Schedule Updated");
            //    new ActivityLogger().activityLogger(Email, "Updating Sections: " + tSectionCode.Text);
            //    loadRecords();
            //}
        }

        private async void delete()
        {
            var delete = new SectionSubjects();
            delete.id = Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value);
            await _sectionSubjectRepo.DeleteRecords(delete);

            new Classes.Toastr("Information", "Subject Deleted");
            new ActivityLogger().activityLogger(Email, "Section Subject Delete: " + dgv.CurrentRow.Cells["descriptive_title"].Value.ToString());

            loadRecords();
        }
        private async void DeleteAll()
        {
            var deleteAll = new SectionSubjects
            {
                id = Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value)
            };
            await _sectionSubjectRepo.DeleteRecords(deleteAll);


            new Classes.Toastr("Information", "All Subjects Deleted");
            new ActivityLogger().activityLogger(Email, "All Section Deleted: " + Section_Code);
            loadRecords();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this subject?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                DialogResult.Yes)
            {
                delete();
            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //tCurriculum.Text = dgv.CurrentRow.Cells["curriculum_id"].Value.ToString();
            tSemester.Text = dgv.CurrentRow.Cells["semester"].Value.ToString();
            tTime.Text = dgv.CurrentRow.Cells["time"].Value.ToString();
            tDay.Text = dgv.CurrentRow.Cells["day"].Value.ToString();
            tRoom.Text = dgv.CurrentRow.Cells["room"].Value.ToString();
            tInstructor.Text = dgv.CurrentRow.Cells["instructor"].Value.ToString();
            btn_save.Text = "Update Subject";
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            btn_save.Text = "Add Subject";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var frm = new frm_select_instructor();
            frm.ShowDialog();
            tInstructor.Text = dgv.CurrentRow.Cells["instructor"].Value.ToString();
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete all this subjects?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DeleteAll();
            }
        }
    }
}
