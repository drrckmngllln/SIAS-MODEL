using school_management_system_model.Core.Entities.Settings;
using school_management_system_model.Data.Repositories.Setings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace school_management_system_model.Forms.settings.UserManagement
{
    public partial class frm_user_management : Form
    {
        UserRepository _userRepo = new UserRepository();

        int add, edit, delete, administrator = 0;

        public string Office { get; }

        public frm_user_management(string office)
        {
            InitializeComponent();
            Office = office;
        }

        

        private async Task UserQuery()
        {
            var query = await _userRepo.GetAllAsync();
        }

        private void frm_user_management_Load(object sender, EventArgs e)
        {
            loadRecords();
        }

        private async void loadRecords()
        {
            var a = await _userRepo.GetAllAsync();
            var users = a
            .Where(x => x.department == Office).ToList();
            dgv.DataSource = users;
            dgv.Columns["id"].Visible = false;
            dgv.Columns["last_name"].Visible = false;
            dgv.Columns["first_name"].Visible = false;
            dgv.Columns["middle_name"].Visible = false;
            dgv.Columns["fullname"].HeaderText = "Name";
            dgv.Columns["fullname"].Width = 350;
            dgv.Columns["employee_id"].HeaderText = "ID Number";
            dgv.Columns["email"].HeaderText = "Email Address";
            dgv.Columns["password"].Visible = false;
            dgv.Columns["access_level"].HeaderText = "Access Level";
            dgv.Columns["department"].HeaderText = "Department";
            dgv.Columns["add"].Visible = false;
            dgv.Columns["edit"].Visible = false;
            dgv.Columns["delete"].Visible = false;
            dgv.Columns["administrator"].Visible = false;
        }

        private async void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length > 2)
            {
                var a = await _userRepo.GetAllAsync();
                var search = a.Where(x => x.fullname.ToLower().Contains(txtSearch.Text.ToLower()));
                dgv.DataSource = search;
            }
            else if (txtSearch.Text.Length == 0)
            {
                loadRecords();
            }
        }

        private async void addUser()
        {
            try
            {
                if (btn_save.Text == "Save")
                {
                    var password = BCrypt.Net.BCrypt.HashPassword(tPassword.Text);

                    var addUser = new User
                    {
                        last_name = tLastname.Text,
                        first_name = tFirstname.Text,
                        middle_name = tMiddlename.Text,
                        fullname = tLastname.Text + ", " + tFirstname.Text + " " + tMiddlename.Text,
                        employee_id = tEmployeeId.Text,
                        email = tEmail.Text,
                        password = password,
                        access_level = tAccessLevel.Text,
                        department = tDepartment.Text,
                        add = add,
                        edit = edit,
                        delete = delete,
                        administrator = administrator
                    };
                    await _userRepo.AddRecords(addUser);
                    new Classes.Toastr("Success", "User Successfully Saved");
                    loadRecords();
                    txtclear();
                }
                else if (btn_save.Text == "Update")
                {
                    int id = Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value);
                    var password = BCrypt.Net.BCrypt.HashPassword(tPassword.Text);

                    var EditUser = new User
                    {
                        last_name = tLastname.Text,
                        first_name = tFirstname.Text,
                        middle_name = tMiddlename.Text,
                        fullname = tLastname.Text + ", " + tFirstname.Text + " " + tMiddlename.Text,
                        employee_id = tEmployeeId.Text,
                        email = tEmail.Text,
                        password = password,
                        access_level = tAccessLevel.Text,
                        department = tDepartment.Text,
                        add = add,
                        edit = edit,
                        delete = delete,
                        administrator = administrator
                    };
                    await _userRepo.UpdateRecords(EditUser);
                    new Classes.Toastr("Information", "User Successfully Updated");
                    loadRecords();
                    txtclear();
                }
            }
            catch (Exception ex)
            {
                new Classes.Toastr("Error", ex.Message);
            }

        }

        private void cAdd_CheckedChanged(object sender, EventArgs e)
        {
            if (cAdd.Checked)
            {
                add = 1;
            }
            else { add = 0; }
        }

        private void cEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (cEdit.Checked)
            {
                edit = 1;
            }
            else
            {
                edit = 0;
            }
        }

        private void cDelete_CheckedChanged(object sender, EventArgs e)
        {
            if (cDelete.Checked)
            {
                delete = 1;
            }
            else { delete = 0; }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tLastname.Text = dgv.CurrentRow.Cells["last_name"].Value.ToString();
            tFirstname.Text = dgv.CurrentRow.Cells["first_name"].Value.ToString();
            tMiddlename.Text = dgv.CurrentRow.Cells["middle_name"].Value.ToString();
            tEmployeeId.Text = dgv.CurrentRow.Cells["employee_id"].Value.ToString();
            tEmail.Text = dgv.CurrentRow.Cells["email"].Value.ToString();
            tAccessLevel.Text = dgv.CurrentRow.Cells["access_level"].Value.ToString();
            tDepartment.Text = dgv.CurrentRow.Cells["department"].Value.ToString();
            if (Convert.ToBoolean(dgv.CurrentRow.Cells["add"].Value))
            {
                cAdd.Checked = true;
            }
            else { cAdd.Checked = false; }

            if (Convert.ToBoolean(dgv.CurrentRow.Cells["edit"].Value))
            {
                cEdit.Checked = true;
            }
            else { cEdit.Checked = false; }

            if (Convert.ToBoolean(dgv.CurrentRow.Cells["delete"].Value))
            {
                cDelete.Checked = true;
            }
            else { cDelete.Checked = false; }

            if (Convert.ToBoolean(dgv.CurrentRow.Cells["administrator"].Value))
            {
                cAdministrator.Checked = true;
            }
            else { cAdministrator.Checked = false; }

            btn_save.Text = "Update";


        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txtclear();
        }

        private async void kryptonButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete user?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var delete = new User();
                delete.id = Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value);
                await _userRepo.DeleteRecords(delete);
                new Classes.Toastr("Success", "User Deleted Successfully");
                loadRecords();
                txtclear();
            }
        }

        private void tAccessLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tAccessLevel.Text == "Administrator")
            {
                cAdministrator.Checked = true;
                cAdd.Checked = true;
                cDelete.Checked = true;
                cEdit.Checked = true;
            }
            else if (tAccessLevel.Text == "User")
            {
                cAdministrator.Checked = false;
                cAdministrator.Enabled = false;
                cAdd.Checked = false;
                cDelete.Checked = false;
                cDelete.Enabled = false;
                cEdit.Checked = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                tPassword.UseSystemPasswordChar = false;
                tPassword.PasswordChar = '\0';
            }
            else if (!checkBox1.Checked)
            {
                tPassword.UseSystemPasswordChar = true;
                tPassword.PasswordChar = '\0';
            }
        }

        private void cAdministrator_CheckedChanged(object sender, EventArgs e)
        {
            if (cAdministrator.Checked)
            {
                administrator = 1;
            }
            else { administrator = 0; }
        }

        private void txtclear()
        {
            tLastname.Clear();
            tFirstname.Clear();
            tMiddlename.Clear();
            tEmployeeId.Clear();
            tEmail.Clear();
            tPassword.Clear();
            cAdd.Checked = false;
            cEdit.Checked = false;
            cDelete.Checked = false;
            tEmployeeId.Select();
            btn_save.Text = "Save";
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            addUser();
        }
    }
}
