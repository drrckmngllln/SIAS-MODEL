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
    public partial class frm_discount_setup : Form
    {
        public frm_discount_setup()
        {
            InitializeComponent();
        }

        private void frm_discount_setup_Load(object sender, EventArgs e)
        {
            loadRecords();
        }

        private void loadRecords()
        {
            var data = new DiscountSetup();
            dgv.DataSource = data.loadRecords();
            dgv.Columns["id"].Visible = false;
            dgv.Columns["code"].HeaderText = "Code";
            dgv.Columns["discount_target"].HeaderText = "Discount Target";
            dgv.Columns["description"].HeaderText = "Description";
            dgv.Columns["description"].Width = 400;
            dgv.Columns["discount_percentage"].HeaderText = "Discount Percentage";
        }
        private void addRecords()
        {
            if (btn_save.Text == "Save")
            {
                var add = new DiscountSetup
                {
                    code = tCode.Text,
                    description = tDescription.Text,
                    discount_target = tDiscountTarget.Text,
                    discount_percentage = Convert.ToInt32(tPercentage.Text)
                };
                add.addRecords();
                MessageBox.Show("Saved", "Success",MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtClear();
                loadRecords();
            }
            else if (btn_save.Text == "Update")
            {
                var edit = new DiscountSetup
                {
                    code = tCode.Text,
                    description = tDescription.Text,
                    discount_target = tDiscountTarget.Text,
                    discount_percentage = Convert.ToInt32(tPercentage.Text)
                };
                edit.editRecords(Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value));
                MessageBox.Show("Updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtClear();
                loadRecords();
            }
        }

        private void txtClear()
        {
            tCode.Clear();
            tDescription.Clear();
            tPercentage.Clear();
            btn_save.Text = "Save";
        }

        private void frm_discount_setup_KeyDown(object sender, KeyEventArgs e)
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

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txtClear();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tCode.Text = dgv.CurrentRow.Cells["code"].Value.ToString();
            tDescription.Text = dgv.CurrentRow.Cells["description"].Value.ToString();
            tPercentage.Text = dgv.CurrentRow.Cells["discount_Percentage"].Value.ToString();

            btn_save.Text = "Update";
        }
        private void deleteRecords()
        {
            var delete = new DiscountSetup();
            delete.deleteRecords(Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value));
            MessageBox.Show("Deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete this record?","Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                deleteRecords();
            }
        }

        private void tsearch_TextChanged(object sender, EventArgs e)
        {
            if (tsearch.Text.Length > 2)
            {
                var data = new DiscountSetup();
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
