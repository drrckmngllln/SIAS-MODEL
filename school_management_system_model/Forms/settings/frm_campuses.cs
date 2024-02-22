using MySql.Data.MySqlClient;
using school_management_system_model.Core.Entities;
using school_management_system_model.Data.Repositories.Setings;
using school_management_system_model.Loggers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace school_management_system_model.Forms.settings
{
    public partial class frm_campuses : Form
    {
        CampusRepository _campusRepo = new CampusRepository();
        public frm_campuses(string email)
        {
            InitializeComponent();
            Email = email;
        }

        private void frm_campuses_Load(object sender, EventArgs e)
        {
            loadrecords();
        }

        private async void loadrecords()
        {
            var campuses = await _campusRepo.GetAllAsync();
            dgv.DataSource = campuses;
            dgv.Columns["id"].Visible = false;
            dgv.Columns["code"].HeaderText = "Code";
            dgv.Columns["description"].HeaderText = "Description";
            dgv.Columns["address"].HeaderText = "Address";
            dgv.Columns["status"].HeaderText = "Status";

        }

        private async void add_records()
        {
            if (btn_save.Text == "Save")
            {
                var AddCampus = new Campuses
                {
                    code = t1.Text,
                    description = t2.Text,
                    address = t3.Text,
                    status = t4.Text
                };
                await _campusRepo.AddRecords(AddCampus);
                
                new Classes.Toastr("Success", "Campus Add Success");
                new ActivityLogger().activityLogger(Email, "Campus Add: " + t2.Text);

                loadrecords();
                txtclear();
            }
            else if (btn_save.Text == "Update")
            {
                var UpdateCampus = new Campuses
                {
                    id = Convert.ToInt32(ID), 
                    code = t1.Text,
                    description = t2.Text,
                    address = t3.Text,
                    status = t4.Text
                };
                await _campusRepo.UpdateRecords(UpdateCampus);
                
                new Classes.Toastr("Information", "Campus Update Success");
                new ActivityLogger().activityLogger(Email, "Campus Edit: " + t2.Text);

                loadrecords();
                txtclear();
            }
        }

        private void txtclear()
        {
            t1.Clear();
            t2.Clear();
            t3.Clear();
            t4.Text = "";
            t1.Select();
            btn_save.Text = "Save";
        }

        private void frm_campuses_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                add_records();
            }
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            add_records();
        }
        string ID;

        public string Email { get; }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = dgv.CurrentRow.Cells[0].Value.ToString();
            t1.Text = dgv.CurrentRow.Cells[1].Value.ToString();
            t2.Text = dgv.CurrentRow.Cells[2].Value.ToString();
            t3.Text = dgv.CurrentRow.Cells[3].Value.ToString();
            t4.Text = dgv.CurrentRow.Cells[4].Value.ToString();
            btn_save.Text = "Update";
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txtclear();
        }

        private async void delete()
        {
            var Delete = new Campuses
            {
                id = Convert.ToInt32(ID)
            };
            await _campusRepo.DeleteRecords(Delete);
            
            new Classes.Toastr("Information", "Campus Deleted");
            new ActivityLogger().activityLogger(Email, "Campus Delete: " + dgv.CurrentRow.Cells["description"].Value.ToString());

            loadrecords();
        }

        private void kryptonButton1_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("are you sure you want to delete this campus?", "warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                delete();
            }
        }
    }
}
