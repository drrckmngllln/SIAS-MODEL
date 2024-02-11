﻿using Krypton.Toolkit;
using school_management_system_model.Classes;
using school_management_system_model.Classes.Parameters;
using school_management_system_model.Core.Entities;
using school_management_system_model.Data.Repositories.Setings;
using school_management_system_model.Data.Repositories.Transaction;
using school_management_system_model.Data.Repositories.Transaction.StudentAccounts;
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
    public partial class frm_create_account : KryptonForm
    {
        StudentAccountRepository _studentAccountRepo = new StudentAccountRepository();
        StudentCourseRepository _studentCoursesRepo = new StudentCourseRepository();
        CourseRepository _courseRepo = new CourseRepository();
        CampusRepository _campusRepo = new CampusRepository();
        SchoolYearRepository _schoolYearRepo = new SchoolYearRepository();

        public static frm_create_account instance;

        public int Id_Number { get; set; }
        public string School_Year { get; set; }
        public string Semester { get; set; }

        //public string schoolYear { get; set; }
        //public int id { get; set; }
        public string course { get; set; }
        public string campus { get; set; }
        //public string semester { get; set; }
        public frm_create_account()
        {
            instance = this;
            InitializeComponent();
        }

        private async void frm_create_account_Load(object sender, EventArgs e)
        {
            if (this.Text == "Create Account")
            {
                tTitle.Text = this.Text;
                loadSchoolYear();
                loadIdNumber();
            }
            else if (this.Text == "Update Account")
            {

                tTitle.Text = this.Text;
                var a = await _studentAccountRepo.GetAllAsync();
                var update = a.FirstOrDefault(x => x.id_number == Id_Number.ToString());

                var b = await _schoolYearRepo.GetAllAsync();
                var school_year = b.FirstOrDefault(x => x.id.ToString() == School_Year);

                tIdNumber.Text = update.id_number;
                tSchoolyear.Text = school_year.ToString();
                tLastname.Text = update.last_name;
                tFirstname.Text = update.first_name;
                tMiddlename.Text = update.middle_name;
                cmbgender.Text = update.gender;
                cmbcivilstat.Text = update.civil_status;
                tDateofBirth.Text = update.date_of_birth;
                tPlaceofBirth.Text = update.place_of_birth;
                tNationality.Text = update.nationality;
                tReligion.Text = update.religion;
                tcontact.Text = update.contact_no;
                temail.Text = update.email;
                telem.Text = update.elem;
                teyear.Text = update.elem_year;
                tjhs.Text = update.jhs;
                tjyear.Text = update.jhs_year;
                tshs.Text = update.shs;
                tsyear.Text = update.shs_year;
                tmother.Text = update.mother_name;
                tmcontact.Text = update.mother_no;
                tfather.Text = update.father_name;
                tfcontact.Text = update.father_no;
                tadd.Text = update.home_address;
                tmoccupation.Text = update.m_occupation;
                tfoccupation.Text = update.f_occupation;
                tStatus.Text = update.status;
                ctype.Text = update.type_of_student;
                kryptonDateTimePicker1 = new KryptonDateTimePicker();


                var UpdateCourseData = await _studentCoursesRepo.GetAllAsync();
                var c = UpdateCourseData.FirstOrDefault(x => x.course == tCourse.Text);

                tCourse.Text = c.course;
                tCampus.Text = c.campus;


                btnCreate.Text = "Update Account";
            }
        }

        private void loadSchoolYear()
        {
            tSchoolyear.Text = School_Year;
        }
        private async void loadIdNumber()
        {
            var a = await _studentAccountRepo.GetAllAsync();
            var data = a.Where(x => x.sy_enrolled == School_Year).Count();
            int count = 0;
            count = data;
            var idNumber = DateTime.Now.Year.ToString();


            idNumber += "-" + Semester;

            if (count < 9)
            {
                count++;
                idNumber += "-" + "000" + count.ToString();
            }
            else if (count < 99)
            {
                count++;
                idNumber += "-" + "00" + count.ToString();
            }
            else if (count < 999)
            {
                count++;
                idNumber += "-" + "0" + count.ToString();
            }
            else if (count < 9999)
            {
                count++;
                idNumber += "-" + count.ToString();
            }
            tIdNumber.Text = idNumber;
            tLastname.Select();
        }



        private async void addRecord()
        {
            try
            {
                if (this.Text == "Create Account")
                {
                    var a = await _schoolYearRepo.GetAllAsync();
                    var school_year = a.FirstOrDefault(x => x.code == School_Year);
                    var add = new StudentAccount
                    {
                        id_number = tIdNumber.Text,
                        school_year_id = school_year.id.ToString(),
                        fullname = tLastname.Text + ", " + tFirstname.Text + " " + tMiddlename.Text,
                        last_name = tLastname.Text,
                        first_name = tFirstname.Text,
                        middle_name = tMiddlename.Text,
                        gender = cmbgender.Text,
                        civil_status = cmbcivilstat.Text,
                        date_of_birth = tDateofBirth.Text,
                        place_of_birth = tPlaceofBirth.Text,
                        nationality = tNationality.Text,
                        religion = tReligion.Text,
                        contact_no = tcontact.Text,
                        email = temail.Text,
                        elem = telem.Text,
                        elem_year = teyear.Text,
                        jhs = tjhs.Text,
                        jhs_year = tjyear.Text,
                        shs = tshs.Text,
                        shs_year = tsyear.Text,
                        mother_name = tmother.Text,
                        mother_no = tmcontact.Text,
                        father_name = tfather.Text,
                        father_no = tfcontact.Text,
                        home_address = tadd.Text,
                        m_occupation = tmoccupation.Text,
                        f_occupation = tfoccupation.Text,
                        type_of_student = ctype.Text,
                        status = tStatus.Text,
                        sy_enrolled = tSchoolyear.Text,
                        date_of_admission = kryptonDateTimePicker1.Text,
                    };
                    await _studentAccountRepo.AddRecords(add);

                    var b = await _studentAccountRepo.GetAllAsync();
                    var id_number_id = b.FirstOrDefault(x => x.id_number == tIdNumber.Text);

                    var c = await _courseRepo.GetAllAsync();
                    var d  = await _campusRepo.GetAllAsync();
                    var course = new StudentCourses
                    {
                        id_number = id_number_id.id.ToString(),
                        course = c.FirstOrDefault(x => x.code == tCourse.Text).id.ToString(),
                        campus = d.FirstOrDefault(x => x.code == tCampus.Text).id.ToString(),
                        curriculum = "Not Set",
                        year_level = "Not Set",
                        section = "Not Set",
                        semester = Semester
                    };
                    await _studentCoursesRepo.AddRecords(course);
                    new Classes.Toastr("Success", "Account Saved");
                    Close();

                }
                else if (this.Text == "Update Account")
                {
                    var a = await _schoolYearRepo.GetAllAsync();
                    var school_year = a.FirstOrDefault(x => x.code == School_Year);
                    var edit = new StudentAccount
                    {
                        id = Id_Number,
                        id_number = tIdNumber.Text,
                        school_year_id = school_year.id.ToString(),
                        fullname = tLastname.Text + ", " + tFirstname.Text + " " + tMiddlename.Text,
                        last_name = tLastname.Text,
                        first_name = tFirstname.Text,
                        middle_name = tMiddlename.Text,
                        gender = cmbgender.Text,
                        civil_status = cmbcivilstat.Text,
                        date_of_birth = tDateofBirth.Text,
                        place_of_birth = tPlaceofBirth.Text,
                        nationality = tNationality.Text,
                        religion = tReligion.Text,
                        contact_no = tcontact.Text,
                        email = temail.Text,
                        elem = telem.Text,
                        elem_year = teyear.Text,
                        jhs = tjhs.Text,
                        jhs_year = tjyear.Text,
                        shs = tshs.Text,
                        shs_year = tsyear.Text,
                        mother_name = tmother.Text,
                        mother_no = tmcontact.Text,
                        father_name = tfather.Text,
                        father_no = tfcontact.Text,
                        home_address = tadd.Text,
                        m_occupation = tmoccupation.Text,
                        f_occupation = tfoccupation.Text,
                        type_of_student = ctype.Text,
                        status = tStatus.Text,
                        sy_enrolled = tSchoolyear.Text,
                        date_of_admission = kryptonDateTimePicker1.Text,

                    };
                    await _studentAccountRepo.UpdateRecords(edit);


                    new Classes.Toastr("Information", "Account Updated");
                    Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frm_create_account_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                addRecord();

            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            addRecord();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            tDateofBirth.Text = dateTimePicker1.Value.ToString("MM-dd-yyyy");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tCurriculum_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCreate_Click_1(object sender, EventArgs e)
        {
            addRecord();
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnSelect_Click_1(object sender, EventArgs e)
        {
            var frm = new frm_select_course();
            frm.ShowDialog();

            if (course != null)
            {
                var a = await _courseRepo.GetAllAsync();

                tCourse.Text = a.FirstOrDefault(x => x.id.ToString() == course).code;

                var b = await _campusRepo.GetAllAsync();
                tCampus.Text = b.FirstOrDefault(x => x.code == campus).code;
            }
        }
    }
}

