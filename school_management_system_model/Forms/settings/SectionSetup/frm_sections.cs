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
            var courses = new sections();
            var data = courses.getCourses();
            foreach(DataRow row in data.Rows)
            {
                tCourse.Items.Add(row["code"]);
            }
        }

        private void loadrecords()
        {
            var data = new sections();
            dgv.DataSource = data.getSections();
            dgv.Columns["id"].Visible = false;
            dgv.Columns["unique_id"].Visible = false;
            dgv.Columns["section_code"].HeaderText = "Section Code";
            dgv.Columns["course"].HeaderText = "Course";
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
                        course = tCourse.Text,
                        year_level = tYearLevel.Text,
                        section = tSection.Text,
                        semester = tSemester.Text,
                        number_of_students = tNumberOfStudents.Text,
                        max_number_of_students = tMaxStudent.Text,
                        status = tStatus.Text,
                        remarks = tRemarks.Text
                    };
                    add.addSection();
                    
                    new Classes.Toastr().toast("Success", "Section Add Success");
                    new ActivityLogger().activityLogger(Email, "Section Add: " + tSectionCode.Text);

                    loadrecords();
                }
                else if (btn_save.Text == "Update")
                {
                    var edit = new sections
                    {
                        unique_id = tSectionCode.Text + tCourse.Text + tYearLevel.Text + tSemester.Text,
                        section_code = tSectionCode.Text,
                        course = tCourse.Text,
                        year_level = tYearLevel.Text,
                        section = tSection.Text,
                        semester = tSemester.Text,
                        number_of_students = tNumberOfStudents.Text,
                        max_number_of_students = tMaxStudent.Text,
                        status = tStatus.Text,
                        remarks = tRemarks.Text
                    };
                    edit.editSection(Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value));
                    new Classes.Toastr().toast("Information", "Section Update Success");
                    new ActivityLogger().activityLogger(Email, "Section Edit: " + tSectionCode.Text);

                    loadrecords();
                    txtclear();
                }
            }
            catch(Exception ex)
            {
                new Classes.Toastr().toast("Error", ex.Message);

            }

        }

        private void delete()
        {
            var delete = new sections
            {
                id = Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value.ToString()),
                section_code = tSectionCode.Text
            };
            delete.deleteData();
            MessageBox.Show("Section Delete Success");
            new ActivityLogger().activityLogger(Email, "Section Delete: " + tSectionCode.Text);

            loadrecords();
        }

        private void txtclear()
        {
            tSectionCode.Clear();
            tSectionCode.Clear();
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
            tCourse.Text = dgv.CurrentRow.Cells["course"].Value.ToString();
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
                var frm = new frm_section_subjects(Email);
                frm_section_subjects.instance.sectionCode = dgv.CurrentRow.Cells["section_code"].Value.ToString();
                frm_section_subjects.instance.course = dgv.CurrentRow.Cells["course"].Value.ToString();
                frm_section_subjects.instance.yearLevel = dgv.CurrentRow.Cells["year_level"].Value.ToString();
                frm_section_subjects.instance.remarks = dgv.CurrentRow.Cells["remarks"].Value.ToString();
                frm_section_subjects.instance.semester = dgv.CurrentRow.Cells["semester"].Value.ToString();
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
    }
}
