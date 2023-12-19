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

namespace school_management_system_model.Forms.transactions.StudentDiscounts
{
    public partial class frm_select_student : KryptonForm
    {
        public frm_select_student()
        {
            InitializeComponent();
        }

        private void frm_select_student_Load(object sender, EventArgs e)
        {
            loadRecords();
        }

        private void loadRecords()
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from student_accounts", con);
            var dt = new DataTable();
            da.Fill(dt);
            dgv.DataSource = dt;
            dgv.Columns["id"].Visible = false;
            dgv.Columns["id_number"].HeaderText = "Student Number";
            dgv.Columns["school_year"].Visible = false;
            dgv.Columns["fullname"].HeaderText = "Student Name";
            dgv.Columns["last_name"].Visible = false;
            dgv.Columns["first_name"].Visible = false;
            dgv.Columns["middle_name"].Visible = false;
            dgv.Columns["gender"].Visible = false;
            dgv.Columns["civil_status"].Visible = false;
            dgv.Columns["date_of_birth"].Visible = false;
            dgv.Columns["place_of_birth"].Visible = false;
            dgv.Columns["nationality"].Visible = false;
            dgv.Columns["religion"].Visible = false;
            dgv.Columns["status"].Visible = false;
            dgv.Columns["status"].Visible = false;
            dgv.Columns["contact_no"].Visible = false;
            dgv.Columns["email"].Visible = false;
            dgv.Columns["elem"].Visible = false;
            dgv.Columns["jhs"].Visible = false;
            dgv.Columns["shs"].Visible = false;
            dgv.Columns["elem_year"].Visible = false;
            dgv.Columns["jhs_year"].Visible = false;
            dgv.Columns["shs_year"].Visible = false;
            dgv.Columns["mother_name"].Visible = false;
            dgv.Columns["mother_no"].Visible = false;
            dgv.Columns["father_name"].Visible = false;
            dgv.Columns["father_no"].Visible = false;
            dgv.Columns["home_address"].Visible = false;
            dgv.Columns["m_occupation"].Visible = false;
            dgv.Columns["f_occupation"].Visible = false;


        }

        private string selectStudentName()
        {
            return dgv.CurrentRow.Cells["fullname"].Value.ToString();
        }
        private string selectStudentId()
        {
            return dgv.CurrentRow.Cells["id_number"].Value.ToString();
        }

        private void frm_select_student_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                frm_student_discounts.instance.idNumber = selectStudentId();
                frm_student_discounts.instance.fullname = selectStudentName();
                Close();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private DataTable searchRecords(string search)
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from student_accounts where concat(id_number, fullname) " +
                "like '%" + search + "%'", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        private void tSearch_TextChanged(object sender, EventArgs e)
        {
            if (tSearch.Text.Length > 2)
            {
                dgv.DataSource = searchRecords(tSearch.Text);
            }
            else if (tSearch.Text.Length == 0)
            {
                loadRecords();
            }
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
