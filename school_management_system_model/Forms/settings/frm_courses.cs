using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto.Modes.Gcm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using school_management_system_model.Classes;
using school_management_system_model.Loggers;
using school_management_system_model.Forms.settings.TuitionFeeDummy;

namespace school_management_system_model.Forms.settings
{
    public partial class frm_courses : Form
    {
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

        private void loadDepartment()
        {
            var department = new Departments().GetDepartments();

            tDepartment.ValueMember = "id";
            tDepartment.DisplayMember = "code";
            tDepartment.DataSource = department;
        }

        private void loadCampus()
        {
            var campus = new Campuses().GetCampuses();

            tCampus.ValueMember = "id";
            tCampus.DisplayMember = "code";
            tCampus.DataSource = campus;
        }

        private void loadLevel()
        {
            var level = new Levels().GetLevels();

            tLevel.ValueMember = "id";
            tLevel.DisplayMember = "code";
            tLevel.DataSource = level;
        }

        private void loadrecords()
        {
            var courses = new Courses().GetCourses();
            dgv.DataSource = courses.ToList();
            dgv.Columns[0].Visible = false;
            dgv.Columns["code"].HeaderText = "Code";
            dgv.Columns["description"].HeaderText = "Description";
            dgv.Columns["level_id"].HeaderText = "Level";
            dgv.Columns["campus_id"].HeaderText = "Campus";
            dgv.Columns["department_id"].HeaderText = "Department";
            dgv.Columns["max_units"].HeaderText = "Max Units";
            dgv.Columns["status"].HeaderText = "Status";
        }

        private void add_records()
        {
            try
            {

                if (btn_save.Text == "Save")
                {
                    var con = new MySqlConnection(connection.con());
                    con.Open();
                    var cmd = new MySqlCommand("insert into courses(code, description, level_id, campus_id, department_id, max_units, status) " +
                        "values(@1,@2,@3,@4,@5,@6,@7)", con);
                    cmd.Parameters.AddWithValue("@1", tCode.Text);
                    cmd.Parameters.AddWithValue("@2", tDescription.Text);
                    cmd.Parameters.AddWithValue("@3", tLevel.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@4", tCampus.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@5", tDepartment.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@6", tMaxUnits.Text);
                    cmd.Parameters.AddWithValue("@7", tStatus.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    new Classes.Toastr("Success", "Add Success");
                    new ActivityLogger().activityLogger(Email, "Course Add: " + tDescription.Text);

                    loadrecords();
                    

                }
                else if (btn_save.Text == "Update")
                {
                    var con = new MySqlConnection(connection.con());
                    con.Open();
                    var cmd = new MySqlCommand("update courses set code=@1, description=@2, level=@3, campus_id=@4, department_id=@5, max_units=@6, status=@7 " +
                        "where id='" + ID + "'", con);
                    cmd.Parameters.AddWithValue("@1", tCode.Text);
                    cmd.Parameters.AddWithValue("@2", tDescription.Text);
                    cmd.Parameters.AddWithValue("@3", tLevel.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@4", tCampus.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@5", tDepartment.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@6", tMaxUnits.Text);
                    cmd.Parameters.AddWithValue("@7", tStatus.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    
                    new Classes.Toastr("Information", "Update Success");
                    new ActivityLogger().activityLogger(Email, "Course Edit: " + tDescription.Text);

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

        private void delete()
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter();
            da.SelectCommand = new MySqlCommand("delete from courses where id='" + ID + "'", con);
            var dt = new DataTable();
            da.Fill(dt);
            MessageBox.Show("Course Deleted");
            new Classes.Toastr("Information", "Course Deleted");
            new ActivityLogger().activityLogger(Email, "Course Delete: " + tDescription.Text);

            loadrecords();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("are you sure you want to delete this record","Warning!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (isDelete)
                {
                    delete();
                }
            }
        }

        private void tsearch_TextChanged(object sender, EventArgs e)
        {
            if (tsearch.Text.Length > 2)
            {
                var search = new Courses().GetCourses()
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
