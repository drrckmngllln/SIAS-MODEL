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
    public partial class frm_instructors : Form
    {
        public string Email { get; }

        public frm_instructors(string email)
        {
            InitializeComponent();
            Email = email;
        }

        private void frm_instructors_Load(object sender, EventArgs e)
        {
            loadRecords();
            loadDepartments();
        }

        private void loadDepartments()
        {
            var departments = new Instructors();
            var data = departments.loadDepartments();
            foreach(DataRow row in data.Rows)
            {
                tDepartment.Items.Add(row["code"]);
            }
        }

        private void loadRecords()
        {
            var data = new Instructors();
            dgv.DataSource = data.loadRecords();
            dgv.Columns["id"].Visible = false;
            dgv.Columns["fullname"].HeaderText = "Full Name";
            dgv.Columns["department"].HeaderText = "Department";
            dgv.Columns["position"].HeaderText = "Position";
        }

        private void addRecords()
        {
            if (btn_save.Text == "Save")
            {
                var data = new Instructors
                {
                    fullname = tFullname.Text,
                    department = tDepartment.Text,
                    position = tPosition.Text
                };
                data.addRecords();
          
                new Classes.Toastr("Success", "Instructor Added");
                new ActivityLogger().activityLogger(Email, "Instructor Add: " + tFullname.Text);

                loadRecords();
                txtClear();
            }
            else if (btn_save.Text == "Update")
            {
                var data = new Instructors
                {
                    id = Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value),
                    fullname = tFullname.Text,
                    department = tDepartment.Text,
                    position = tPosition.Text
                };
                data.editRecords();
               
                new Classes.Toastr("Information", "Instructor Updated");
                new ActivityLogger().activityLogger(Email, "Instructor Edit: " + tFullname.Text);

                loadRecords();
                txtClear();
            }
        }

        private void txtClear()
        {
            tFullname.Clear();
            tDepartment.Text = "";
            tPosition.Clear();
            btn_save.Text = "Save";
        }

        private void deleteRecords()
        {
            var delete = new Instructors
            {
                id = Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value.ToString())
            };
            delete.deleteRecords();
            
            new Classes.Toastr("Information", "Instructor Deleted");
            new ActivityLogger().activityLogger(Email, "Instructor Delete: " + dgv.CurrentRow.Cells["fullname"].Value.ToString());

            loadRecords();
        }

        private void searchRecords()
        {
            if (tsearch.Text.Length > 2)
            {
                var search = new Instructors
                {
                    search = tsearch.Text
                };
                dgv.DataSource = search.searchRecords();
            }
            else if (tsearch.Text.Length == 0)
            {
                loadRecords();
            }
        }

        private void frm_instructors_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                addRecords();
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            addRecords();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txtClear();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("are you sure you want to delete this instructor?", "Warning" , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                deleteRecords();
            }
        }

        private void tsearch_TextChanged(object sender, EventArgs e)
        {
            searchRecords();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tFullname.Text = dgv.CurrentRow.Cells["fullname"].Value.ToString();
            tDepartment.Text = dgv.CurrentRow.Cells["department"].Value.ToString();
            tPosition.Text = dgv.CurrentRow.Cells["position"].Value.ToString();
            btn_save.Text = "Update";
        }
    }
}
