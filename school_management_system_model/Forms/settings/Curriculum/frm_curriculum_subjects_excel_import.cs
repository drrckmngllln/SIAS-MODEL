using ExcelDataReader;
using Krypton.Toolkit;
using MySql.Data.MySqlClient;
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
        public int id { get; set; }
        public string curriculumIdCode { get; set; }
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

        public static frm_curriculum_subjects_excel_import instance;

        public frm_curriculum_subjects_excel_import()
        {
            instance = this;
            InitializeComponent();
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
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }

        private void saveRecords()
        {
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("insert into curriculum_subjects(curriculumIdCode, curriculum, year_level, semester, code, descriptive_title, " +
                "total_units, lecture_units, lab_units, pre_requisite, total_hrs_per_week) " +
                "values(@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11)", con);
            cmd.Parameters.AddWithValue("@1", curriculumIdCode);
            cmd.Parameters.AddWithValue("@2", curriculum);
            cmd.Parameters.AddWithValue("@3", year_level);
            cmd.Parameters.AddWithValue("@4", semester);
            cmd.Parameters.AddWithValue("@5", code);
            cmd.Parameters.AddWithValue("@6", descriptive_title);
            cmd.Parameters.AddWithValue("@7", total_units);
            cmd.Parameters.AddWithValue("@8", lecture_units);
            cmd.Parameters.AddWithValue("@9", lab_units);
            cmd.Parameters.AddWithValue("@10", pre_requisite);
            cmd.Parameters.AddWithValue("@11", total_hrs_per_week);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            excelImport();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    curriculumIdCode = curriculum + row.Cells["code"].Value.ToString();
                    year_level = row.Cells["year_level"].Value.ToString();
                    semester = row.Cells["semester"].Value.ToString();
                    code = row.Cells["code"].Value.ToString();
                    descriptive_title = row.Cells["descriptive_title"].Value.ToString();
                    total_units = row.Cells["total_units"].Value.ToString();
                    lecture_units = row.Cells["lecture_units"].Value.ToString();
                    lab_units = row.Cells["lab_units"].Value.ToString();
                    pre_requisite = row.Cells["pre_requisite"].Value.ToString();
                    total_hrs_per_week = row.Cells["total_hrs_per_week"].Value.ToString();
                    saveRecords();
                }

                new Classes.Toastr().toast("Success", "Curriculum Import Success");

                Close();
            }
            catch(Exception ex)
            {
                new Classes.Toastr().toast("Error", ex.Message);

            }

        }
    }
}
