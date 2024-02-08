using Krypton.Toolkit;
using MySql.Data.MySqlClient;
using school_management_system_model.Classes;
using school_management_system_model.Core.Entities;
using school_management_system_model.Data.Repositories.Setings.Section;
using school_management_system_model.Loggers;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace school_management_system_model.Forms.settings
{
    public partial class frm_section_subject_add : KryptonForm
    {
        SectionRepository _sectionRepo = new SectionRepository();
        SectionSubjectRepository _sectionSubjectRepo = new SectionSubjectRepository();
        public static frm_section_subject_add instance;
        public string sectionCode { get; set; }
        public string curriculum_id { get; set; }
        public string course { get; set; }
        public string year_level { get; set; }
        public string section { get; set; }
        public string semester { get; set; }
        public string remarks { get; set; }
        public string Email { get; }

        Curriculums curriculum = new Curriculums();
        public frm_section_subject_add(string email)
        {
            instance = this;
            InitializeComponent();
            Email = email;
        }

        private void frm_section_subject_add_Load(object sender, EventArgs e)
        {
            loadRecords();
        }

        private void loadRecords()
        {
            tCurriculum.Text = new Curriculums().GetCurriculums().FirstOrDefault(x => x.id == Convert.ToInt32(curriculum_id)).description;
            tYearLevel.Text = year_level;
            tSemester.Text = semester;
            var subjects = new CurriculumSubjects().GetCurriculumSubjects().Where(x => x.curriculum_id == curriculum_id && x.year_level == tYearLevel.Text && x.semester == tSemester.Text);
            dgv.DataSource = subjects.ToList();
            dgv.Columns["id"].Visible = false;
            dgv.Columns["uid"].Visible = false;
            dgv.Columns["curriculum_id"].Visible = false;
            dgv.Columns["year_level"].Visible = false;
            dgv.Columns["semester"].Visible = false;
            dgv.Columns["code"].HeaderText = "Code";
            dgv.Columns["descriptive_title"].HeaderText = "Descriptive Title";
            dgv.Columns["descriptive_title"].Width = 400;
            dgv.Columns["total_units"].HeaderText = "Total Units";
            dgv.Columns["lecture_units"].HeaderText = "Lecture Units";
            dgv.Columns["lab_units"].HeaderText = "Lab Units";
            dgv.Columns["pre_requisite"].HeaderText = "Pre Requisite";
            dgv.Columns["total_hrs_per_week"].HeaderText = "Total Hours Per Week";
        }

        private void SaveSectionSubjects()
        {
            try
            {
                var save = new section_subject
                {
                    //unique_id = sectionCode + "-" + curriculum_id + "-" + course + "-" + year_level + "-" + semester + "-" +
                    //    dgv.CurrentRow.Cells["code"].Value.ToString(),
                    //section_code = sectionCode,
                    //curriculum = curriculum_id,
                    //course = course,
                    //year_level = year_level,
                    //semester = semester,
                    //subject_code = dgv.CurrentRow.Cells["code"].Value.ToString(),
                    //descriptive_title = dgv.CurrentRow.Cells["descriptive_title"].Value.ToString(),
                    //total_units = Convert.ToDecimal(dgv.CurrentRow.Cells["total_units"].Value.ToString()),
                    //lecture_units = Convert.ToDecimal(dgv.CurrentRow.Cells["lecture_units"].Value.ToString()),
                    //lab_units = Convert.ToDecimal(dgv.CurrentRow.Cells["lab_units"].Value.ToString()),
                    //pre_requisite = dgv.CurrentRow.Cells["pre_requisite"].Value.ToString(),
                    //time = tTime.Text,
                    //day = tDay.Text,
                    //room = tRoom.Text
                };
                save.saveSectionSubjects();
                new Classes.Toastr("Success", "Subject Imported");
                new ActivityLogger().activityLogger(Email, "Section Subject Add: " + dgv.CurrentRow.Cells["descriptive_title"].Value.ToString());

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private async void saveAllSectionSubjects()
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                //var sections = await _sectionRepo.GetAllAsync();
                //    var a = sections.FirstOrDefault(x => x.id == Convert.ToInt32(sectionCode));
                var uid = sectionCode + course + year_level + section + semester
                    + row.Cells["code"].Value.ToString();


                var SaveSectionSubjects = new SectionSubjects
                {
                    unique_id = uid,
                    section_code = sectionCode,
                    year_level = year_level,
                    semester = semester,
                    subject_code = row.Cells["code"].Value.ToString(),
                    descriptive_title = row.Cells["descriptive_title"].Value.ToString(),
                    total_units = row.Cells["total_units"].Value.ToString(),
                    lecture_units = row.Cells["lecture_units"].Value.ToString(),
                    lab_units = row.Cells["lab_units"].Value.ToString(),
                    pre_requisite = row.Cells["pre_requisite"].Value.ToString()
                };
                await _sectionSubjectRepo.AddRecords(SaveSectionSubjects);
            }
            new Classes.Toastr("Success", "Subjects Imported");
            new ActivityLogger().activityLogger(Email, "Section Subject Select All");

            Close();
            try
            {


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            SaveSectionSubjects();
        }

        private void frm_section_subject_add_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SaveSectionSubjects();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to add these set of subjects?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                DialogResult.Yes)
            {
                saveAllSectionSubjects();
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            var subjects = new CurriculumSubjects().GetCurriculumSubjects().Where(x => x.curriculum_id == curriculum_id && x.year_level == tYearLevel.Text && x.semester == tSemester.Text);
            dgv.DataSource = subjects.ToList();
        }
    }
}
