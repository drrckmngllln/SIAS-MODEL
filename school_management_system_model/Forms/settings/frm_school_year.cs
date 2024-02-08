using school_management_system_model.Classes;
using school_management_system_model.Core.Entities;
using school_management_system_model.Data.Repositories.Setings;
using school_management_system_model.Loggers;
using System;
using System.Windows.Forms;

namespace school_management_system_model.Forms.settings
{
    public partial class frm_school_year : Form
    {
        SchoolYearRepository _schoolYearRepo = new SchoolYearRepository();
        public bool isAdd { get; set; }
        public bool isEdit { get; set; }
        public bool isDelete { get; set; }
        public bool isAdministrator { get; set; }
        public string Email { get; }

        public frm_school_year(string email)
        {
            InitializeComponent();
            Email = email;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            tFrom.Text = dateTimePicker1.Value.ToString("MM-dd-yyyy");
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            tTo.Text = dateTimePicker2.Value.ToString("MM-dd-yyyy");
        }

        private void frm_school_year_Load(object sender, EventArgs e)
        {
            loadRecords();
        }

        private async void loadRecords()
        {
            var data = await _schoolYearRepo.GetAllAsync();
            dgv.DataSource = data;
            dgv.Columns["id"].Visible = false;
            dgv.Columns["code"].HeaderText = "Code";
            dgv.Columns["description"].HeaderText = "Description";
            dgv.Columns["description"].Width = 300;
            dgv.Columns["school_year_from"].HeaderText = "From";
            dgv.Columns["school_year_to"].HeaderText = "To";
            dgv.Columns["semester"].HeaderText = "Semester";
            dgv.Columns["is_current"].HeaderText = "Default";
        }

        private async void addRecords()
        {
            try
            {
                if (btn_save.Text == "Save")
                {
                    var add = new SchoolYear
                    {
                        code = tCode.Text,
                        description = tDescription.Text,
                        school_year_from = tFrom.Text,
                        school_year_to = tTo.Text,
                        semester = tSemester.Text,
                        is_current = tCurrent.Text
                    };
                    await _schoolYearRepo.AddRecords(add);
                    new Classes.Toastr("Success", "Successfully Saved");
                    new ActivityLogger().activityLogger(Email, "School Year Add: " + tDescription.Text);

                    loadRecords();
                    txtClear();
                    
                }
                else if (btn_save.Text == "Update")
                {
                    int id = Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value);
                    var edit = new SchoolYear
                    {
                        code = tCode.Text,
                        description = tDescription.Text,
                        school_year_from = tFrom.Text,
                        school_year_to = tTo.Text,
                        semester = tSemester.Text,
                        is_current = tCurrent.Text
                    };
                    await _schoolYearRepo.UpdateRecords(edit);
                    new Classes.Toastr("Information", "Successfully Updated");
                    new ActivityLogger().activityLogger(Email, "School Year Edit: " + tDescription.Text);

                    loadRecords();
                    txtClear();
                    
                }
            }
            catch(Exception ex)
            {
                new Classes.Toastr("Error", ex.Message);
            }
        }
        private void txtClear()
        {
            tCode.Clear();
            tDescription.Clear();
            tFrom.Clear();
            tTo.Clear();
            tSemester.Clear();
            btn_save.Text = "Save";
        }
        private void deleteRecords()
        {
            int id = Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value);
            var delete = new SchoolYearSetup();
            delete.deleteRecords(id);
            
            new Classes.Toastr("Information", "Successfully Deleted");
            new ActivityLogger().activityLogger(Email, "School Year Delete: " + dgv.CurrentRow.Cells["description"].Value.ToString());

            loadRecords();
        }

        private void frm_school_year_KeyDown(object sender, KeyEventArgs e)
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

        private void dgv_Click(object sender, EventArgs e)
        {
            tCode.Text = dgv.CurrentRow.Cells["code"].Value.ToString();
            tDescription.Text = dgv.CurrentRow.Cells["description"].Value.ToString();
            tFrom.Text = dgv.CurrentRow.Cells["school_year_from"].Value.ToString();
            tTo.Text = dgv.CurrentRow.Cells["school_year_to"].Value.ToString();
            tSemester.Text = dgv.CurrentRow.Cells["semester"].Value.ToString();
            btn_save.Text = "Update";
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("are you sure you want to delete records?", "Warning", MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                deleteRecords();
            }
        }

        private void tsearch_TextChanged(object sender, EventArgs e)
        {
            if (tsearch.Text.Length > 2)
            {
                var search = new SchoolYearSetup();
                dgv.DataSource = search.searchRecords(tsearch.Text);
            }
            else if (tsearch.Text.Length == 0)
            {
                loadRecords();
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txtClear();
        }
    }
}
