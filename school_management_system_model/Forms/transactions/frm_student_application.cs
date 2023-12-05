using school_management_system_model.Forms.transactions.Classes;
using System;
using System.Data;
using System.Windows.Forms;

namespace school_management_system_model.Forms.transactions
{
    public partial class frm_student_application : Form
    {
        public static frm_student_application instance;
        public DataTable dt = new DataTable();
        public frm_student_application()
        {
            instance = this;
            InitializeComponent();
        }

        private void frm_student_application_Load(object sender, EventArgs e)
        {
            loadRecords();
        }

        private void loadRecords()
        {
            var data = new student_accounts();
            data.loadRecords();
            dgv.DataSource = dt;
            dgv.Columns["id"].Visible = false;
            dgv.Columns["id_number"].HeaderText = "ID Number";
            dgv.Columns["fullname"].HeaderText = "Name";
            dgv.Columns["fullname"].Width = 400;
            dgv.Columns["last_name"].Visible = false;
            dgv.Columns["first_name"].Visible = false;
            dgv.Columns["middle_name"].Visible = false;
            dgv.Columns["gender"].HeaderText = "Gender";
            dgv.Columns["civil_status"].HeaderText = "Civil Status";
            dgv.Columns["date_of_birth"].HeaderText = "Date of Birth";
            dgv.Columns["place_of_birth"].HeaderText = "Place of Birth";
            dgv.Columns["nationality"].HeaderText = "Nationality";
            dgv.Columns["religion"].HeaderText = "Religion";
            dgv.Columns["status"].HeaderText = "Status";


        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            addRecords();
        }

        private void addRecords()
        {
            if (btn_save.Text == "Create Account")
            {
                try
                {
                    var id_number = dgv.Rows.Count;
                    var add = new student_accounts
                    {
                        id_number = tIDNumber.Text,
                        semester = tsemester.Text,
                        full_name = tlastname.Text + ", " + tfirstname.Text + " " + tmiddlename.Text,
                        last_name = tlastname.Text,
                        first_name = tfirstname.Text,
                        middle_name = tmiddlename.Text,
                        gender = tgender.Text,
                        civil_status = tcivilstatus.Text,
                        date_of_birth = Convert.ToDateTime(tdateofbirth.Text),
                        place_of_birth = tplaceofbirth.Text,
                        nationality = tnationality.Text,
                        religion = treligion.Text,
                        status = tstatus.Text
                    };
                    add.addRecords();
                    loadRecords();
                    MessageBox.Show("Student Account Successfully Created!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtclear();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else if (btn_save.Text == "Update Account")
            {
                var edit = new student_accounts
                {
                    id_number = tIDNumber.Text,
                    full_name = tlastname.Text + ", " + tfirstname.Text + " " + tmiddlename.Text,
                    last_name = tlastname.Text,
                    first_name = tfirstname.Text,
                    middle_name = tmiddlename.Text,
                    gender = tgender.Text,
                    civil_status = tcivilstatus.Text,
                    date_of_birth = Convert.ToDateTime(tdateofbirth.Text),
                    place_of_birth = tplaceofbirth.Text,
                    nationality = tnationality.Text,
                    religion = treligion.Text,
                    status = tstatus.Text
                };
                edit.editRecords();
                loadRecords();
                MessageBox.Show("Student Account Successfully Updated!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void txtclear()
        {
            tIDNumber.Text = "";
            tlastname.Text = "";
            tfirstname.Text = "";
            tmiddlename.Text = "";
            tgender.Text = "";
            tcivilstatus.Text = "";
            tdateofbirth.Text = "";
            tplaceofbirth.Text = "";
            tnationality.Text = "";
            treligion.Text = "";
            tstatus.Text = "Pending";
            btn_save.Text = "Create Account";
            tsemester.Enabled = true;
        }

        private void tsemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            var dgvcount = dgv.Rows.Count + 1;
            if (dgv.Rows.Count == 0)
            {
                tIDNumber.Text = DateTime.Now.ToString("yyyy-") + tsemester.Text + "-0001";
            }
            else if (dgv.Rows.Count < 10)
            {
                tIDNumber.Text = DateTime.Now.ToString("yyyy-") + tsemester.Text + "-000" + dgvcount++;
            }
        }

        private void kryptonDateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            tdateofbirth.Text = kryptonDateTimePicker1.Value.ToString("yyyy-MM-dd");
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tsemester.Text = dgv.CurrentRow.Cells["semester"].Value.ToString();
            tIDNumber.Text = dgv.CurrentRow.Cells["id_number"].Value.ToString();
            tlastname.Text = dgv.CurrentRow.Cells["last_name"].Value.ToString();
            tfirstname.Text = dgv.CurrentRow.Cells["first_name"].Value.ToString();
            tmiddlename.Text = dgv.CurrentRow.Cells["middle_name"].Value.ToString();
            tgender.Text = dgv.CurrentRow.Cells["gender"].Value.ToString();
            tcivilstatus.Text = dgv.CurrentRow.Cells["civil_status"].Value.ToString();
            tdateofbirth.Text = dgv.CurrentRow.Cells["date_of_birth"].Value.ToString();
            tplaceofbirth.Text = dgv.CurrentRow.Cells["place_of_birth"].Value.ToString();
            tnationality.Text = dgv.CurrentRow.Cells["nationality"].Value.ToString();
            treligion.Text = dgv.CurrentRow.Cells["religion"].Value.ToString();
            tstatus.Text = dgv.CurrentRow.Cells["status"].Value.ToString();
            btn_save.Text = "Update Account";
            tsemester.Enabled = false;
            tinfoStatus.Text = dgv.CurrentRow.Cells["status"].Value.ToString();

            if (dgv.CurrentRow.Cells["status"].Value.ToString() == "For Enrollment")
            {
                btnEnrol.Visible = true;
            }
            else
            {
                btnEnrol.Visible = false;
            }
            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            txtclear();
        }

        private void tsearch_TextChanged(object sender, EventArgs e)
        {
            if (tsearch.Text.Length > 2)
            {
                var search = new student_accounts
                {
                    search = tsearch.Text,
                };
                search.searchRecords();
                dgv.DataSource = dt;
                dgv.Columns["id"].Visible = false;
                dgv.Columns["id_number"].HeaderText = "ID Number";
                dgv.Columns["fullname"].HeaderText = "Name";
                dgv.Columns["fullname"].Width = 400;
                dgv.Columns["last_name"].Visible = false;
                dgv.Columns["first_name"].Visible = false;
                dgv.Columns["middle_name"].Visible = false;
                dgv.Columns["gender"].HeaderText = "Gender";
                dgv.Columns["civil_status"].HeaderText = "Civil Status";
                dgv.Columns["date_of_birth"].HeaderText = "Date of Birth";
                dgv.Columns["place_of_birth"].HeaderText = "Place of Birth";
                dgv.Columns["nationality"].HeaderText = "Nationality";
                dgv.Columns["religion"].HeaderText = "Religion";
                dgv.Columns["status"].HeaderText = "Status";
            }
            else if (tsearch.Text.Length == 0)
            {
                loadRecords();
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to approve account?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) 
                == DialogResult.Yes)
            {
                var approve = new student_accounts
                {
                    id_number = dgv.CurrentRow.Cells["id_number"].Value.ToString()
                };
                approve.approveAccount();
                loadRecords();
            }
        }

        private void btnEnrol_Click(object sender, EventArgs e)
        {
            var frm = new frm_student_enrollment();
            frm.Text = "Enrollment: " + dgv.CurrentRow.Cells["id_number"].Value.ToString();
            frm_student_enrollment.instance.id_number = dgv.CurrentRow.Cells["id_number"].Value.ToString();
            frm_student_enrollment.instance.studentName = dgv.CurrentRow.Cells["fullname"].Value.ToString();
            frm.ShowDialog();
            loadRecords();
        }

       
    }
}
