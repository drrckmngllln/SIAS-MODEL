using Krypton.Toolkit;
using school_management_system_model.Classes;
using school_management_system_model.Classes.Parameters;
using school_management_system_model.Forms.transactions.StudentEnrollment;
using school_management_system_model.Loggers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace school_management_system_model.Forms.transactions
{
    public partial class frm_student_enrollment : KryptonForm
    {
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

        private void frm_student_enrollment_Load(object sender, EventArgs e)
        {
            loadRecords();

        }

        private void loadSection()
        {
            try
            {
                var section = new sections().GetSections()
                    .FirstOrDefault(x => x.course_id.ToString() == tCourse.Text && x.semester == tSemester.Text && x.year_level.ToString() == tYearLevel.Text);

                if (section == null)
                {
                    tSection.Text = "No Section Exist";
                }
                else
                {
                    tSection.Text = section.section_code;
                }

                loadSectionSubjects();
            }
            catch (Exception ex)
            {
                new Classes.Toastr("Warning", ex.Message);
            }
        }

        private void loadCurriculum()
        {
            var curriculums = new Curriculums().GetCurriculums().Where(x => x.course_id == tCourse.Text);
            tCurriculum.ValueMember = "id";
            tCurriculum.DisplayMember = "code";
            tCurriculum.DataSource = curriculums.ToList();


            var campuses = curriculums.FirstOrDefault(x => x.course_id == tCourse.Text);

            if (campuses == null)
            {
                tCampus.Text = "No Campus Set";
            }
            else
            {
                tCampus.Text = campuses.campus_id;
            }
        }



        private void loadRecords()
        {

            var student_account = new StudentAccount().GetStudentAccounts().FirstOrDefault(x => x.id_number == id_number);
            var student_course = new student_course().GetStudentCourses().FirstOrDefault(x => x.id_number_id == id_number);

            tIdNumber.Text = student_account.id_number;
            tStudentName.Text = student_account.fullname;
            tCourse.Text = student_course.course_id;
            tCampus.Text = student_course.campus_id;
            tCurriculum.Text = student_course.curriculum_id;
            tSection.Text = student_course.section_id;
            tYearLevel.Text = student_course.year_level;
            tSemester.Text = student_course.semester;
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

        private void loadSectionSubjects()
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
                var sectionSubjects = new SectionSubjects().GetSectionSubjects()
                    .Where(x => x.section_code_id == tSection.Text && x.year_level == tYearLevel.Text)
                    .ToList();

                if (tSection.Text == "No Section Exist")
                {
                    dgv.Rows.Clear();
                }
                else
                {
                    foreach (var item in sectionSubjects)
                    {
                        dgv.Rows.Add(
                            item.subject_code, item.descriptive_title, item.pre_requisite, item.total_units,
                            item.lecture_units, item.lab_units, item.time, item.day, item.room, item.instructor_id
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

        private void SaveStudentCourse()
        {
            var section = new sections().GetSections().FirstOrDefault(x => x.section_code == tSection.Text);
            var id_number = new StudentAccount().GetStudentAccounts().FirstOrDefault(x => x.id_number == tIdNumber.Text);
            var course = new Courses().GetCourses().FirstOrDefault(x => x.code == tCourse.Text);
            var campus = new Campuses().GetCampuses().FirstOrDefault(x => x.code == tCampus.Text);
            var curriculum = new Curriculums().GetCurriculums().FirstOrDefault(x => x.code == tCurriculum.Text);
            var student_course = new student_course
            {
                id_number_id = id_number.id.ToString(),
                course_id = course.id.ToString(),
                campus_id = campus.id.ToString(),
                curriculum_id = curriculum.id.ToString(),
                year_level = tYearLevel.Text,
                section_id = section.id.ToString(),
            };
            student_course.UpdateStudentCourse(id_number.id);
        }

        private void IncrementingSectionNumber()
        {
            var sections = new sections().GetSections().FirstOrDefault(x => x.section_code == tSection.Text);
            var numberOfStudent = sections.number_of_students + 1;

            var section = new sections();
            var sectionId = section.GetSections().FirstOrDefault(x => x.section_code == tSection.Text).id;
            section.IncrementNumberOfStudent(sectionId, numberOfStudent);
        }

        private void SavingOfSubjects()
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                var id_number = new StudentAccount().GetStudentAccounts().FirstOrDefault(x => x.id_number == tIdNumber.Text).id;
                var school_year = new SchoolYear().GetSchoolYears().FirstOrDefault(x => x.code == school_year_id).id;
                var subject_code = row.Cells["subject_code"].Value.ToString();
                var unique_id = id_number + school_year + subject_code;
                var descriptive_title = row.Cells["descriptive_title"].Value.ToString();
                var pre_requisite = row.Cells["pre_requisite"].Value.ToString();
                var total_units = row.Cells["total_units"].Value.ToString();
                var lecture_units = row.Cells["lecture_units"].Value.ToString();
                var lab_units = row.Cells["lab_units"].Value.ToString();
                var time = row.Cells["time"].Value.ToString();
                var day = row.Cells["day"].Value.ToString();
                var room = row.Cells["room"].Value.ToString();
                var instructor = new Instructors().GetInstructors()
                    .FirstOrDefault(x => x.fullname == row.Cells["instructor"].Value.ToString()).id;

                var StudentSubject = new StudentSubject
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
                    instructor_id = instructor.ToString()
                };
                StudentSubject.SaveSectionSubjects();
            }
        }

        private void ChangeStudentStatus()
        {
            var studentStatus = new StudentAccount();
            studentStatus.ApproveStudent(tIdNumber.Text);
        }

        private void saveAllChanges()
        {
            // INCREMENTING OF SECTIONS

            var section = new sections().GetSections().FirstOrDefault(x => x.section_code == tSection.Text);
            var studentCourse = new student_course().GetStudentCourses().FirstOrDefault(x => x.id_number_id == tIdNumber.Text);

            if (section.number_of_students <= section.max_number_of_students)
            {
                // STUDENT COURSE
                SaveStudentCourse();
                // INCREMENTING NUMBER OF STUDENTS IN SECTIONS
                IncrementingSectionNumber();
                // SAVING THE SUBJECTS
                SavingOfSubjects();
                // CHANGING THE STATUS OF STUDENT ACCOUNT TO ACCOUNTING
                ChangeStudentStatus();

                new Classes.Toastr("Success", "Student Enrolled!");
                new ActivityLogger().activityLogger(Email, "Student Enrollment: " + tIdNumber.Text);
                Close();
            }
            else
            {
                new Classes.Toastr("Warning", "Section is Full!");
                var sections = new sections();
                var sectionId = sections.GetSections().FirstOrDefault(x => x.section_code == tSection.Text).id;
                sections.FullStudent(sectionId);
            }

        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to enrol these subjects?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                saveAllChanges();
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

        private void tCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadCurriculum();
        }

        private void kryptonButton1_Click_1(object sender, EventArgs e)
        {
            var frm = new frm_select_subject();
            frm.Text = "Add Subject";
            frm.ShowDialog();

            
            var customSubject = new SectionSubjects().GetSectionSubjects()
                .FirstOrDefault(x => x.id == Id);
           

            if (Id != 0)
            {
                
                dgv.Rows.Add
                    (
                        customSubject.subject_code,
                        customSubject.descriptive_title,
                        customSubject.pre_requisite,
                        customSubject.total_units,
                        customSubject.lecture_units,
                        customSubject.lab_units,
                        customSubject.time,
                        customSubject.day,
                        customSubject.room,
                        customSubject.instructor_id
                    );

                int lastRow = dgv.Rows.Count - 1;
                //totalUnits += Convert.ToInt32(dgv.Rows[lastRow].Cells["total_units"].Value);
                totalUnits += Convert.ToDecimal(customSubject.total_units);
                //totalLectureUnits += Convert.ToInt32(dgv.Rows[lastRow].Cells["lecture_units"].Value);
                totalLectureUnits += Convert.ToDecimal(customSubject.lecture_units);
                //totalLabUnits += Convert.ToInt32(dgv.Rows[lastRow].Cells["lab_units"].Value);
                totalLabUnits += Convert.ToDecimal(customSubject.lecture_units);
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
                tLoading.Visible = true;
                await Task.Delay(200);
                tLoading.Visible = false;
                loadSection();

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
                tLoading.Visible = true;
                await Task.Delay(200);
                tLoading.Visible = false;

                tCourse.Text = course;

                loadSection();
                loadCurriculum();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var frm = new frm_select_section(tCourse.Text, tSemester.Text, tYearLevel.Text);
            frm.Text = "Select Subjects";
            frm.ShowDialog();
            if (section != null)
            {
                tSection.Text = section;
                loadSectionSubjects();
            }
        }
    }
}
