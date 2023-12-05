using Krypton.Toolkit;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace school_management_system_model.Forms.settings
{
    public partial class frm_add_curriculum_subjects : KryptonForm
    {
        public string curriculum;
        string curriculumIdCOde;
        string semester;
        string code;
        string descriptive_title;
        string total_units;
        string lecture_units;
        string lab_units;
        string pre_requisite;
        string total_hrs_per_week;
        string status;
        public static frm_add_curriculum_subjects instance;
        public frm_add_curriculum_subjects()
        {
            instance = this;
            InitializeComponent();
        }

        private void frm_add_curriculum_subjects_Load(object sender, EventArgs e)
        {
            loadrecords();
        }

        private void loadrecords()
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from subjects", con);
            var dt = new DataTable();
            da.Fill(dt);
            dgv.DataSource = dt;
            dgv.Columns[0].Visible = false;
            dgv.Columns["descriptive_title"].Width = 400;
        }

        private void tsearch_TextChanged(object sender, EventArgs e)
        {
            if (tsearch.Text.Length > 2)
            {
                var con = new MySqlConnection(connection.con());
                var da = new MySqlDataAdapter("select * from subjects where concat(semester, code, descriptive_title, pre_requisite) " +
                    "like '%" + tsearch.Text + "%'", con);
                var dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
            }
            else if (tsearch.Text.Length == 0)
            {
                loadrecords();
            }
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            add_records();
        }

        private void add_records()
        {
            
            try
            {
                var con = new MySqlConnection(connection.con());
                con.Open();
                var cmd = new MySqlCommand("insert into curriculum_subjects(curriculumIdCode, curriculum, semester, code, descriptive_title, " +
                    "total_units, lecture_units, lab_units, pre_requisite, total_hrs_per_week, status) " +
                    "values(@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11)", con);
                cmd.Parameters.AddWithValue("@1", curriculumIdCOde);
                cmd.Parameters.AddWithValue("@2", curriculum);
                cmd.Parameters.AddWithValue("@3", semester);
                cmd.Parameters.AddWithValue("@4", code);
                cmd.Parameters.AddWithValue("@5", descriptive_title);
                cmd.Parameters.AddWithValue("@6", total_units);
                cmd.Parameters.AddWithValue("@7", lecture_units);
                cmd.Parameters.AddWithValue("@8", lab_units);
                cmd.Parameters.AddWithValue("@9", pre_requisite);
                cmd.Parameters.AddWithValue("@10", total_hrs_per_week);
                cmd.Parameters.AddWithValue("@11", status);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Subject Added");

            }
            catch
            {
                MessageBox.Show("Error, Duplicate Entry!","Error!",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            curriculumIdCOde = curriculum + dgv.CurrentRow.Cells["code"].Value.ToString();
            semester = dgv.CurrentRow.Cells["semester"].Value.ToString();
            code = dgv.CurrentRow.Cells["code"].Value.ToString();
            descriptive_title = dgv.CurrentRow.Cells["descriptive_title"].Value.ToString();
            total_units = dgv.CurrentRow.Cells["total_units"].Value.ToString();
            lecture_units = dgv.CurrentRow.Cells["lecture_units"].Value.ToString();
            lab_units = dgv.CurrentRow.Cells["lab_units"].Value.ToString();
            pre_requisite = dgv.CurrentRow.Cells["pre_requisite"].Value.ToString();
            total_hrs_per_week = dgv.CurrentRow.Cells["total_hrs_per_week"].Value.ToString();
            status = dgv.CurrentRow.Cells["status"].Value.ToString();
        }

        private void frm_add_curriculum_subjects_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                add_records();
            }
        }
    }
}
