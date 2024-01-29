﻿using school_management_system_model.Classes;
using school_management_system_model.Forms.settings.FeeSetup;
using school_management_system_model.Forms.settings.TuitionFeeDummy;
using school_management_system_model.Loggers;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace school_management_system_model.Forms.settings
{
    public partial class frm_lab_fee_setup : Form
    {
        public string Email { get; set; }

        public frm_lab_fee_setup(string email)
        {
            InitializeComponent();
            Email = email;
        }

        private void frm_lab_fee_setup_Load(object sender, EventArgs e)
        {
            loadCampuses();
            loadLevels();
            loadRecords(tCampus.Text, tLevel.Text, tYearLevel.Text, tSemester.Text);
        }

        private void loadLevels()
        {
            var levels = new Levels().GetLevels();
            tLevel.ValueMember = "id";
            tLevel.DisplayMember = "code";
            tLevel.DataSource = levels;
        }

        private void loadCampuses()
        {
            var campuses = new Campuses().GetCampuses();
            tCampus.ValueMember = "id";
            tCampus.DisplayMember = "code";
            tCampus.DataSource = campuses;
        }

        private void loadRecords(string campus, string level, string yearLevel, string semester)
        {
            var lab = new LabFeeSetup().GetLabFeeSetups()
                .Where(x => x.campus == campus && x.level == level && x.year_level == yearLevel && x.semester == semester)
                .ToList();
            dgv.DataSource = lab;
            dgv.Columns["id"].Visible = false;
            dgv.Columns["uid"].Visible = false;
            dgv.Columns["category"].Visible = false;
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
            try
            {
                if (btn_save.Text == "Save")
                {
                    var LabAdd = new LabFeeSetup
                    {
                        uid = tCategory.Text + tDescription.Text + tCampus.SelectedValue.ToString() + tLevel.SelectedValue.ToString() + tYearLevel.Text + tSemester.Text,
                        category = tCategory.Text,
                        description = tDescription.Text,
                        campus = tCampus.SelectedValue.ToString(),
                        level = tLevel.SelectedValue.ToString(),
                        year_level = tYearLevel.Text,
                        semester = tSemester.Text,
                        amount = Convert.ToDecimal(tAmount.Text)
                    };
                    LabAdd.addRecords();
                    new Classes.Toastr("Success", "Miscellaneous Fee Added");
                    new ActivityLogger().activityLogger(Email, "Miscelaneous fee Add: " + tDescription.Text);
                    loadRecords(tCampus.Text, tLevel.Text, tYearLevel.Text, tSemester.Text);
                    txtClear();
                }
                else if (btn_save.Text == "Update")
                {
                    var LabEdit = new LabFeeSetup
                    {
                        uid = tCategory.Text + tDescription.Text + tCampus.SelectedValue.ToString() + tLevel.SelectedValue.ToString() + tYearLevel.Text + tSemester.Text,
                        category = tCategory.Text,
                        description = tDescription.Text,
                        campus = tCampus.SelectedValue.ToString(),
                        level = tLevel.SelectedValue.ToString(),
                        year_level = tYearLevel.Text,
                        semester = tSemester.Text,
                        amount = Convert.ToDecimal(tAmount.Text)
                    };
                    LabEdit.editRecords(Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value));
                    new Classes.Toastr("Information", "Miscellaneous Fee Updated");
                    new ActivityLogger().activityLogger(Email, "Miscelaneous fee Add: " + tDescription.Text);
                    loadRecords(tCampus.Text, tLevel.Text, tYearLevel.Text, tSemester.Text);
                    txtClear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void deleteRecords()
        {
            var delete = new LabFeeSetup();
            delete.deleteRecords(Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value.ToString()));
            new Classes.Toastr("Information", "Lab Fee Deleted");
            new ActivityLogger().activityLogger(Email, "Lab Fee Deletion: " + tDescription.Text);
            loadRecords(tCampus.Text, tLevel.Text, tYearLevel.Text, tSemester.Text);

        }

        private void frm_lab_fee_setup_KeyDown(object sender, KeyEventArgs e)
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

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            deleteRecords();
        }

        private void txtClear()
        {
            tCampus.Text = "";
            tDescription.Clear();
            tSemester.Clear();
            tAmount.Clear();
            btn_save.Text = "Save";
        }

        private void btn_clear_Click_1(object sender, EventArgs e)
        {
            txtClear();
        }

        private void kryptonButton1_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this fee?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var delete = new LabFeeSetup();
                delete.deleteRecords(Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value));
                new ActivityLogger().activityLogger(Email, "Lab fee Delete: " + dgv.CurrentRow.Cells["description"].Value.ToString());
                loadRecords(tCampus.Text, tLevel.Text, tYearLevel.Text, tSemester.Text);

            }
        }

        private void btn_save_Click_1(object sender, EventArgs e)
        {
            addRecords();
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            var frm = new frm_link_subjects(Email, Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value));
            frm.Text = "Select";
            frm.ShowDialog();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            var frm = new frm_link_subjects(Email, Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value));

            frm.Text = "View";
            frm.ShowDialog();
        }

        private void tsearch_TextChanged_1(object sender, EventArgs e)
        {
            if (tsearch.Text.Length > 2)
            {
                var search = new LabFeeSetup().GetLabFeeSetups()
                    .Where(x => x.category.ToLower().Contains(tsearch.Text) && x.description.ToLower().Contains(tsearch.Text))
                    .ToList();
                dgv.DataSource = search;
            }
            else if (tsearch.Text.Length == 0)
            {
                loadRecords(tCampus.Text, tLevel.Text, tYearLevel.Text, tSemester.Text);
            }
        }

        private void btn_save_Click_2(object sender, EventArgs e)
        {
            addRecords();
        }

        private void dgv_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            tCategory.Text = dgv.CurrentRow.Cells["category"].Value.ToString();
            tDescription.Text = dgv.CurrentRow.Cells["description"].Value.ToString();
            tCampus.Text = dgv.CurrentRow.Cells["campus"].Value.ToString();
            tLevel.Text = dgv.CurrentRow.Cells["level"].Value.ToString();
            tYearLevel.Text = dgv.CurrentRow.Cells["year_level"].Value.ToString();
            tSemester.Text = dgv.CurrentRow.Cells["semester"].Value.ToString();
            tAmount.Text = dgv.CurrentRow.Cells["amount"].Value.ToString();
            btn_save.Text = "Update";
        }

        private void kryptonButton1_Click_2(object sender, EventArgs e)
        {
            deleteRecords();
        }

        private void tCampus_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadRecords(tCampus.Text, tLevel.Text, tYearLevel.Text, tSemester.Text);

        }
    }
}
