using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using school_management_system_model.Classes;
using school_management_system_model.Data.Repositories.Setings;
using school_management_system_model.Core.Entities;

namespace school_management_system_model.Forms.settings
{
    public partial class frm_courses : Form
    {
        CourseRepository _courseRepo = new CourseRepository();
        DepartmentRepository _departmentRepo = new DepartmentRepository();
        LevelsRepository _levelsRepo = new LevelsRepository();
        CampusRepository _campusRepo = new CampusRepository();
        public bool isAdd { get; set; }
        public bool isEdit { get; set; }
        public bool isDelete { get; set; }
        public bool isAdministrator { get; set; }
        public string Email { get; }

        string ID;



        public frm_courses(string email)
        {
            InitializeComponent();
            Email = email;
        }

        private void frm_courses_Load(object sender, EventArgs e)
        {
            loadrecords();
            loadLevel();
            loadCampus();
            loadDepartment();
        }

        private async void loadDepartment()
        {
            var department = await _departmentRepo.GetAllAsync();

            tDepartment.ValueMember = "id";
            tDepartment.DisplayMember = "code";
            tDepartment.DataSource = department;
        }

        private async void loadCampus()
        {
            var campus = await _campusRepo.GetAllAsync();

            tCampus.ValueMember = "id";
            tCampus.DisplayMember = "code";
            tCampus.DataSource = campus;
        }

        private async void loadLevel()
        {
            var level = await _levelsRepo.GetAllAsync();

            tLevel.ValueMember = "id";
            tLevel.DisplayMember = "code";
            tLevel.DataSource = level;
        }

        private async void loadrecords()
        {
            var courses = await _courseRepo.GetAllAsync();
            dgv.DataSource = courses.ToList();
            dgv.Columns[0].Visible = false;
            dgv.Columns["code"].HeaderText = "Code";
            dgv.Columns["description"].HeaderText = "Description";
            dgv.Columns["level"].HeaderText = "Level";
            dgv.Columns["campus"].HeaderText = "Campus";
            dgv.Columns["department"].HeaderText = "Department";
            dgv.Columns["max_units"].HeaderText = "Max Units";
            dgv.Columns["status"].HeaderText = "Status";
        }

        private async void add_records()
        {
            try
            {
                if (btn_save.Text == "Save")
                {
                    var AddCourses = new Courses
                    {
                        code = tCode.Text,
                        description = tDescription.Text,
                        level = tLevel.SelectedValue.ToString(),
                        campus = tCampus.SelectedValue.ToString(),
                        department = tDepartment.SelectedValue.ToString(),
                        max_units = tMaxUnits.Text,
                        status = tStatus.Text
                    };
                    await _courseRepo.AddRecords(AddCourses);
                    new Classes.Toastr("Success", "Course Added");
                    loadrecords();


                }
                else if (btn_save.Text == "Update")
                {
                    var EditCourses = new Courses
                    {
                        id = Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value),
                        code = tCode.Text,
                        description = tDescription.Text,
                        level = tLevel.SelectedValue.ToString(),
                        campus = tCampus.SelectedValue.ToString(),
                        department = tDepartment.SelectedValue.ToString(),
                        max_units = tMaxUnits.Text,
                        status = tStatus.Text
                    };
                    await _courseRepo.UpdateRecords(EditCourses);
                    new Classes.Toastr("Information", "Course Updated");
                    loadrecords();
                }
            }
            catch
            {
                new Classes.Toastr("Error", "Error, Missing Fields or Duplicate Entry");
            }

        }

        private void txtclear()
        {
            tCode.Text = "";
            tDescription.Text = "";
            tLevel.Text = "";
            tCampus.Text = "";
            tDepartment.Text = "";
            tMaxUnits.Text = "";
            tStatus.Text = "";
            tCode.Select();
            btn_save.Text = "Save";
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = dgv.CurrentRow.Cells[0].Value.ToString();
            tCode.Text = dgv.CurrentRow.Cells[1].Value.ToString();
            tDescription.Text = dgv.CurrentRow.Cells[2].Value.ToString();
            tLevel.Text = dgv.CurrentRow.Cells[3].Value.ToString();
            tCampus.Text = dgv.CurrentRow.Cells[4].Value.ToString();
            tDepartment.Text = dgv.CurrentRow.Cells[5].Value.ToString();
            tMaxUnits.Text = dgv.CurrentRow.Cells[6].Value.ToString();
            tStatus.Text = dgv.CurrentRow.Cells[7].Value.ToString();
            btn_save.Text = "Update";
        }

        private void frm_courses_KeyDown(object sender, KeyEventArgs e)
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

        private async void delete()
        {
            var delete = new Courses
            {
                id = Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value)
            };
            await _courseRepo.DeleteRecords(delete);
            new Classes.Toastr("Information", "Course Deleted");
            loadrecords();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("are you sure you want to delete this record", "Warning!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                delete();
            }
        }

        private async void tsearch_TextChanged(object sender, EventArgs e)
        {
            if (tsearch.Text.Length > 2)
            {
                var a = await _courseRepo.GetAllAsync();
                var search = a
                    .Where(x => x.code.ToLower().Contains(tsearch.Text.ToLower()) || x.description.ToLower().Contains(tsearch.Text.ToLower()))
                    .ToList();
                dgv.DataSource = search;
            }
            else if (tsearch.Text.Length == 0)
            {
                loadrecords();
            }
        }
    }
}
