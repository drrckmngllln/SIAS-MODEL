﻿using school_management_system_model.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace school_management_system_model.Forms.transactions.Collection
{
    public partial class frm_statements_of_accounts : Form
    {
        public static frm_statements_of_accounts instance;
        public string fullname { get; set; }
        public string id_number { get; set; }
        public frm_statements_of_accounts()
        {
            instance = this;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var frm = new frm_select_student();
            frm.Text = "Select Student";
            frm.ShowDialog();
            if (id_number != null)
            {
                loadStudentRecords();
                loadRecords();
            }
        }

        private void loadStudentRecords()
        {
            var data = new StatementsOfAccounts();
            var studentDetails = data.loadStudentRecords(id_number);
            tIdNumber.Text = studentDetails.Rows[0]["id_number"].ToString();
            tCourse.Text = studentDetails.Rows[0]["course"].ToString();
            tCampus.Text = studentDetails.Rows[0]["campus"].ToString();
            tYearLevel.Text = studentDetails.Rows[0]["year_level"].ToString();
            tSemester.Text = studentDetails.Rows[0]["campus"].ToString();
        }

        private void loadRecords()
        {
            var data = new StatementsOfAccounts();
            var soa = data.loadLatestSOA(tIdNumber.Text);
            dgv.DataSource = soa;
            dgv.Columns["id"].Visible = false;
            dgv.Columns["id_number"].Visible = false;
            dgv.Columns["date"].HeaderText = "Date";
            dgv.Columns["reference_no"].HeaderText = "OR Number";
            dgv.Columns["particulars"].HeaderText = "Particulars";
            dgv.Columns["particulars"].Width = 400;
            dgv.Columns["debit"].HeaderText = "Debit";
            dgv.Columns["credit"].HeaderText = "Credit";
            dgv.Columns["balance"].HeaderText = "Balance";
            dgv.Columns["cashier_in_charge"].Visible = false;
        }

        private void tSearch_TextChanged(object sender, EventArgs e)
        {
            if (tSearch.Text.Length > 2)
            {
                var data = new StatementsOfAccounts();
                var search = data.searchRecords(tIdNumber.Text, tSearch.Text);
                dgv.DataSource = search;
            }
            else if (tSearch.Text.Length == 0)
            {
                loadRecords();
            }
        }
    }
}