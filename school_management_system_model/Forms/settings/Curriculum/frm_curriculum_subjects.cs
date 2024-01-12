using Krypton.Toolkit;
using MySql.Data.MySqlClient;
using school_management_system_model.Forms.settings.Curriculum;
using System;
using System.Data;
using System.Windows.Forms;

namespace school_management_system_model.Forms.settings
{
    public partial class frm_curriculum_subjects : KryptonForm
    {
        public string Curriculum;
        private string ID { get; set; }
        public static frm_curriculum_subjects instance;
        public frm_curriculum_subjects()
        {
            instance = this;
            InitializeComponent();
        }

        private void frm_curriculum_subjects_Load(object sender, EventArgs e)
        {
            loadrecords();
        }

        private void loadrecords()
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from curriculum_subjects where curriculum='"+ Curriculum +"'", con);
            var dt = new DataTable();
            da.Fill(dt);
            dgv.DataSource = dt;
            dgv.Columns["id"].Visible = false;
            dgv.Columns["curriculumIdCode"].Visible = false;
            dgv.Columns["curriculum"].Visible = false;
            dgv.Columns["year_level"].HeaderText = "Year Level";
            dgv.Columns["semester"].HeaderText = "Semester";
            dgv.Columns["code"].HeaderText = "Code";
            dgv.Columns["descriptive_title"].HeaderText = "Descriptive Tittle";
            dgv.Columns["descriptive_title"].Width = 300;
            dgv.Columns["total_units"].HeaderText = "Total Units";
            dgv.Columns["lecture_units"].HeaderText = "Lecture Units";
            dgv.Columns["lab_units"].HeaderText = "Lab Units";
            dgv.Columns["pre_requisite"].HeaderText = "Pre Requisite";
            dgv.Columns["total_hrs_per_week"].HeaderText = "Total Hours Per Week";

            con = new MySqlConnection(connection.con());
            da = new MySqlDataAdapter("select * from curriculums where code='" + Curriculum + "'", con);
            var ds = new DataTable();
            da.Fill(ds);
            
            tcode.Text = ds.Rows[0]["code"].ToString();
            tdescription.Text = ds.Rows[0]["description"].ToString();
            tcampus.Text = ds.Rows[0]["campus"].ToString();
            tcourse.Text = ds.Rows[0]["course"].ToString();
            teffective.Text = ds.Rows[0]["effective"].ToString();
            texpires.Text = ds.Rows[0]["expires"].ToString();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            var frm = new frm_add_curriculum_subjects();
            frm.Text = "Add Subjects";
            frm_add_curriculum_subjects.instance.curriculum = Curriculum;
            frm.ShowDialog();
            loadrecords();
        }
        
        private void delete()
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter();
            da.SelectCommand = new MySqlCommand("delete from curriculum_subjects where id='" + ID + "'", con);
            var dt = new DataTable();
            da.Fill(dt);
        }
        private void deleteAll(string curriculum)
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter();
            da.SelectCommand = new MySqlCommand("delete from curriculum_subjects where curriculum='" + curriculum + "'", con);
            var dt = new DataTable();
            da.Fill(dt);
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("are you sure you want to delete subject?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                DialogResult.Yes)
            {
                delete();
                
                new Classes.Toastr().toast("Information", "Curriculum Subject Deleted");

                loadrecords();
            }
        }

        private void dgv_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            ID = dgv.CurrentRow.Cells["id"].Value.ToString();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            var frm = new frm_curriculum_subjects_excel_import();
            frm_curriculum_subjects_excel_import.instance.curriculum = tcode.Text;
            frm.Text = "Excel Import - Curriculum Subjects";
            frm.ShowDialog();
            loadrecords();
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("are you sure you want to delete all subjects in this curriculum?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
               DialogResult.Yes)
            {
                deleteAll(tcode.Text);
                MessageBox.Show("Curriculum Subject Deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                new Classes.Toastr().toast("Information", "Curriculum Subject Deleted");

                loadrecords();
            }
        }

        private DataTable onSearch(string search)
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from curriculum_subjects where concat(curriculum, code, descriptive_title) like '%" + search + "%'", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        private void tsearch_TextChanged(object sender, EventArgs e)
        {
            if (tsearch.Text.Length > 2)
            {
                dgv.DataSource = onSearch(tsearch.Text);
            }
            else if (tsearch.Text.Length == 0)
            {
                loadrecords();
            }
        }
    }
}
