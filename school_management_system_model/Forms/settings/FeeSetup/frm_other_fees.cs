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

namespace school_management_system_model.Forms.settings.FeeSetup
{
    public partial class frm_other_fees : Form
    {
        public frm_other_fees()
        {
            InitializeComponent();
        }

        private void frm_other_fees_Load(object sender, EventArgs e)
        {
            loadRecords();
            loadCampus();
        }

        private void loadCampus()
        {
            var data = new OtherFeesSetup();
            var campus = data.loadCampus();
            foreach(DataRow row in campus.Rows)
            {
                tCampus.Items.Add(row["code"]);
            }
        }

        private void loadRecords()
        {
            var data = new OtherFeesSetup();
            dgv.DataSource = data.loadRecords();
            dgv.Columns["id"].Visible = false;
            dgv.Columns["category"].HeaderText = "Category";
            dgv.Columns["description"].HeaderText = "Description";
            dgv.Columns["description"].Width = 350;
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
                    var add = new OtherFeesSetup
                    {
                        category = tCategory.Text,
                        description = tDescription.Text,
                        campus = tCampus.Text,
                        first_year = Convert.ToDecimal(tFirstYear.Text),
                        second_year = Convert.ToDecimal(tSecondYear.Text),
                        third_year = Convert.ToDecimal(tThirdYear.Text),
                        fourth_year = Convert.ToDecimal(tFourthYear.Text)
                    };
                    add.addRecords();
                    new Classes.Toastr().toast("Success", "Other fee Saved");
                    
                    loadRecords();
                    txtClear();
                }
                else if (btn_save.Text == "Update")
                {
                    var edit = new OtherFeesSetup
                    {
                        category = tCategory.Text,
                        description = tDescription.Text,
                        campus = tCampus.Text,
                        first_year = Convert.ToDecimal(tFirstYear.Text),
                        second_year = Convert.ToDecimal(tSecondYear.Text),
                        third_year = Convert.ToDecimal(tThirdYear.Text),
                        fourth_year = Convert.ToDecimal(tFourthYear.Text)
                    };
                    
                    edit.editRecords(Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value));
 
                    new Classes.Toastr().toast("Information", "Other fee Updated");
                    loadRecords();
                    txtClear();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtClear()
        {
            tDescription.Clear();
            tFirstYear.Clear();
            tSecondYear.Clear();
            tThirdYear.Clear();
            tFourthYear.Clear();
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
                var delete = new OtherFeesSetup();
                delete.deleteRecords(Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value));
                new Classes.Toastr().toast("Information", "Other fee Deleted!");

                loadRecords();
            }
        }

        private void tsearch_TextChanged(object sender, EventArgs e)
        {
            if (tsearch.Text.Length > 2)
            {
                var data = new OtherFeesSetup();
                var search = data.searchRecords(tsearch.Text);
                dgv.DataSource = search;
            }
            else if (tsearch.Text.Length == 0)
            {
                loadRecords();
            }
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tDescription.Text = dgv.CurrentRow.Cells["description"].Value.ToString();
            tCampus.Text = dgv.CurrentRow.Cells["campus"].Value.ToString();
            tFirstYear.Text = dgv.CurrentRow.Cells["first_year"].Value.ToString();
            tSecondYear.Text = dgv.CurrentRow.Cells["second_year"].Value.ToString();
            tThirdYear.Text = dgv.CurrentRow.Cells["third_year"].Value.ToString();
            tFourthYear.Text = dgv.CurrentRow.Cells["fourth_year"].Value.ToString();
            btn_save.Text = "Update";
        }

        private void frm_other_fees_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                addRecords();
            }
        }
    }
}
