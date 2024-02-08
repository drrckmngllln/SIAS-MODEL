using Krypton.Toolkit;
using MySql.Data.MySqlClient;
using school_management_system_model.Data.Repositories.Transaction.StudentAssessment;
using System;
using System.Data;
using System.Windows.Forms;

namespace school_management_system_model.Forms.transactions.StudentAssessment
{
    public partial class frm_view_subjects : KryptonForm
    {
        StudentSubjectRepository _studentSubjectRepo = new StudentSubjectRepository();
        public static frm_view_subjects instance;
        public string id_number { get; set; }
        public frm_view_subjects()
        {
            instance = this;
            InitializeComponent();
        }

        private void frm_view_subjects_Load(object sender, EventArgs e)
        {
            loadRecords();
        }

        private void loadRecords()
        {
            tTitle.Text = this.Text;


            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from student_subjects where id_number='" + id_number + "'", con);
            var dt = new DataTable();
            da.Fill(dt);
            dgv.DataSource = dt;
            dgv.Columns["id"].Visible = false;
            dgv.Columns["id_number"].Visible = false;
            dgv.Columns["unique_id"].Visible = false;
            dgv.Columns["subject_code"].HeaderText = "Subject Code";
            dgv.Columns["descriptive_title"].HeaderText = "Descriptive Title";
            dgv.Columns["descriptive_title"].Width = 300;
            dgv.Columns["pre_requisite"].Visible = false;
            dgv.Columns["total_units"].HeaderText = "Total Units";
            dgv.Columns["lecture_units"].HeaderText = "Lecture Units";
            dgv.Columns["lab_units"].HeaderText = "Lab Units";
            dgv.Columns["time"].Visible = false;
            dgv.Columns["day"].Visible = false;
            dgv.Columns["room"].Visible = false;
            dgv.Columns["instructor"].Visible = false;
            dgv.Columns["grade"].Visible = false;
            dgv.Columns["remarks"].Visible = false;
        }

        private void frm_view_subjects_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
    }
}
