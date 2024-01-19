using Krypton.Toolkit;
using MySql.Data.MySqlClient;
using school_management_system_model.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace school_management_system_model.Forms.settings.UserManagement
{
    public partial class frm_set_accessLevel : KryptonForm
    {
        public frm_set_accessLevel(string office)
        {
            InitializeComponent();
            Office = office;
        }

        public string Office { get; }
        MySqlConnection con = new MySqlConnection();

        private void frm_set_accessLevel_Load(object sender, EventArgs e)
        {
            loadRecords(Office);
        }

        private void loadRecords(string office)
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from access_level where office='" + office + "'", con);
            var dt = new DataTable();
            da.Fill(dt);
            dgv.DataSource = dt;
            dgv.Columns["id"].Visible = false;
            dgv.Columns["access_level"].HeaderText = "Access Level";
            dgv.Columns["office"].Visible = false;
        }

        private void addRecords()
        {
            try
            {
                if (btnSave.Text == "Save")
                {
                    con = new MySqlConnection(connection.con());
                    con.Open();
                    var cmd = new MySqlCommand("insert into access_level(access_level, office) values('" + tAccessLevel.Text + "','" + Office + "')", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    new Classes.Toastr("Success", "Access Level Added");
                    txtClear();
                }
                else if (btnSave.Text == "Update")
                {
                    con = new MySqlConnection(connection.con());
                    con.Open();
                    var cmd = new MySqlCommand("update access_level set access_level='" + tAccessLevel.Text + "' " +
                        "where id='" + Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value) + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    new Classes.Toastr("Information", "Access Level Updated");
                    txtClear();
                }
            }
            catch(Exception ex)
            {
                new Classes.Toastr("Error", ex.Message);
            }
        }

        private void txtClear()
        {
            tAccessLevel.Clear();
            tAccessLevel.Select();
            btnSave.Text = "Save";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            addRecords();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tAccessLevel.Text = dgv.CurrentRow.Cells["access_level"].Value.ToString();
            btnSave.Text = "Update";
        }
    }
}
