using Krypton.Toolkit;
using MySql.Data.MySqlClient;
using school_management_system_model.Data.Repositories.Transaction.StudentAssessment;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
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

        private async void frm_view_subjects_Load(object sender, EventArgs e)
        {
            await loadRecords();
        }

        private async Task loadRecords()
        {
            tTitle.Text = this.Text;
            
            dgv.Columns.Add("id_number_id", "ID Number");
            dgv.Columns.Add("subject_code", "Subject Code");
            dgv.Columns.Add("descriptive_title", "Descriptive Title");
            dgv.Columns.Add("pre_requisite", "Pre Requisite");
            dgv.Columns.Add("total_units", "Total Units");
            dgv.Columns.Add("lecture_units", "Lecture Units");
            dgv.Columns.Add("lab_units", "Lab Units");

            dgv.Columns["descriptive_title"].Width = 300;
            


            var studentSubjects = await _studentSubjectRepo.GetAllAsync();
            var subjects = studentSubjects.Where(x => x.id_number_id == id_number).ToList();

            foreach ( var subject in subjects )
            {
                dgv.Rows.Add(subject.id_number_id, subject.subject_code, subject.descriptive_title, subject.pre_requisite, subject.total_units, 
                    subject.lecture_units, subject.lab_units);
            }
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

        private async void tSearch_TextChanged(object sender, EventArgs e)
        {
            if (tSearch.Text.Length > 2)
            {
                var studentSubjects = await _studentSubjectRepo.GetAllAsync();
                var subjects = studentSubjects
                    .Where(x => x.id_number_id == id_number && x.subject_code.ToLower().Contains(tSearch.Text) || x.descriptive_title.ToLower().Contains(tSearch.Text))
                    .ToList();

                dgv.Rows.Clear();
                foreach (var subject in subjects)
                {
                    dgv.Rows.Add(subject.id_number_id, subject.subject_code, subject.descriptive_title, subject.pre_requisite, subject.total_units,
                        subject.lecture_units, subject.lab_units);
                }
            }
            else if (tSearch.Text.Length == 0)
            {
                await loadRecords();
            }
        }
    }
}
