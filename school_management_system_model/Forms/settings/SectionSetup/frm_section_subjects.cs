using Krypton.Toolkit;
using school_management_system_model.Classes;
using school_management_system_model.Loggers;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace school_management_system_model.Forms.settings
{
    public partial class frm_section_subjects : KryptonForm
    {
        public static frm_section_subjects instance;
        public int Id { get; }
        public string Email { get; }
        public string instructor { get; set; }

        public frm_section_subjects(int id, string email)
        {
            instance = this;
            InitializeComponent();
            Id = id;
            Email = email;
        }

        private void frm_section_subjects_Load(object sender, EventArgs e)
        {
            loadSections();
            loadRecords();
        }

        private void loadRecords()
        {
            var sectionSubjects = new SectionSubjects().GetSectionSubjects();
            dgv.DataSource = sectionSubjects.Where(x => x.semester == tSemester.Text && x.section_code_id == tSectionCode.Text).ToList();
            dgv.Columns["id"].Visible = false;
            dgv.Columns["unique_id"].Visible = false;
            dgv.Columns["section_code_id"].Visible = false;
            dgv.Columns["curriculum_id"].Visible = false;
            dgv.Columns["course_id"].Visible = false;
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
            dgv.Columns["instructor_id"].HeaderText = "Instructor";
            dgv.Columns["status"].Visible = false;

            dgv.Columns["descriptive_title"].Width = 400;
            dgv.Columns["instructor_id"].Width = 350;
            dgv.Columns["time"].Width = 300;

            
            tLoading.Visible = false;
        }

        private void loadSections()
        {
            var section = new sections().GetSections().FirstOrDefault(x => x.id == Id);
            tSectionCode.Text = section.section_code;
            tCourse.Text = section.course_id;
            tYearLevel.Text = section.year_level.ToString();
            tSemester.Text = section.semester;

            if (dgv.Rows.Count == 0)
            {
                var curriculum = new Curriculums().GetCurriculums().Where(x => x.course_id == tCourse.Text).ToList();
                tCurriculum.DataSource = curriculum;
                tCurriculum.ValueMember = "id";
                tCurriculum.DisplayMember = "code";
            }
            else
            {
                tCurriculum.Text = dgv.Rows[0].Cells["curriculum_id"].Value.ToString();
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (btn_save.Text == "Add Subject")
            {
                var curriculum_id = new Curriculums().GetCurriculums().FirstOrDefault(x => x.code == tCurriculum.Text);
                var section_id = new sections().GetSections().FirstOrDefault(x => x.section_code == tSectionCode.Text);
                var frm = new frm_section_subject_add(Email);
                frm_section_subject_add.instance.curriculum_id = curriculum_id.id.ToString();
                frm_section_subject_add.instance.sectionCode = section_id.id.ToString();
                frm_section_subject_add.instance.course = tCourse.Text;
                frm_section_subject_add.instance.year_level = tYearLevel.Text;
                frm_section_subject_add.instance.semester = tSemester.Text;
                frm.Text = "Subjects";
                frm.ShowDialog();
                loadRecords();
            }
            else if (btn_save.Text == "Update Subject")
            {
                
                var update = new SectionSubjects
                {
                    time = tTime.Text,
                    day = tDay.Text,
                    room = tRoom.Text,
                    instructor_id = instructor
                };
                update.UpdateSectionSubjects(Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value.ToString()));
                
                new Classes.Toastr("Information", "Schedule Updated");
                new ActivityLogger().activityLogger(Email, "Updating Sections: " + tSectionCode.Text);
                loadRecords();
            }
        }

        private void delete()
        {
            var delete = new SectionSubjects();
            delete.DeleteSectionSubjects(Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value));
            
            new Classes.Toastr("Information", "Subject Deleted");
            new ActivityLogger().activityLogger(Email, "Section Subject Delete: " + dgv.CurrentRow.Cells["descriptive_title"].Value.ToString());

            loadRecords();
        }
        private void DeleteAll()
        {
            var deleteAll = new SectionSubjects();
            deleteAll.DeleteAllSectionSubjects(Id);
            new Classes.Toastr("Information", "All Subjects Deleted");
            new ActivityLogger().activityLogger(Email, "All Section Deleted: " + Id);
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
            tCurriculum.Text = dgv.CurrentRow.Cells["curriculum_id"].Value.ToString();
            tSemester.Text = dgv.CurrentRow.Cells["semester"].Value.ToString();
            tTime.Text = dgv.CurrentRow.Cells["time"].Value.ToString();
            tDay.Text = dgv.CurrentRow.Cells["day"].Value.ToString();
            tRoom.Text = dgv.CurrentRow.Cells["room"].Value.ToString();
            tInstructor.Text = dgv.CurrentRow.Cells["instructor_id"].Value.ToString();
            instructor = new Instructors().GetInstructors().FirstOrDefault(x => x.fullname == tInstructor.Text).id.ToString();
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
            tInstructor.Text = new Instructors().GetInstructors().FirstOrDefault(x => x.id.ToString() == instructor).fullname;
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete all this subjects?","Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DeleteAll();
            }
        }
    }
}
