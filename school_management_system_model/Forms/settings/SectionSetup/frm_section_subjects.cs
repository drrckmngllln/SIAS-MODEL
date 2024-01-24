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
        public frm_section_subjects instance;
        public int Id { get; }
        public string Email { get; }
        public string instructor { get; set; }

        public frm_section_subjects(int id, string email)
        {
            
            InitializeComponent();
            Id = id;
            Email = email;
        }

        private void frm_section_subjects_Load(object sender, EventArgs e)
        {
            loadRecords();
        }

        private void loadRecords()
        {
            var sectionSubjects = new SectionSubjects().GetSectionSubjects();
            dgv.DataSource = sectionSubjects.ToList();
            dgv.Columns["id"].Visible =false;
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

            var section = new sections().GetSections().FirstOrDefault(x => x.id == Id);
            tSectionCode.Text = section.section_code;
            tCourse.Text = section.course_id;
            tYearLevel.Text = section.year_level.ToString();
            tSemester.Text = section.semester;
           
            if (dgv.Rows.Count == 0)
            {
                var curriculum = new Curriculums().GetCurriculums().Where(x => x.course_id == tCourse.Text).ToList();
                tCurriculum.ValueMember = "id";
                tCurriculum.DisplayMember = "code";
                tCurriculum.DataSource = curriculum;
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
                var frm = new frm_section_subject_add(Email);
                frm_section_subject_add.instance.curriculum_id = curriculum_id.id.ToString();
                frm_section_subject_add.instance.sectionCode = tSectionCode.Text;
                frm_section_subject_add.instance.course = tCourse.Text;
                frm_section_subject_add.instance.year_level = tYearLevel.Text;
                frm_section_subject_add.instance.semester = tSemester.Text;
                frm.Text = "Subjects";
                frm.ShowDialog();
                loadRecords();
            }
            else if (btn_save.Text == "Update Subject")
            {
                var update = new section_subject
                {
                    id = Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value.ToString()),
                    time = tTime.Text,
                    day = tDay.Text,
                    room = tRoom.Text,
                    instructor = tInstructor.Text
                };
                update.updateSectionSubject();
                
                new Classes.Toastr("Information", "Schedule Updated");
                new ActivityLogger().activityLogger(Email, "Updating Sections: " + tSectionCode.Text);
                loadRecords();
            }
        }

        private void delete()
        {
            var delete = new section_subject
            {
                id = Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value.ToString())
            };
            delete.deleteSectionSubjects();
            MessageBox.Show("Subject Deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            new ActivityLogger().activityLogger(Email, "Section Subject Delete: " + dgv.CurrentRow.Cells["descriptive_title"].Value.ToString());

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
            tCurriculum.Text = dgv.CurrentRow.Cells["curriculum"].Value.ToString();
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
            tInstructor.Text = instructor;
        }
    }
}
