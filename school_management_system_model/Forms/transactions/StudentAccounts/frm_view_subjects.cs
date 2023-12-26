﻿using Krypton.Toolkit;
using MySql.Data.MySqlClient;
using school_management_system_model.Classes;
using school_management_system_model.Reports.Accounting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace school_management_system_model.Forms.transactions.StudentAccounts
{
    public partial class frm_view_subjects : KryptonForm
    {
        public static frm_view_subjects instance;
        
        public string id_number { get; set; }
        public string fullname { get; set; }
        public string school_year { get; set; }

        public string subjectCode { get; set; }
        public int Id { get; set; }
        int totalUnits = 0;
        int totalLectureUnits = 0;
        int totalLabUnits = 0;

        public frm_view_subjects()
        {
            instance = this;
            InitializeComponent();
        }

        private void frm_view_subjects_Load(object sender, EventArgs e)
        {
            tIdNumber.Text = id_number + " - " + fullname;
            tSchoolYear.Text = school_year;
            loadRecords(id_number, school_year);
            loadSchoolYear();
        }
        private void loadSchoolYear()
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from school_year", con);
            var dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                tSchoolYear.Items.Add(row["code"]);
            }
        }

        private void loadRecords(string idNumber, string schoolYear)
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from student_subjects where id_number='" + idNumber + "' and school_year='" + schoolYear + "'", con);
            var dt = new DataTable();
            da.Fill(dt);

            dgv.Columns.Clear();
            dgv.Columns.Add("subject_code", "Subject Code");
            dgv.Columns.Add("descriptive_title", "Descriptive Title");
            dgv.Columns.Add("pre_requisite", "Pre Requisites");
            dgv.Columns.Add("total_units", "Total Units");
            dgv.Columns.Add("lecture_units", "Lecture Units");
            dgv.Columns.Add("lab_units", "Lab Units");
            dgv.Columns.Add("time", "Time");
            dgv.Columns.Add("day", "Day");
            dgv.Columns.Add("room", "Room");
            dgv.Columns.Add("instructor", "Instructor");
            dgv.Columns.Add("grade", "Grade");
            dgv.Columns.Add("remarks", "Remarks");

            decimal totalUnits = 0;
            decimal lectureUnits = 0;
            decimal labUnits = 0;
            dgv.Rows.Clear();
            foreach (DataRow row in dt.Rows)
            {
                dgv.Rows.Add(
                    row["subject_code"],
                    row["descriptive_title"],
                    row["pre_requisite"],
                    row["total_units"],
                    row["lecture_units"],
                    row["lab_units"],
                    row["time"],
                    row["day"],
                    row["room"],
                    row["instructor"],
                    row["grade"],
                    row["remarks"]
                    );
                totalUnits += Convert.ToDecimal(row["total_units"]);
                lectureUnits += Convert.ToDecimal(row["lecture_units"]);
                labUnits += Convert.ToDecimal(row["lab_units"]);
            }
            dgv.Rows.Add("", "Total:", "", totalUnits, lectureUnits, labUnits);



            dgv.Columns["subject_code"].HeaderText = "Subject Code";
            dgv.Columns["descriptive_title"].HeaderText = "Descriptive Title";
            dgv.Columns["descriptive_title"].Width = 350;
            dgv.Columns["pre_requisite"].HeaderText = "Pre Requisite";
            dgv.Columns["total_units"].HeaderText = "Total Units";
            dgv.Columns["lecture_units"].HeaderText = "Lecture Units";
            dgv.Columns["time"].HeaderText = "Time";
            dgv.Columns["day"].HeaderText = "Day";
            dgv.Columns["room"].HeaderText = "Room";
            dgv.Columns["instructor"].HeaderText = "Instructor";
            dgv.Columns["grade"].HeaderText = "Grade";
            dgv.Columns["remarks"].HeaderText = "Remarks";
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tSchoolYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadRecords(id_number, tSchoolYear.Text);
        }

        private void btnEnroll_Click(object sender, EventArgs e)
        {
            var frm = new frm_input_grade
            {
                id_number = id_number,
                subject_code = dgv.CurrentRow.Cells["subject_code"].Value.ToString()
            };
            frm.ShowDialog();
            loadRecords(id_number, school_year);
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int grade = 0;
                grade = Convert.ToInt32(dgv.CurrentRow.Cells["grade"].Value);
                if (grade == 0)
                {
                    tGrade.Text = "No Grade";
                }
                else
                {
                    tGrade.Text = dgv.CurrentRow.Cells["grade"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dropSubject(string subjectCode)
        {


            if (MessageBox.Show("Are you sure you want to drop this subject?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var con = new MySqlConnection(connection.con());
                con.Open();
                var cmd = new MySqlCommand("update student_subjects where id_number='" + id_number + "' and subject_code='" + subjectCode + "'", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Subject Dropped!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadRecords(id_number, school_year);
            }

        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            var frm = new frm_add_subject
            {
                idnumber = id_number,
                schoolyear = school_year,
            };

            frm.ShowDialog();

            var addCustomSubject = new proceed_to_enrollment
            {
                id = Id
            };
            var data = addCustomSubject.addCustomSubject();

            if (Id != 0)
            {
                dgv.Rows.Add(
                data.Rows[0]["subject_code"],
                data.Rows[0]["descriptive_title"],
                data.Rows[0]["pre_requisite"],
                data.Rows[0]["total_units"],
                data.Rows[0]["lecture_units"],
                data.Rows[0]["lab_units"],
                data.Rows[0]["time"],
                data.Rows[0]["day"],
                data.Rows[0]["room"],
                data.Rows[0]["instructor"]
                );

                int lastRow = dgv.Rows.Count - 1;
                totalUnits += Convert.ToInt32(dgv.Rows[lastRow].Cells["total_units"].Value);
                totalLectureUnits += Convert.ToInt32(dgv.Rows[lastRow].Cells["lecture_units"].Value);
                totalLabUnits += Convert.ToInt32(dgv.Rows[lastRow].Cells["lab_units"].Value);
            }

        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to drop this subject!", "Warning", MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                var idnumber = id_number;
                string subjectcode = dgv.CurrentRow.Cells["subject_code"].Value.ToString();
                var con = new MySqlConnection(connection.con());
                con.Open();
                var cmd = new MySqlCommand("delete from student_subjects where id_number='" + id_number + "' and subject_code='" + dgv.CurrentRow.Cells["subject_code"].Value.ToString() + "'", con);
            
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Subject Dropped!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadRecords(id_number, school_year);
            }
          
        }
        public string studentCampus(string idNumber)
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from student_course where id_number='" + idNumber + "'", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt.Rows[0]["campus"].ToString();
        }

        
    }
}


