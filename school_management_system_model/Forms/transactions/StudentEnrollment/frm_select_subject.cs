using Krypton.Toolkit;
using MySql.Data.MySqlClient;
using school_management_system_model.Classes;
using school_management_system_model.Classes.Parameters;
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

namespace school_management_system_model.Forms.transactions
{
    public partial class frm_select_subject : KryptonForm
    {
        SectionSubjectRepository _sectionSubjectRepo = new SectionSubjectRepository();
        PaginationParams paging = new PaginationParams();

        public frm_select_subject()
        {
            InitializeComponent();
        }

        private void frm_select_subject_Load(object sender, EventArgs e)
        {
            loadRecords();
        }

        private async void loadRecords()
        {
            paging.pageSize = 10;
            tLoading.Visible = true;
            var sectionSubjects = await _sectionSubjectRepo.GetAllAsync();
            var sectionSubject = sectionSubjects
                .Skip(paging.pageSize * (paging.pageNumber - 1))
                .Take(paging.pageSize)
                .ToList();
            
            dgv.DataSource = sectionSubject;
            tLoading.Visible = false;
            dgv.Columns["id"].Visible = false;
            dgv.Columns["unique_id"].Visible = false;
            dgv.Columns["section_code"].HeaderText = "Section";
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
            dgv.Columns["instructor"].HeaderText = "Instructor";
            dgv.Columns["instructor"].Width = 250;
        }

        private async void searchRecords(string search)
        {
            tLoading.Visible = true;
            var searchSubjects = await _sectionSubjectRepo.GetAllAsync();
                searchSubjects.Where(x => x.subject_code.ToLower().Contains(tSearch.Text) || x.descriptive_title.ToLower().Contains(tSearch.Text));
            dgv.DataSource = searchSubjects.ToList();
            tLoading.Visible = false;
            
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
                searchRecords(tSearch.Text);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                tSearch.Clear();
                tSearch.Select();
                loadRecords();
            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tTime.Text = dgv.CurrentRow.Cells["time"].Value.ToString();
            tDay.Text = dgv.CurrentRow.Cells["day"].Value.ToString();
            tRoom.Text = dgv.CurrentRow.Cells["room"].Value.ToString();
            tInstructor.Text = dgv.CurrentRow.Cells["instructor_id"].Value.ToString();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            selectSubject();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            paging.pageNumber++;
            tPageSize.Text = paging.pageNumber.ToString();
            loadRecords();
            if (dgv.Rows.Count < paging.pageSize)
            {
                btnNext.Enabled = false;
            }
            btnPrev.Enabled = true;
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            paging.pageNumber--;
            tPageSize.Text = paging.pageNumber.ToString();
            loadRecords();
            if (tPageSize.Text == "1")
            {
                btnPrev.Enabled = false;
            }
            btnNext.Enabled = true;
        }

        private async void tSearch_TextChanged(object sender, EventArgs e)
        {
            if (tSearch.Text.Length > 2)
            {
                var studentSubjects = await _sectionSubjectRepo.GetAllAsync();
                var search = studentSubjects.Where(x => x.section_code.ToLower().Contains(tSearch.Text)
                || x.subject_code.ToLower().Contains(tSearch.Text)
                || x.descriptive_title.ToLower().Contains(tSearch.Text)
                || x.instructor.ToLower().Contains(tSearch.Text))
                    .Skip(paging.pageSize * (paging.pageNumber - 1))
                    .Take(paging.pageSize)
                    .ToList();
                dgv.DataSource = search;
            }
            else if (tSearch.Text.Length == 0)
            {
                loadRecords();
            }
            
        }
    }
}
