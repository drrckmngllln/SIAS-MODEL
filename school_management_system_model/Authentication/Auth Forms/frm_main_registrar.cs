using Krypton.Toolkit;
using school_management_system_model.Authentication.Auth_Forms.UserCustomization;
using school_management_system_model.Authentication.Login;
using school_management_system_model.Forms.Reports.Registrar.MasterlistOfStudentEnrolled;
using school_management_system_model.Forms.settings;
using school_management_system_model.Forms.settings.Schedule;
using school_management_system_model.Forms.settings.UserManagement;
using school_management_system_model.Forms.transactions;
using school_management_system_model.Forms.transactions.StudentAccounts;
using System;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;

namespace school_management_system_model.Authentication.Auth_Forms.Registrar
{
    public partial class frm_main_registrar : KryptonForm
    {
        public static frm_main_registrar instance;
        public string fullname { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string access_level { get; set; }
        public bool is_add { get; set; }
        public bool is_edit { get; set; }
        public bool is_delete { get; set; }
        public bool isAdministrator { get; set; }
        public string picUrl { get; set; }

        const string Office = "Registrar";


        public frm_main_registrar()
        {
            instance = this;
            InitializeComponent();
        }

        private void AuthenticationSession()
        {
            if (isAdministrator)
            {
                btnSettings.Enabled = true;
            }
            else
            {
                btnSettings.Enabled = false;
            }
        }

       
        private void frm_main_registrar_Load(object sender, EventArgs e)
        {
            loadUserCredentials();
            AuthenticationSession();
        }

        private void loadUserCredentials()
        {
            tUsername.Text = fullname;
            tAccesslevel.Text = access_level;
        }

        private void tLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("are you sure you want to logout?","Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == DialogResult.Yes)
            {
                var frm = new frm_login();
                frm.Show();
                this.Close();
            }
        }

        private void btnTransaction_Click(object sender, EventArgs e)
        {
            if (panelTransaction.Visible == false)
            {
                panelTransaction.Visible = true;
                btnTransaction.BackColor = Color.FromArgb(0, 0, 100);
            }
            else if (panelTransaction.Visible == true)
            {
                panelTransaction.Visible = false;
                btnTransaction.BackColor = Color.FromArgb(0, 0, 25);
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            if (panelSettings.Visible == false)
            {
                panelSettings.Visible = true;
                btnSettings.BackColor = Color.FromArgb(0, 0, 100);
            }
            else
            {
                panelSettings.Visible = false;
                btnSettings.BackColor = Color.FromArgb(0, 0, 25);
            }
        }

        private void btnStudentAccounts_Click(object sender, EventArgs e)
        {
            var frm = new frmStudentAccountModule(email)
            {
                IsAdd = is_add,
                IsEdit = is_edit,
                IsDelete = is_delete,
                IsAdministrator = isAdministrator
            };
            frm.TopLevel = false;
            panelTask.Controls.Clear();
            panelTask.Controls.Add(frm);
            frm.Show();


            //var frm = new frmStudentAccountModule(email);
            //{
                
            //}
            //frm.TopLevel = false;
            //panelTask.Controls.Clear();
            //panelTask.Controls.Add(frm);
            //frm.Show();
        }

        // Settings Menu
        private void btnAdmissionSchedule_Click(object sender, EventArgs e)
        {
            var frm = new frm_admission_schedule(email);
            frm.TopLevel = false;
            panelTask.Controls.Clear();
            panelTask.Controls.Add(frm);
            frm.Show();
        }

        private void btnSchoolYear_Click(object sender, EventArgs e)
        {
            var frm = new frm_school_year(email);
            frm.TopLevel = false;
            panelTask.Controls.Clear();
            panelTask.Controls.Add(frm);
            frm.Show();
        }

        private void btnCourses_Click(object sender, EventArgs e)
        {
            var frm = new frm_courses(email);
            frm.TopLevel = false;
            panelTask.Controls.Clear();
            panelTask.Controls.Add(frm);
            frm.Show();
        }

        private void btnLevel_Click(object sender, EventArgs e)
        {
            var frm = new frm_levels(email);
            frm.TopLevel = false;
            panelTask.Controls.Clear();
            panelTask.Controls.Add(frm);
            frm.Show();
        }

        private void btnCampuses_Click(object sender, EventArgs e)
        {
            var frm = new frm_campuses(email);
            frm.TopLevel = false;
            panelTask.Controls.Clear();
            panelTask.Controls.Add(frm);
            frm.Show();
        }

        private void btnCurriculum_Click(object sender, EventArgs e)
        {
            var frm = new frm_curriculum(email);
            frm.TopLevel = false;
            panelTask.Controls.Clear();
            panelTask.Controls.Add(frm);
            frm.Show();
        }

        private void btnSections_Click(object sender, EventArgs e)
        {
            var frm = new frm_sections(email);
            frm.TopLevel = false;
            panelTask.Controls.Clear();
            panelTask.Controls.Add(frm);
            frm.Show();
        }

        private void btnUserManagement_Click(object sender, EventArgs e)
        {
            var frm = new frm_user_management(Office);
            frm.TopLevel = false;
            panelTask.Controls.Clear();
            panelTask.Controls.Add(frm);
            frm.Show();
        }

        private void btnDepartment_Click(object sender, EventArgs e)
        {
            var frm = new frm_departments(email);
            frm.TopLevel = false;
            panelTask.Controls.Clear();
            panelTask.Controls.Add(frm);
            frm.Show();
        }

        private void tUsername_Click(object sender, EventArgs e)
        {
           
        }

        private void btnInstructors_Click(object sender, EventArgs e)
        {
            var frm = new frm_instructors(email);
            frm.TopLevel = false;
            panelTask.Controls.Clear();
            panelTask.Controls.Add(frm);
            frm.Show();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            panelTask.Controls.Clear();
            panelTransaction.Visible = false;
            panelSettings.Visible = false;

            btnTransaction.BackColor = Color.FromArgb(0,0,25);
            btnSettings.BackColor = Color.FromArgb(0,0,25);
        }

        private void timerTime_Tick(object sender, EventArgs e)
        {
            tTime.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            if (panelReports.Visible == false)
            {
                panelReports.Visible = true;
                btnReports.BackColor = Color.FromArgb(0, 0, 100);
            }
            else
            {
                panelReports.Visible = false;
                btnReports.BackColor = Color.FromArgb(0, 0, 25);
            }
        }

        private void btnMasterlistOfStudent_Click(object sender, EventArgs e)
        {
            var frm = new frmMasterlistOfStudentEnrolledParentModule();
            frm.TopLevel = false;
            panelTask.Controls.Clear();
            panelTask.Controls.Add(frm);
            frm.Show();
        }

        private void btnEnrollment_Click(object sender, EventArgs e)
        {
            var frm = new frm_student_enrollment(email);
            frm.TopLevel = false;
            panelTask.Controls.Clear();
            panelTask.Controls.Add(frm);
            frm.Show();
        }
    }
}
