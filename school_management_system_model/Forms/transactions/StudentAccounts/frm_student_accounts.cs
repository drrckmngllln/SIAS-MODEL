﻿using school_management_system_model.Classes;
using school_management_system_model.Forms.transactions.StudentAccounts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace school_management_system_model.Forms.transactions
{
    public partial class frm_student_accounts : Form
    {
        public static frm_student_accounts instance;
        public string schoolYear { get; set; }
        public frm_student_accounts()
        {
            instance = this;
            InitializeComponent();
        }

        private void timerTotal_Tick(object sender, EventArgs e)
        {
            tTotal.Text = dgv.Rows.Count.ToString();
        }

        private void frm_student_accounts_Load(object sender, EventArgs e)
        {
            loadSchoolYear();
            loadRecords();
        }

        private void loadRecords()
        {
            var data = new StudentAccount();
            dgv.DataSource = data.loadRecords(tSchoolYear.Text);
            dgv.Columns["id"].Visible = false;
            dgv.Columns["id_number"].HeaderText = "Student Number";
            dgv.Columns["school_year"].Visible = false;
            dgv.Columns["fullname"].HeaderText = "Student Name";
            dgv.Columns["fullname"].Width = 300;
            dgv.Columns["last_name"].Visible = false;
            dgv.Columns["first_name"].Visible = false;
            dgv.Columns["middle_name"].Visible = false;
            dgv.Columns["gender"].HeaderText = "Gender";
            dgv.Columns["civil_status"].HeaderText = "Civil Status";
            dgv.Columns["date_of_birth"].HeaderText = "Date of Birth";
            dgv.Columns["place_of_birth"].HeaderText = "Place of Birth";
            dgv.Columns["nationality"].HeaderText = "Nationality";
            dgv.Columns["religion"].HeaderText = "Religion";
            dgv.Columns["status"].HeaderText = "Status";
        }

        private void loadSchoolYear()
        {
            var data = new StudentAccount();
            tSchoolYear.Text = data.schoolYearPreSet();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var frm = new frm_select_school_year();
            frm.ShowDialog();
            if (schoolYear != null)
            {
                tSchoolYear.Text = schoolYear;
            }
            loadRecords();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (btnCreate.Text == "Create Account")
            {
                var frm = new frm_create_account();
                frm_create_account.instance.schoolYear = tSchoolYear.Text;
                frm.Text = "Create Account";
                frm.ShowDialog();
                loadRecords();
            }
            else if (btnCreate.Text == "Update Account")
            {
                var frm = new frm_create_account();
                frm_create_account.instance.id = Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value);
                frm.Text = "Update Account";
                frm.ShowDialog();
                loadRecords();
            }
        }

        private void searchRecords(string search)
        {
            var searchRecords = new StudentAccount();
            dgv.DataSource = searchRecords.searchRecords(search);
        }

        private void tSearch_TextChanged(object sender, EventArgs e)
        {
            if (tSearch.Text.Length > 2)
            {
                searchRecords(tSearch.Text);
            }
            else if (tSearch.Text.Length == 0)
            {
                loadRecords();
            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnCreate.Text = "Update Account";
            if (dgv.CurrentRow.Cells["status"].Value.ToString() == "Pending")
            {
                btnApprove.Enabled = true;
            }
            else
            {
                btnApprove.Enabled= false;
            }

            if (dgv.CurrentRow.Cells["status"].Value.ToString() == "For Enrollment")
            {
                btnEnroll.Enabled = true;
            }
            else
            {
                btnEnroll.Enabled = false;
            }
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            btnCreate.Text = "Create Account";
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Approve Student?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var approve = new StudentAccount();
                approve.approveStudent(dgv.CurrentRow.Cells["id_number"].Value.ToString());
                MessageBox.Show("Student Approved, Proceed to Enrollment", "Success", 
                    MessageBoxButtons.OK, MessageBoxIcon.Question);
                loadRecords();
            }
        }

        private void btnEnroll_Click(object sender, EventArgs e)
        {
            var frm = new frm_student_enrollment();
            frm.Text = "Enrollment: " + dgv.CurrentRow.Cells["id_number"].Value.ToString();
            frm_student_enrollment.instance.id_number = dgv.CurrentRow.Cells["id_number"].Value.ToString();
            frm_student_enrollment.instance.studentName = dgv.CurrentRow.Cells["fullname"].Value.ToString();
            frm_student_enrollment.instance.school_year = dgv.CurrentRow.Cells["school_year"].Value.ToString();
            frm.ShowDialog();
            loadRecords();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            var frm = new frm_view_subjects();
            frm_view_subjects.instance.id_number = dgv.CurrentRow.Cells["id_number"].Value.ToString();
            frm_view_subjects.instance.fullname = dgv.CurrentRow.Cells["fullname"].Value.ToString();
            frm_view_subjects.instance.school_year = dgv.CurrentRow.Cells["school_year"].Value.ToString();
            frm.ShowDialog();
        }

        private void promoteStudent()
        {
            
        }

        private void btnPromoteStudent_Click(object sender, EventArgs e)
        {
            var frm = new frm_student_promotion
            {
                id_number = dgv.CurrentRow.Cells["id_number"].Value.ToString(),
                fullname = dgv.CurrentRow.Cells["fullname"].Value.ToString(),
                school_year = dgv.CurrentRow.Cells["school_year"].Value.ToString()
            };
            frm.ShowDialog();
            loadRecords();
        }
    }
}
