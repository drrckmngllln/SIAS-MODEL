using MySql.Data.MySqlClient;
using school_management_system_model.Classes;
using school_management_system_model.Core.Entities;
using school_management_system_model.Data.Repositories.Setings;
using school_management_system_model.Loggers;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace school_management_system_model.Forms.settings
{
    public partial class frm_curriculum : Form
    {
        CourseRepository _courseRepo = new CourseRepository();
        CurriculumRepository _curriculumRepo = new CurriculumRepository();
        string ID;

        public string Email { get; }
        

        public frm_curriculum(string email)
        {
            InitializeComponent();
            Email = email;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            tEffective.Text = dateTimePicker1.Value.ToString("dd-MM-yyyy");
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            tExpires.Text = dateTimePicker2.Value.ToString("dd-MM-yyyy");
        }

        private void frm_curriculum_Load(object sender, EventArgs e)
        {
            loadrecords();
            loadcombobox();
            loadCampus();
            loadCourse();
        }

        private async void loadCourse()
        {
            var course = await _courseRepo.GetAllAsync();

            tCourse.ValueMember = "id";
            tCourse.DisplayMember = "code";
            tCourse.DataSource = course;
        }

        private void loadCampus()
        {
            var campus = new Campuses().GetCampuses();

            tCampus.ValueMember = "id";
            tCampus.DisplayMember = "code";
            tCampus.DataSource = campus;
        }

        private void loadcombobox()
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from campuses", con);
            var dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                tCampus.Items.Add(item["code"]);
            }

            con = new MySqlConnection(connection.con());
            da = new MySqlDataAdapter("select * from courses", con);
            dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                tCourse.Items.Add(item["code"]);
            }
        }

        private async void loadrecords()
        {
            var data = await _curriculumRepo.GetAllAsync();
            dgv.DataSource = data;
            dgv.Columns["id"].Visible = false;
            dgv.Columns["code"].HeaderText = "Curriculum Code";
            dgv.Columns["description"].HeaderText = "Curriculum Description";
            dgv.Columns["description"].Width = 400;
            dgv.Columns["campus_id"].HeaderText = "Campus";
            dgv.Columns["course_id"].HeaderText = "Course";
            dgv.Columns["effective"].HeaderText = "Effective";
            dgv.Columns["expires"].HeaderText = "Expires";
            dgv.Columns["status"].HeaderText = "Status";
        }

        private async void add_records()
        {
            if (btn_save.Text == "Save")
            {
                var add = new Curriculums
                {
                    code = tCode.Text,
                    description = tDescription.Text,
                    campus_id = tCampus.SelectedValue.ToString(),
                    course_id = tCourse.SelectedValue.ToString(),
                    effective = tEffective.Text,
                    expires = tExpires.Text,
                    status = tStatus.Text
                };
                await _curriculumRepo.AddRecords(add);
                new ActivityLogger().activityLogger(Email, "Add: " + tDescription.Text);
                
                new Classes.Toastr("Success", "Curriculum Added");
                loadrecords();
                txtclear();

            }
            else if (btn_save.Text == "Update")
            {
                var edit = new Curriculums
                {
                    code = tCode.Text,
                    description = tDescription.Text,
                    campus_id = tCampus.SelectedValue.ToString(),
                    course_id = tCourse.SelectedValue.ToString(),
                    effective = tEffective.Text,
                    expires = tExpires.Text,
                    status = tStatus.Text
                };
                await _curriculumRepo.UpdateRecords(edit);

                new ActivityLogger().activityLogger(Email, "Edit: " + tDescription.Text);
                new Classes.Toastr("Information", "Curriculum Updated");

                loadrecords();
                txtclear();
            }
        }

        private void txtclear()
        {
            tCode.Text = "";
            tDescription.Text = "";
            tCampus.Text = "";
            tCourse.Text = "";
            tEffective.Text = "";
            tExpires.Text = "";
            tStatus.Text = "";
            btn_save.Text = "Save";
        }

        private async void delete()
        {
            var delete = new Curriculums();
            delete.deleteRecords(dgv.CurrentRow.Cells["id"].Value.ToString());
            await _curriculumRepo.DeleteRecords(delete);

            new Classes.Toastr("Information", "Curriculum Deleted");
            new ActivityLogger().activityLogger(Email, "Delete Curriculum: " + dgv.CurrentRow.Cells["description"].Value.ToString());
            loadrecords();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = dgv.CurrentRow.Cells[0].Value.ToString();
            tCode.Text = dgv.CurrentRow.Cells[1].Value.ToString();
            tDescription.Text = dgv.CurrentRow.Cells[2].Value.ToString();
            tCampus.Text = dgv.CurrentRow.Cells[3].Value.ToString();
            tCourse.Text = dgv.CurrentRow.Cells[4].Value.ToString();
            tEffective.Text = dgv.CurrentRow.Cells[5].Value.ToString();
            tExpires.Text = dgv.CurrentRow.Cells[6].Value.ToString();
            tStatus.Text = dgv.CurrentRow.Cells[7].Value.ToString();
            btn_save.Text = "Update";
        }

        private void frm_curriculum_KeyDown(object sender, KeyEventArgs e)
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
            if (MessageBox.Show("are you sure you want to delete record?", "Warning!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                delete();
            }
        }

        
        private void tsearch_TextChanged(object sender, EventArgs e)
        {
            if (tsearch.Text.Length > 2)
            {
                //var search = new Curriculums().GetCurriculums().Where(x => x.code.ToLower().Contains(tsearch.Text) || x.description.ToLower().Contains(tsearch.Text));
                //dgv.DataSource = search;
            }
            else if (tsearch.Text.Length == 0)
            {
                loadrecords();
            }
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            var curriculum_id = (int)dgv.CurrentRow.Cells["id"].Value;
            var frm = new frm_curriculum_subjects(Email, curriculum_id);
            frm.Text = "Curriculum Subjecs";
            frm.ShowDialog();
        }

        
    }
}
