using Krypton.Toolkit;
using MySql.Data.MySqlClient;
using school_management_system_model.Classes;
using school_management_system_model.Classes.Parameters;
using school_management_system_model.Core.Entities;
using school_management_system_model.Data.Repositories.Setings;
using school_management_system_model.Loggers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace school_management_system_model.Forms.settings.FeeSetup
{
    public partial class frm_link_subjects : KryptonForm
    {
        CurriculumSubjectsRepository _curriculumSubjectsRepo = new CurriculumSubjectsRepository();
        LabFeeSubjectRepository _labFeeSubjectRepo = new LabFeeSubjectRepository();
        LabFeeRepository _labFeeRepo = new LabFeeRepository();

        public string Description { get; set; }
        public string Email { get; set; }

        PaginationParams paging = new PaginationParams();

        public frm_link_subjects(string email, string description)
        {
            InitializeComponent();
            Email = email;
            Description = description;
        }

        private void frm_link_subjects_Load(object sender, EventArgs e)
        {

            loadRecords();
        }


        private async void loadRecords()
        {
            if (this.Text == "Select")
            {
                paging.PageSize = 10;
                tTitle.Text = "Select Subjects: " + Description;
                tPageSize.Text = paging.pageNumber.ToString();
                var a = await _curriculumSubjectsRepo.GetAllAsync();
                var curriculumSubjects = a
                    .Select(x => new
                    {
                        x.code,
                        x.descriptive_title,
                        x.lab_units
                    })
                    .Skip(paging.PageSize * (paging.pageNumber - 1))
                    .Take(paging.PageSize)
                    .ToList();

                dgv.DataSource = curriculumSubjects;

                dgv.Columns["code"].HeaderText = "Subject Code";
                dgv.Columns["descriptive_title"].HeaderText = "Descriptive Title";
                dgv.Columns["code"].Width = 100;
                dgv.Columns["lab_units"].HeaderText = "Lab Units";

                btnRemove.Visible = false;
            }
            else if (this.Text == "View")
            {
                tTitle.Text = "Linked Subjects: " + Description;

                var labFeeSubjects = await _labFeeSubjectRepo.GetAllAsync();
                var a = labFeeSubjects
                    .Where(x => x.lab_fee == Description).ToList();


                dgv.DataSource = a;

                dgv.Columns["id"].Visible = false;
                dgv.Columns["lab_fee"].Visible = false;
                dgv.Columns["subject_code"].HeaderText = "Subject Code";
                dgv.Columns["subject_code"].Width = 100;
                dgv.Columns["descriptive_title"].HeaderText = "Descriptive Title";

                btnSelect.Visible = false;
            }
        }

        private async void linkSubject(string code, string descriptiveTitle)
        {
            try
            {
                var labDescription = await _labFeeRepo.GetAllAsync();
                var a = labDescription
                    .FirstOrDefault(x => x.description == Description);
                var linkSubject = new LabFeeSubjects
                {
                    uid = a.id.ToString() + code.ToString(),
                    lab_fee = a.id.ToString(),
                    subject_code = code,
                    descriptive_title = descriptiveTitle
                };
                await _labFeeSubjectRepo.AddRecords(linkSubject);
                new Classes.Toastr("Success", "Subject Linked");
                Close();
            }
            catch (Exception ex)
            {
                new Classes.Toastr("Warning", ex.Message);
            }
        }

        private void removeLink(int id)
        {
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("delete from lab_fee_subjects where id='" + id + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            loadRecords();
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frm_link_subjects_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                linkSubject(
                    dgv.CurrentRow.Cells["code"].Value.ToString(),
                    dgv.CurrentRow.Cells["descriptive_title"].Value.ToString()
                    );
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            linkSubject(
                dgv.CurrentRow.Cells["code"].Value.ToString(),
                dgv.CurrentRow.Cells["descriptive_title"].Value.ToString()
                );

            new ActivityLogger().activityLogger(Email, "Select Link Subject: " + dgv.CurrentRow.Cells["descriptive_title"].Value.ToString());

        }

        private async void tsearch_TextChanged(object sender, EventArgs e)
        {
            if (this.Text == "Select")
            {
                if (tsearch.Text.Length > 2)
                {
                    var a = await _curriculumSubjectsRepo.GetAllAsync();
                    var curriculumSubjects = a
                        .Where(x => x.code.ToLower().Contains(tsearch.Text) || x.descriptive_title.ToLower().Contains(tsearch.Text))
                        .Select(x => new
                        {
                            x.code,
                            x.descriptive_title,
                            x.lab_units
                        }).ToList();
                    dgv.DataSource = curriculumSubjects;
                }
                else if (tsearch.Text.Length == 0)
                {
                    loadRecords();
                }
            }
            else if (this.Text == "View")
            {
                if (tsearch.Text.Length > 2)
                {
                    var labFeeSubjects = await _labFeeSubjectRepo.GetAllAsync();
                    var a = labFeeSubjects
                        .Where(x => x.lab_fee == Description && x.subject_code.ToLower().Contains(tsearch.Text) || x.descriptive_title.ToLower().Contains(tsearch.Text))
                        .ToList();
                    dgv.DataSource = a;
                }
                else if (tsearch.Text.Length == 0)
                {
                    loadRecords();
                }
            }

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to unlink these subject?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                removeLink(Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value));
                new ActivityLogger().activityLogger(Email, "Unlink Subject: " + dgv.CurrentRow.Cells["descriptive_title"].Value.ToString());
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            paging.pageNumber++;
            tPageSize.Text = paging.pageNumber.ToString();
            loadRecords();
            if (dgv.Rows.Count < paging.PageSize)
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
    }
}
