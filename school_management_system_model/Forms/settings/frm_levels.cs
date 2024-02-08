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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace school_management_system_model.Forms.settings
{
    public partial class frm_levels : Form
    {
        LevelsRepository _levelRepo = new LevelsRepository();
        string ID;

        public string Email { get; }

        public frm_levels(string email)
        {
            InitializeComponent();
            Email = email;
        }

        private void frm_levels_Load(object sender, EventArgs e)
        {
            loadrecords();
        }

        private async void loadrecords()
        {
            var levels = await _levelRepo.GetAllAsync();
            dgv.DataSource = levels;
            dgv.Columns["id"].Visible = false;
            dgv.Columns["code"].HeaderText = "Code";
            dgv.Columns["description"].HeaderText = "Description";
            dgv.Columns["status"].HeaderText = "Status";
        }

        private async void add_records()
        {
            if (btn_save.Text == "Save")
            {
                var AddLevel = new Levels
                {
                    code = tCode.Text,
                    description = tDescription.Text,
                    status = tStatus.Text,
                };
                await _levelRepo.AddRecords(AddLevel);

                new Classes.Toastr("Success", "Level Added");
                new ActivityLogger().activityLogger(Email, "Level Add: " + tDescription.Text);

                loadrecords();
                txtclear();

            }
            else if (btn_save.Text == "Update")
            {
                var UpdateLevel = new Levels
                {
                    id = Convert.ToInt32(ID),
                    code = tCode.Text,
                    description = tDescription.Text,
                    status = tStatus.Text,
                };
                await _levelRepo.UpdateRecords(UpdateLevel);
             
                new Classes.Toastr("Information", "Level Updated");
                new ActivityLogger().activityLogger(Email, "Level Edit: " + tDescription.Text);

                loadrecords();
                txtclear();
            }
        }

        private async void delete()
        {
            var Delete = new Levels
            {
                id = Convert.ToInt32(ID)
            };
            await _levelRepo.DeleteRecords(Delete);
            
            new Classes.Toastr("Information", "Level Deleted");
            new ActivityLogger().activityLogger(Email, "Level Delete: " + dgv.CurrentRow.Cells["description"].Value.ToString());

            loadrecords();
        }

        private void txtclear()
        {
            tCode.Clear();
            tDescription.Clear();
            tStatus.Text = "";
            tCode.Select();
            btn_save.Text = "Save";
        }
        
        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = dgv.CurrentRow.Cells[0].Value.ToString();
            tCode.Text = dgv.CurrentRow.Cells[1].Value.ToString();
            tDescription.Text = dgv.CurrentRow.Cells[2].Value.ToString();
            tStatus.Text = dgv.CurrentRow.Cells[3].Value.ToString();
            btn_save.Text = "Update";
        }

        private void frm_levels_KeyDown(object sender, KeyEventArgs e)
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
            delete();
        }
    }
}
