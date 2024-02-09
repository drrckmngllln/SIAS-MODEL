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
    public partial class frm_tuition_fee : Form
    {
        LevelsRepository _levelRepo = new LevelsRepository();
        CampusRepository _campusRepo = new CampusRepository();
        TuitionFeeRepository _tuitionFeeRepo = new TuitionFeeRepository();
        public string Email { get; }

        public frm_tuition_fee(string email)
        {
            InitializeComponent();
            Email = email;
        }

        private void frm_tuition_fee_Load(object sender, System.EventArgs e)
        {
            loadCampuses();
            loadLevel();
            loadRecords(tCampus.Text, tLevel.Text, tYearLevel.Text, tSemester.Text);
        }

        private async void loadLevel()
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

        private async void loadRecords(string campus, string level, string yearLevel, string semester)
        {
            var tuition = await _tuitionFeeRepo.GetAllAsync();
            var a = tuition
                .Where(x => x.campus == campus && x.level == level && x.year_level == yearLevel && x.semester == semester)
                .ToList();
            dgv.DataSource = tuition;
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
                var AddRecords = new TuitionFee
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
                await _tuitionFeeRepo.AddRecords(AddRecords);
                new Classes.Toastr("Success", "Miscellaneous fee Added");
                new ActivityLogger().activityLogger(Email, "Misc Fee Setup Add: " + tCategory.Text);
                loadRecords(tCampus.Text, tLevel.Text, tYearLevel.Text, tSemester.Text);
            }
            else if (btn_save.Text == "Update")
            {
                var EditRecords = new TuitionFee
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
                await _tuitionFeeRepo.UpdateRecords(EditRecords);
                new Classes.Toastr("Success", "Miscellaneous fee Added");
                new ActivityLogger().activityLogger(Email, "Misc Fee Setup Add: " + tCategory.Text);
                loadRecords(tCampus.Text, tLevel.Text, tYearLevel.Text, tSemester.Text);
            }
        }

        private async void deleteRecords()
        {
            var delete = new TuitionFee();
            delete.id = Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value);
            await _tuitionFeeRepo.DeleteRecords(delete);

            MessageBox.Show("Tuition Fee Deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            new ActivityLogger().activityLogger(Email, "Miscellaneous Setup Delete: " + dgv.CurrentRow.Cells["description"].Value.ToString());

            loadRecords(tCampus.Text, tLevel.Text, tYearLevel.Text, tSemester.Text);
        }

        private void txtClear()
        {
            tCampus.Text = "";
            tDescription.Clear();
            tSemester.Text = "1";
            tAmount.Clear();
            btn_save.Text = "Save";
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
            if (MessageBox.Show("Are you sure you want to delete this fee?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                deleteRecords();
            }
        }

        private void frm_tuition_fee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                addRecords();
            }
        }

        private async void tsearch_TextChanged(object sender, EventArgs e)
        {
            if (tsearch.Text.Length > 2)
            {
                var search = await _tuitionFeeRepo.GetAllAsync();
                var a = search
                    .Where(x => x.category.ToLower().Contains(tsearch.Text) && x.description.ToLower().Contains(tsearch.Text))
                    .ToList();
                dgv.DataSource = a;
            }
            else if (tsearch.Text.Length == 0)
            {
                loadRecords(tCampus.Text, tLevel.Text, tYearLevel.Text, tSemester.Text);
            }
        }

        private void tCampus_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadRecords(tCampus.Text, tLevel.Text, tYearLevel.Text, tSemester.Text);

        }

        private void tLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadRecords(tCampus.Text, tLevel.Text, tYearLevel.Text, tSemester.Text);

        }

        private void tYearLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadRecords(tCampus.Text, tLevel.Text, tYearLevel.Text, tSemester.Text);

        }

        private void tSemester_TextChanged(object sender, EventArgs e)
        {
            loadRecords(tCampus.Text, tLevel.Text, tYearLevel.Text, tSemester.Text);

        }

        private void kryptonButton1_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this record?","Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                deleteRecords();
            }
        }

        private void btn_clear_Click_1(object sender, EventArgs e)
        {
            txtClear();
        }

        private void btn_save_Click_1(object sender, EventArgs e)
        {
            addRecords();
        }

        private void dgv_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            tCategory.Text = dgv.CurrentRow.Cells["category"].Value.ToString();
            tDescription.Text = dgv.CurrentRow.Cells["description"].Value.ToString();
            tCampus.Text = dgv.CurrentRow.Cells["campus"].Value.ToString();
            tLevel.Text = dgv.CurrentRow.Cells["level"].Value.ToString();
            tSemester.Text = dgv.CurrentRow.Cells["semester"].Value.ToString();
            tAmount.Text = dgv.CurrentRow.Cells["amount"].Value.ToString();
            btn_save.Text = "Update";
        }
    }
}
