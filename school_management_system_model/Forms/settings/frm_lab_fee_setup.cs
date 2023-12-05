using Org.BouncyCastle.Crypto.Modes.Gcm;
using school_management_system_model.Classes;
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
        public frm_lab_fee_setup()
        {
            InitializeComponent();
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
            dgv.Columns["category"].HeaderText = "Category";
            dgv.Columns["category"].Width = 250;
            dgv.Columns["campus"].HeaderText = "Campus";
            dgv.Columns["first_year"].HeaderText = "1st Year";
            dgv.Columns["second_year"].HeaderText = "2nd Year";
            dgv.Columns["third_year"].HeaderText = "3rd Year";
            dgv.Columns["fourth_year"].HeaderText = "4th Year";
        }

        private void addRecords()
        {
            if (btn_save.Text == "Save")
            {
                var add = new LabFeeSetup
                {
                    category = tCategory.Text,
                    campus = tCampus.Text,
                    first_year = Convert.ToDecimal(tFirstYear.Text),
                    second_year = Convert.ToDecimal(tSecondYear.Text),
                    third_year = Convert.ToDecimal(tThirdYear.Text),
                    fourth_year = Convert.ToDecimal(tFourthYear.Text),
                };
                add.addRecords();
                MessageBox.Show("Miscellaneous Fee Added","Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadRecords();
            }
            else if (btn_save.Text == "Update")
            {
                var edit = new LabFeeSetup
                {
                    id = Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value),
                    campus = tCampus.Text,
                    first_year = Convert.ToDecimal(tFirstYear.Text),
                    second_year = Convert.ToDecimal(tSecondYear.Text),
                    third_year = Convert.ToDecimal(tThirdYear.Text),
                    fourth_year = Convert.ToDecimal(tFourthYear.Text),
                };
                edit.editRecords();
                MessageBox.Show("Miscellaneous Fee Updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadRecords();
            }
        }
        
        private void deleteRecords()
        {
            var delete = new LabFeeSetup
            {
                id = Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value.ToString())
            };
            delete.deleteRecords();
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
            tCategory.Clear();
            tCampus.Text = "";
            tFirstYear.Clear();
            tSecondYear.Clear();
            tThirdYear.Clear();
            tFourthYear.Clear();
            btn_save.Text = "Save";
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txtClear();
        }

       
        private void tsearch_TextChanged(object sender, EventArgs e)
        {
            if (tsearch.Text.Length > 2)
            {
                var search = new LabFeeSetup
                {
                    search = tsearch.Text
                };
                dgv.DataSource = search.searchRecords();
            }
        }

        private void btn_clear_Click_1(object sender, EventArgs e)
        {
            txtClear();
        }

        private void kryptonButton1_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("are you sure you want to delete this record?","Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                deleteRecords();
            }
        }
    }
}
