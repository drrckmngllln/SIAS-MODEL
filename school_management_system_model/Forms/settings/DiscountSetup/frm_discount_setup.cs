using school_management_system_model.Classes;
using school_management_system_model.Core.Entities.Settings;
using school_management_system_model.Data.Repositories.Setings;
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
    public partial class frm_discount_setup : Form
    {
        DiscountRepository _discountRepo = new DiscountRepository();
        public string Email { get; }

        public frm_discount_setup(string email)
        {
            InitializeComponent();
            Email = email;
        }

        private void frm_discount_setup_Load(object sender, EventArgs e)
        {
            loadRecords();
        }

        private async void loadRecords()
        {
            var data = await _discountRepo.GetAllAsync();
            dgv.DataSource = data;
            dgv.Columns["id"].Visible = false;
            dgv.Columns["code"].HeaderText = "Code";
            dgv.Columns["discount_target"].HeaderText = "Discount Target";
            dgv.Columns["description"].HeaderText = "Description";
            dgv.Columns["description"].Width = 400;
            dgv.Columns["discount_percentage"].HeaderText = "Discount Percentage";
        }
        private async void addRecords()
        {
            try
            {
                if (btn_save.Text == "Save")
                {
                    if (cTuition.Checked)
                    {
                        var add = new Discount
                        {
                            code = tCode.Text,
                            description = tDescription.Text,
                            discount_target = cTuition.Text,
                            discount_percentage = Convert.ToInt32(tPercentage.Text)
                        };
                        await _discountRepo.AddRecords(add);
                    }
                    if (cMisc.Checked)
                    {
                        var add = new Discount
                        {
                            code = tCode.Text,
                            description = tDescription.Text,
                            discount_target = cMisc.Text,
                            discount_percentage = Convert.ToInt32(tPercentage.Text)
                        };
                        await _discountRepo.AddRecords(add);
                    }
                    if (cOther.Checked)
                    {
                        var add = new Discount
                        {
                            code = tCode.Text,
                            description = tDescription.Text,
                            discount_target = cOther.Text,
                            discount_percentage = Convert.ToInt32(tPercentage.Text)
                        };
                        await _discountRepo.AddRecords(add);
                    }
                    if (cLab.Checked)
                    {
                        var add = new Discount
                        {
                            code = tCode.Text,
                            description = tDescription.Text,
                            discount_target = cLab.Text,
                            discount_percentage = Convert.ToInt32(tPercentage.Text)
                        };
                        await _discountRepo.AddRecords(add);
                    }


                    new Classes.Toastr("Success", "Discount Setup Added");
                    new ActivityLogger().activityLogger(Email, "Add Discount: " + tDescription.Text);
                    txtClear();
                    loadRecords();
                }
                else if (btn_save.Text == "Update")
                {
                    if (cTuition.Checked)
                    {
                        var edit = new Discount
                        {
                            id = Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value),
                            code = tCode.Text,
                            description = tDescription.Text,
                            discount_target = cTuition.Text,
                            discount_percentage = Convert.ToInt32(tPercentage.Text)
                        };
                        await _discountRepo.UpdateRecords(edit);
                    }
                    if (cMisc.Checked)
                    {
                        var edit = new Discount
                        {
                            id = Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value),
                            code = tCode.Text,
                            description = tDescription.Text,
                            discount_target = cMisc.Text,
                            discount_percentage = Convert.ToInt32(tPercentage.Text)
                        };
                        await _discountRepo.UpdateRecords(edit);
                    }
                    if (cOther.Checked)
                    {
                        var edit = new Discount
                        {
                            id = Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value),

                            code = tCode.Text,
                            description = tDescription.Text,
                            discount_target = cOther.Text,
                            discount_percentage = Convert.ToInt32(tPercentage.Text)
                        };
                        await _discountRepo.UpdateRecords(edit);
                    }
                    if (cLab.Checked)
                    {
                        var edit = new Discount
                        {
                            id = Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value),
                            code = tCode.Text,
                            description = tDescription.Text,
                            discount_target = cLab.Text,
                            discount_percentage = Convert.ToInt32(tPercentage.Text)
                        };
                        await _discountRepo.UpdateRecords(edit);
                    }

                    new Classes.Toastr("Success", "Discount Setup Updated");

                    txtClear();
                    loadRecords();
                }
            }
            catch (Exception ex)
            {
                new Classes.Toastr("Warning", ex.Message);
            }

        }

        private void txtClear()
        {
            tCode.Clear();
            tDescription.Clear();
            tPercentage.Clear();
            btn_save.Text = "Save";
            cTuition.Checked = false; cLab.Checked = false; cOther.Checked = false; cLab.Checked = false;
        }

        private void frm_discount_setup_KeyDown(object sender, KeyEventArgs e)
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

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txtClear();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tCode.Text = dgv.CurrentRow.Cells["code"].Value.ToString();
            tDescription.Text = dgv.CurrentRow.Cells["description"].Value.ToString();
            tPercentage.Text = dgv.CurrentRow.Cells["discount_Percentage"].Value.ToString();
            if (dgv.CurrentRow.Cells["discount_target"].Value.ToString() == "Tuition Fee")
            {
                cTuition.Checked = true;
            }
            else
            {
                cTuition.Checked = false;
            }

            if (dgv.CurrentRow.Cells["discount_target"].Value.ToString() == "Miscellaneous Fee")
            {
                cMisc.Checked = true;
            }
            else
            {
                cMisc.Checked = false;
            }

            if (dgv.CurrentRow.Cells["discount_target"].Value.ToString() == "Other Fee")
            {
                cOther.Checked = true;
            }
            else
            {
                cOther.Checked = false;
            }

            if (dgv.CurrentRow.Cells["discount_target"].Value.ToString() == "Laboratory Fee")
            {
                cLab.Checked = true;
            }
            else
            {
                cLab.Checked = false;
            }

            btn_save.Text = "Update";
        }
        private async void deleteRecords()
        {
            var delete = new Discount();
            delete.id = Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value);
            await _discountRepo.DeleteRecords(delete);
            MessageBox.Show("Deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            new Classes.Toastr("Success", "Discount Setup Deleted");

            new ActivityLogger().activityLogger(Email, "Discount Delete: " + dgv.CurrentRow.Cells["description"].Value.ToString());
            loadRecords();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete this record?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                deleteRecords();
            }
        }

        private async void tsearch_TextChanged(object sender, EventArgs e)
        {
            if (tsearch.Text.Length > 2)
            {
                var data = await _discountRepo.GetAllAsync();
                var search = data.Where(x => x.code.ToLower().Contains(tsearch.Text.ToLower()) || x.description.ToLower().Contains(tsearch.Text))
                    .ToList();
                dgv.DataSource = search;
            }
            else if (tsearch.Text.Length == 0)
            {
                loadRecords();
            }
        }

        private void tDiscountTarget_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
