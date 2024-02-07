using Krypton.Toolkit;
using school_management_system_model.Classes;
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
    public partial class frm_create_account : KryptonForm
    {
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

        private void frm_create_account_Load(object sender, EventArgs e)
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
                var update = new StudentAccount().GetStudentAccounts().FirstOrDefault(x => x.id_number == Id_Number.ToString());

                var school_year = new SchoolYear().GetSchoolYears().FirstOrDefault(x => x.id.ToString() == School_Year);

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
               

                var UpdateCourseData = new StudentCourses().GetStudentCourses().FirstOrDefault(x => x.course == tCourse.Text);

                tCourse.Text = UpdateCourseData.course;
                tCampus.Text = UpdateCourseData.campus;
                    

                btnCreate.Text = "Update Account";
            }
        }

        private void loadSchoolYear()
        {
            tSchoolyear.Text = School_Year;
        }
        private void loadIdNumber()
        {
            
            var data = new StudentAccount().GetStudentAccounts().Where(x => x.sy_enrolled == School_Year).Count();
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

        
       
        private void addRecord()
        {
            try
            {
                if (this.Text == "Create Account")
                {
                    var school_year = new SchoolYear().GetSchoolYears().FirstOrDefault(x => x.code == School_Year);
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
                    add.AddStudentAccount();

                    var id_number_id = new StudentAccount().GetStudentAccounts().FirstOrDefault(x => x.id_number == tIdNumber.Text);
                    var course = new StudentCourses
                    {
                        id_number = id_number_id.id.ToString(),
                        course = new Courses().GetCourses().FirstOrDefault(x => x.code == tCourse.Text).id.ToString(),
                        campus = new Campuses().GetCampuses().FirstOrDefault(x => x.code == tCampus.Text).id.ToString(),
                        curriculum = "Not Set",
                        year_level = "Not Set",
                        section = "Not Set",
                        semester = Semester
                    };
                    course.AddStudentCourse();
                    new school_management_system_model.Classes.Toastr("Success", "Account Saved");
                    Close();

                }
                else if (this.Text == "Update Account")
                {
                    var parameter = new SaveStudentAccountsParams
                    {
                        id_number = tIdNumber.Text,
                        school_year = tSchoolyear.Text,
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
                        course = tCourse.Text,
                        campus = tCampus.Text
                    };
                    var edit = new StudentAccount();
                    edit.editRecord(parameter);

                    edit = new StudentAccount();


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

        private void btnSelect_Click(object sender, EventArgs e)
        {
            var frm = new frm_select_course();
            frm.ShowDialog();
            if (course != null)
            {
                tCourse.Text = new Courses().GetCourses().FirstOrDefault(x => x.code == course).code;
                tCampus.Text = new Campuses().GetCampuses().FirstOrDefault(x => x.code == campus).code;
            }
        }

        private void btnCreate_Click_1(object sender, EventArgs e)
        {
            addRecord();
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSelect_Click_1(object sender, EventArgs e)
        {
            var frm = new frm_select_course();
            frm.ShowDialog();
            if (course != null)
            {
                tCourse.Text = new Courses().GetCourses().FirstOrDefault(x => x.id.ToString() == course).code;
                tCampus.Text = campus;
            }
        }
    }
    }

