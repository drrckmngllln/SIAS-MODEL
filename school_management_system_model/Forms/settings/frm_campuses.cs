using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace school_management_system_model.Forms.settings
{
    public partial class frm_campuses : Form
    {
        public frm_campuses()
        {
            InitializeComponent();
        }

        private void frm_campuses_Load(object sender, EventArgs e)
        {
            loadrecords();
        }

        private void loadrecords()
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from campuses", con);
            var dt = new DataTable();
            da.Fill(dt);
            dgv.DataSource = dt;
            dgv.Columns["id"].Visible = false;
            dgv.Columns["code"].HeaderText = "Code";
            dgv.Columns["description"].HeaderText = "Description";
            dgv.Columns["address"].HeaderText = "Address";
            dgv.Columns["status"].HeaderText = "Status";

        }

        private void add_records()
        {
            if (btn_save.Text == "Save")
            {
                var con = new MySqlConnection(connection.con());
                con.Open();
                var cmd = new MySqlCommand("insert into campuses(code, description, address, status) values(@1,@2,@3,@4)", con);
                cmd.Parameters.AddWithValue("@1", t1.Text);
                cmd.Parameters.AddWithValue("@2", t2.Text);
                cmd.Parameters.AddWithValue("@3", t3.Text);
                cmd.Parameters.AddWithValue("@4", t4.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                
                new Classes.Toastr().toast("Success", "Campus Add Success");
                loadrecords();
                txtclear();
            }
            else if (btn_save.Text == "Update")
            {
                var con = new MySqlConnection(connection.con());
                con.Open();
                var cmd = new MySqlCommand("update campuses set code=@1, description=@2, address=@3, status=@4 where id='"+ ID +"'", con);
                cmd.Parameters.AddWithValue("@1", t1.Text);
                cmd.Parameters.AddWithValue("@2", t2.Text);
                cmd.Parameters.AddWithValue("@3", t3.Text);
                cmd.Parameters.AddWithValue("@4", t4.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                
                new Classes.Toastr().toast("Information", "Campus Update Success");
                loadrecords();
                txtclear();
            }
        }

        private void txtclear()
        {
            t1.Clear();
            t2.Clear();
            t3.Clear();
            t4.Text = "";
            t1.Select();
            btn_save.Text = "Save";
        }

        private void frm_campuses_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                add_records();
            }
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            add_records();
        }
        string ID;
        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = dgv.CurrentRow.Cells[0].Value.ToString();
            t1.Text = dgv.CurrentRow.Cells[1].Value.ToString();
            t2.Text = dgv.CurrentRow.Cells[2].Value.ToString();
            t3.Text = dgv.CurrentRow.Cells[3].Value.ToString();
            t4.Text = dgv.CurrentRow.Cells[4].Value.ToString();
            btn_save.Text = "Update";
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txtclear();
        }

        private void delete()
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter();
            da.SelectCommand = new MySqlCommand("delete from campuses where id='" + ID + "'", con);
            var dt = new DataTable();
            da.Fill(dt);
            
            new Classes.Toastr().toast("Information", "Campus Deleted");
            loadrecords();
        }

        private void kryptonButton1_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("are you sure you want to delete this campus?", "warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                delete();
            }
        }
    }
}
