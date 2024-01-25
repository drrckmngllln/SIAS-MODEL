using MySql.Data.MySqlClient;
using school_management_system_model.Classes;
using school_management_system_model.Loggers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace school_management_system_model.Forms.settings
{
    public partial class frm_sections : Form
    {
        string ID;

        public string Email { get; }

        public frm_sections(string email)
        {
            InitializeComponent();
            Email = email;
        }

        private void frm_sections_Load(object sender, EventArgs e)
        {
            loadrecords();
            loadcourses();
        }

        private void loadcourses()
        {
            tCourse.ValueMember = "id";
            tCourse.DisplayMember = "code";
            tCourse.DataSource = new Courses().GetCourses();
        }

        private void loadrecords()
        {
            var data = new sections().GetSections();
            dgv.DataSource = data;
            dgv.Columns["id"].Visible = false;
            dgv.Columns["unique_id"].Visible = false;
            dgv.Columns["section_code"].HeaderText = "Section Code";
            dgv.Columns["course_id"].HeaderText = "Course";
            dgv.Columns["year_level"].HeaderText = "Year Level";
            dgv.Columns["section"].HeaderText = "Section";
            dgv.Columns["semester"].HeaderText = "Semester";
            dgv.Columns["number_of_students"].HeaderText = "Number of Students";
            dgv.Columns["max_number_of_students"].HeaderText = "Max Number of Students";
            dgv.Columns["status"].HeaderText = "Status";
            dgv.Columns["remarks"].HeaderText = "Remarks";
        }

        private void add_records()
        {
            try
            {
                if (btn_save.Text == "Save")
                {
                    var add = new sections
                    {
                        unique_id = tSectionCode.Text + tCourse.Text + tYearLevel.Text + tSemester.Text,
                        section_code = tSectionCode.Text,
                        course_id = tCourse.SelectedValue.ToString(),
                        year_level = Convert.ToInt32(tYearLevel.Text),
                        section = tSection.Text,
                        semester = tSemester.Text,
                        number_of_students = Convert.ToInt32(tNumberOfStudents.Text),
                        max_number_of_students = Convert.ToInt32(tMaxStudent.Text),
                        status = tStatus.Text,
                        remarks = tRemarks.Text
                    };
                    add.AddSection();
                    
                    new Classes.Toastr("Success", "Section Add Success");
                    new ActivityLogger().activityLogger(Email, "Section Add: " + tSectionCode.Text);

                    loadrecords();
                }
                else if (btn_save.Text == "Update")
                {
                    var edit = new sections
                    {
                        unique_id = tSectionCode.Text + tCourse.Text + tYearLevel.Text + tSemester.Text,
                        section_code = tSectionCode.Text,
                        course_id = tCourse.SelectedValue.ToString(),
                        year_level = Convert.ToInt32(tYearLevel.Text),
                        section = tSection.Text,
                        semester = tSemester.Text,
                        number_of_students = Convert.ToInt32(tNumberOfStudents.Text),
                        max_number_of_students = Convert.ToInt32(tMaxStudent.Text),
                        status = tStatus.Text,
                        remarks = tRemarks.Text
                    };
                    edit.EditSection(Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value));
                    new Classes.Toastr("Information", "Section Update Success");
                    new ActivityLogger().activityLogger(Email, "Section Edit: " + tSectionCode.Text);

                    loadrecords();
                    txtclear();
                }
            }
            catch(Exception ex)
            {
                new Classes.Toastr("Error", ex.Message);

            }

        }

        private void delete()
        {
            var delete = new sections();
            delete.DeleteSection(Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value));
            MessageBox.Show("Section Delete Success");
            new ActivityLogger().activityLogger(Email, "Section Delete: " + tSectionCode.Text);

            loadrecords();
        }

        private void txtclear()
        {
            tSectionCode.Text = "";
            tYearLevel.Clear();
            tSection.Clear();
            tCourse.Text = "";
            tNumberOfStudents.Text = "0";
            tMaxStudent.Text = "50";
            tStatus.Text = "";
            tSectionCode.Select();
            btn_save.Text = "Save";
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = dgv.CurrentRow.Cells[0].Value.ToString();
            tSectionCode.Text = dgv.CurrentRow.Cells["section_code"].Value.ToString();
            tYearLevel.Text = dgv.CurrentRow.Cells["year_level"].Value.ToString();
            tCourse.Text = dgv.CurrentRow.Cells["course_id"].Value.ToString();
            tSemester.Text = dgv.CurrentRow.Cells["semester"].Value.ToString();
            tNumberOfStudents.Text = dgv.CurrentRow.Cells["number_of_students"].Value.ToString();
            tMaxStudent.Text = dgv.CurrentRow.Cells["max_number_of_students"].Value.ToString();
            tStatus.Text = dgv.CurrentRow.Cells["status"].Value.ToString();
            tSection.Text = dgv.CurrentRow.Cells["section"].Value.ToString();
            tRemarks.Text = dgv.CurrentRow.Cells["remarks"].Value.ToString();
            btn_save.Text = "Update";
        }

        private void frm_sections_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                add_records();
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            add_records();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txtclear();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this section?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==
                DialogResult.Yes)
            {
                delete();
            }
        }

        private void tcourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            tSectionCode.Text += tCourse.Text.ToUpper();
            tYearLevel.Clear();
            tSection.Clear();
        }

        private void tyearlevel_TextChanged(object sender, EventArgs e)
        {
            tSectionCode.Text += "-" +tYearLevel.Text.ToUpper();
        }

        private void tsection_TextChanged(object sender, EventArgs e)
        {
            tSectionCode.Text += "-" + tSection.Text.ToUpper();
        }

        private void btnSubjects_Click(object sender, EventArgs e)
        {
            if (tRemarks.Text == "Regular")
            {
                var id = Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value);
                var frm = new frm_section_subjects(id, Email);
                frm.Text = "Section Subjects";
                frm.ShowDialog();
            }
            else if (tRemarks.Text == "Irregular")
            {

            }
        }

        private void tStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            tSectionCode.Text = tCourse.Text + "-" + tYearLevel.Text + "-" + tSection.Text;
        }

        private void tSearch_TextChanged(object sender, EventArgs e)
        {
            if (tSearch.Text.Length > 2)
            {
                var search = new sections().GetSections().Where(x => x.section_code.ToLower().Contains(tSearch.Text));
                dgv.DataSource = search;
            }
            else if (tSearch.Text.Length == 0)
            {
                loadrecords();
            }
        }

        private void tYearLevel_TextChanged_1(object sender, EventArgs e)
        {
            tSectionCode.Text = tCourse.Text + "-" + tYearLevel.Text + "-" + tSection.Text;
        }

        private void tSection_TextChanged_1(object sender, EventArgs e)
        {
            tSectionCode.Text = tCourse.Text + "-" + tYearLevel.Text + "-" + tSection.Text;
        }

        private void tSemester_TextChanged(object sender, EventArgs e)
        {
            tSectionCode.Text = tCourse.Text + "-" + tYearLevel.Text + "-" + tSection.Text;
        }

        private void tCourse_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            tSectionCode.Text = tCourse.Text + "-" + tYearLevel.Text + "-" + tSection.Text;
        }
    }
}
