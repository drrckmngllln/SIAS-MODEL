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

namespace school_management_system_model.Forms.settings
{
    public partial class frm_subjects : Form
    {
        string ID;
        public frm_subjects()
        {
            InitializeComponent();
        }

        private void frm_subjects_Load(object sender, EventArgs e)
        {
            loadrecords();
        }

        private void loadrecords()
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from subjects order by id desc", con);
            var dt = new DataTable();
            da.Fill(dt);
            dgv.DataSource = dt;
            dgv.Columns[0].Visible = false;
            dgv.Columns["semester"].HeaderText = "Semester";
            dgv.Columns["code"].HeaderText = "Subject Code";
            dgv.Columns["descriptive_title"].HeaderText = "Descriptive Tittle";
            dgv.Columns["descriptive_title"].Width = 350;
            dgv.Columns["total_units"].HeaderText = "Total Units";
            dgv.Columns["lecture_units"].HeaderText = "Lecture Units";
            dgv.Columns["lab_units"].HeaderText = "Lab Units";
            dgv.Columns["pre_requisite"].HeaderText = "Pre Requisite";
            dgv.Columns["total_hrs_per_week"].HeaderText = "Total Hours Per Week";
            dgv.Columns["status"].HeaderText = "Status";
        }

        private void add_records()
        {
            if (btn_save.Text == "Save")
            {
                try
                {
                    var con = new MySqlConnection(connection.con());
                    con.Open();
                    var cmd = new MySqlCommand("insert into subjects(semester, code, descriptive_title, total_units,lecture_units ,lab_units, pre_requisite, " +
                        "total_hrs_per_week, status) values(@1,@2,@3,@4,@5,@6,@7,@8,@9)", con);
                    cmd.Parameters.AddWithValue("@1", t1.Text);
                    cmd.Parameters.AddWithValue("@2", t2.Text);
                    cmd.Parameters.AddWithValue("@3", t3.Text);
                    cmd.Parameters.AddWithValue("@4", t4.Text);
                    cmd.Parameters.AddWithValue("@5", t5.Text);
                    cmd.Parameters.AddWithValue("@6", t6.Text);
                    cmd.Parameters.AddWithValue("@7", t7.Text);
                    cmd.Parameters.AddWithValue("@8", t8.Text);
                    cmd.Parameters.AddWithValue("@9", t9.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Subject Add Success");
                    loadrecords();
                    txtclear();

                }
                catch 
                {
                    MessageBox.Show("Error, Missing fields or Duplicate Entry");
                }

            }
            else if (btn_save.Text == "Update")
            {
                var con = new MySqlConnection(connection.con());
                con.Open();
                var cmd = new MySqlCommand("update subjects set semester=@1, code=@2, descriptive_title=@3, total_units=@4, lecture_units= @5, " +
                    "lab_units=@6, pre_requisite=@7, total_hrs_per_week=@8, status=@9 where id='"+ ID +"'", con);
                cmd.Parameters.AddWithValue("@1", t1.Text);
                cmd.Parameters.AddWithValue("@2", t2.Text);
                cmd.Parameters.AddWithValue("@3", t3.Text);
                cmd.Parameters.AddWithValue("@4", t4.Text);
                cmd.Parameters.AddWithValue("@5", t5.Text);
                cmd.Parameters.AddWithValue("@6", t6.Text);
                cmd.Parameters.AddWithValue("@7", t7.Text);
                cmd.Parameters.AddWithValue("@8", t8.Text);
                cmd.Parameters.AddWithValue("@9", t9.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Subject Update Success");
                loadrecords();
                txtclear();
            }
        }

        private void delete()
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter();
            da.SelectCommand = new MySqlCommand("delete from subjects where id='"+ ID +"'", con);
            var dt = new DataTable();
            da.Fill(dt);
            MessageBox.Show("Subject Deleted!");
            loadrecords();
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
            t8.Text = "";
            t9.Text = "";
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
            t8.Text = dgv.CurrentRow.Cells[8].Value.ToString();
            t9.Text = dgv.CurrentRow.Cells[9].Value.ToString();
            btn_save.Text = "Update";
        }

        private void frm_subjects_KeyDown(object sender, KeyEventArgs e)
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
            if (MessageBox.Show("are you sure you want to delete records?","Warning!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                delete();
            }
        }

        private void tsearch_TextChanged(object sender, EventArgs e)
        {
            if (tsearch.Text.Length > 2)
            {
                var con = new MySqlConnection(connection.con());
                var da = new MySqlDataAdapter("select * from subjects where concat(semester, code, descriptive_title, total_units, " +
                    "lecture_units, lab_units, pre_requisite, total_hrs_per_week, status) like '%" + tsearch.Text + "%' order by id desc", con);
                var dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
                dgv.Columns[0].Visible = false;
                dgv.Columns["semester"].HeaderText = "Semester";
                dgv.Columns["code"].HeaderText = "Subject Code";
                dgv.Columns["descriptive_title"].HeaderText = "Descriptive Tittle";
                dgv.Columns["descriptive_title"].Width = 350;
                dgv.Columns["total_units"].HeaderText = "Total Units";
                dgv.Columns["lecture_units"].HeaderText = "Lecture Units";
                dgv.Columns["lab_units"].HeaderText = "Lab Units";
                dgv.Columns["pre_requisite"].HeaderText = "Pre Requisite";
                dgv.Columns["total_hrs_per_week"].HeaderText = "Total Hours Per Week";
                dgv.Columns["status"].HeaderText = "Status";
            }
            else if (tsearch.Text.Length == 0)
            {
                loadrecords();
            }
        }
    }
}
