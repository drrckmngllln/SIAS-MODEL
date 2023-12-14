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

namespace school_management_system_model.Forms.transactions
{
    public partial class frm_select_student : KryptonForm
    {
        public string campus { get; set; }
        public string yearLevel { get; set; }
        public string id_number { get; set; }
        public static frm_select_student instance;
        public frm_select_student()
        {
            instance = this;
            InitializeComponent();
        }

        private void frm_select_student_Load(object sender, EventArgs e)
        {
            loadRecords();
        }

        private void loadRecords()
        {
            if (this.Text == "Select Student")
            {
                tTitle.Text = this.Text;
                var con = new MySqlConnection(connection.con());
                var da = new MySqlDataAdapter("select * from student_accounts where status='Accounting' order by fullname asc", con);
                var dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
                dgv.Columns["id"].Visible = false;
                dgv.Columns["id_number"].HeaderText = "ID Number";
                dgv.Columns["sy_enrolled"].Visible = false;
                dgv.Columns["school_year"].HeaderText = "School Year";
                dgv.Columns["fullname"].HeaderText = "Student Name";
                dgv.Columns["fullname"].Width = 250;
                dgv.Columns["last_name"].Visible = false;
                dgv.Columns["first_name"].Visible = false;
                dgv.Columns["middle_name"].Visible = false;
                dgv.Columns["gender"].HeaderText = "Gender";
                dgv.Columns["civil_status"].Visible = false;
                dgv.Columns["date_of_birth"].Visible = false;
                dgv.Columns["place_of_birth"].Visible = false;
                dgv.Columns["nationality"].Visible = false;
                dgv.Columns["religion"].Visible = false;
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
            }
            else if (this.Text == "Select School Year")
            {
                tTitle.Text = this.Text;
                var con = new MySqlConnection(connection.con());
                var da = new MySqlDataAdapter("select * from school_year order by id desc", con);
                var dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
                dgv.Columns["id"].Visible = false;
                dgv.Columns["code"].HeaderText = "Code";
                dgv.Columns["description"].HeaderText = "Description";
                dgv.Columns["description"].Width = 300;
                dgv.Columns["school_year_from"].HeaderText = "From";
                dgv.Columns["school_year_to"].HeaderText = "To";
                dgv.Columns["semester"].HeaderText = "Semester";
            }
            else if (this.Text == "Select Lab Fee")
            {
                tTitle.Text = this.Text;
                var con = new MySqlConnection (connection.con());
                var da = new MySqlDataAdapter("select * from lab_fee_setup where campus='"+ campus +"'", con);
                var dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
                dgv.Columns["id"].Visible = false;
                dgv.Columns["category"].HeaderText = "Category";
                dgv.Columns["campus"].Visible = false;
                dgv.Columns["first_year"].HeaderText = "1st Year";
                dgv.Columns["second_year"].HeaderText = "2nd Year";
                dgv.Columns["third_year"].HeaderText = "3rd Year";
                dgv.Columns["fourth_year"].HeaderText = "4th Year";
            }
            else if (this.Text == "View Subjects")
            {
                
            }
        }

        private string selectStudent()
        {
            return dgv.CurrentRow.Cells["id_number"].Value.ToString();
        }
        private string selectSchoolYear()
        {
            return dgv.CurrentRow.Cells["code"].Value.ToString();
        }

        private void frm_select_student_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if(this.Text == "Select Student")
                {
                    frm_student_assessment.instance.studentID = selectStudent();
                    this.Close();
                }
                else if (this.Text == "Select School Year")
                {
                    frm_student_assessment.instance.schoolYear = selectSchoolYear();
                    this.Close();
                }
                else if (this.Text == "Select Lab Fee")
                {
                    if (yearLevel == "1")
                    {
                        frm_student_assessment.instance.labFee = Convert.ToDecimal(dgv.CurrentRow.Cells["first_year"].Value);
                        frm_student_assessment.instance.labFeeCategory = dgv.CurrentRow.Cells["category"].Value.ToString();
                        this.Close();
                    }
                    else if (yearLevel == "2")
                    {
                        frm_student_assessment.instance.labFee = Convert.ToDecimal(dgv.CurrentRow.Cells["second_year"].Value);
                        frm_student_assessment.instance.labFeeCategory = dgv.CurrentRow.Cells["category"].Value.ToString();
                        this.Close();
                    }
                    else if(yearLevel == "3")
                    {
                        frm_student_assessment.instance.labFee = Convert.ToDecimal(dgv.CurrentRow.Cells["third_year"].Value);
                        frm_student_assessment.instance.labFeeCategory = dgv.CurrentRow.Cells["category"].Value.ToString();
                        this.Close();
                    }
                    else if (yearLevel == "4")
                    {
                        frm_student_assessment.instance.labFee = Convert.ToDecimal(dgv.CurrentRow.Cells["fourth_year"].Value);
                        frm_student_assessment.instance.labFeeCategory = dgv.CurrentRow.Cells["category"].Value.ToString();
                        this.Close();
                    }
                }
                
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void tSearch_TextChanged(object sender, EventArgs e)
        {
            if (this.Text == "Select Student")
            {
                if (tSearch.Text.Length > 2)
                {
                    var con = new MySqlConnection(connection.con());
                    var da = new MySqlDataAdapter("select * from student_accounts " +
                        "where concat(id_number, last_name, first_name, middle_name) like '%" + tSearch.Text + "%' " +
                        "and status='Accounting'", con);
                    var dt = new DataTable();
                    da.Fill(dt);
                    dgv.DataSource = dt;
                    dgv.Columns["id"].Visible = false;
                    dgv.Columns["id_number"].HeaderText = "ID Number";
                    dgv.Columns["school_year"].HeaderText = "School Year";
                    dgv.Columns["fullname"].HeaderText = "Student Name";
                    dgv.Columns["fullname"].Width = 250;
                    dgv.Columns["last_name"].Visible = false;
                    dgv.Columns["first_name"].Visible = false;
                    dgv.Columns["middle_name"].Visible = false;
                    dgv.Columns["gender"].HeaderText = "Gender";
                    dgv.Columns["civil_status"].Visible = false;
                    dgv.Columns["date_of_birth"].Visible = false;
                    dgv.Columns["place_of_birth"].Visible = false;
                    dgv.Columns["nationality"].Visible = false;
                    dgv.Columns["religion"].Visible = false;
                    dgv.Columns["status"].Visible = false;
                }
                else if (tSearch.Text.Length == 0)
                {
                    loadRecords();
                }
            }
            else if (this.Text == "Select School Year")
            {

            }
        }
    }
}
