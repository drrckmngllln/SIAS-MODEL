using ExcelDataReader;
using Krypton.Toolkit;
using MySql.Data.MySqlClient;
using school_management_system_model.Classes;
using school_management_system_model.Core.Entities;
using school_management_system_model.Data.Repositories.Setings;
using school_management_system_model.Loggers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace school_management_system_model.Forms.settings.Curriculum
{
    public partial class frm_curriculum_subjects_excel_import : KryptonForm
    {
        CurriculumRepository _curriculumRepo = new CurriculumRepository();
        CurriculumSubjectsRepository _curriculumSubjectsRepo = new CurriculumSubjectsRepository();

        public int id { get; set; }
        public string uid { get; set; }
        public string curriculum { get; set; }
        public string year_level { get; set; }
        public string semester { get; set; }
        public string code { get; set; }
        public string descriptive_title { get; set; }
        public string total_units { get; set; }
        public string lecture_units { get; set; }
        public string lab_units { get; set; }
        public string pre_requisite { get; set; }
        public string total_hrs_per_week { get; set; }
        public string status { get; set; }
        public string Email { get; }

        public static frm_curriculum_subjects_excel_import instance;

        public frm_curriculum_subjects_excel_import(string email)
        {
            instance = this;
            InitializeComponent();
            Email = email;
        }

        private void frm_curriculum_subjects_excel_import_Load(object sender, EventArgs e)
        {

        }

        private void excelImport()
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            ofd.Title = "Select an Excel file";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string file_path = ofd.FileName;
                    using (var str = File.Open(file_path, FileMode.Open, FileAccess.Read))
                    {
                        using (var reader = ExcelReaderFactory.CreateReader(str))
                        {
                            DataSet ds = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                                {
                                    UseHeaderRow = true
                                }
                            });

                            DataTable dt = ds.Tables[0];
                            dgv.DataSource = dt;
                        }
                    }

                    this.Text = Path.GetFileName(ofd.FileName);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }

        private async Task SaveLoading()
        {
            panelWait.Visible = true;
            btnSave.Enabled = false;

            int totalSubjects = Convert.ToInt32(dgv.Rows.Count);

            UpdateProgressBar(totalSubjects);
            await Task.Delay(1);

            panelWait.Visible = false;

            //progressBar1.Minimum = 0;
            //progressBar1.Maximum = 100;
            //progressBar1.Value = 0;
            //try
            //{
            //    await Task.Run(async () =>
            //    {
            //        int totalSubjects = Convert.ToInt32(dgv.Rows.Count);

            //        for (int i = 1; i <= totalSubjects; i++)
            //        {
            //            await Task.Delay(10);

            //            int progress = (int)(i / ((double)totalSubjects) * 100);
            //            UpdateProgressBar(progress);
            //        }
            //    });
            //}
            //catch
            //{
            //    new Classes.Toastr("Warning", "An Error has occured while saving");
            //}
            //finally
            //{
            //    panelWait.Visible = false;
            //    btnSave.Enabled = true;
            //}
        }

        private void UpdateProgressBar(int progress)
        {
            if (progressBar1.InvokeRequired)
            {
                progressBar1.Invoke(new Action<int>(UpdateProgressBar), progress);
            }
            else
            {
                progressBar1.Value = progress;
            }
        }

        private async Task saveRecords()
        {
            await SaveLoading();
            var a = await _curriculumRepo.GetAllAsync();
            var curriculum_id = a.FirstOrDefault(x => x.code == curriculum).id;
            var subjects = new CurriculumSubjects
            {
                uid = curriculum + code,
                curriculum = curriculum_id.ToString(),
                year_level = year_level,
                semester = semester,
                code = code.ToString(),
                descriptive_title = descriptive_title.ToString(),
                total_units = total_units,
                lecture_units = lecture_units,
                lab_units = lab_units,
                pre_requisite = pre_requisite.ToString(),
                total_hrs_per_week = total_hrs_per_week.ToString()

            };
            await _curriculumSubjectsRepo.AddRecords(subjects);
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            excelImport();
        }

        private async void kryptonButton1_Click(object sender, EventArgs e)
        {
            
            try
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    uid = curriculum + row.Cells["code"].Value.ToString();
                    year_level = row.Cells["year_level"].Value.ToString();
                    semester = row.Cells["semester"].Value.ToString();
                    code = row.Cells["code"].Value.ToString();
                    descriptive_title = row.Cells["descriptive_title"].Value.ToString();
                    total_units = row.Cells["total_units"].Value.ToString();
                    lecture_units = row.Cells["lecture_units"].Value.ToString();
                    lab_units = row.Cells["lab_units"].Value.ToString();
                    pre_requisite = row.Cells["pre_requisite"].Value.ToString();
                    total_hrs_per_week = row.Cells["total_hrs_per_week"].Value.ToString();
                    await saveRecords();
                }

                new Classes.Toastr("Success", "Curriculum Import Success");
                new ActivityLogger().activityLogger(Email, "Curriculum File Import: " + this.Text);
                Close();
            }
            catch(Exception ex)
            {
                new Classes.Toastr("Error", ex.Message);
                
            }

        }
    }
}
