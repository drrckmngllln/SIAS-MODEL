using school_management_system_model.Classes;
using System;
using System.Data;
using System.Windows.Forms;

namespace school_management_system_model.Forms.settings
{
    public partial class frm_tuition_fee : Form
    {
        public frm_tuition_fee()
        {
            InitializeComponent();
        }

        private void frm_tuition_fee_Load(object sender, System.EventArgs e)
        {
            loadRecords();
            loadCampuses();
        }

        private void loadCampuses()
        {
            var courses = new TuitionFeeSetup();
            var data = courses.loadCampuses();
            foreach(DataRow row in data.Rows)
            {
                tCampus.Items.Add(row["code"]);
            }
        }

        private void loadRecords()
        {
            var data = new TuitionFeeSetup();
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
                var add = new TuitionFeeSetup
                {
                    category = tCategory.Text,
                    campus = tCampus.Text,
                    first_year = Convert.ToDecimal(tFirstYear.Text),
                    second_year = Convert.ToDecimal(tSecondYear.Text),
                    third_year = Convert.ToDecimal(tThirdYear.Text),
                    fourth_year = Convert.ToDecimal(tFourthYear.Text)
                };
                add.addRecords();
                MessageBox.Show("Tuition Fee Add Success", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadRecords();
                txtClear();
            }
            else if (btn_save.Text == "Update")
            {
                var edit = new TuitionFeeSetup
                {
                    id = Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value.ToString()),
                    category = tCategory.Text,
                    campus = tCampus.Text,
                    first_year = Convert.ToDecimal(tFirstYear.Text),
                    second_year = Convert.ToDecimal(tSecondYear.Text),
                    third_year = Convert.ToDecimal(tThirdYear.Text),
                    fourth_year = Convert.ToDecimal(tFourthYear.Text)
                };
                edit.editRecords();
                MessageBox.Show("Tuition Fee Update Success", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadRecords();
                txtClear();
            }
        }

        private void deleteRecords()
        {
            var delete = new TuitionFeeSetup
            {
                id = Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value.ToString())
            };
            delete.deleteRecords();
            MessageBox.Show("Tuition Fee Deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadRecords();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tCategory.Text = dgv.CurrentRow.Cells["category"].Value.ToString();
            tCampus.Text = dgv.CurrentRow.Cells["campus"].Value.ToString();
            tFirstYear.Text = dgv.CurrentRow.Cells["first_year"].Value.ToString();
            tSecondYear.Text = dgv.CurrentRow.Cells["second_year"].Value.ToString();
            tThirdYear.Text = dgv.CurrentRow.Cells["third_year"].Value.ToString();
            tFourthYear.Text = dgv.CurrentRow.Cells["fourth_year"].Value.ToString();
            btn_save.Text = "Update";
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
            if (MessageBox.Show("Are you sure you want to delete this fee?","Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
    }
}
