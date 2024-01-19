using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto.Modes.Gcm;
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
using school_management_system_model.Loggers;

namespace school_management_system_model.Forms.settings
{
    public partial class frm_courses : Form
    {
        public bool isAdd { get; set; }
        public bool isEdit { get; set; }
        public bool isDelete { get; set; }
        public bool isAdministrator { get; set; }
        public string Email { get; }

        string ID;

        

        public frm_courses(string email)
        {
            InitializeComponent();
            Email = email;
        }

        private void frm_courses_Load(object sender, EventArgs e)
        {
            loadrecords();
            loadcombobox();
        }

        private void loadcombobox()
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from levels", con);
            var dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                t3.Items.Add(item["code"]);
            }

            con = new MySqlConnection(connection.con());
            da = new MySqlDataAdapter("select * from campuses", con);
            dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow item in dt.Rows)
            {
                t4.Items.Add(item["code"]);
            }

            con = new MySqlConnection(connection.con());
            da = new MySqlDataAdapter("select * from departments", con);
            dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow item in dt.Rows)
            {
                t5.Items.Add(item["code"]);
            }
        }

        private void loadrecords()
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from courses order by id desc", con);
            var dt = new DataTable();
            da.Fill(dt);
            dgv.DataSource = dt;
            dgv.Columns[0].Visible = false;
            dgv.Columns["code"].HeaderText = "Code";
            dgv.Columns["description"].HeaderText = "Description";
            dgv.Columns["level"].HeaderText = "Level";
            dgv.Columns["campus"].HeaderText = "Campus";
            dgv.Columns["department"].HeaderText = "Department";
            dgv.Columns["max_units"].HeaderText = "Max Units";
            dgv.Columns["status"].HeaderText = "Status";
        }

        private void add_records()
        {
            try
            {

                if (btn_save.Text == "Save")
                {
                    var con = new MySqlConnection(connection.con());
                    con.Open();
                    var cmd = new MySqlCommand("insert into courses(code, description, level, campus, department, max_units, status) " +
                        "values(@1,@2,@3,@4,@5,@6,@7)", con);
                    cmd.Parameters.AddWithValue("@1", t1.Text);
                    cmd.Parameters.AddWithValue("@2", t2.Text);
                    cmd.Parameters.AddWithValue("@3", t3.Text);
                    cmd.Parameters.AddWithValue("@4", t4.Text);
                    cmd.Parameters.AddWithValue("@5", t5.Text);
                    cmd.Parameters.AddWithValue("@6", t6.Text);
                    cmd.Parameters.AddWithValue("@7", t7.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    new Classes.Toastr("Success", "Add Success");
                    new ActivityLogger().activityLogger(Email, "Course Add: " + t2.Text);

                    loadrecords();
                    txtclear();
                    

                }
                else if (btn_save.Text == "Update")
                {
                    var con = new MySqlConnection(connection.con());
                    con.Open();
                    var cmd = new MySqlCommand("update courses set code=@1, description=@2, level=@3, campus=@4, department=@5, max_units=@6, status=@7 " +
                        "where id='" + ID + "'", con);
                    cmd.Parameters.AddWithValue("@1", t1.Text);
                    cmd.Parameters.AddWithValue("@2", t2.Text);
                    cmd.Parameters.AddWithValue("@3", t3.Text);
                    cmd.Parameters.AddWithValue("@4", t4.Text);
                    cmd.Parameters.AddWithValue("@5", t5.Text);
                    cmd.Parameters.AddWithValue("@6", t6.Text);
                    cmd.Parameters.AddWithValue("@7", t7.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    
                    new Classes.Toastr("Information", "Update Success");
                    new ActivityLogger().activityLogger(Email, "Course Edit: " + t2.Text);

                    loadrecords();
                    txtclear();
                    
                    
                }
            }
            catch
            {
                new Classes.Toastr("Error", "Error, Missing Fields or Duplicate Entry");
            }
            
        }

        private void txtclear()
        {
            t1.Text = "";
            t2.Text = "";
            t3.Text = "";
            t4.Text = "";
            t5.Text = "";
            t6.Text = "";
            t7.Text = "";
            t1.Select();
            btn_save.Text = "Save";
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = dgv.CurrentRow.Cells[0].Value.ToString();
            t1.Text = dgv.CurrentRow.Cells[1].Value.ToString();
            t2.Text = dgv.CurrentRow.Cells[2].Value.ToString();
            t3.Text = dgv.CurrentRow.Cells[3].Value.ToString();
            t4.Text = dgv.CurrentRow.Cells[4].Value.ToString();
            t5.Text = dgv.CurrentRow.Cells[5].Value.ToString();
            t6.Text = dgv.CurrentRow.Cells[6].Value.ToString();
            t7.Text = dgv.CurrentRow.Cells[7].Value.ToString();
            btn_save.Text = "Update";
        }

        private void frm_courses_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                add_records();
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            add_records();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txtclear();
        }

        private void delete()
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter();
            da.SelectCommand = new MySqlCommand("delete from courses where id='" + ID + "'", con);
            var dt = new DataTable();
            da.Fill(dt);
            MessageBox.Show("Course Deleted");
            new Classes.Toastr("Information", "Course Deleted");
            new ActivityLogger().activityLogger(Email, "Course Delete: " + t2.Text);

            loadrecords();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("are you sure you want to delete this record","Warning!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (isDelete)
                {
                    delete();
                }
            }
        }

      
    }
}
