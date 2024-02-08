﻿using Krypton.Toolkit;
using school_management_system_model.Classes;
using school_management_system_model.Data.Repositories.Transaction;
using school_management_system_model.Reports.Datasets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace school_management_system_model.Forms.transactions.StudentAccounts
{
    public partial class frm_student_details : KryptonForm
    {
        StudentCourseRepository _studentCourseRepo = new StudentCourseRepository();
        public frm_student_details(string id_number, string student_name)
        {
            InitializeComponent();
            Id_Number = id_number;
            Student_Name = student_name;
        }

        public string Id_Number { get; }
        public string Student_Name { get; }

        private async void frm_student_details_Load(object sender, EventArgs e)
        {
            await loadRecords();
        }

        private void messageBox(string type, string message)
        {
            switch (type)
            {
                case "Success":
                    panelMessage.Visible = false;
                    break;
                case "Warning":
                    panelMessage.Visible = true;
                    messagePic.Image = Properties.Resources.warning;
                    tMessage.Text = message;
                    break;
                case "Loading":
                    panelMessage.Visible = true;
                    messagePic.Image = Properties.Resources.information;
                    tMessage.Text = message;
                    break;
            }
        }

        private async Task loadRecords()
        {
            messageBox("Loading", "Loading Data...");
            tStudentName.Text = Student_Name;

            await Task.Delay(100);
            var a = await _studentCourseRepo.GetAllAsync();
            var studentCourse = a.Where(x => x.id_number == Id_Number).FirstOrDefault();

            if (studentCourse != null)
            {
                messageBox("Success", "");
                tCourse.Text = studentCourse.course;
                tCampus.Text = studentCourse.campus;
                tCurriculum.Text = studentCourse.curriculum;
                tYearLevel.Text = studentCourse.year_level;
                tSection.Text = studentCourse.section;
                tSemester.Text = studentCourse.semester;
            }
            else
            {
                messageBox("Warning", "Student Not Enrolled!");
                panelMessage.Visible = true;
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}