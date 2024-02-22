using MySql.Data.MySqlClient;
using school_management_system_model.Classes;
using school_management_system_model.Core.Entities;
using school_management_system_model.Data.Repositories.Setings;
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
    public partial class frm_departments : Form
    {
        DepartmentRepository _departmentRepo = new DepartmentRepository();
        CampusRepository _campusRepo = new CampusRepository();
        public frm_departments(string email)
        {
            InitializeComponent();
            Email = email;
        }

        private void frm_departments_Load(object sender, EventArgs e)
        {
            loadrecords();
            loadCampus();
        }

        private async void loadCampus()
        {
            var campus = await _campusRepo.GetAllAsync();

            tCampus.ValueMember = "id";
            tCampus.DisplayMember = "code";
            tCampus.DataSource = campus;
        }

        private async void loadrecords()
        {
            var departments = await _departmentRepo.GetAllAsync();
            dgv.DataSource = departments;
            dgv.Columns["id"].Visible = false;
            dgv.Columns["code"].HeaderText = "Code";
            dgv.Columns["description"].HeaderText = "Description";
            dgv.Columns["campus"].HeaderText = "Campus";
        }

        string ID;

        public string Email { get; }

        private async void add_records()
        {
            if (btn_save.Text == "Save")
            {
                var AddDepartment = new Departments
                {
                    code = tCode.Text,
                    description = tDescription.Text,
                    campus = tCampus.SelectedValue.ToString()
                };
                await _departmentRepo.AddRecords(AddDepartment);
                
                new Classes.Toastr("Success", "Department Added");
                new ActivityLogger().activityLogger(Email, "Department Add: " + tDescription.Text);

                loadrecords();
                txtclear();
            }
            else
            {
                var EditDepartment = new Departments
                {
                    id = Convert.ToInt32(ID),
                    code = tCode.Text,
                    description = tDescription.Text,
                    campus = tCampus.SelectedValue.ToString()
                };
                await _departmentRepo.UpdateRecords(EditDepartment);
               
                new Classes.Toastr("Information", "Department Updated");
                new ActivityLogger().activityLogger(Email, "Department Edit: " + tDescription.Text);

                loadrecords();
                txtclear();
            }
        }

        private void txtclear()
        {
            tCode.Clear();
            tDescription.Clear();
            tCampus.Text = "";
            tCode.Select();
            btn_save.Text = "Save";
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = dgv.CurrentRow.Cells[0].Value.ToString();
            tCode.Text = dgv.CurrentRow.Cells[1].Value.ToString();
            tDescription.Text = dgv.CurrentRow.Cells[2].Value.ToString();
            tCampus.Text = dgv.CurrentRow.Cells[3].Value.ToString();
            btn_save.Text = "Update";
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            add_records();
        }

        private void frm_departments_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                add_records();
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txtclear();
        }

        private async void delete()
        {
            var Delete = new Departments
            {
                id = Convert.ToInt32(ID)
            };
            await _departmentRepo.DeleteRecords(Delete);
            new Classes.Toastr("Information", "Department Deleted");
            new ActivityLogger().activityLogger(Email, "Department Delete: " + tDescription.Text);

            loadrecords();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("are you sure you want to delete record?", "warning!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                delete();
            }
        }
    }
}
