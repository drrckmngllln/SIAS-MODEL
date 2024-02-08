﻿using school_management_system_model.Classes;
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
        public string Email { get; }

        public frm_student_discounts(string email)
        {
            instance = this;
            InitializeComponent();
            Email = email;
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

        private async void loadRecords()
        {
            var a = await new StudentDiscount().GetStudentDiscounts();
            var studentDiscount = a
                .Where(x => x.id_number == idNumber).ToList();
            //var data = new StudentDiscount();

            if (studentDiscount != null)
            {
                dgv.DataSource = studentDiscount;
                dgv.Columns["id"].Visible = false;
                dgv.Columns["id_number"].Visible = false;
                dgv.Columns["discount_target"].HeaderText = "Discount Target";
                dgv.Columns["code"].HeaderText = "Discount Code";
                dgv.Columns["description"].HeaderText = "Description";
                dgv.Columns["discount_percentage"].HeaderText = "Discount Percentage";
            }
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
                }
            }
        }



        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete discount?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var delete = new StudentDiscount();
                delete.deleteRecords(Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value));
                new Classes.Toastr("Information", "Discount Removed");
                new ActivityLogger().activityLogger(Email, "Remove discount: " + tStudentName.Text);
                loadRecords();
            }
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            var save = new StudentDiscount
            {
                id_number = tIdNumber.Text,
                code = tCode.Text,
                discount_target = tDiscountTarget.Text,
                description = tDescription.Text,
                discount_percentage = Convert.ToInt32(tDiscountPercentage.Text),

            };
            save.addRecords();
            loadRecords();
            txtClear();
            new Classes.Toastr("Success", "Student Discount Added");
            new ActivityLogger().activityLogger(Email, "Adding discount to student: " + tStudentName.Text);
        }

        private void txtClear()
        {
            tCode.Clear();
            tDescription.Clear();
            tDiscountPercentage.Clear();
            tDiscountTarget.Clear();

        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
