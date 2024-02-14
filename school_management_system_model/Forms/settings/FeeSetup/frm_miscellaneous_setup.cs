using school_management_system_model.Classes;
using school_management_system_model.Core.Entities.Settings;
using school_management_system_model.Data.Repositories.Setings;
using school_management_system_model.Loggers;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace school_management_system_model.Forms.settings
{
    public partial class frm_miscellaneous_setup : Form
    {
        LevelsRepository _levelRepo = new LevelsRepository();
        CampusRepository _campusRepo = new CampusRepository();
        MiscFeeRepository _miscFeeRepo = new MiscFeeRepository();

        public static frm_miscellaneous_setup instance;
        public string ID { get; set; }
        public string Email { get; }

        public frm_miscellaneous_setup(string email)
        {
            instance = this;
            InitializeComponent();
            Email = email;
        }

        private void frm_fees_Load(object sender, EventArgs e)
        {
            loadCampuses();
            loadLevels();
            loadRecords(tCampus.Text, tLevel.Text, tYearLevel.Text);
        }

        private async void loadLevels()
        {
            var level = await _levelRepo.GetAllAsync();
            tLevel.ValueMember = "id";
            tLevel.DisplayMember = "code";
            tLevel.DataSource = level;
        }

        private async void loadCampuses()
        {
            var campus = await _campusRepo.GetAllAsync();
            tCampus.ValueMember = "id";
            tCampus.DisplayMember = "code";
            tCampus.DataSource = campus;
        }

        private async void loadRecords(string campus, string level, string yearLevel)
        {
            var a = await _miscFeeRepo.GetAllAsync();
            var misc = a
                .Where(x => x.campus == campus && x.level == level && x.year_level == yearLevel)
                .ToList();
            dgv.DataSource = misc;
            dgv.Columns["id"].Visible = false;
            dgv.Columns["uid"].Visible = false;
            dgv.Columns["category"].HeaderText = "Category";
            dgv.Columns["description"].HeaderText = "Description";
            dgv.Columns["description"].Width = 250;
            dgv.Columns["campus"].HeaderText = "Campus";
            dgv.Columns["level"].HeaderText = "Level";
            dgv.Columns["year_level"].HeaderText = "Year Level";
            dgv.Columns["semester"].HeaderText = "Semester";
            dgv.Columns["amount"].HeaderText = "Amount";
        }   

        private async void addRecords()
        {
            if (btn_save.Text == "Save")
            {
                var AddRecords = new MiscellaneousFee
                {
                    uid = tCategory.Text + tCampus.SelectedValue.ToString() + tDescription.Text + tLevel.SelectedValue.ToString() + tYearLevel.Text + tSemester.Text,
                    category = tCategory.Text,
                    description = tDescription.Text,
                    campus = tCampus.SelectedValue.ToString(),
                    level = tLevel.SelectedValue.ToString(),
                    year_level = tYearLevel.Text,
                    semester = tSemester.Text,
                    amount = Convert.ToDecimal(tAmount.Text),
                };
                await _miscFeeRepo.AddRecords(AddRecords);
                new Classes.Toastr("Success", "Miscellaneous fee Added");
                new ActivityLogger().activityLogger(Email, "Misc Fee Setup Add: " + tCategory.Text);
                loadRecords(tCampus.Text, tLevel.Text, tYearLevel.Text);
                
            }
            else if (btn_save.Text == "Update")
            {
                var editRecords = new MiscellaneousFee
                {
                    id = Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value),
                    uid = tCategory.Text + tCampus.SelectedValue.ToString() + tDescription.Text + tLevel.SelectedValue.ToString() + tYearLevel.Text + tSemester.Text,
                    category = tCategory.Text,
                    description = tDescription.Text,
                    campus = tCampus.SelectedValue.ToString(),
                    level = tLevel.SelectedValue.ToString(),
                    year_level = tYearLevel.Text,
                    semester = tSemester.Text,
                    amount = Convert.ToDecimal(tAmount.Text),
                };
                await _miscFeeRepo.UpdateRecords(editRecords);
                new Classes.Toastr("Success", "Miscellaneous fee Added");
                new ActivityLogger().activityLogger(Email, "Misc Fee Setup Add: " + tCategory.Text);
                loadRecords(tCampus.Text, tLevel.Text, tYearLevel.Text);
            }
        }

        private void txtClear()
        {
            tDescription.Clear();
            tSemester.Clear();
            tAmount.Clear();
            btn_save.Text = "Save";
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            addRecords();
        }

        private async void deleteRecords(int id)
        {
            var delete = new MiscellaneousFee();
            delete.id = id;
            await _miscFeeRepo.DeleteRecords(delete);
        }

        private async void searchRecords(string search)
        {
            var miscFees = await _miscFeeRepo.GetAllAsync();
            var searchFee = miscFees
                .Where(x => x.category.ToLower().Contains(search) || x.description.ToLower().Contains(search))
                .ToList();
            dgv.DataSource = searchFee;
        }

       
        private void btn_clear_Click(object sender, EventArgs e)
        {
            txtClear();
        }

        
        private void btn_save_Click_1(object sender, EventArgs e)
        {
            addRecords();
        }

        private void btn_clear_Click_1(object sender, EventArgs e)
        {
            txtClear();
        }

        private void frm_miscellaneous_setup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                addRecords();
            }
        }

        private void kryptonButton1_Click_2(object sender, EventArgs e)
        {
            if (MessageBox.Show("are you sure you want to delete this record?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                DialogResult.Yes)
            {
                deleteRecords(Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value));
               
            }
        }

        private void dgv_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            ID = dgv.CurrentRow.Cells["id"].Value.ToString();
            tCategory.Text = dgv.CurrentRow.Cells["category"].Value.ToString();
            tDescription.Text = dgv.CurrentRow.Cells["description"].Value.ToString();
            tCampus.Text = dgv.CurrentRow.Cells["campus"].Value.ToString();
            tYearLevel.Text = dgv.CurrentRow.Cells["year_level"].Value.ToString();
            tLevel.Text = dgv.CurrentRow.Cells["level"].Value.ToString();
            tSemester.Text = dgv.CurrentRow.Cells["semester"].Value.ToString();
            tAmount.Text = dgv.CurrentRow.Cells["amount"].Value.ToString();
            
            btn_save.Text = "Update";
        }

        private void tsearch_TextChanged_1(object sender, EventArgs e)
        {
            if (tsearch.Text.Length > 2)
            {
                searchRecords(tsearch.Text);
            }
            else if (tsearch.Text.Length == 0)
            {
                loadRecords(tCampus.Text, tLevel.Text, tYearLevel.Text);
            }
        }

        private void tCampus_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadRecords(tCampus.Text, tLevel.Text, tYearLevel.Text);
        }

        private void tLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadRecords(tCampus.Text, tLevel.Text, tYearLevel.Text);
        }

        private void tYearLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadRecords(tCampus.Text, tLevel.Text, tYearLevel.Text);
        }
    }
}
