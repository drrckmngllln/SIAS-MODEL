using Krypton.Toolkit;
using school_management_system_model.Classes;
using school_management_system_model.Core.Entities;
using school_management_system_model.Data.Repositories.Setings;
using school_management_system_model.Data.Repositories.Setings.Section;
using school_management_system_model.Data.Repositories.Transaction;
using school_management_system_model.Data.Repositories.Transaction.StudentAccounts;
using school_management_system_model.Data.Repositories.Transaction.StudentAssessment;
using school_management_system_model.Forms.transactions.StudentEnrollment;
using school_management_system_model.Loggers;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace school_management_system_model.Forms.transactions
{
    public partial class frm_student_enrollment : KryptonForm
    {
        SectionSubjectRepository _sectionSubjectRepo = new SectionSubjectRepository();
        SectionRepository _sectionRepository = new SectionRepository();
        StudentAccountRepository _studentAccountRepo = new StudentAccountRepository();
        StudentSubjectRepository _studentSubjectRepo = new StudentSubjectRepository();
        StudentCourseRepository _studentCourseRepo = new StudentCourseRepository();
        InstructorRepository _instructorRepo = new InstructorRepository();
        SchoolYearRepository _schoolYearRepo = new SchoolYearRepository();
        CurriculumRepository _curriculumRepo = new CurriculumRepository();


        public int Id { get; set; }
        public string id_number { get; set; }
        public string studentName { get; set; }
        public string course { get; set; }
        public string section { get; set; }
        public string section_code { get; set; }
        public string school_year_id { get; set; }
        public string Email { get; }

        decimal totalUnits = 0;
        decimal totalLectureUnits = 0;
        decimal totalLabUnits = 0;


        public DataTable dt = new DataTable();

        public static frm_student_enrollment instance;

        public frm_student_enrollment(string Email)
        {
            instance = this;
            InitializeComponent();
            this.Email = Email;
        }

        private async void frm_student_enrollment_Load(object sender, EventArgs e)
        {
            await loadRecords();
            await LoadingStudent();
        }

        private async Task LoadingStudent()
        {
            await Task.Delay(500);
            tStudentLoading.Visible = false;
        }

        private async Task EnrollingStudent()
        {
            await Task.Delay(200);
            tLoading.Visible = true;
        }

        private async Task loadSection()
        {
            try
            {
                var section = await _sectionRepository.GetAllAsync();
                var a = section.FirstOrDefault(x => x.course.ToString() == tCourse.Text && x.semester == tSemester.Text && x.year_level.ToString() == tYearLevel.Text);

                if (a == null)
                {
                    tSection.Text = "No Section Exist";
                }
                else
                {
                    tSection.Text = a.section_code;
                }

                await loadSectionSubjects(tSection.Text);
            }
            catch (Exception ex)
            {
                new Classes.Toastr("Warning", ex.Message);
            }
        }

        private async Task loadCurriculum(string course)
        {
            var curriculums = await _curriculumRepo.GetAllAsync();
            var loadCurriculum = curriculums.Where(x => x.course == course).ToList();

            tCurriculum.ValueMember = "id";
            tCurriculum.DisplayMember = "code";

            tCurriculum.DataSource = loadCurriculum;

        }



        private async Task loadRecords()
        {
            var schoolYears = await _schoolYearRepo.GetAllAsync();
            var sy = schoolYears.FirstOrDefault(x => x.code == school_year_id);


            var a = await _studentAccountRepo.GetAllAsync();
            var student_account = a.FirstOrDefault(x => x.id_number == id_number);
            var student_course = await _studentCourseRepo.GetAllAsync();
            var b = student_course.FirstOrDefault(x => x.id_number == id_number);
            tIdNumber.Text = student_account.id_number;
            tStudentName.Text = student_account.fullname;
            tCourse.Text = b.course;
            tCampus.Text = b.campus;
            tCurriculum.Text = b.curriculum;
            tSection.Text = b.section;
            tYearLevel.Text = b.year_level;
            tSemester.Text = sy.semester;
            tYearLevel.Select();




            dgv.Columns.Add("subject_code", "Subject Code");
            dgv.Columns.Add("descriptive_title", "Descriptive Title");
            dgv.Columns.Add("pre_requisite", "Pre Requisite");
            dgv.Columns.Add("total_units", "Total Units");
            dgv.Columns.Add("lecture_units", "Lecture Units");
            dgv.Columns.Add("lab_units", "Lab Units");
            dgv.Columns.Add("time", "Time");
            dgv.Columns.Add("day", "Day");
            dgv.Columns.Add("room", "Room");
            dgv.Columns.Add("instructor", "Instructor");
            dgv.Columns["instructor"].Width = 300;
            dgv.Columns["descriptive_title"].Width = 400;

        }

        private async Task loadSectionSubjects(string section_code)
        {
            if (tCurriculum.Text.Length == 0 && tSemester.Text.Length == 0)
            {

                new Classes.Toastr("Warning", "Please select a Curriculum and Semester");
            }
            else
            {
                dgv.Rows.Clear();
                totalUnits = 0;
                totalLectureUnits = 0;
                totalLabUnits = 0;
                var sectionSubjects = await _sectionSubjectRepo.GetAllAsync();
                var loadSubjects = sectionSubjects.Where(x => x.section_code == section_code)
                .ToList();

                if (tSection.Text == "No Section Exist")
                {
                    dgv.Rows.Clear();
                }
                else
                {
                    foreach (var item in loadSubjects)
                    {
                        dgv.Rows.Add(
                            item.subject_code, item.descriptive_title, item.pre_requisite, item.total_units,
                            item.lecture_units, item.lab_units, item.time, item.day, item.room, item.instructor
                            );
                        totalUnits += Convert.ToDecimal(item.total_units);
                        totalLectureUnits += Convert.ToDecimal(item.lecture_units);
                        totalLabUnits += Convert.ToDecimal(item.lab_units);
                    }
                }
            }
        }


        private void kryptonTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            var frm = new frm_add_courses();
            frm.Text = "Add Course";
            frm.ShowDialog();
            tCourse.Text = course;

            var curriculum = new add_course
            {
                curriculum = course
            };
            curriculum.loadCurriculum();
            foreach (DataRow item in dt.Rows)
            {
                tCurriculum.Items.Add(item["code"]);
            }
        }

        private void tCurriculum_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            dgv.Rows.Remove(dgv.CurrentRow);
        }

        private async Task SaveStudentCourse()
        {
            var id = await _studentCourseRepo.GetAllAsync();
            var a = id.FirstOrDefault(x => x.id_number == tIdNumber.Text);
            var section = await _sectionRepository.GetAllAsync();
            var b = section.FirstOrDefault(x => x.section_code == tSection.Text);
            var enrollStudent = new StudentCourses();
            await _studentCourseRepo.EnrolStudent(a.id, tYearLevel.Text, b.id.ToString());
        }

        private async Task IncrementingSectionNumber()
        {
            var sections = await _sectionRepository.GetAllAsync();
            var a = sections.FirstOrDefault(x => x.section_code == tSection.Text);
            var numberOfStudent = a.number_of_students + 1;

            var section = await _sectionRepository.GetAllAsync();
            var sectionId = section.FirstOrDefault(x => x.section_code == tSection.Text).id;
            _sectionRepository.IncrementNumberOfStudent(sectionId, numberOfStudent);
        }

        private async Task SavingOfSubjects()
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                var a = await _studentAccountRepo.GetAllAsync();
                var id_number = a.FirstOrDefault(x => x.id_number == tIdNumber.Text).id;

                var b = await _schoolYearRepo.GetAllAsync();
                var school_year = b.FirstOrDefault(x => x.code == school_year_id).id;
                var subject_code = row.Cells["subject_code"].Value.ToString();
                var unique_id = id_number.ToString() + school_year.ToString() + subject_code.ToString();
                var descriptive_title = row.Cells["descriptive_title"].Value.ToString();
                var pre_requisite = row.Cells["pre_requisite"].Value.ToString();
                var total_units = row.Cells["total_units"].Value.ToString();
                var lecture_units = row.Cells["lecture_units"].Value.ToString();
                var lab_units = row.Cells["lab_units"].Value.ToString();
                var time = row.Cells["time"].Value.ToString();
                var day = row.Cells["day"].Value.ToString();
                var room = row.Cells["room"].Value.ToString();

                var ins = await _instructorRepo.GetAllAsync();
                string instructor;
                if (row.Cells["instructor"].Value.ToString() == "Not Set")
                {
                    instructor = "Not Set";
                }
                else
                {
                    instructor = ins.FirstOrDefault(x => x.fullname == row.Cells["instructor"].Value.ToString()).fullname;
                }


                var studentSubject = new StudentSubject
                {
                    id_number_id = id_number.ToString(),
                    school_year_id = school_year.ToString(),
                    subject_code = subject_code,
                    unique_id = unique_id,
                    descriptive_title = descriptive_title,
                    pre_requisite = pre_requisite,
                    total_units = total_units,
                    lecture_units = lecture_units,
                    lab_units = lab_units,
                    time = time,
                    day = day,
                    room = room,
                    instructor_id = instructor
                };
                await _studentSubjectRepo.AddRecords(studentSubject);

            }
        }

        private async Task ChangeStudentStatus()
        {
            await _studentAccountRepo.ChangeStudentStatus(tIdNumber.Text);
        }

        private async Task saveAllChanges()
        {
            // INCREMENTING OF SECTIONS

            var section = await _sectionRepository.GetAllAsync();
            var a = section.FirstOrDefault(x => x.section_code == tSection.Text);
            var studentCourse = await _studentCourseRepo.GetAllAsync();
            var b = studentCourse.FirstOrDefault(x => x.id_number == tIdNumber.Text);

            if (a.number_of_students <= a.max_number_of_students)
            {
                // STUDENT COURSE
                await SaveStudentCourse();
                // INCREMENTING NUMBER OF STUDENTS IN SECTIONS
                await IncrementingSectionNumber();
                // SAVING THE SUBJECTS
                await SavingOfSubjects();
                // CHANGING THE STATUS OF STUDENT ACCOUNT TO ACCOUNTING
                await ChangeStudentStatus();

                new Classes.Toastr("Success", "Student Enrolled!");
                new ActivityLogger().activityLogger(Email, "Student Enrollment: " + tIdNumber.Text);
                Close();
            }
            else
            {
                new Classes.Toastr("Warning", "Section is Full!");
                var sections = await _sectionRepository.GetAllAsync();
                var sectionId = sections.FirstOrDefault(x => x.section_code == tSection.Text).id;
                _sectionRepository.FullStudent(sectionId);
            }

        }

        private async void kryptonButton4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to enrol these subjects?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                await EnrollingStudent();
                await saveAllChanges();
            }
        }

        private void kryptonButton5_Click(object sender, EventArgs e)
        {
            //if (tCourse.Text == "")
            //{
            //    MessageBox.Show("Error, no course selected", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //else
            //{
            //    var frm = new frm_select_section();
            //    frm_select_section.instance.course = tCourse.Text;
            //    frm.Text = "Select Section";
            //    frm.ShowDialog();
            //    tSection.Text = section;

            //}
        }

        private async void tCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            await loadCurriculum(course);
        }

        private async void kryptonButton1_Click_1(object sender, EventArgs e)
        {
            var frm = new frm_select_subject();
            frm.Text = "Add Subject";
            frm.ShowDialog();


            var customSubject = await _sectionSubjectRepo.GetAllAsync();

            var subject = customSubject.FirstOrDefault(x => x.id == Id);


            if (Id != 0)
            {

                dgv.Rows.Add
                   (
                       subject.subject_code,
                       subject.descriptive_title,
                       subject.pre_requisite,
                       subject.total_units,
                       subject.lecture_units,
                       subject.lab_units,
                       subject.time,
                       subject.day,
                       subject.room,
                       subject.instructor
                   );

                int lastRow = dgv.Rows.Count - 1;
                //totalUnits += Convert.ToInt32(dgv.Rows[lastRow].Cells["total_units"].Value);
                totalUnits += Convert.ToDecimal(subject.total_units);
                //totalLectureUnits += Convert.ToInt32(dgv.Rows[lastRow].Cells["lecture_units"].Value);
                totalLectureUnits += Convert.ToDecimal(subject.lecture_units);
                //totalLabUnits += Convert.ToInt32(dgv.Rows[lastRow].Cells["lab_units"].Value);
                totalLabUnits += Convert.ToDecimal(subject.lecture_units);
            }



        }
        private void tSemester_TextChanged(object sender, EventArgs e)
        {

        }

        private void timerCounter_Tick(object sender, EventArgs e)
        {
            //CountUnits();
            tTotalUnits.Text = totalUnits.ToString();
            tLectureUnits.Text = totalLectureUnits.ToString();
            tLabUnits.Text = totalLabUnits.ToString();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to remove this subject?", "Warning",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                totalUnits -= Convert.ToDecimal(dgv.CurrentRow.Cells["total_units"].Value);
                totalLectureUnits -= Convert.ToDecimal(dgv.CurrentRow.Cells["lecture_units"].Value);
                totalLabUnits -= Convert.ToDecimal(dgv.CurrentRow.Cells["lab_units"].Value);
                dgv.Rows.Remove(dgv.CurrentRow);
            }
        }

        private async void tYearLevel_TextChanged(object sender, EventArgs e)
        {
            if (tYearLevel.Text.Length == 1)
            {
                await loadSection();
            }
            else if (tYearLevel.Text.Length == 0)
            {
                dgv.Rows.Clear();
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var frm = new frm_select_course();
            frm.Text = "Select Course";
            frm.ShowDialog();
            if (course != null)
            {
                //tLoading.Visible = true;
                //await Task.Delay(200);
                //tLoading.Visible = false;

                tCourse.Text = course;

                await loadSection();
                await loadCurriculum(course);
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            var frm = new frm_select_section(tCourse.Text, tSemester.Text, tYearLevel.Text);
            frm.Text = "Select Subjects";
            frm.ShowDialog();
            if (section != null)
            {
                tSection.Text = section;
                await loadSectionSubjects(tSection.Text);
            }
        }
    }
}
