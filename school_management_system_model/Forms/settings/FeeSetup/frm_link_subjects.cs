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

namespace school_management_system_model.Forms.settings.FeeSetup
{
    public partial class frm_link_subjects : KryptonForm
    {
        public int id { get; set; }
        public frm_link_subjects()
        {
            InitializeComponent();
        }

        private void frm_link_subjects_Load(object sender, EventArgs e)
        {
            
            loadRecords();
        }

        private string labFee(int id)
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from lab_fee_setup where id='" + id + "'", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt.Rows[0]["description"].ToString();
        }

        private void loadRecords()
        {
            if (this.Text == "Select")
            {
                tTitle.Text = "Select Subjects: " + labFee(id);
                var con = new MySqlConnection(connection.con());
                var da = new MySqlDataAdapter("select code, descriptive_title from curriculum_subjects order by code asc", con);
                var dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;

                dgv.Columns["code"].HeaderText = "Subject Code";
                dgv.Columns["descriptive_title"].HeaderText = "Descriptive Title";
                dgv.Columns["code"].Width = 100;

                btnRemove.Visible = false;
            }
            else if (this.Text == "View")
            {
                tTitle.Text = "Linked Subjects: " + labFee(id);
                var con = new MySqlConnection(connection.con());
                var da = new MySqlDataAdapter("select * from lab_fee_subjects where lab_fee_id='"+ id +"'", con);
                var dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;

                dgv.Columns["id"].Visible = false;
                dgv.Columns["lab_fee_id"].Visible = false;
                dgv.Columns["subject_code"].HeaderText = "Subject Code";
                dgv.Columns["subject_code"].Width = 100;
                dgv.Columns["descriptive_title"].HeaderText = "Descriptive Title";

                btnSelect.Visible = false;
            }
        }

        private DataTable searchRecords(string search)
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select code, descriptive_title from curriculum_subjects where concat(code, descriptive_title) " +
                "like '%" + search + "%'", con);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        private void linkSubject(string code, string descriptiveTitle)
        {
            var con = new MySqlConnection (connection.con());
            con.Open();
            var cmd = new MySqlCommand("insert into lab_fee_subjects(lab_fee_id, subject_code, descriptive_title) " +
                "values('" + id + "','" + code + "','"+ descriptiveTitle +"')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Subject Linked","Success!",MessageBoxButtons.OK,MessageBoxIcon.Information);
            Close();
        }

        private void removeLink(int id)
        {
            var con = new MySqlConnection(connection.con());
            con.Open();
            var cmd = new MySqlCommand("delete from lab_fee_subjects where id='" + id + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            loadRecords();
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frm_link_subjects_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                linkSubject(
                    dgv.CurrentRow.Cells["code"].Value.ToString(),
                    dgv.CurrentRow.Cells["descriptive_title"].Value.ToString()
                    );
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            linkSubject(
                dgv.CurrentRow.Cells["code"].Value.ToString(),
                dgv.CurrentRow.Cells["descriptive_title"].Value.ToString()
                );
        }

        private void tsearch_TextChanged(object sender, EventArgs e)
        {
            if (tsearch.Text.Length > 2)
            {
                var search = searchRecords(tsearch.Text);
                dgv.DataSource = search;
            }
            else if (tsearch.Text.Length == 0)
            {
                loadRecords();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to unlink these subject?","Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                removeLink(Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value));
            }
        }
    }
}
