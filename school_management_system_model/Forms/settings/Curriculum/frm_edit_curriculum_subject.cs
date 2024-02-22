using Krypton.Toolkit;
using school_management_system_model.Classes;
using school_management_system_model.Core.Entities;
using school_management_system_model.Data.Repositories.Setings;
using school_management_system_model.Loggers;
using System;
using System.Linq;
using System.Windows.Forms;

namespace school_management_system_model.Forms.settings.Curriculum
{
    public partial class frm_edit_curriculum_subject : KryptonForm
    {
        CurriculumSubjectsRepository _curriculumSubjectsRepo = new CurriculumSubjectsRepository();
        public frm_edit_curriculum_subject(int id, string email)
        {
            InitializeComponent();
            Id = id;
            Email = email;
        }

        public int Id { get; }
        public string Email { get; }
        private string uid { get; set; }

        private void frm_edit_curriculum_subject_Load(object sender, EventArgs e)
        {
            loadRecords();
        }

        private async void loadRecords()
        {
            var a = await _curriculumSubjectsRepo.GetAllAsync();
            var curriculumSubject = a.FirstOrDefault(x => x.id == Id);
            uid = curriculumSubject.curriculum + curriculumSubject.code;
            tYearLevel.Text = curriculumSubject.year_level;
            tSemester.Text = curriculumSubject.semester;
            tCode.Text = curriculumSubject.code;
            tDescriptiveTitle.Text = curriculumSubject.descriptive_title;
            tTotalUnits.Text = curriculumSubject.total_units;
            tLectureUnits.Text = curriculumSubject.lecture_units;
            tLabUnits.Text = curriculumSubject.lab_units;
            tPreRequisite.Text = curriculumSubject.pre_requisite;
            tTotalHoursPerWeek.Text = curriculumSubject.total_hrs_per_week;
        }

        private async void UpdateSubject()
        {
            try
            {
                var update = new CurriculumSubjects
                {
                    id = Id,
                    uid = uid,
                    year_level = tYearLevel.Text,
                    semester = tSemester.Text,
                    code = tCode.Text,
                    descriptive_title = tDescriptiveTitle.Text,
                    total_units = tTotalUnits.Text,
                    lecture_units = tLectureUnits.Text,
                    lab_units = tLabUnits.Text,
                    pre_requisite = tPreRequisite.Text,
                    total_hrs_per_week = tTotalHoursPerWeek.Text,
                };
                await _curriculumSubjectsRepo.UpdateRecords(update);
                new Classes.Toastr("Information", "Curriculum Subject Updated");
                new ActivityLogger().activityLogger(Email, "Curriculum Subject Update: " + Id);
                Close();
            }
            catch (Exception ex)
            {
                new Classes.Toastr("Error", ex.Message);
            }

        }

        private void frm_edit_curriculum_subject_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdateSubject();
            }
            else if (e.KeyCode == Keys.Escape) Close();
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            UpdateSubject();
        }
    }
}
