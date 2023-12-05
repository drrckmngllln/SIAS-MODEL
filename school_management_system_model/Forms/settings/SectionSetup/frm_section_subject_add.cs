using Krypton.Toolkit;
using school_management_system_model.Classes;
using System;
using System.Windows.Forms;

namespace school_management_system_model.Forms.settings
{
    public partial class frm_section_subject_add : KryptonForm
    {
        public static frm_section_subject_add instance;
        public string sectionCode { get; set; }
        public string curriculum { get; set; }
        public string course { get; set; }
        public string year_level { get; set; }
        public string semester { get; set; }
        public string remarks { get; set; }
       
        public frm_section_subject_add()
        {
            instance = this;
            InitializeComponent();
        }

        private void frm_section_subject_add_Load(object sender, EventArgs e)
        {
            loadRecords();
        }

        private void loadRecords()
        {
            var data = new section_subject
            {
                curriculumCode = curriculum,
                semester = semester
            };
            dgv.DataSource = data.GetCurriculumData();
            dgv.Columns["id"].Visible = false;
            dgv.Columns["curriculumIdCode"].Visible = false;
            dgv.Columns["curriculum"].Visible = false;
            dgv.Columns["year_level"].HeaderText = "Year Level";
            dgv.Columns["semester"].Visible = false;
            dgv.Columns["code"].HeaderText = "Code";
            dgv.Columns["descriptive_title"].HeaderText = "Descriptive Title";
            dgv.Columns["descriptive_title"].Width = 400;
            dgv.Columns["total_units"].HeaderText = "Total Units";
            dgv.Columns["lecture_units"].HeaderText = "Lecture Units";
            dgv.Columns["lab_units"].HeaderText = "Lab Units";
            dgv.Columns["pre_requisite"].HeaderText = "Pre Requisite";
            dgv.Columns["total_hrs_per_week"].HeaderText = "Total Hours Per Week";
            

            tCurriculum.Text = curriculum.ToString();

        }

        private void SaveSectionSubjects()
        {
            var save = new section_subject
            {
                unique_id = sectionCode + "-" + curriculum + "-" + course + "-" + year_level + "-" + semester + "-" +
                    dgv.CurrentRow.Cells["code"].Value.ToString(),
                section_code = sectionCode,
                curriculum = curriculum,
                course = course,
                year_level = year_level,
                semester = semester,
                subject_code = dgv.CurrentRow.Cells["code"].Value.ToString(),
                descriptive_title = dgv.CurrentRow.Cells["descriptive_title"].Value.ToString(),
                total_units = Convert.ToDecimal(dgv.CurrentRow.Cells["total_units"].Value.ToString()),
                lecture_units = Convert.ToDecimal(dgv.CurrentRow.Cells["lecture_units"].Value.ToString()),
                lab_units = Convert.ToDecimal(dgv.CurrentRow.Cells["lab_units"].Value.ToString()),
                pre_requisite = dgv.CurrentRow.Cells["pre_requisite"].Value.ToString(),
                time = tTime.Text,
                day = tDay.Text,
                room = tRoom.Text
            };
            save.saveSectionSubjects();
            this.Close();
        }
        private void saveAllSectionSubjects()
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            SaveSectionSubjects();
        }

        private void tsearch_TextChanged(object sender, EventArgs e)
        {
            
            if (tsearch.Text.Length > 2)
            {
                var search = new section_subject
                {
                    search = tsearch.Text,
                    curriculumCode = tCurriculum.Text
                };
                dgv.DataSource = search.searchSectionSubjectRegular();
                
            }
            else if (tsearch.Text.Length == 0)
            {
                loadRecords();
            }
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

        }
    }
}
