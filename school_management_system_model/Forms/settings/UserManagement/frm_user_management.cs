﻿using System;
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
        int add, edit, delete = 0;
        public frm_user_management()
        {
            InitializeComponent();
        }

        private void frm_user_management_Load(object sender, EventArgs e)
        {
            loadRecords();
        }

        private void loadRecords()
        {
            dgv.DataSource = new Classes.UserManagement().loadRecords();
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
            dgv.Columns["is_add"].HeaderText = "Add Authorization";
            dgv.Columns["is_edit"].HeaderText = "Edit Authorization";
            dgv.Columns["is_delete"].HeaderText = "Delete Authorization";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length > 2)
            {
                dgv.DataSource = new Classes.UserManagement().searchRecords(txtSearch.Text);
            }
            else if (txtSearch.Text.Length == 0)
            {
                loadRecords();
            }
        }

        private void addUser()
        {
            try
            {
                if (btn_save.Text == "Save")
                {
                    var password = BCrypt.Net.BCrypt.HashPassword(tPassword.Text);

                    var addUser = new Classes.UserManagement
                    {
                        last_name = tLastname.Text,
                        first_name = tFirstname.Text,
                        middle_name = tMiddlename.Text,
                        fullname = tLastname.Text + ", " + tFirstname.Text + " " + tMiddlename.Text,
                        employee_id = tEmployeeId.Text,
                        email = tEmail.Text,
                        password = password,
                        access_level = tAccessLevel.Text,
                        add = add,
                        edit = edit,
                        delete = delete
                    };
                    addUser.addUser();
                    new Classes.Toastr().toast("Success", "User Successfully Saved");
                    loadRecords();
                    txtclear();
                }
                else if (btn_save.Text == "Update")
                {
                    int id = Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value);
                    var password = BCrypt.Net.BCrypt.HashPassword(tPassword.Text);

                    var addUser = new Classes.UserManagement
                    {
                        last_name = tLastname.Text,
                        first_name = tFirstname.Text,
                        middle_name = tMiddlename.Text,
                        fullname = tLastname.Text + ", " + tFirstname.Text + " " + tMiddlename.Text,
                        employee_id = tEmployeeId.Text,
                        email = tEmail.Text,
                        password = password,
                        access_level = tAccessLevel.Text,
                        add = add,
                        edit = edit,
                        delete = delete
                    };
                    addUser.editUser(id);
                    new Classes.Toastr().toast("Information", "User Successfully Updated");
                    loadRecords();
                    txtclear();
                }
            }
            catch(Exception ex)
            {
                new Classes.Toastr().toast("Error", ex.Message);
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
            else {  delete = 0; }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string fullname = dgv.CurrentRow.Cells["fullname"].Value.ToString();
            string[] name = fullname.Split(' ',',');
            tLastname.Text = dgv.CurrentRow.Cells["last_name"].Value.ToString();
            tFirstname.Text = dgv.CurrentRow.Cells["first_name"].Value.ToString();
            tMiddlename.Text = dgv.CurrentRow.Cells["middle_name"].Value.ToString();
            tEmployeeId.Text = dgv.CurrentRow.Cells["employee_id"].Value.ToString(); 
            tEmail.Text = dgv.CurrentRow.Cells["employee_id"].Value.ToString(); 
            tAccessLevel.Text = dgv.CurrentRow.Cells["access_level"].Value.ToString();
            if (Convert.ToBoolean(dgv.CurrentRow.Cells["is_add"].Value))
            {
                cAdd.Checked = true;
            }else { cAdd.Checked = false; }

            if (Convert.ToBoolean(dgv.CurrentRow.Cells["is_edit"].Value))
            {
                cEdit.Checked = true;
            }else { cEdit.Checked = false; }
            
            if (Convert.ToBoolean(dgv.CurrentRow.Cells["is_delete"].Value))
            {
                cDelete.Checked = true;
            }else { cDelete.Checked = false; }

            btn_save.Text = "Update";
            
            
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txtclear();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete user?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var delete = new Classes.UserManagement();
                delete.deleteUser(Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value));
                new Classes.Toastr().toast("Success", "User Deleted Successfully");
                loadRecords();
                txtclear();
            }
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
