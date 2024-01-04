﻿using Krypton.Toolkit;
using school_management_system_model.Authentication.Login;
using school_management_system_model.Classes;
using school_management_system_model.Controls;
using school_management_system_model.Forms.settings;
using school_management_system_model.Forms.settings.Schedule;
using school_management_system_model.Forms.settings.UserManagement;
using school_management_system_model.Forms.transactions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void AdmissionScheduleChecker()
        {
            bool EnrollmentSchedule = new MainRegistrar("Enrollment").ScheduleChecker();

            if (!EnrollmentSchedule)
            {
                btnStudentAccounts.Visible = false;
            }
        }


        private void frm_main_registrar_Load(object sender, EventArgs e)
        {
            loadUserCredentials();
            AuthenticationSession();
            AdmissionScheduleChecker();
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
            var frm = new frm_student_accounts
            {
                IsAdd = is_add,
                IsEdit = is_edit,
                IsDelete = is_delete,
            };
            frm.TopLevel = false;
            panelTask.Controls.Clear();
            panelTask.Controls.Add(frm);
            frm.Show();
        }

        // Settings Menu
        private void btnAdmissionSchedule_Click(object sender, EventArgs e)
        {
            var frm = new frm_admission_schedule();
            frm.TopLevel = false;
            panelTask.Controls.Clear();
            panelTask.Controls.Add(frm);
            frm.Show();
        }

        private void btnSchoolYear_Click(object sender, EventArgs e)
        {
            var frm = new frm_school_year();
            frm.TopLevel = false;
            panelTask.Controls.Clear();
            panelTask.Controls.Add(frm);
            frm.Show();
        }

        private void btnCourses_Click(object sender, EventArgs e)
        {
            var frm = new frm_courses();
            frm.TopLevel = false;
            panelTask.Controls.Clear();
            panelTask.Controls.Add(frm);
            frm.Show();
        }

        private void btnLevel_Click(object sender, EventArgs e)
        {
            var frm = new frm_levels();
            frm.TopLevel = false;
            panelTask.Controls.Clear();
            panelTask.Controls.Add(frm);
            frm.Show();
        }

        private void btnCampuses_Click(object sender, EventArgs e)
        {
            var frm = new frm_campuses();
            frm.TopLevel = false;
            panelTask.Controls.Clear();
            panelTask.Controls.Add(frm);
            frm.Show();
        }

        private void btnCurriculum_Click(object sender, EventArgs e)
        {
            var frm = new frm_curriculum();
            frm.TopLevel = false;
            panelTask.Controls.Clear();
            panelTask.Controls.Add(frm);
            frm.Show();
        }

        private void btnSections_Click(object sender, EventArgs e)
        {
            var frm = new frm_sections();
            frm.TopLevel = false;
            panelTask.Controls.Clear();
            panelTask.Controls.Add(frm);
            frm.Show();
        }

        private void btnUserManagement_Click(object sender, EventArgs e)
        {
            var frm = new frm_user_management();
            frm.TopLevel = false;
            panelTask.Controls.Clear();
            panelTask.Controls.Add(frm);
            frm.Show();
        }
    }
}
