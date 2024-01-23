using MySql.Data.MySqlClient;
using school_management_system_model.Classes;
using school_management_system_model.Loggers;
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
    public partial class frm_departments : Form
    {
        public frm_departments(string email)
        {
            InitializeComponent();
            Email = email;
        }

        private void frm_departments_Load(object sender, EventArgs e)
        {
            loadrecords();
            loadCampus();
        }

        private void loadCampus()
        {
            var campus = new Campuses().GetCampuses();

            tCampus.ValueMember = "id";
            tCampus.DisplayMember = "code";
            tCampus.DataSource = campus;
        }

        private void loadrecords()
        {
            var departments = new Departments().GetDepartments().ToList();
            dgv.DataSource = departments;
            dgv.Columns["id"].Visible = false;
            dgv.Columns["code"].HeaderText = "Code";
            dgv.Columns["description"].HeaderText = "Description";
            dgv.Columns["campus_id"].HeaderText = "Campus";
        }

        string ID;

        public string Email { get; }

        private void add_records()
        {
            if (btn_save.Text == "Save")
            {
                var con = new MySqlConnection(connection.con());
                con.Open();
                var cmd = new MySqlCommand("insert into departments(code, description, campus_id) values(@1,@2,@3)", con);
                cmd.Parameters.AddWithValue("@1", tCode.Text);
                cmd.Parameters.AddWithValue("@2", tDescription.Text);
                cmd.Parameters.AddWithValue("@3", tCampus.SelectedValue.ToString());
                cmd.ExecuteNonQuery();
                con.Close();
                
                new Classes.Toastr("Success", "Department Added");
                new ActivityLogger().activityLogger(Email, "Department Add: " + tDescription.Text);

                loadrecords();
                txtclear();
            }
            else
            {
                var con = new MySqlConnection(connection.con());
                con.Open();
                var cmd = new MySqlCommand("update departments set code=@1, description=@2, campus_id=@3 where id='"+ ID +"'", con);
                cmd.Parameters.AddWithValue("@1", tCode.Text);
                cmd.Parameters.AddWithValue("@2", tDescription.Text);
                cmd.Parameters.AddWithValue("@3", tCampus.SelectedValue.ToString());
                cmd.ExecuteNonQuery();
                con.Close();
               
                new Classes.Toastr("Information", "Department Updated");
                new ActivityLogger().activityLogger(Email, "Department Edit: " + tDescription.Text);

                loadrecords();
                txtclear();
            }
        }

        private void txtclear()
        {
            tCode.Clear();
            tDescription.Clear();
            tCampus.Text = "";
            tCode.Select();
            btn_save.Text = "Save";
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = dgv.CurrentRow.Cells[0].Value.ToString();
            tCode.Text = dgv.CurrentRow.Cells[1].Value.ToString();
            tDescription.Text = dgv.CurrentRow.Cells[2].Value.ToString();
            tCampus.Text = dgv.CurrentRow.Cells[3].Value.ToString();
            btn_save.Text = "Update";
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            add_records();
        }

        private void frm_departments_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                add_records();
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txtclear();
        }

        private void delete()
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter();

            da.SelectCommand = new MySqlCommand("delete from departments where id='" + ID + "'", con);
            var dt = new DataTable();
            da.Fill(dt);
            new Classes.Toastr("Information", "Department Deleted");
            new ActivityLogger().activityLogger(Email, "Department Delete: " + tDescription.Text);

            loadrecords();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("are you sure you want to delete record?", "warning!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                delete();
            }
        }
    }
}
