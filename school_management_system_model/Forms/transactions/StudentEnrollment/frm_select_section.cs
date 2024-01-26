using MySql.Data.MySqlClient;
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

namespace school_management_system_model.Forms.transactions.StudentEnrollment
{
    public partial class frm_select_section : Form
    {
        public frm_select_section(string course, string semester, string year_level)
        {
            InitializeComponent();
            Course = course;
            Semester = semester;
            Year_Level = year_level;
        }

        public string Course { get; }
        public string Semester { get; }
        public string Year_Level { get; }

        private void frm_select_section_Load(object sender, EventArgs e)
        {
            loadSection();
        }

        private void loadSection()
        {
            var section = new sections().GetSections().Where(x => x.course_id == Course && x.semester == Semester && x.year_level.ToString() == Year_Level).ToList();

            //var con = new MySqlConnection(connection.con());
            //var da = new MySqlDataAdapter("select * from sections where course='" + Course + "' and semester='" + Semester + "' and year_level='" + Year_Level + "'", con);
            //var dt = new DataTable();
            //da.Fill(dt);
            dgv.DataSource = section;
            dgv.Columns["id"].Visible = false;
            dgv.Columns["unique_id"].Visible = false;
            dgv.Columns["section_code"].HeaderText = "Section Code";
            dgv.Columns["course"].HeaderText = "Course";
            dgv.Columns["year_level"].HeaderText = "Year Level";
            dgv.Columns["section"].Visible = false;
            dgv.Columns["semester"].HeaderText = "Semester";
            dgv.Columns["number_of_students"].HeaderText = "Students Enrolled";
            dgv.Columns["max_number_of_students"].HeaderText = "Max Students";
            dgv.Columns["status"].HeaderText = "Status";
            dgv.Columns["remarks"].HeaderText = "Remarks";
        }

        string selectSection()
        {
            return dgv.CurrentRow.Cells["section_code"].Value.ToString();
        }

        private void frm_select_section_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                frm_student_enrollment.instance.section = selectSection();
                Close();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void btnSelectSection_Click(object sender, EventArgs e)
        {
            frm_student_enrollment.instance.section = selectSection();
            Close();
        }
    }
}
