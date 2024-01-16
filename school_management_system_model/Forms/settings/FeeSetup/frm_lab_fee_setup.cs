using Org.BouncyCastle.Crypto.Modes.Gcm;
using school_management_system_model.Classes;
using school_management_system_model.Forms.settings.FeeSetup;
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
            loadRecords();
            loadCampuses();
        }

        private void loadCampuses()
        {
            var courses = new LabFeeSetup();
            var data = courses.loadCampuses();

            foreach(DataRow row in data.Rows)
            {
                tCampus.Items.Add(row["code"]);
            }
        }

        private void loadRecords()
        {
            var data = new LabFeeSetup();
            dgv.DataSource = data.loadRecords();
            dgv.Columns["id"].Visible = false;
            dgv.Columns["category"].Visible = false;
            dgv.Columns["description"].HeaderText = "Description";
            dgv.Columns["description"].Width = 250;
            dgv.Columns["campus"].HeaderText = "Campus";
            dgv.Columns["first_year"].HeaderText = "1st Year";
            dgv.Columns["second_year"].HeaderText = "2nd Year";
            dgv.Columns["third_year"].HeaderText = "3rd Year";
            dgv.Columns["fourth_year"].HeaderText = "4th Year";
        }

        private void addRecords()
        {
            try
            {
                if (btn_save.Text == "Save")
                {
                    var add = new LabFeeSetup
                    {
                        category = tCategory.Text,
                        description = tDescription.Text,
                        campus = tCampus.Text,
                        first_year = Convert.ToDecimal(tFirstYear.Text),
                        second_year = Convert.ToDecimal(tSecondYear.Text),
                        third_year = Convert.ToDecimal(tThirdYear.Text),
                        fourth_year = Convert.ToDecimal(tFourthYear.Text),
                    };
                    add.addRecords();
                    MessageBox.Show("Miscellaneous Fee Added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    new ActivityLogger().activityLogger(Email, "Miscelaneous fee Add: " + tDescription.Text);
                    loadRecords();
                    txtClear();
                }
                else if (btn_save.Text == "Update")
                {
                    var edit = new LabFeeSetup
                    {
                        id = Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value),
                        category = tCategory.Text,
                        campus = tCampus.Text,
                        description = tDescription.Text,
                        first_year = Convert.ToDecimal(tFirstYear.Text),
                        second_year = Convert.ToDecimal(tSecondYear.Text),
                        third_year = Convert.ToDecimal(tThirdYear.Text),
                        fourth_year = Convert.ToDecimal(tFourthYear.Text),
                    };
                    edit.editRecords();
                    MessageBox.Show("Miscellaneous Fee Updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadRecords();
                    txtClear();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        
        private void deleteRecords()
        {
            var delete = new LabFeeSetup();
            delete.deleteRecords(Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value.ToString()));
            MessageBox.Show("Deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information );
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
            tFirstYear.Clear();
            tSecondYear.Clear();
            tThirdYear.Clear();
            tFourthYear.Clear();

            btn_save.Text = "Save";
        }

        

       
        private void tsearch_TextChanged(object sender, EventArgs e)
        {
            if (tsearch.Text.Length > 2)
            {
                var search = new LabFeeSetup();
                dgv.DataSource = search.searchRecords(tsearch.Text);
            }
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
                loadRecords();
            }
        }

        private void btn_save_Click_1(object sender, EventArgs e)
        {
            addRecords();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tCategory.Text = dgv.CurrentRow.Cells["category"].Value.ToString();
            tDescription.Text = dgv.CurrentRow.Cells["description"].Value.ToString();
            tCampus.Text = dgv.CurrentRow.Cells["campus"].Value.ToString();
            tFirstYear.Text = dgv.CurrentRow.Cells["first_year"].Value.ToString();
            tSecondYear.Text = dgv.CurrentRow.Cells["second_year"].Value.ToString();
            tThirdYear.Text = dgv.CurrentRow.Cells["third_year"].Value.ToString();
            tFourthYear.Text = dgv.CurrentRow.Cells["fourth_year"].Value.ToString();
            btn_save.Text = "Update";
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
                var data = new LabFeeSetup();
                var search = data.searchRecords(tsearch.Text);
                dgv.DataSource = search;
            }
            else if (tsearch.Text.Length == 0)
            {
                loadRecords();
            }
        }
    }
}
