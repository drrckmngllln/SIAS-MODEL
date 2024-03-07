using Krypton.Toolkit;
using MySql.Data.MySqlClient;
using school_management_system_model.Data.Repositories.Setings;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace school_management_system_model.Forms.settings
{
    public partial class frm_select_instructor : KryptonForm
    {
        InstructorRepository _instructorRepo = new InstructorRepository();
        public frm_select_instructor()
        {
            InitializeComponent();
        }

        private async void frm_select_instructor_Load(object sender, EventArgs e)
        {
            await loadRecords();
        }

        private async Task loadRecords()
        {
            var instructor = await _instructorRepo.GetAllAsync();
            dgv.DataSource = instructor.ToList();
            dgv.Columns["id"].Visible = false;
            dgv.Columns["fullname"].HeaderText = "Full Name";
            dgv.Columns["department_id"].HeaderText = "Department";
            dgv.Columns["position"].HeaderText = "Position";
        }

        private void selectInstructor()
        {
            frm_section_subjects.instance.Instructor = dgv.CurrentRow.Cells["id"].Value.ToString();
            Close();
        }

        private async void tSearch_TextChanged(object sender, EventArgs e)
        {
            if (tSearch.Text.Length > 2)
            {
                var con = new MySqlConnection(connection.con());
                var da = new MySqlDataAdapter("select * from instructors where concat(fullname, department, position) like '%"+ tSearch.Text +"%'", con);
                var dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
                dgv.Columns["fullname"].HeaderText = "Full Name";
                dgv.Columns["department_id"].HeaderText = "Department";
                dgv.Columns["position"].HeaderText = "Position";
            }
            else if (tSearch.Text.Length == 0)
            {
                await loadRecords();
            }
        }

        private void frm_select_instructor_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                selectInstructor();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            selectInstructor();
        }
    }
}
