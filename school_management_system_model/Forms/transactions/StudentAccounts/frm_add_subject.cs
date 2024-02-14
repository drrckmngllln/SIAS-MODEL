using Krypton.Toolkit;
using MySql.Data.MySqlClient;
using school_management_system_model.Classes;
using school_management_system_model.Classes.Parameters;
using school_management_system_model.Core.Entities;
using school_management_system_model.Data.Repositories.Setings.Section;
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
    public partial class frm_add_subject : KryptonForm
    {
        SectionSubjectRepository _sectionSubjectsRepo = new SectionSubjectRepository();
        public string idnumber { get; set; }
        public string schoolyear { get; set; }

        PaginationParams paging = new PaginationParams();

        public static frm_add_subject instance;
        public frm_add_subject()
        {
            instance = this;
            InitializeComponent();
        }

        private void frm_add_subject_Load(object sender, EventArgs e)
        {
            loadRecords();
        }

        private async void loadRecords()
        {
            tLoading.Visible = true;
            await Task.Delay(100);
            tLoading.Visible = false;
            paging.pageSize = 10;
            var sectionSubjects = await _sectionSubjectsRepo.GetAllAsync();
                sectionSubjects.Skip(paging.pageSize * (paging.pageNumber - 1))
                .Take(paging.pageSize).ToList();

            //var con = new MySqlConnection(connection.con());
            //var da = new MySqlDataAdapter("select * from section_subjects", con);
            //var dt = new DataTable();
            //da.Fill(dt);
            dgv.DataSource = sectionSubjects;
            dgv.Columns["id"].Visible = false;
            dgv.Columns["unique_id"].Visible = false;
            dgv.Columns["section_code_id"].HeaderText = "Section";
            dgv.Columns["curriculum_id"].HeaderText = "Curriculum";
            dgv.Columns["course_id"].HeaderText = "Course";
            dgv.Columns["year_level"].HeaderText = "Year Level";
            dgv.Columns["semester"].HeaderText = "Semester";
            dgv.Columns["subject_code"].HeaderText = "Subject Code";
            dgv.Columns["descriptive_title"].HeaderText = "Descriptive Title";
            dgv.Columns["descriptive_title"].Width = 350;
            dgv.Columns["total_units"].HeaderText = "Total Units";
            dgv.Columns["lecture_units"].HeaderText = "Lecture Units";
            dgv.Columns["lab_units"].HeaderText = "Lab Units";
            dgv.Columns["pre_requisite"].HeaderText = "Pre Requisite";
            dgv.Columns["time"].HeaderText = "Time";
            dgv.Columns["day"].HeaderText = "Day";
            dgv.Columns["room"].HeaderText = "Room";
            dgv.Columns["instructor_id"].HeaderText = "Instructor";
            dgv.Columns["instructor_id"].Width = 250;
            dgv.Columns["status"].Visible = false;
        }
        private async void searchRecords(string search)
        {
            var sectionSubjects = await _sectionSubjectsRepo.GetAllAsync();
                sectionSubjects.Where(x => x.subject_code.ToLower().Contains(search) || x.descriptive_title.ToLower().Contains(search)).ToList();
            
            dgv.DataSource = sectionSubjects;
            dgv.Columns["subject_code"].HeaderText = "Subject Code";
            dgv.Columns["descriptive_title"].HeaderText = "Descriptive Title";
            dgv.Columns["descriptive_title"].Width = 350;
            dgv.Columns["total_units"].HeaderText = "Total Units";
            dgv.Columns["lecture_units"].HeaderText = "Lecture Units";
            dgv.Columns["lab_units"].HeaderText = "Lab Units";
            dgv.Columns["pre_requisite"].HeaderText = "Pre Requisite";
            dgv.Columns["id"].Visible = false;
            dgv.Columns["unique_id"].Visible = false;
            dgv.Columns["section_code_id"].HeaderText = "Section";
            dgv.Columns["curriculum_id"].HeaderText = "Curriculum";
            dgv.Columns["course_id"].HeaderText = "Course";
            dgv.Columns["year_level"].HeaderText = "Year Level";
            dgv.Columns["semester"].HeaderText = "Semester";
            dgv.Columns["time"].HeaderText = "Time";
            dgv.Columns["day"].HeaderText = "Day";
            dgv.Columns["room"].HeaderText = "Room";
            dgv.Columns["instructor_id"].HeaderText = "Instructor";
            dgv.Columns["instructor_id"].Width = 250;
            dgv.Columns["status"].Visible = false;
        }
        private void selectSubject()
        {
            int id = Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value);
            frm_student_enrollment.instance.Id = id;
            this.Close();
        }
        private void frm_select_subject_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                selectSubject();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tTime.Text = dgv.CurrentRow.Cells["time"].Value.ToString();
            tDay.Text = dgv.CurrentRow.Cells["day"].Value.ToString();
            tRoom.Text = dgv.CurrentRow.Cells["room"].Value.ToString();
            tInstructor.Text = dgv.CurrentRow.Cells["instructor"].Value.ToString();
        }
        private void frm_add_subject_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)

            {
                searchRecords(tSearch.Text);
            }
            else if (e.KeyCode == Keys.Escape)

            {
                tSearch.Clear();
                tSearch.Select();
                loadRecords();
            }
        }

        private async void addrecords(string idnumber, string schoolyear)
        {
            var subjectcode = dgv.CurrentRow.Cells["subject_code"].Value.ToString();
            var curriculum = dgv.CurrentRow.Cells["curriculum"].Value.ToString();
            var course = dgv.CurrentRow.Cells["course"].Value.ToString();
            var yearlevel = dgv.CurrentRow.Cells["year_level"].Value.ToString();
            var semester = dgv.CurrentRow.Cells["semester"].Value.ToString();
            var sectioncode = dgv.CurrentRow.Cells["section_code"].Value.ToString();
            var descriptivetitle = dgv.CurrentRow.Cells["descriptive_title"].Value.ToString();
            var lectureunits = Convert.ToDecimal(dgv.CurrentRow.Cells["lecture_units"].Value.ToString());
            var labunits = Convert.ToDecimal(dgv.CurrentRow.Cells["lab_units"].Value.ToString());
            var prerequisite = dgv.CurrentRow.Cells["pre_requisite"].Value.ToString();
            var time = dgv.CurrentRow.Cells["time"].Value.ToString();
            var day = dgv.CurrentRow.Cells["day"].Value.ToString();
            var room = dgv.CurrentRow.Cells["room"].Value.ToString();
            var status = dgv.CurrentRow.Cells["status"].Value.ToString();
            var instructor = dgv.CurrentRow.Cells["instructor"].Value.ToString();


            var add = new SectionSubjects
            {
                unique_id = idnumber + "-" + schoolyear + "-" + subjectcode,
                section_code = sectioncode,
                subject_code = subjectcode,
                year_level = yearlevel,
                semester = semester,
                descriptive_title = descriptivetitle,
                lecture_units = lectureunits,
                pre_requisite = prerequisite,
                lab_units = labunits,
                time = time,
                day = day,
                room = room,
                instructor = instructor


            };
            await _sectionSubjectsRepo.AddRecords(add);
            new Classes.Toastr("Success", "Subject Added Successfully");
            Close();


        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void btnPrev_Click(object sender, EventArgs e)
        {
            tLoading.Visible = true;
            await Task.Delay(100);
            tLoading.Visible = false;
            if (paging.pageNumber == 1)
            {
                btnPrev.Enabled = false;
            }
            else
            {
                paging.pageNumber--;
                tPageNumber.Text = paging.pageNumber.ToString();
                loadRecords();
                btnNext.Enabled = true;
            }
        }

        private async void btnNext_Click(object sender, EventArgs e)
        {
            tLoading.Visible = true;
            await Task.Delay(100);
            tLoading.Visible = false;
            if (dgv.Rows.Count < paging.pageSize)
            {
                btnNext.Enabled = false;
            }
            else
            {
                paging.pageNumber++;
                tPageNumber.Text = paging.pageNumber.ToString();
                loadRecords();
                btnPrev.Enabled = true;
            }
        }

        private void btnAddSubject_Click(object sender, EventArgs e)
        {
            addrecords(idnumber, schoolyear);

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
