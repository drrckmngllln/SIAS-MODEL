using MySql.Data.MySqlClient;
using school_management_system_model.Classes;
using school_management_system_model.Data.Repositories.Setings;
using school_management_system_model.Data.Repositories.Transaction.StudentAccounts;
using school_management_system_model.Data.Repositories.Transaction.StudentAssessment;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace school_management_system_model.Forms.transactions.StudentAccounts
{
    public partial class frm_view_subjects : Form
    {
        StudentAccountRepository _studentAccountRepo = new StudentAccountRepository();
        SchoolYearRepository _schoolYearRepo = new SchoolYearRepository();
        StudentSubjectRepository _studentSubjectRepo = new StudentSubjectRepository();

        public static frm_view_subjects instance;
        public bool IsAdministrator { get; set; }

        public int id_number { get; set; }
        public string fullname { get; set; }
        public int school_year { get; set; }

        public string subjectCode { get; set; }
        public int Id { get; set; }

        public frm_view_subjects(int id_number_id, int school_year_id)
        {
            id_number = id_number_id;
            school_year = school_year_id;
            instance = this;

            InitializeComponent();
        }


        private async void frm_view_subjects_Load(object sender, EventArgs e)
        {
            await loadSchoolYear();
            await GetStudentDetails();
            loadRecords(id_number, school_year);
        }

        private async Task GetStudentDetails()
        {
            var student = await _studentAccountRepo.GetByIdAsync(id_number);
            tIdNumber.Text = student.id_number + " - " + student.fullname;
        }
        private async Task loadSchoolYear()
        {
            var schoolYear = await _schoolYearRepo.GetAllAsync();
            tSchoolYear.ValueMember = "id";
            tSchoolYear.DisplayMember = "code";
            tSchoolYear.DataSource = schoolYear;
        }

        private async void loadRecords(int idNumber, int schoolYear)
        {

            var studentsubject = await _studentSubjectRepo.GetStudentSubjectsAsync(idNumber, schoolYear);

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
            loadRecords(id_number, Convert.ToInt32(tSchoolYear.SelectedValue));
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


