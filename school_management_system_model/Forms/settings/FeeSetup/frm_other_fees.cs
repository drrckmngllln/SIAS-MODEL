using school_management_system_model.Classes;
using school_management_system_model.Forms.settings.TuitionFeeDummy;
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

namespace school_management_system_model.Forms.settings.FeeSetup
{
    public partial class frm_other_fees : Form
    {
        public string Email { get; }

        public frm_other_fees(string email)
        {
            InitializeComponent();
            Email = email;
        }

        private void frm_other_fees_Load(object sender, EventArgs e)
        {
            loadCampuses();
            loadLevels();
            loadRecords(tCampus.Text, tLevel.Text, tYearLevel.Text);
        }

        private void loadLevels()
        {
            var level = new Levels().GetLevels().ToList();
            tLevel.ValueMember = "id";
            tLevel.DisplayMember = "code";
            tLevel.DataSource = level;
        }

        private void loadCampuses()
        {
            var campus = new Campuses().GetCampuses().ToList();
            tCampus.ValueMember = "id";
            tCampus.DisplayMember = "code";
            tCampus.DataSource = campus;
        }

        private void loadRecords(string campus, string level, string yearLevel)
        {
            var misc = new OtherFeesSetup().GetOtherFeesSetups()
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

        private void addRecords()
        {
            if (btn_save.Text == "Save")
            {
                var AddRecords = new OtherFeesSetup
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
                AddRecords.addRecords();
                new Classes.Toastr("Success", "Miscellaneous fee Added");
                new ActivityLogger().activityLogger(Email, "Misc Fee Setup Add: " + tCategory.Text);
                loadRecords(tCampus.Text, tLevel.Text, tYearLevel.Text);

            }
            else if (btn_save.Text == "Update")
            {
                var editRecords = new OtherFeesSetup
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
                editRecords.editRecords(Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value));
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

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txtClear();
        }

        private void tsearch_TextChanged(object sender, EventArgs e)
        {
            if (tsearch.Text.Length > 2)
            {
                var searchRecord = new OtherFeesSetup().GetOtherFeesSetups()
                .Where(x => x.category.ToLower().Contains(tsearch.Text) || x.description.ToLower().Contains(tsearch.Text))
                .ToList();
                dgv.DataSource = searchRecord;
            }
            else if (tsearch.Text.Length == 0)
            {
                loadRecords(tCampus.Text, tLevel.Text, tYearLevel.Text);

            }
        }

        private void frm_other_fees_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                addRecords();
            }
        }

        private void btn_save_Click_1(object sender, EventArgs e)
        {
            addRecords();
        }

        private void btn_clear_Click_1(object sender, EventArgs e)
        {
            txtClear();
        }

        private void kryptonButton1_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this fee?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var delete = new OtherFeesSetup();
                delete.deleteRecords(Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value));
                new Classes.Toastr("Information", "Other fee Deleted!");
                new ActivityLogger().activityLogger(Email, "Miscellaneous Setup Delete: " + dgv.CurrentRow.Cells["description"].Value.ToString());
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

        private void tSemester_TextChanged(object sender, EventArgs e)
        {
            loadRecords(tCampus.Text, tLevel.Text, tYearLevel.Text);

        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tDescription.Text = dgv.CurrentRow.Cells["description"].Value.ToString();
            tCampus.Text = dgv.CurrentRow.Cells["campus"].Value.ToString();
            tLevel.Text = dgv.CurrentRow.Cells["level"].Value.ToString();
            tYearLevel.Text = dgv.CurrentRow.Cells["year_level"].Value.ToString();
            tSemester.Text = dgv.CurrentRow.Cells["semester"].Value.ToString();
            tAmount.Text = dgv.CurrentRow.Cells["amount"].Value.ToString();
            btn_save.Text = "Update";
        }
    }
}
