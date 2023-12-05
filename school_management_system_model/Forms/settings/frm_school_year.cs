using school_management_system_model.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace school_management_system_model.Forms.settings
{
    public partial class frm_school_year : Form
    {
        public frm_school_year()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            tFrom.Text = dateTimePicker1.Value.ToString("MM-dd-yyyy");
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            tTo.Text = dateTimePicker2.Value.ToString("MM-dd-yyyy");
        }

        private void frm_school_year_Load(object sender, EventArgs e)
        {
            loadRecords();
        }

        private void loadRecords()
        {
            var data = new SchoolYearSetup();
            dgv.DataSource = data.loadRecords();
            dgv.Columns["id"].Visible = false;
            dgv.Columns["code"].HeaderText = "Code";
            dgv.Columns["description"].HeaderText = "Description";
            dgv.Columns["description"].Width = 300;
            dgv.Columns["school_year_from"].HeaderText = "From";
            dgv.Columns["school_year_to"].HeaderText = "To";
            dgv.Columns["semester"].HeaderText = "Semester";
        }

        private void addRecords()
        {
            try
            {
                if (btn_save.Text == "Save")
                {
                    var add = new SchoolYearSetup
                    {
                        code = tCode.Text,
                        description = tDescription.Text,
                        from = tFrom.Text,
                        to = tTo.Text,
                        semester = tSemester.Text
                    };
                    add.addRecords();
                    MessageBox.Show("Successfully Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadRecords();
                    txtClear();
                }
                else if (btn_save.Text == "Update")
                {
                    int id = Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value);
                    var edit = new SchoolYearSetup
                    {
                        code = tCode.Text,
                        description = tDescription.Text,
                        from = tFrom.Text,
                        to = tTo.Text,
                        semester = tSemester.Text
                    };
                    edit.EditRecords(id);
                    MessageBox.Show("Successfully Updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadRecords();
                    txtClear();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }
        private void txtClear()
        {
            tCode.Clear();
            tDescription.Clear();
            tFrom.Clear();
            tTo.Clear();
            tSemester.Clear();
            btn_save.Text = "Save";
        }
        private void deleteRecords()
        {
            int id = Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value);
            var delete = new SchoolYearSetup();
            delete.deleteRecords(id);
            MessageBox.Show("Record Deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadRecords();
        }

        private void frm_school_year_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                addRecords();
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            addRecords();
        }

        private void dgv_Click(object sender, EventArgs e)
        {
            tCode.Text = dgv.CurrentRow.Cells["code"].Value.ToString();
            tDescription.Text = dgv.CurrentRow.Cells["description"].Value.ToString();
            tFrom.Text = dgv.CurrentRow.Cells["school_year_from"].Value.ToString();
            tTo.Text = dgv.CurrentRow.Cells["school_year_to"].Value.ToString();
            tSemester.Text = dgv.CurrentRow.Cells["semester"].Value.ToString();
            btn_save.Text = "Update";
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("are you sure you want to delete records?", "Warning", MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                deleteRecords();
            }
        }

        private void tsearch_TextChanged(object sender, EventArgs e)
        {
            if (tsearch.Text.Length > 2)
            {
                var search = new SchoolYearSetup();
                dgv.DataSource = search.searchRecords(tsearch.Text);
            }
            else if (tsearch.Text.Length == 0)
            {
                loadRecords();
            }
        }
    }
}
