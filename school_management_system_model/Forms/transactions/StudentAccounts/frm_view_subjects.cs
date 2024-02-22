using Krypton.Toolkit;
using MySql.Data.MySqlClient;
using school_management_system_model.Classes;
using school_management_system_model.Data.Repositories.Setings;
using school_management_system_model.Data.Repositories.Transaction.StudentAccounts;
using school_management_system_model.Data.Repositories.Transaction.StudentAssessment;
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
        StudentAccountRepository _studentAccountRepo = new StudentAccountRepository();
        SchoolYearRepository _schoolYearRepo = new SchoolYearRepository();
        StudentSubjectRepository _studentSubjectRepo = new StudentSubjectRepository();

        public static frm_view_subjects instance;
        public bool IsAdministrator { get; set; }

        public string id_number { get; set; }
        public string fullname { get; set; }
        public string school_year { get; set; }

        public string subjectCode { get; set; }
        public int Id { get; set; }

        public frm_view_subjects()
        {
            instance = this;

            InitializeComponent();
        }

        private void AdmissionChecker()
        {
            var schedule = new MainRegistrar("Adding and Dropping").ScheduleChecker();
            if (schedule || IsAdministrator)
            {
                btnAdd.Visible = true;
                btnDrop.Visible = true;
            }
            else
            {
                btnAdd.Visible = false;
                btnDrop.Visible = false;
            }
        }

        private void frm_view_subjects_Load(object sender, EventArgs e)
        {
            tIdNumber.Text = id_number + " - " + fullname;
            tSchoolYear.Text = school_year;
            loadSchoolYear();
            loadRecords(id_number, school_year);
            AdmissionChecker();
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

        private async void loadRecords(string idNumber, string schoolYear)
        {
            var a = await _studentAccountRepo.GetAllAsync();
            var idnumber = a.FirstOrDefault(x => x.id_number == idNumber);

            var b = await _schoolYearRepo.GetAllAsync();
            var schoolyear = b.FirstOrDefault(x => x.code == schoolYear);

            var studentSubjects = await _studentSubjectRepo.GetAllAsync();
            var studentsubject = studentSubjects
                .Where(x => x.id_number_id == idNumber && x.school_year_id == schoolYear)
                .ToList();

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
            dgv.Columns["descriptive_title"].Width = 350;


            decimal totalUnits = 0;
            decimal lectureUnits = 0;
            decimal labUnits = 0;
            dgv.Rows.Clear();

            foreach (var subject in studentsubject)
            {
                dgv.Rows.Add(
                    subject.subject_code,
                    subject.descriptive_title,
                    subject.pre_requisite,
                    subject.total_units,
                    subject.lecture_units,
                    subject.lab_units,
                    subject.time,
                    subject.day,
                    subject.room,
                    subject.instructor_id,
                    subject.grade,
                    subject.remarks
                    );
                totalUnits += Convert.ToDecimal(subject.total_units);
                lectureUnits += Convert.ToDecimal(subject.lecture_units);
                labUnits += Convert.ToDecimal(subject.lab_units);
            }
            dgv.Rows.Add("", "", "", totalUnits, lectureUnits, labUnits);
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
                var grade = dgv.CurrentRow.Cells["grade"].Value.ToString();
                if (grade == "No Grade")
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
                new Classes.Toastr("Warning", ex.Message);
            }
        }

        private DataTable addCustomSubject()
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from section_subjects where id='" + Id + "'", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            var frm = new frm_add_subject
            {
                idnumber = id_number,
                schoolyear = school_year,
            };

            frm.ShowDialog();

            var data = addCustomSubject();

            loadRecords(id_number, school_year);
        }

        private async void kryptonButton2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to drop this subject!", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var studentAccounts = await _studentAccountRepo.GetAllAsync();
                var idnumber = studentAccounts.FirstOrDefault(x => x.id_number == id_number).id;
                string subjectcode = dgv.CurrentRow.Cells["subject_code"].Value.ToString();
                var con = new MySqlConnection(connection.con());
                con.Open();
                var cmd = new MySqlCommand("delete from student_subjects where id_number_id='" + idnumber + "' and subject_code='" + dgv.CurrentRow.Cells["subject_code"].Value.ToString() + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Subject Dropped!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadRecords(id_number, tSchoolYear.Text);
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


