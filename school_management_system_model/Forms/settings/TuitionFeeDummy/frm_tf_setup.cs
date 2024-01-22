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

namespace school_management_system_model.Forms.settings.TuitionFeeDummy
{
    public partial class frm_tf_setup : Form
    {
        public frm_tf_setup(string email)
        {
            InitializeComponent();
            Email = email;
        }

        public string Email { get; }
        public int id { get; set; }

        private void frm_tf_setup_Load(object sender, EventArgs e)
        {
            loadCampus();
            loadLevel();
            loadRecords();
        }

        private void loadLevel()
        {
            var level = new TuitionFeeSetup();
            tLevel.ValueMember = "id";
            tLevel.DisplayMember = "Code";
            tLevel.DataSource = level.GetLevels();
        }

        private void loadCampus()
        {
            var campus = new TuitionFeeSetup();
            tCampus.DataSource = campus.loadCampus();
            tCampus.ValueMember = "id";
            tCampus.DisplayMember = "code";
        }

        private void loadRecords()
        {
            //var tuitionfee = new TuitionFeeSetup();
            //dgv.DataSource = tuitionfee.loadRecords(tSemester.Text);
           

            var data = new TuitionFeeSetup();
            dgv.DataSource = data.GetRecords().Where(x => x.semester == tSemester.Text && x.campus == tCampus.Text).ToList();
            dgv.Columns["id"].Visible = false;
            dgv.Columns["uid"].Visible = false;
            dgv.Columns["category"].HeaderText = "Category";
            dgv.Columns["description"].HeaderText = "Description";
            dgv.Columns["description"].Width = 150;
            dgv.Columns["campus"].HeaderText = "Campus";
            dgv.Columns["level"].HeaderText = "Level";
            dgv.Columns["year_level"].HeaderText = "Year Level";
            dgv.Columns["semester"].Visible = false;
            dgv.Columns["amount"].HeaderText = "Amount";
        }

        void addRecords()
        {
            try
            {
                if (btn_save.Text == "Save")
                {
                    var add = new TuitionFeeSetup
                    {
                        uid = tCategory.Text + tCampus.SelectedValue.ToString() + tYearlevel.Text + tSemester.Text,
                        category = tCategory.Text,
                        description = tDescription.Text,
                        campus = tCampus.SelectedValue.ToString(),
                        level = tLevel.SelectedValue.ToString(),
                        year_level = tYearlevel.Text,
                        semester = tSemester.Text,
                        amount = Convert.ToDecimal(tAmount.Text)
                    };
                    add.addRecords();
                    new Classes.Toastr("Success", "Tuition Fee Setup Added");
                    new ActivityLogger().activityLogger(Email, "Tuition fee setup add: " + tDescription.Text);
                    loadRecords();

                }
                else if (btn_save.Text == "Update")
                {
                    int id = (int)dgv.CurrentRow.Cells["id"].Value;
                    var add = new TuitionFeeSetup
                    {
                        uid = tCategory.Text + tCampus.SelectedValue.ToString() + tYearlevel.Text + tSemester.Text,
                        category = tCategory.Text,
                        description = tDescription.Text,
                        campus = tCampus.SelectedValue.ToString(),
                        level = tLevel.SelectedValue.ToString(),
                        year_level = tYearlevel.Text,
                        semester = tSemester.Text,
                        amount = Convert.ToDecimal(tAmount.Text)
                    };
                    add.editRecords(id);
                    new Classes.Toastr("Information", "Tuition Fee Updated");
                    new ActivityLogger().activityLogger(Email, "Tuition fee setup Update: " + tDescription.Text);
                    loadRecords();

                }
            }
            catch(Exception ex)
            {
                new Classes.Toastr("Error", ex.Message);
            }
            
        }

        private void txtclear()
        {
            tDescription.Clear();
            tCampus.Text = "";
            tYearlevel.Clear();
            tAmount.Clear();
            btn_save.Text = "Save";
            tDescription.Select();
        }

        private void deleteRecords(int id)
        {
            var delete = new TuitionFeeSetup();
            delete.deleteRecords(id);
            new Classes.Toastr("Information", "Tuition Fee Deleted");
            loadRecords();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            addRecords();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txtclear();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("delete tuition fee?","Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var id = Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value);
                deleteRecords(id);
            }
        }

        private void tSemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadRecords();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value);
            tCategory.Text = dgv.CurrentRow.Cells["category"].Value.ToString();
            tDescription.Text = dgv.CurrentRow.Cells["description"].Value.ToString();
            tCampus.Text = dgv.CurrentRow.Cells["campus"].Value.ToString();
            tYearlevel.Text = dgv.CurrentRow.Cells["year_level"].Value.ToString();
            tSemester.Text = dgv.CurrentRow.Cells["semester"].Value.ToString();
            tAmount.Text = dgv.CurrentRow.Cells["amount"].Value.ToString();
            btn_save.Text = "Update";
        }

        private void tsearch_TextChanged(object sender, EventArgs e)
        {
            if (tsearch.Text.Length > 2)
            {
                var searchTerm = tsearch.Text;
                var search = new TuitionFeeSetup();
                dgv.DataSource = search.GetRecords().Where(x => x.semester == tSemester.Text && x.description.ToLower().Contains(searchTerm)).ToList();
            }
            else if (tsearch.Text.Length == 0)
            {
                loadRecords();
            }
        }

        private void tCampus_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadRecords();
        }
    }
}
