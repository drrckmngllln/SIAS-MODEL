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

namespace school_management_system_model.Forms.transactions.StudentDiscounts
{
    public partial class frm_student_discounts : Form
    {
        public static frm_student_discounts instance;
        public string fullname { get; set; }
        public string idNumber { get; set; }
        public frm_student_discounts()
        {
            instance = this;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var frm = new frm_select_student();
            frm.ShowDialog();
            if (idNumber != null && fullname != null)
            {
                tIdNumber.Text = idNumber.ToString();
                tStudentName.Text = fullname.ToString();
            }
            loadRecords();
        }

        private void loadRecords()
        {
            var data = new StudentDiscount();
            dgv.DataSource = data.loadRecords(tIdNumber.Text);
            dgv.Columns["id"].Visible = false;
            dgv.Columns["id_number"].Visible = false;
            dgv.Columns["discount_target"].HeaderText = "Discount Target";
            dgv.Columns["code"].HeaderText = "Discount Code";
            dgv.Columns["description"].HeaderText = "Description";
            dgv.Columns["discount_percentage"].HeaderText = "Discount Percentage";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (tIdNumber.Text == "")
            {
                MessageBox.Show("select student", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var frm = new frm_select_discount();
                frm_select_discount.instance.idNumber = tIdNumber.Text;
                frm.ShowDialog();
                loadRecords();
            }
        }

        private void totalTimer_Tick(object sender, EventArgs e)
        {
            int count = 0;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                count += Convert.ToInt32(row.Cells["discount_percentage"].Value);
            }
            tTotalPercentage.Text = count.ToString() + "%";
        }

        

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete discount?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var delete = new StudentDiscount();
                delete.deleteRecords(Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value));
                MessageBox.Show("Discount Deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadRecords();
            }
        }
    }
}
