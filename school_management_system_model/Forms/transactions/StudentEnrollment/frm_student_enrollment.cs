using Krypton.Toolkit;
using MySql.Data.MySqlClient;
using school_management_system_model.Classes;
using school_management_system_model.Forms.transactions.Classes;
using System;
using System.Data;
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
        public string school_year { get; set; }

        int totalUnits = 0;
        int totalLectureUnits = 0;
        int totalLabUnits = 0;


        public DataTable dt = new DataTable();

        public static frm_student_enrollment instance;
        public frm_student_enrollment()
        {
            instance = this;
            InitializeComponent();
        }

        private void frm_student_enrollment_Load(object sender, EventArgs e)
        {
            loadRecords();
            loadCourses();
        }

        private void loadSection()
        {
            tSection.Items.Clear();
            var section = new proceed_to_enrollment
            {
                course = tCourse.Text,
                semester = tSemester.Text
            };
            var data = section.loadSection();

            foreach(DataRow row in data.Rows)
            {
                tSection.Items.Add(row["section_code"]);
            }
        }

        private void loadCurriculum()
        {
            tCurriculum.Items.Clear();
            var curriculum = new proceed_to_enrollment
            {
                course = tCourse.Text
            };
            var data = curriculum.loadCurriculum();

            foreach(DataRow row in data.Rows)
            {
                tCurriculum.Items.Add(row["code"]);
            }

            var campus = new proceed_to_enrollment { course = tCourse.Text };
            tCampus.Text = campus.getCampus();
        }

        private void loadCourses()
        {
            var courses = new proceed_to_enrollment();
            var data = courses.loadCourses();

            foreach(DataRow row in data.Rows)
            {
                tCourse.Items.Add(row["code"]);
            }
        }

        private void loadRecords()
        {
            
            var loadCourse = new proceed_to_enrollment
            {
                id_number = id_number
            };
            var data = loadCourse.loadStudentIdAndCourse();

            tIdNumber.Text = id_number;
            tStudentName.Text = studentName;
            tCourse.Text = data.Rows[0]["course"].ToString();
            tCampus.Text = data.Rows[0]["campus"].ToString();
            tYearLevel.Text = data.Rows[0]["year_level"].ToString();
            tSection.Text = data.Rows[0]["section"].ToString();
            tSemester.Text = data.Rows[0]["semester"].ToString();

            dgv.Columns.Add("subject_code", "Subject Code");
            dgv.Columns.Add("descriptive_title", "Descriptive Title");
            dgv.Columns.Add("pre_requisite", "Pre Requisite");
            dgv.Columns.Add("total_units", "Total Units");
            dgv.Columns.Add("lecture_units", "Lecture Units");
            dgv.Columns.Add("lab_units", "Lab Units");
            dgv.Columns.Add("time", "Time");
            dgv.Columns.Add("day","Day");
            dgv.Columns.Add("room","Room");
            dgv.Columns.Add("instructor", "Instructor");
            dgv.Columns["instructor"].Width = 300;
            dgv.Columns["descriptive_title"].Width = 400;
            
        }
        private void tSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tCurriculum.Text.Length == 0 && tSemester.Text.Length == 0)
            {
                MessageBox.Show("Please select a Curriculum and Semester", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                dgv.Rows.Clear();
                var sectionSubjects = new proceed_to_enrollment
                {
                    curriculum = tCurriculum.Text,
                    semester = tSemester.Text
                };
                var data = sectionSubjects.loadSubjects();
                foreach(DataRow row in data.Rows)
                {
                    dgv.Rows.Add(
                        row["subject_code"], row["descriptive_title"], row["pre_requisite"], row["total_units"],
                        row["lecture_units"], row["lab_units"], row["time"], row["day"], row["room"], row["instructor"]
                        );
                    totalUnits += Convert.ToInt32(row["total_units"]);
                    totalLectureUnits += Convert.ToInt32(row["lecture_units"]);
                    totalLabUnits += Convert.ToInt32(row["lab_units"]);
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
            foreach(DataRow item in dt.Rows)
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
        private void saveAllChanges()
        {
            try
            {
                

                // INCREMENTING OF SECTIONS
                var sectionCheck = new add_subjects
                {
                    section_code = tSection.Text,
                    course = tCourse.Text,
                    year_level = tYearLevel.Text,
                    semester = tSemester.Text
                };
                var increment = sectionCheck.CheckMaximum();
                if (increment == "Available")
                {
                    // student course
                    var save = new proceed_to_enrollment
                    {
                        id_number = id_number,
                        course = tCourse.Text,
                        curriculum = tCurriculum.Text,
                        year_level = tYearLevel.Text,
                        section = tSection.Text,
                        semester = tSemester.Text,
                        campus = tCampus.Text
                    };
                    save.saveStudentCourse();

                    // incrementing number of students in sections
                    var sectionIncrement = new add_subjects
                    {
                        section_code = tSection.Text,
                        course = tCourse.Text,
                        year_level = tYearLevel.Text,
                        semester = tSemester.Text
                    };
                    sectionIncrement.incrementSection();

                    // save subjects
                    string schoolYear = DateTime.Now.Year.ToString();
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        var subjects = new add_subjects
                        {
                            id_number = id_number,
                            unique_id = id_number + "-" + schoolYear + "-" + tSemester.Text + "-" + row.Cells["subject_code"].Value.ToString(),
                            school_year = school_year,
                            subject_code = row.Cells["subject_code"].Value.ToString(),
                            descriptive_title = row.Cells["descriptive_title"].Value.ToString(),
                            pre_requisite = row.Cells["pre_requisite"].Value.ToString(),
                            total_units = row.Cells["total_units"].Value.ToString(),
                            lecture_units = row.Cells["lecture_units"].Value.ToString(),
                            lab_units = row.Cells["lab_units"].Value.ToString(),
                            time = row.Cells["time"].Value.ToString(),
                            day = row.Cells["day"].Value.ToString(),
                            room = row.Cells["room"].Value.ToString(),
                            instructor = row.Cells["instructor"].Value.ToString()
                        };
                        subjects.saveStudentSubjects();
                    }

                    // changing the status of the accounts
                    var status = new student_accounts
                    {
                        id_number = tIdNumber.Text,
                        status = "Accounting"
                    };
                    status.changeStatus();

                    MessageBox.Show("Subjects Successfully Added! Proceed to Accounting!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else if (increment == "Full")
                {
                    MessageBox.Show("Section is Full Please select another section", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    var data = new add_subjects
                    {
                        section_code = tSection.Text,
                        course = tCourse.Text,
                        year_level = tYearLevel.Text,
                        semester = tSemester.Text
                    };
                    data.disableFullSubject();
                    tSection.Text = "";
                    loadSection();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to enrol these subjects?","Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                saveAllChanges();
                //var frm = new frm_student_assessment();
                //frm_student_assessment.instance.idNumber = tIdNumber.Text;
                //frm.Text = "Student Assessment";
                //frm.ShowDialog();
            }
        }

        private void kryptonButton5_Click(object sender, EventArgs e)
        {
            if (tCourse.Text == "")
            {
                MessageBox.Show("Error, no course selected", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var frm = new frm_select_section();
                frm_select_section.instance.course = tCourse.Text;
                frm.Text = "Select Section";
                frm.ShowDialog();
                tSection.Text = section;

            }
        }

        private void tCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadCurriculum();
        }

        private void kryptonButton1_Click_1(object sender, EventArgs e)
        {
            var frm = new frm_select_subject();
            frm.ShowDialog();

            var addCustomSubject = new proceed_to_enrollment
            {
                id = Id
            };
            var data = addCustomSubject.addCustomSubject();

            if (Id != 0)
            {
                dgv.Rows.Add(
                data.Rows[0]["subject_code"],
                data.Rows[0]["descriptive_title"],
                data.Rows[0]["pre_requisite"],
                data.Rows[0]["total_units"],
                data.Rows[0]["lecture_units"],
                data.Rows[0]["lab_units"],
                data.Rows[0]["time"],
                data.Rows[0]["day"],
                data.Rows[0]["room"],
                data.Rows[0]["instructor"]
                );
                
                int lastRow = dgv.Rows.Count - 1;
                totalUnits += Convert.ToInt32(dgv.Rows[lastRow].Cells["total_units"].Value);
                totalLectureUnits += Convert.ToInt32(dgv.Rows[lastRow].Cells["lecture_units"].Value);
                totalLabUnits += Convert.ToInt32(dgv.Rows[lastRow].Cells["lab_units"].Value);
            }
            
            
            
        }


        //dgv.Columns.Add("subject_code", "Subject Code");
        //dgv.Columns.Add("descriptive_title", "Descriptive Title");
        //dgv.Columns.Add("pre_requisite", "Pre Requisite");
        //dgv.Columns.Add("total_units", "Total Units");
        //dgv.Columns.Add("lecture_units", "Lecture Units");
        //dgv.Columns.Add("lab_units", "Lab Units");
        //dgv.Columns.Add("time", "Time");
        //dgv.Columns.Add("day","Day");
        //dgv.Columns.Add("room","Room");
        //dgv.Columns.Add("instructor", "Instructor");
        private void tSemester_TextChanged(object sender, EventArgs e)
        {
            loadSection();
        }

        private void timerCounter_Tick(object sender, EventArgs e)
        {
            tTotalUnits.Text = totalUnits.ToString();
            tLectureUnits.Text = totalLectureUnits.ToString();
            tLabUnits.Text = totalLabUnits.ToString();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to remove this subject?", "Warning", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dgv.Rows.Remove(dgv.CurrentRow);
            }
        }
    }
}
