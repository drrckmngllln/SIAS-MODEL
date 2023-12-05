using MySql.Data.MySqlClient;
using school_management_system_model.Classes;
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
        public frm_sections()
        {
            InitializeComponent();
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
                tcourse.Items.Add(row["code"]);
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
                        unique_id = tsectioncode.Text + tcourse.Text + tyearlevel.Text + tSemester.Text,
                        section_code = tsectioncode.Text,
                        course = tcourse.Text,
                        year_level = tyearlevel.Text,
                        section = tsection.Text,
                        semester = tSemester.Text,
                        number_of_students = tnumberofstudents.Text,
                        max_number_of_students = tmaxstudents.Text,
                        status = tstatus.Text,
                        remarks = tRemarks.Text
                    };
                    add.addSection();
                    MessageBox.Show("Section Add Success", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadrecords();
                }
                else if (btn_save.Text == "Update")
                {
                    var edit = new sections
                    {
                        id = Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value.ToString()),
                        section_code = tsectioncode.Text,
                        course = tcourse.Text,
                        year_level = tyearlevel.Text,
                        section = tsection.Text,
                        semester = tSemester.Text,
                        number_of_students = tnumberofstudents.Text,
                        max_number_of_students = tmaxstudents.Text,
                        status = tstatus.Text,
                        remarks = tRemarks.Text
                    };
                    edit.editSection();
                    MessageBox.Show("Section Update Success");
                    loadrecords();
                    txtclear();
                }
            }
            catch
            {
                MessageBox.Show("Error, Duplicate Entry","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void delete()
        {
            var delete = new sections
            {
                id = Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value.ToString()),
                section_code = tsectioncode.Text
            };
            delete.deleteData();
            MessageBox.Show("Section Delete Success");
            loadrecords();
        }

        private void txtclear()
        {
            tsectioncode.Clear();
            tsectioncode.Clear();
            tyearlevel.Clear();
            tsection.Clear();
            tcourse.Text = "";
            tnumberofstudents.Text = "0";
            tmaxstudents.Text = "50";
            tstatus.Text = "";
            tsectioncode.Select();
            btn_save.Text = "Save";
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = dgv.CurrentRow.Cells[0].Value.ToString();
            tsectioncode.Text = dgv.CurrentRow.Cells["section_code"].Value.ToString();
            tyearlevel.Text = dgv.CurrentRow.Cells["year_level"].Value.ToString();
            tcourse.Text = dgv.CurrentRow.Cells["course"].Value.ToString();
            tSemester.Text = dgv.CurrentRow.Cells["semester"].Value.ToString();
            tnumberofstudents.Text = dgv.CurrentRow.Cells["number_of_students"].Value.ToString();
            tmaxstudents.Text = dgv.CurrentRow.Cells["max_number_of_students"].Value.ToString();
            tstatus.Text = dgv.CurrentRow.Cells["status"].Value.ToString();
            tsection.Text = dgv.CurrentRow.Cells["section"].Value.ToString();
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
            
            tsectioncode.Text += tcourse.Text.ToUpper();
            tyearlevel.Clear();
            tsection.Clear();
        }

        private void tyearlevel_TextChanged(object sender, EventArgs e)
        {
            tsectioncode.Text += "-" +tyearlevel.Text.ToUpper();
        }

        private void tsection_TextChanged(object sender, EventArgs e)
        {
            tsectioncode.Text += "-" + tsection.Text.ToUpper();
        }

        private void btnSubjects_Click(object sender, EventArgs e)
        {
            if (tRemarks.Text == "Regular")
            {
                var frm = new frm_section_subjects();
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
    }
}
