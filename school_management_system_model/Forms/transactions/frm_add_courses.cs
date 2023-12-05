using Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using school_management_system_model.Classes;

namespace school_management_system_model.Forms.transactions
{
    public partial class frm_add_courses : KryptonForm
    {
        public DataTable dt = new DataTable();
        public string course;
        public static frm_add_courses instance;
        public frm_add_courses()
        {
            instance = this;
            InitializeComponent();
        }

        private void frm_add_courses_Load(object sender, EventArgs e)
        {
            loadRecords();
        }

        private void loadRecords()
        {
            if (this.Text == "Add Course")
            {
                var data = new add_course();
                dt.Clear();
                data.loadRecords();
                dgv.DataSource = dt;
                dgv.Columns["id"].Visible = false;
                dgv.Columns["code"].HeaderText = "Code";
                dgv.Columns["description"].HeaderText = "Description";
                dgv.Columns["description"].Width = 400;
                dgv.Columns["level"].HeaderText = "Level";
                dgv.Columns["campus"].HeaderText = "Campus";
                dgv.Columns["department"].HeaderText = "Department";
                dgv.Columns["status"].Visible = false;

            }
        }

        private void tsearch_TextChanged(object sender, EventArgs e)
        {
            if (tsearch.Text.Length > 2)
            {
                var search = new add_course
                {
                    search = tsearch.Text
                };
                dt.Clear();
                search.searchRecords();
                dgv.DataSource = dt;
            }
            else if (tsearch.Text.Length == 0)
            {
                loadRecords();
            }
        }

        private void selectCourse()
        {
            var select = new add_course
            {
                code = dgv.CurrentRow.Cells["code"].Value.ToString()
            };
            select.selectCourse();
            this.Close();
            
        }

        private void frm_add_courses_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                selectCourse();
            }
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            selectCourse();
        }
    }
}
