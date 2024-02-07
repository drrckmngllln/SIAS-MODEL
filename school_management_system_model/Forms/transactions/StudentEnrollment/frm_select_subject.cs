using Krypton.Toolkit;
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

namespace school_management_system_model.Forms.transactions
{
    public partial class frm_select_subject : KryptonForm
    {
        public frm_select_subject()
        {
            InitializeComponent();
        }

        private void frm_select_subject_Load(object sender, EventArgs e)
        {
            loadRecords();
        }

        private void loadRecords()
        {
            tLoading.Visible = true;
            var sectionSubjects = new SectionSubjects().GetSectionSubjects();
            //var con = new MySqlConnection(connection.con());
            //var da = new MySqlDataAdapter("select * from section_subjects", con);
            //var dt = new DataTable();
            //da.Fill(dt);
            dgv.DataSource = sectionSubjects;
            tLoading.Visible = false;
            dgv.Columns["id"].Visible = false;
            dgv.Columns["unique_id"].Visible = false;
            dgv.Columns["section_code_id"].HeaderText = "Section";
            dgv.Columns["curriculum_id"].HeaderText = "Curriculum";
            dgv.Columns["course_id"].HeaderText = "Course";
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
            dgv.Columns["instructor_id"].HeaderText = "Instructor";
            dgv.Columns["instructor_id"].Width = 250;
            dgv.Columns["status"].Visible = false;
        }

        private async void searchRecords(string search)
        {
            tLoading.Visible = true;
            var searchSubjects = await new SectionSubjects().GetSectionSubjects();
                searchSubjects.Where(x => x.subject_code.ToLower().Contains(tSearch.Text) || x.descriptive_title.ToLower().Contains(tSearch.Text));
            dgv.DataSource = searchSubjects.ToList();
            tLoading.Visible = false;
            
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
                searchRecords(tSearch.Text);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                tSearch.Clear();
                tSearch.Select();
                loadRecords();
            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tTime.Text = dgv.CurrentRow.Cells["time"].Value.ToString();
            tDay.Text = dgv.CurrentRow.Cells["day"].Value.ToString();
            tRoom.Text = dgv.CurrentRow.Cells["room"].Value.ToString();
            tInstructor.Text = dgv.CurrentRow.Cells["instructor_id"].Value.ToString();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            selectSubject();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
