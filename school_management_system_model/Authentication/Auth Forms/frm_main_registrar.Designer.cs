﻿namespace school_management_system_model.Authentication.Auth_Forms.Registrar
{
    partial class frm_main_registrar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelUserDetails = new System.Windows.Forms.Panel();
            this.tLogout = new System.Windows.Forms.Label();
            this.tAccesslevel = new System.Windows.Forms.Label();
            this.tUsername = new System.Windows.Forms.Label();
            this.userPic = new System.Windows.Forms.PictureBox();
            this.btnTransaction = new System.Windows.Forms.Button();
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.panelSettings = new System.Windows.Forms.Panel();
            this.btnUserManagement = new System.Windows.Forms.Button();
            this.btnSections = new System.Windows.Forms.Button();
            this.btnCurriculum = new System.Windows.Forms.Button();
            this.btnCampuses = new System.Windows.Forms.Button();
            this.btnLevel = new System.Windows.Forms.Button();
            this.btnCourses = new System.Windows.Forms.Button();
            this.btnSchoolYear = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.panelTransaction = new System.Windows.Forms.Panel();
            this.btnAdmissionSchedule = new System.Windows.Forms.Button();
            this.btnStudentAccounts = new System.Windows.Forms.Button();
            this.panelTask = new System.Windows.Forms.Panel();
            this.panelUserDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userPic)).BeginInit();
            this.panelSidebar.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.panelSettings.SuspendLayout();
            this.panelTransaction.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelUserDetails
            // 
            this.panelUserDetails.Controls.Add(this.tLogout);
            this.panelUserDetails.Controls.Add(this.tAccesslevel);
            this.panelUserDetails.Controls.Add(this.tUsername);
            this.panelUserDetails.Controls.Add(this.userPic);
            this.panelUserDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelUserDetails.Location = new System.Drawing.Point(0, 0);
            this.panelUserDetails.Name = "panelUserDetails";
            this.panelUserDetails.Size = new System.Drawing.Size(250, 160);
            this.panelUserDetails.TabIndex = 1;
            // 
            // tLogout
            // 
            this.tLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tLogout.ForeColor = System.Drawing.SystemColors.Control;
            this.tLogout.Location = new System.Drawing.Point(3, 122);
            this.tLogout.Name = "tLogout";
            this.tLogout.Size = new System.Drawing.Size(244, 23);
            this.tLogout.TabIndex = 3;
            this.tLogout.Text = "Logout";
            this.tLogout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tLogout.Click += new System.EventHandler(this.tLogout_Click);
            // 
            // tAccesslevel
            // 
            this.tAccesslevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tAccesslevel.ForeColor = System.Drawing.SystemColors.Control;
            this.tAccesslevel.Location = new System.Drawing.Point(3, 99);
            this.tAccesslevel.Name = "tAccesslevel";
            this.tAccesslevel.Size = new System.Drawing.Size(244, 23);
            this.tAccesslevel.TabIndex = 2;
            this.tAccesslevel.Text = "Access Level";
            this.tAccesslevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tUsername
            // 
            this.tUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tUsername.ForeColor = System.Drawing.SystemColors.Control;
            this.tUsername.Location = new System.Drawing.Point(3, 76);
            this.tUsername.Name = "tUsername";
            this.tUsername.Size = new System.Drawing.Size(244, 23);
            this.tUsername.TabIndex = 1;
            this.tUsername.Text = "Lastname, Firstname Middlename";
            this.tUsername.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // userPic
            // 
            this.userPic.Location = new System.Drawing.Point(78, 12);
            this.userPic.Name = "userPic";
            this.userPic.Size = new System.Drawing.Size(88, 61);
            this.userPic.TabIndex = 0;
            this.userPic.TabStop = false;
            // 
            // btnTransaction
            // 
            this.btnTransaction.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTransaction.FlatAppearance.BorderSize = 0;
            this.btnTransaction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransaction.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransaction.ForeColor = System.Drawing.SystemColors.Control;
            this.btnTransaction.Location = new System.Drawing.Point(0, 0);
            this.btnTransaction.Name = "btnTransaction";
            this.btnTransaction.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnTransaction.Size = new System.Drawing.Size(250, 50);
            this.btnTransaction.TabIndex = 1;
            this.btnTransaction.Text = "Transaction";
            this.btnTransaction.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTransaction.UseVisualStyleBackColor = true;
            this.btnTransaction.Click += new System.EventHandler(this.btnTransaction_Click);
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(25)))));
            this.panelSidebar.Controls.Add(this.panelMenu);
            this.panelSidebar.Controls.Add(this.panelUserDetails);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(250, 701);
            this.panelSidebar.TabIndex = 2;
            // 
            // panelMenu
            // 
            this.panelMenu.AutoScroll = true;
            this.panelMenu.Controls.Add(this.panelSettings);
            this.panelMenu.Controls.Add(this.btnSettings);
            this.panelMenu.Controls.Add(this.panelTransaction);
            this.panelMenu.Controls.Add(this.btnTransaction);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMenu.Location = new System.Drawing.Point(0, 160);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(250, 541);
            this.panelMenu.TabIndex = 2;
            // 
            // panelSettings
            // 
            this.panelSettings.Controls.Add(this.btnUserManagement);
            this.panelSettings.Controls.Add(this.btnSections);
            this.panelSettings.Controls.Add(this.btnCurriculum);
            this.panelSettings.Controls.Add(this.btnCampuses);
            this.panelSettings.Controls.Add(this.btnLevel);
            this.panelSettings.Controls.Add(this.btnCourses);
            this.panelSettings.Controls.Add(this.btnSchoolYear);
            this.panelSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSettings.Location = new System.Drawing.Point(0, 180);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Size = new System.Drawing.Size(250, 257);
            this.panelSettings.TabIndex = 4;
            this.panelSettings.Visible = false;
            // 
            // btnUserManagement
            // 
            this.btnUserManagement.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUserManagement.FlatAppearance.BorderSize = 0;
            this.btnUserManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserManagement.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserManagement.ForeColor = System.Drawing.SystemColors.Control;
            this.btnUserManagement.Location = new System.Drawing.Point(0, 180);
            this.btnUserManagement.Name = "btnUserManagement";
            this.btnUserManagement.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.btnUserManagement.Size = new System.Drawing.Size(250, 30);
            this.btnUserManagement.TabIndex = 10;
            this.btnUserManagement.Text = "User Management";
            this.btnUserManagement.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUserManagement.UseVisualStyleBackColor = true;
            // 
            // btnSections
            // 
            this.btnSections.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSections.FlatAppearance.BorderSize = 0;
            this.btnSections.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSections.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSections.ForeColor = System.Drawing.SystemColors.Control;
            this.btnSections.Location = new System.Drawing.Point(0, 150);
            this.btnSections.Name = "btnSections";
            this.btnSections.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.btnSections.Size = new System.Drawing.Size(250, 30);
            this.btnSections.TabIndex = 9;
            this.btnSections.Text = "Sections";
            this.btnSections.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSections.UseVisualStyleBackColor = true;
            // 
            // btnCurriculum
            // 
            this.btnCurriculum.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCurriculum.FlatAppearance.BorderSize = 0;
            this.btnCurriculum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCurriculum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCurriculum.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCurriculum.Location = new System.Drawing.Point(0, 120);
            this.btnCurriculum.Name = "btnCurriculum";
            this.btnCurriculum.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.btnCurriculum.Size = new System.Drawing.Size(250, 30);
            this.btnCurriculum.TabIndex = 8;
            this.btnCurriculum.Text = "Curriculum";
            this.btnCurriculum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCurriculum.UseVisualStyleBackColor = true;
            // 
            // btnCampuses
            // 
            this.btnCampuses.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCampuses.FlatAppearance.BorderSize = 0;
            this.btnCampuses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCampuses.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCampuses.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCampuses.Location = new System.Drawing.Point(0, 90);
            this.btnCampuses.Name = "btnCampuses";
            this.btnCampuses.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.btnCampuses.Size = new System.Drawing.Size(250, 30);
            this.btnCampuses.TabIndex = 7;
            this.btnCampuses.Text = "Campuses";
            this.btnCampuses.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCampuses.UseVisualStyleBackColor = true;
            // 
            // btnLevel
            // 
            this.btnLevel.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLevel.FlatAppearance.BorderSize = 0;
            this.btnLevel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLevel.ForeColor = System.Drawing.SystemColors.Control;
            this.btnLevel.Location = new System.Drawing.Point(0, 60);
            this.btnLevel.Name = "btnLevel";
            this.btnLevel.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.btnLevel.Size = new System.Drawing.Size(250, 30);
            this.btnLevel.TabIndex = 5;
            this.btnLevel.Text = "Level";
            this.btnLevel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLevel.UseVisualStyleBackColor = true;
            // 
            // btnCourses
            // 
            this.btnCourses.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCourses.FlatAppearance.BorderSize = 0;
            this.btnCourses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCourses.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCourses.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCourses.Location = new System.Drawing.Point(0, 30);
            this.btnCourses.Name = "btnCourses";
            this.btnCourses.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.btnCourses.Size = new System.Drawing.Size(250, 30);
            this.btnCourses.TabIndex = 3;
            this.btnCourses.Text = "Courses";
            this.btnCourses.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCourses.UseVisualStyleBackColor = true;
            // 
            // btnSchoolYear
            // 
            this.btnSchoolYear.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSchoolYear.FlatAppearance.BorderSize = 0;
            this.btnSchoolYear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSchoolYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSchoolYear.ForeColor = System.Drawing.SystemColors.Control;
            this.btnSchoolYear.Location = new System.Drawing.Point(0, 0);
            this.btnSchoolYear.Name = "btnSchoolYear";
            this.btnSchoolYear.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.btnSchoolYear.Size = new System.Drawing.Size(250, 30);
            this.btnSchoolYear.TabIndex = 2;
            this.btnSchoolYear.Text = "School Year";
            this.btnSchoolYear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSchoolYear.UseVisualStyleBackColor = true;
            // 
            // btnSettings
            // 
            this.btnSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.ForeColor = System.Drawing.SystemColors.Control;
            this.btnSettings.Location = new System.Drawing.Point(0, 130);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnSettings.Size = new System.Drawing.Size(250, 50);
            this.btnSettings.TabIndex = 3;
            this.btnSettings.Text = "Settings";
            this.btnSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // panelTransaction
            // 
            this.panelTransaction.Controls.Add(this.btnAdmissionSchedule);
            this.panelTransaction.Controls.Add(this.btnStudentAccounts);
            this.panelTransaction.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTransaction.Location = new System.Drawing.Point(0, 50);
            this.panelTransaction.Name = "panelTransaction";
            this.panelTransaction.Size = new System.Drawing.Size(250, 80);
            this.panelTransaction.TabIndex = 2;
            this.panelTransaction.Visible = false;
            // 
            // btnAdmissionSchedule
            // 
            this.btnAdmissionSchedule.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAdmissionSchedule.FlatAppearance.BorderSize = 0;
            this.btnAdmissionSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdmissionSchedule.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdmissionSchedule.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAdmissionSchedule.Location = new System.Drawing.Point(0, 30);
            this.btnAdmissionSchedule.Name = "btnAdmissionSchedule";
            this.btnAdmissionSchedule.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.btnAdmissionSchedule.Size = new System.Drawing.Size(250, 30);
            this.btnAdmissionSchedule.TabIndex = 3;
            this.btnAdmissionSchedule.Text = "Admission Schedule";
            this.btnAdmissionSchedule.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdmissionSchedule.UseVisualStyleBackColor = true;
            // 
            // btnStudentAccounts
            // 
            this.btnStudentAccounts.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStudentAccounts.FlatAppearance.BorderSize = 0;
            this.btnStudentAccounts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStudentAccounts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStudentAccounts.ForeColor = System.Drawing.SystemColors.Control;
            this.btnStudentAccounts.Location = new System.Drawing.Point(0, 0);
            this.btnStudentAccounts.Name = "btnStudentAccounts";
            this.btnStudentAccounts.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.btnStudentAccounts.Size = new System.Drawing.Size(250, 30);
            this.btnStudentAccounts.TabIndex = 2;
            this.btnStudentAccounts.Text = "Student Accounts";
            this.btnStudentAccounts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStudentAccounts.UseVisualStyleBackColor = true;
            this.btnStudentAccounts.Click += new System.EventHandler(this.btnStudentAccounts_Click);
            // 
            // panelTask
            // 
            this.panelTask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTask.Location = new System.Drawing.Point(250, 0);
            this.panelTask.Name = "panelTask";
            this.panelTask.Size = new System.Drawing.Size(1043, 701);
            this.panelTask.TabIndex = 3;
            // 
            // frm_main_registrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1293, 701);
            this.ControlBox = false;
            this.Controls.Add(this.panelTask);
            this.Controls.Add(this.panelSidebar);
            this.CornerRoundingRadius = 10F;
            this.Name = "frm_main_registrar";
            this.StateActive.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(25)))));
            this.StateActive.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(25)))));
            this.StateActive.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(25)))));
            this.StateActive.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(25)))));
            this.StateActive.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.StateActive.Header.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(25)))));
            this.StateActive.Header.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(25)))));
            this.StateActive.Header.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(25)))));
            this.StateActive.Header.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(25)))));
            this.StateActive.Header.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.StateActive.Header.Content.ShortText.Color1 = System.Drawing.SystemColors.Control;
            this.StateActive.Header.Content.ShortText.Color2 = System.Drawing.SystemColors.Control;
            this.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.StateCommon.Border.Rounding = 10F;
            this.StateInactive.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(25)))));
            this.StateInactive.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(25)))));
            this.StateInactive.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(25)))));
            this.StateInactive.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(25)))));
            this.StateInactive.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.StateInactive.Header.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(25)))));
            this.StateInactive.Header.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(25)))));
            this.StateInactive.Header.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(25)))));
            this.StateInactive.Header.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(25)))));
            this.StateInactive.Header.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.Text = "frm_main_registrar";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_main_registrar_Load);
            this.panelUserDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.userPic)).EndInit();
            this.panelSidebar.ResumeLayout(false);
            this.panelMenu.ResumeLayout(false);
            this.panelSettings.ResumeLayout(false);
            this.panelTransaction.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelUserDetails;
        private System.Windows.Forms.Label tAccesslevel;
        private System.Windows.Forms.Label tUsername;
        private System.Windows.Forms.PictureBox userPic;
        private System.Windows.Forms.Label tLogout;
        private System.Windows.Forms.Button btnTransaction;
        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelTransaction;
        private System.Windows.Forms.Button btnAdmissionSchedule;
        private System.Windows.Forms.Button btnStudentAccounts;
        private System.Windows.Forms.Panel panelSettings;
        private System.Windows.Forms.Button btnCourses;
        private System.Windows.Forms.Button btnSchoolYear;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnLevel;
        private System.Windows.Forms.Button btnCampuses;
        private System.Windows.Forms.Button btnUserManagement;
        private System.Windows.Forms.Button btnSections;
        private System.Windows.Forms.Button btnCurriculum;
        private System.Windows.Forms.Panel panelTask;
    }
}