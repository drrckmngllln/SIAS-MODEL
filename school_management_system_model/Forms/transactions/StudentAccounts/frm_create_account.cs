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
        public string schoolYear { get; set; }
        public int id { get; set; }
        public string course { get; set; }
        public string campus { get; set; }
        public string semester { get; set; }
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
                loadCourses();
            }
            else if (this.Text == "Update Account")
            {
                tTitle.Text = this.Text;
                var update = new StudentAccount();
                var data = update.loadUpdateRecord(id);


                tIdNumber.Text = data.Rows[0]["id_number"].ToString();
                tSchoolyear.Text = data.Rows[0]["school_year"].ToString();
                tLastname.Text = data.Rows[0]["last_name"].ToString();
                tFirstname.Text = data.Rows[0]["first_name"].ToString();
                tMiddlename.Text = data.Rows[0]["middle_name"].ToString();
                cmbgender.Text = data.Rows[0]["Gender"].ToString();
                cmbcivilstat.Text = data.Rows[0]["civil_status"].ToString();
                tDateofBirth.Text = data.Rows[0]["date_of_birth"].ToString();
                tPlaceofBirth.Text = data.Rows[0]["Place_of_birth"].ToString();
                tNationality.Text = data.Rows[0]["Nationality"].ToString();
                tReligion.Text = data.Rows[0]["Religion"].ToString();
                tcontact.Text = data.Rows[0]["contact_no"].ToString();
                temail.Text = data.Rows[0]["Email"].ToString();
                telem.Text = data.Rows[0]["elem"].ToString();
                teyear.Text = data.Rows[0]["elem_year"].ToString();
                tjhs.Text = data.Rows[0]["JHS"].ToString();
                tjyear.Text = data.Rows[0]["jhs_year"].ToString();
                tshs.Text = data.Rows[0]["SHS"].ToString();
                tsyear.Text = data.Rows[0]["shs_year"].ToString();
                tmother.Text= data.Rows[0]["mother_name"].ToString() ;
                tmcontact.Text = data.Rows[0]["mother_no"].ToString();
                tfather.Text = data.Rows[0]["father_name"].ToString();
                tfcontact.Text = data.Rows[0]["father_no"].ToString();
                tadd.Text = data.Rows[0]["home_address"].ToString();
                tmoccupation.Text = data.Rows[0]["m_occupation"].ToString();
                tfoccupation.Text = data.Rows[0]["f_occupation"].ToString();
                tStatus.Text = data.Rows[0]["Status"].ToString();
                ctype.Text = data.Rows[0]["type_of_student"].ToString();
                kryptonDateTimePicker1 = new KryptonDateTimePicker();
               

                var UpdateCourseData = new StudentAccount().loadUpdateCourseRecord(tIdNumber.Text);

                tCourse.Text = UpdateCourseData.Rows[0]["course"].ToString();
                tCampus.Text = UpdateCourseData.Rows[0]["campus"].ToString();
                    

                btnCreate.Text = "Update Account";
            }
        }

        private void loadCourses()
        {
            var data = new StudentAccount();
        }

        private void loadSchoolYear()
        {
            tSchoolyear.Text = schoolYear;
            
        }
        private void loadIdNumber()
        {
            var data = new StudentAccount();
            int count = 0;
            count = data.countStudent(tSchoolyear.Text);
            var idNumber = DateTime.Now.Year.ToString();

            var semester = new StudentAccount();
            idNumber += "-" + semester.loadSemester(tSchoolyear.Text);

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
                        // Inserting of Course
                        course = tCourse.Text,
                        semester = semester,
                        campus = tCampus.Text
                    };
                    var add = new StudentAccount();

                    add.addRecord(parameter);
                    new school_management_system_model.Classes.Toastr("Success", "Account Saved");

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
                tCourse.Text = course;
                tCampus.Text = campus;
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
                tCourse.Text = course;
                tCampus.Text = campus;
            }
        }
    }
    }

