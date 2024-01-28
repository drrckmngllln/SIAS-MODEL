using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto.Generators;
using school_management_system_model.Classes;
using school_management_system_model.Forms.settings.TuitionFeeDummy;
using school_management_system_model.Loggers;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace school_management_system_model.Forms.settings
{
    public partial class frm_miscellaneous_setup : Form
    {
        public static frm_miscellaneous_setup instance;
        public DataTable dt = new DataTable();
        public DataTable coursesDt = new DataTable();
        string ID;

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
            var misc = new MiscellaneousFeeSetup().GetMiscellaneousFeeSetups()
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
                var AddRecords = new MiscellaneousFeeSetup
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
                AddRecords.AddMiscFee();
                new Classes.Toastr("Success", "Miscellaneous fee Added");
                new ActivityLogger().activityLogger(Email, "Misc Fee Setup Add: " + tCategory.Text);
                loadRecords(tCampus.Text, tLevel.Text, tYearLevel.Text);
                
            }
            else if (btn_save.Text == "Update")
            {
                var editRecords = new MiscellaneousFeeSetup
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
                editRecords.EditMiscFee(Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value));
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

        private void deleteRecords()
        {
            
        }

        private void searchRecords(string search)
        {
            var searchRecord = new MiscellaneousFeeSetup().GetMiscellaneousFeeSetups()
                .Where(x => x.category.ToLower().Contains(search) || x.description.ToLower().Contains(search))
                .ToList();
            dgv.DataSource = searchRecord;
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("are you sure you want to delete records?","Warning!",
                MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                deleteRecords();
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txtClear();
        }

        private void tsearch_TextChanged(object sender, EventArgs e)
        {
            
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
                deleteRecords();
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
