using MySql.Data.MySqlClient;
using school_management_system_model.Classes;
using school_management_system_model.Loggers;
using System;
using System.Data;
using System.Windows.Forms;

namespace school_management_system_model.Forms.settings
{
    public partial class frm_curriculum : Form
    {
        string ID;

        public string Email { get; }
        

        public frm_curriculum(string email)
        {
            InitializeComponent();
            Email = email;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            t5.Text = dateTimePicker1.Value.ToString("dd-MM-yyyy");
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            t6.Text = dateTimePicker2.Value.ToString("dd-MM-yyyy");
        }

        private void frm_curriculum_Load(object sender, EventArgs e)
        {
            loadrecords();
            loadcombobox();
        }

        private void loadcombobox()
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from campuses", con);
            var dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                t3.Items.Add(item["code"]);
            }

            con = new MySqlConnection(connection.con());
            da = new MySqlDataAdapter("select * from courses", con);
            dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                t4.Items.Add(item["code"]);
            }
        }

        private void loadrecords()
        {
            var data = new Curriculums();
            dgv.DataSource = data.loadRecords();
            dgv.Columns["id"].Visible = false;
            dgv.Columns["code"].HeaderText = "Curriculum Code";
            dgv.Columns["description"].HeaderText = "Curriculum Description";
            dgv.Columns["description"].Width = 400;
            dgv.Columns["campus"].HeaderText = "Campus";
            dgv.Columns["course"].HeaderText = "Course";
            dgv.Columns["effective"].HeaderText = "Effective";
            dgv.Columns["expires"].HeaderText = "Expires";
            dgv.Columns["status"].HeaderText = "Status";
        }

        private void add_records()
        {
            if (btn_save.Text == "Save")
            {
                var add = new Curriculums
                {
                    code = t1.Text,
                    description = t2.Text,
                    campus = t3.Text,
                    course = t4.Text,
                    effective = t5.Text,
                    expires = t6.Text,
                    status = t7.Text
                };
                add.addRecords();
                new ActivityLogger().activityLogger(Email, "Add: " + t2.Text);
                
                new Classes.Toastr().toast("Success", "Curriculum Added");
                loadrecords();
                txtclear();

            }
            else if (btn_save.Text == "Update")
            {
                var edit = new Curriculums
                {
                    code = t1.Text,
                    description = t2.Text,
                    campus = t3.Text,
                    course = t4.Text,
                    effective = t5.Text,
                    expires = t6.Text,
                    status = t7.Text
                };
                edit.editRecords(dgv.CurrentRow.Cells["id"].Value.ToString());
                new ActivityLogger().activityLogger(Email, "Edit: " + t2.Text);
                new Classes.Toastr().toast("Information", "Curriculum Updated");

                loadrecords();
                txtclear();
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
            btn_save.Text = "Save";
        }

        private void delete()
        {
            var delete = new Curriculums();
            delete.deleteRecords(dgv.CurrentRow.Cells["id"].Value.ToString());
            
            new Classes.Toastr().toast("Information", "Curriculum Deleted");
            new ActivityLogger().activityLogger(Email, "Delete Curriculum: " + dgv.CurrentRow.Cells["description"].Value.ToString());
            loadrecords();
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

        private void frm_curriculum_KeyDown(object sender, KeyEventArgs e)
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
            if (MessageBox.Show("are you sure you want to delete record?", "Warning!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                delete();
            }
        }

        
        private void tsearch_TextChanged(object sender, EventArgs e)
        {
            if (tsearch.Text.Length > 2)
            {
                var search = new Curriculums();
                var data = search.searchRecords(tsearch.Text);
                dgv.DataSource = data;
            }
            else if (tsearch.Text.Length == 0)
            {
                loadrecords();
            }
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
           
            var frm = new frm_curriculum_subjects(Email);
            frm_curriculum_subjects.instance.Curriculum = dgv.CurrentRow.Cells["code"].Value.ToString();
            frm.Text = "Curriculum Subject of " + dgv.CurrentRow.Cells["code"].Value.ToString();
            frm.ShowDialog();
        }

        
    }
}
