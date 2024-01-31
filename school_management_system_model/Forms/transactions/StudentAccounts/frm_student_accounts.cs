﻿using school_management_system_model.Classes;
using school_management_system_model.Classes.Parameters;
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
        public int id { get; set; }
        public bool IsAdd { get; set; }
        public bool IsEdit { get; set; }
        public bool IsDelete { get; set; }
        public bool IsAdministrator { get; set; }

        public static frm_student_accounts instance;
        public string schoolYear { get; set; }

        public bool AdmissionValidator { get; set; }
        public string Email { get; }

        PaginationParams paging = new PaginationParams();
        public frm_student_accounts(string email)
        {
            instance = this;
            InitializeComponent();
            Email = email;
            if (id != 0)
            {
                id = (int)dgv.CurrentRow.Cells["id"].Value;
            }
        }

        private void timerTotal_Tick(object sender, EventArgs e)
        {
            tTotal.Text = dgv.Rows.Count.ToString();
        }

        private void AdmissionScheduleChecker()
        {
            var schedule = new MainRegistrar("Enrollment").ScheduleChecker();
            if (schedule)
            {
                AdmissionValidator = true;
            }
            
        }
        private void getStudentCourse()
        {
            try
            {
                var id = dgv.CurrentRow.Cells["id_number"].Value.ToString();
                var student_course = new student_course().GetStudentCourses().FirstOrDefault(x => x.id_number_id == id.ToString()).course_id;
                var course = new Courses().GetCourses().FirstOrDefault(x => x.code.ToString() == student_course);
                tSudentCourse.Text = course.code;
            }
            catch(Exception ex)
            {
                new Classes.Toastr("Information", ex.Message);
            }
        }

        private void frm_student_accounts_Load(object sender, EventArgs e)
        {
            loadSchoolYear();
            loadRecords();
            AdmissionScheduleChecker();
        }

        private void loadRecords()
        {
            var data = new StudentAccount().GetStudentAccounts();
            data.Where(x => x.school_year_id == tSchoolYear.Text).Skip(paging.pageSize * (paging.pageNumber - 1)).Take(paging.pageSize).ToList();
            dgv.DataSource = data;
            dgv.Columns["id"].Visible = false;
            dgv.Columns["id_number"].HeaderText = "Student Number";
            dgv.Columns["sy_enrolled"].Visible = false;
            dgv.Columns["school_year_id"].Visible = false;
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
            dgv.Columns["contact_no"].HeaderText = "Contact Number";
            dgv.Columns["email"].HeaderText = "Email";
            dgv.Columns["elem"].HeaderText = "Elementary";
            dgv.Columns["jhs"].HeaderText = "Junior High School";
            dgv.Columns["shs"].HeaderText = "Senior High School";
            dgv.Columns["elem_year"].HeaderText = "Elementary Year";
            dgv.Columns["jhs_year"].HeaderText = "JHS Year";
            dgv.Columns["shs_year"].HeaderText = "Shs Year";
            dgv.Columns["mother_name"].HeaderText = "Mother Name";
            dgv.Columns["mother_no"].HeaderText = "Mother Contact No.";
            dgv.Columns["father_name"].HeaderText = "Father Name";
            dgv.Columns["father_no"].HeaderText = "Father Contact No.";
            dgv.Columns["home_address"].HeaderText = "Home Address ";
            dgv.Columns["m_occupation"].HeaderText = "Mother Occupation";
            dgv.Columns["f_occupation"].HeaderText = "Father Occupation";
            dgv.Columns["type_of_student"].HeaderText = "Type of Student";
            dgv.Columns["date_of_admission"].Visible = false;
        }

        private void loadSchoolYear()
        {
            var school_year = new SchoolYear().GetSchoolYears().FirstOrDefault(x => x.is_current == "Yes");
            ;
            tSchoolYear.Text = school_year.code;
            tSemester.Text = school_year.semester;
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

        private void CreateAccount()
        {
            var school_year = new SchoolYear().GetSchoolYears().FirstOrDefault(x => x.code == tSchoolYear.Text);
            var frm = new frm_create_account
            //(id_number_id, school_year.id.ToString(), school_year.semester);
            {
                School_Year = tSchoolYear.Text,
                Semester = school_year.semester
            };
            frm.Text = "Create Account";
            frm.ShowDialog();
            loadRecords();
        }
        private void UpdateAccount()
        {
            var id_number_id = Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value.ToString());
            var school_year = new SchoolYear().GetSchoolYears().FirstOrDefault(x => x.code == tSchoolYear.Text);
            var frm = new frm_create_account
            //(id_number_id, school_year.id.ToString(), school_year.semester);
            {
                Id_Number = id_number_id,
                School_Year = tSchoolYear.Text,
                Semester = school_year.semester
            };
            frm.Text = "Update Account";
            frm.ShowDialog();
            loadRecords();
        }

        
        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (btnCreate.Text == "Create Account")
            {
                if (IsAdd || IsAdministrator)
                {
                    if (AdmissionValidator || IsAdministrator)
                    {
                        CreateAccount();
                    }
                    else
                    {
                        new Classes.Toastr("Error", "No Enrollment Schedule Available");
                    }
                }
                else
                {
                    new Classes.Toastr("Error", "Authorization Denied");
                }
            }
            else if (btnCreate.Text == "Update Account")
            {
                if (IsEdit || IsAdministrator)
                {
                    UpdateAccount();
                }
                else
                {
                    new Classes.Toastr("Error", "Authorization Denied");
                }
            }
            
        }

        private void searchRecords(string search)
        {
            var searchRecord = new StudentAccount()
                .GetStudentAccounts()
                .Where(x => x.fullname.ToLower().Contains(search))
                .Skip(paging.pageSize * (paging.pageNumber - 1))
                .Take(paging.pageSize)
                .ToList();
            dgv.DataSource = searchRecord;
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
                btnApprove.Enabled = false;
            }

            if (dgv.CurrentRow.Cells["status"].Value.ToString() == "For Enrollment")
            {
                btnEnroll.Enabled = true;
            }
            else
            {
                btnEnroll.Enabled = false;
            }
            getStudentCourse();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            btnCreate.Text = "Create Account";
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (AdmissionValidator)
            {
                var frm = new frm_approve_account
                {
                    id_number_id = dgv.CurrentRow.Cells["id"].Value.ToString(),
                    fullname = dgv.CurrentRow.Cells["fullname"].Value.ToString()
                };
                frm.ShowDialog();
                loadRecords();
            }
            else
            {
                new Classes.Toastr("Warning", "No Scheduled Enrollment or Adding Schedule");
            }
        }

        private void btnEnroll_Click(object sender, EventArgs e)
        {
            if (AdmissionValidator)
            {
                var frm = new frm_student_enrollment(Email);
                frm.Text = "Enrollment: " + dgv.CurrentRow.Cells["id_number"].Value.ToString();
                frm_student_enrollment.instance.id_number = dgv.CurrentRow.Cells["id_number"].Value.ToString();
                frm_student_enrollment.instance.studentName = dgv.CurrentRow.Cells["fullname"].Value.ToString();
                frm_student_enrollment.instance.school_year_id = dgv.CurrentRow.Cells["school_year_id"].Value.ToString();
                frm.ShowDialog();
                loadRecords();
            }
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            
            var frm = new frm_view_subjects();
            frm_view_subjects.instance.id_number = dgv.CurrentRow.Cells["id_number"].Value.ToString();
            frm_view_subjects.instance.fullname = dgv.CurrentRow.Cells["fullname"].Value.ToString();
            frm_view_subjects.instance.school_year = dgv.CurrentRow.Cells["school_year_id"].Value.ToString();
            frm_view_subjects.instance.IsAdministrator = IsAdministrator;
            frm.ShowDialog();
            
        }

        private void btnPromoteStudent_Click(object sender, EventArgs e)
        {
            var frm = new frm_student_promotion
            {
                id_number = dgv.CurrentRow.Cells["id_number"].Value.ToString()
            };
            frm.ShowDialog();
            loadRecords();
        }

        private void btnSYoptions_Click(object sender, EventArgs e)
        {
            var frm = new frm_select_school_year();
            frm.ShowDialog();
            if (schoolYear != null)
            {
                tSchoolYear.Text = schoolYear;

            }
            btnCreate.Text = "Create Account";
            loadRecords();
        }

        private void btnCancelEnrollment_Click(object sender, EventArgs e)
        {

        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
