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
        public string code { get; set; }
        public string description { get; set; }
        public string discount_target { get; set; }
        public string discount_percentage { get; set; }
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
                new Classes.Toastr("Warning", "Select Student");
            }
            else
            {
                var frm = new frm_select_discount();
                frm.ShowDialog();
                loadRecords();
                if (code != null && discount_target != null && description != null && discount_percentage != null)
                {
                    tCode.Text = code;
                    tDescription.Text = description;
                    tDiscountTarget.Text = discount_target;
                    tDiscountPercentage.Text = discount_percentage;
                    dateTimePicker1.Select();
                }
            }
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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            tFrom.Text = dateTimePicker1.Value.ToString("dd-MM-yyyy");
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            tTo.Text = dateTimePicker2.Value.ToString("dd-MM-yyyy");
        }
    }
}
