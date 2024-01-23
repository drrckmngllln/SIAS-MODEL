using Krypton.Toolkit;
using MySql.Data.MySqlClient;
using school_management_system_model.Classes;
using school_management_system_model.Forms.settings.Curriculum;
using school_management_system_model.Loggers;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace school_management_system_model.Forms.settings
{
    public partial class frm_curriculum_subjects : KryptonForm
    {
        public int CurriculumId { get; set; }
        private string id { get; set; }
        public string Email { get; }

        public static frm_curriculum_subjects instance;
        public frm_curriculum_subjects(string email, int curriculum_id)
        {
            instance = this;
            InitializeComponent();
            Email = email;
            CurriculumId = curriculum_id;
        }

        private void frm_curriculum_subjects_Load(object sender, EventArgs e)
        {
            loadrecords();
        }

        private void loadrecords()
        {
            var curriculumSubjects = new CurriculumSubjects().GetCurriculumSubjects().Where(x => x.curriculum_id == CurriculumId).ToList();
            dgv.DataSource = curriculumSubjects;


            dgv.Columns["id"].Visible = false;
            dgv.Columns["uid"].Visible = false;
            dgv.Columns["curriculum_id"].Visible = false;
            dgv.Columns["year_level"].HeaderText = "Year Level";
            dgv.Columns["semester"].HeaderText = "Semester";
            dgv.Columns["code"].HeaderText = "Code";
            dgv.Columns["descriptive_title"].HeaderText = "Descriptive Tittle";
            dgv.Columns["descriptive_title"].Width = 300;
            dgv.Columns["total_units"].HeaderText = "Total Units";
            dgv.Columns["lecture_units"].HeaderText = "Lecture Units";
            dgv.Columns["lab_units"].HeaderText = "Lab Units";
            dgv.Columns["pre_requisite"].HeaderText = "Pre Requisite";
            dgv.Columns["total_hrs_per_week"].HeaderText = "Total Hours Per Week";


            var curriculums = new Curriculums().GetCurriculums().FirstOrDefault(x => x.id == CurriculumId);
            //var campus = new Campuses().GetCampuses().FirstOrDefault(x => x.id == curriculums.id);
            //var course = new Courses().GetCourses().FirstOrDefault(x => x.id == curriculums.id);
            tcode.Text = curriculums.code;
            tdescription.Text = curriculums.description;
            tcampus.Text = curriculums.campus_id;
            tcourse.Text = curriculums.course_id;
            teffective.Text = curriculums.effective;
            texpires.Text = curriculums.expires;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            //var frm = new frm_add_curriculum_subjects();
            //frm.Text = "Add Subjects";
            //frm_add_curriculum_subjects.instance.curriculum = Curriculum;
            //frm.ShowDialog();
            //loadrecords();
        }
        
        private void delete()
        {
            //var con = new MySqlConnection(connection.con());
            //var da = new MySqlDataAdapter();
            //da.SelectCommand = new MySqlCommand("delete from curriculum_subjects where id='" + ID + "'", con);
            //var dt = new DataTable();
            //da.Fill(dt);
        }
        private void deleteAll(string curriculum)
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter();
            da.SelectCommand = new MySqlCommand("delete from curriculum_subjects where curriculum='" + curriculum + "'", con);
            var dt = new DataTable();
            da.Fill(dt);
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("are you sure you want to delete subject?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                DialogResult.Yes)
            {
                delete();
                new Classes.Toastr("Information", "Curriculum Subject Deleted");
                new ActivityLogger().activityLogger(Email, "Curriculum Subject Delete: " + dgv.CurrentRow.Cells["descriptive_title"].Value.ToString());
                loadrecords();
            }
        }

        private void dgv_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            id = dgv.CurrentRow.Cells["id"].Value.ToString();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            var frm = new frm_curriculum_subjects_excel_import(Email);
            frm_curriculum_subjects_excel_import.instance.curriculum = tcode.Text;
            frm.Text = "Excel Import - Curriculum Subjects";
            frm.ShowDialog();
            loadrecords();
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("are you sure you want to delete all subjects in this curriculum?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
               DialogResult.Yes)
            {
                deleteAll(tcode.Text);
                MessageBox.Show("Curriculum Subject Deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                new Classes.Toastr("Information", "Curriculum Subject Deleted");
                new ActivityLogger().activityLogger(Email, "Deleted All Curriculum: " + tdescription.Text);
                loadrecords();
            }
        }

        private DataTable onSearch(string search)
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from curriculum_subjects where concat(curriculum, code, descriptive_title) like '%" + search + "%'", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        private void tsearch_TextChanged(object sender, EventArgs e)
        {
            if (tsearch.Text.Length > 2)
            {
                dgv.DataSource = onSearch(tsearch.Text);
            }
            else if (tsearch.Text.Length == 0)
            {
                loadrecords();
            }
        }
    }
}
