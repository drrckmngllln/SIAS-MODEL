using Krypton.Toolkit;
using school_management_system_model.Classes;
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
    public partial class frm_select_section : KryptonForm
    {
        public string course;
        public DataTable dt = new DataTable();
        public static frm_select_section instance;
        public frm_select_section()
        {
            instance = this;
            InitializeComponent();
        }

        private void frm_select_section_Load(object sender, EventArgs e)
        {
            loadRecords();
        }

        private void loadRecords()
        {
            var data = new add_section
            {
                course = course 
            };
            data.loadAvailableSections();
            dgv.DataSource = dt;
            dgv.Columns["id"].Visible = false;
            dgv.Columns["section_code"].HeaderText = "Section Code";
            dgv.Columns["course"].Visible = false;
            dgv.Columns["year_level"].HeaderText = "Year Level";
            dgv.Columns["section"].Visible = false;
            dgv.Columns["number_of_students"].Visible = false;
            dgv.Columns["max_number_of_students"].Visible = false;
            dgv.Columns["status"].Visible = false;
        }

        private void selectSection()
        {
            frm_student_enrollment.instance.section = dgv.CurrentRow.Cells["section"].Value.ToString();
            frm_student_enrollment.instance.section_code = dgv.CurrentRow.Cells["section_code"].Value.ToString();
            this.Close();
        }

        private void frm_select_section_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                selectSection();
            }
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            selectSection();
        }

        private void tsearch_TextChanged(object sender, EventArgs e)
        {
            if (tsearch.Text.Length > 2)
            {
                var search = new add_section
                {
                    search = tsearch.Text,
                    course = course
                };
                dt.Rows.Clear();
                search.searchSections();
                dgv.DataSource = dt;
                dgv.DataSource = dt;
                dgv.Columns["id"].Visible = false;
                dgv.Columns["section_code"].HeaderText = "Section Code";
                dgv.Columns["course"].Visible = false;
                dgv.Columns["year_level"].HeaderText = "Year Level";
                dgv.Columns["section"].Visible = false;
                dgv.Columns["number_of_students"].Visible = false;
                dgv.Columns["max_number_of_students"].Visible = false;
                dgv.Columns["status"].Visible = false;
            }
            else if (tsearch.Text.Length == 0)
            {
                loadRecords();
            }
        }
    }
}
