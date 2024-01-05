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

namespace school_management_system_model.Forms.settings.Schedule
{
    public partial class frm_admission_schedule : Form
    {
        
        public frm_admission_schedule()
        {
            InitializeComponent();
        }

        private void frm_admission_schedule_Load(object sender, EventArgs e)
        {
            loadRecords();
        }

        private async void loadRecords()
        {
            var data = new AdmissionSchedule().loadRecords();
            await Task.Delay(100);
            dgv.DataSource = data;
            dgv.Columns["id"].Visible = false;
            dgv.Columns["code"].HeaderText = "Code";
            dgv.Columns["description"].HeaderText = "Description";
            dgv.Columns["description"].Width = 350;
            dgv.Columns["schedule_from"].HeaderText = "From";
            dgv.Columns["schedule_to"].HeaderText = "To";
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            tFrom.Text = dateTimePicker1.Value.ToString("yyyy-MM-dd");
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            tTo.Text = dateTimePicker2.Value.ToString("yyyy-MM-dd");
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (btn_save.Text == "Save")
                {
                    var addRecords = new AdmissionSchedule
                    {
                        code = tCode.Text,
                        description = tDescription.Text,
                        schedule_from = tFrom.Text,
                        schedule_to = tTo.Text,
                    };
                    addRecords.AddRecords();
                    new Classes.Toastr().toast("Success", "Schedule Saved");
                    loadRecords();
                    txtclear();
                }
                else if (btn_save.Text == "Update")
                {
                    var editRecords = new AdmissionSchedule
                    {
                        code = tCode.Text,
                        description = tDescription.Text,
                        schedule_from = tFrom.Text,
                        schedule_to = tTo.Text,
                    };
                    editRecords.EditRecords(Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value));
                    new Classes.Toastr().toast("Information", "Schedule Updated");
                    loadRecords();
                    txtclear();
                }
            }
            catch (Exception ex)
            {
                new Classes.Toastr().toast("Error", ex.Message);
            }
        }

        private void txtclear()
        {
            tCode.Text = "";
            tDescription.Clear();
            tFrom.Clear();
            tTo.Clear();
            tCode.Select();
            btn_save.Text = "Save";
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txtclear();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this record?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var delete = new AdmissionSchedule();
                delete.DeleteRecords(Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value));
                new Classes.Toastr().toast("Information", "Schedule deleted");
                loadRecords();
            }
        }

        private void tsearch_TextChanged(object sender, EventArgs e)
        {
            if (tsearch.Text.Length > 2)
            {
                var search = new AdmissionSchedule().searchRecords(tsearch.Text);
                dgv.DataSource = search;
            }
            else if (tsearch.Text.Length == 0)
            {
                loadRecords();
            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tCode.Text = dgv.CurrentRow.Cells["code"].Value.ToString();
            tDescription.Text = dgv.CurrentRow.Cells["description"].Value.ToString();
            tFrom.Text = dgv.CurrentRow.Cells["schedule_from"].Value.ToString();
            tTo.Text = dgv.CurrentRow.Cells["schedule_to"].Value.ToString();
            btn_save.Text = "Update";
        }
    }
}
