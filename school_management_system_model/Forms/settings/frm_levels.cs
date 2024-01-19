using MySql.Data.MySqlClient;
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
    public partial class frm_levels : Form
    {
        string ID;

        public string Email { get; }

        public frm_levels(string email)
        {
            InitializeComponent();
            Email = email;
        }

        private void frm_levels_Load(object sender, EventArgs e)
        {
            loadrecords();
        }

        private void loadrecords()
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from levels", con);
            var dt = new DataTable();
            da.Fill(dt);
            dgv.DataSource = dt;
            dgv.Columns["id"].Visible = false;
            dgv.Columns["code"].HeaderText = "Code";
            dgv.Columns["description"].HeaderText = "Description";
            dgv.Columns["status"].HeaderText = "Status";
        }

        private void add_records()
        {
            if (btn_save.Text == "Save")
            {
                var con = new MySqlConnection(connection.con());
                con.Open();
                var cmd = new MySqlCommand("insert into levels(code, description, status) values(@1,@2,@3)", con);
                cmd.Parameters.AddWithValue("@1", t1.Text);
                cmd.Parameters.AddWithValue("@2", t2.Text);
                cmd.Parameters.AddWithValue("@3", t3.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                
                new Classes.Toastr("Success", "Level Added");
                new ActivityLogger().activityLogger(Email, "Level Add: " + t2.Text);

                loadrecords();
                txtclear();

            }
            else if (btn_save.Text == "Update")
            {
                var con = new MySqlConnection(connection.con());
                con.Open();
                var cmd = new MySqlCommand("update levels set code=@1, description=@2, status=@3 where id='"+ ID +"'", con);
                cmd.Parameters.AddWithValue("@1", t1.Text);
                cmd.Parameters.AddWithValue("@2", t2.Text);
                cmd.Parameters.AddWithValue("@3", t3.Text);
                cmd.ExecuteNonQuery();
                con.Close();
             
                new Classes.Toastr("Information", "Level Updated");
                new ActivityLogger().activityLogger(Email, "Level Edit: " + t2.Text);

                loadrecords();
                txtclear();
            }
        }

        private void delete()
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter();
            da.SelectCommand = new MySqlCommand("delete from levels where id='" + ID + "'");
            var dt = new DataTable();
            da.Fill(dt);
            
            new Classes.Toastr("Information", "Level Deleted");
            new ActivityLogger().activityLogger(Email, "Level Delete: " + dgv.CurrentRow.Cells["description"].Value.ToString());

            loadrecords();
        }

        private void txtclear()
        {
            t1.Clear();
            t2.Clear();
            t3.Text = "";
            t1.Select();
            btn_save.Text = "Save";
        }
        
        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = dgv.CurrentRow.Cells[0].Value.ToString();
            t1.Text = dgv.CurrentRow.Cells[1].Value.ToString();
            t2.Text = dgv.CurrentRow.Cells[2].Value.ToString();
            t3.Text = dgv.CurrentRow.Cells[3].Value.ToString();
            btn_save.Text = "Update";
        }

        private void frm_levels_KeyDown(object sender, KeyEventArgs e)
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

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            delete();
        }
    }
}
