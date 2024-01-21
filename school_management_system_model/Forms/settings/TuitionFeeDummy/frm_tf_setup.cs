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

namespace school_management_system_model.Forms.settings.TuitionFeeDummy
{
    public partial class frm_tf_setup : Form
    {
        public frm_tf_setup(string email)
        {
            InitializeComponent();
            Email = email;
        }

        public string Email { get; }

        private void frm_tf_setup_Load(object sender, EventArgs e)
        {
            loadRecords();
        }

        private void loadRecords()
        {
            var tuitionfee = new TuitionFeeSetup();
            dgv.DataSource = tuitionfee.loadRecords(cSemester.Text);
            dgv.Columns["id"].Visible = false;
            dgv.Columns["uid"].Visible = false;
            dgv.Columns["category"].HeaderText = "Category";
            dgv.Columns["description"].HeaderText = "Description";
            dgv.Columns["campus"].HeaderText = "Campus";
            dgv.Columns["year_level"].HeaderText = "Year Level";
            dgv.Columns["semester"].Visible = false;
            dgv.Columns["amount"].HeaderText = "Amount";
            
        }

        void addRecords()
        {
            if (btn_save.Text == "Save")
            {
                var add = new TuitionFeeSetup
                {
                    uid = tCategory.Text + tCampus.Text + tYearlevel.Text + tSemester.Text,
                    category = tCategory.Text,
                    description = tDescription.Text,
                    campus = tCampus.Text,
                    year_level = tYearlevel.Text,
                    semester = tSemester.Text,
                    amount = Convert.ToDecimal(tAmount.Text)
                };
                add.addRecords();
                new Classes.Toastr("Success", "Tuition Fee Setup Added");
                new ActivityLogger().activityLogger(Email, "Tuition fee setup add: " + tDescription.Text);
                loadRecords();
                txtclear();
            }
            else if (btn_save.Text == "Update")
            {

            }
        }

        private void txtclear()
        {
            tCategory.Clear();
            tDescription.Clear();
            tCampus.Text = "";
            tYearlevel.Clear();
            tSemester.Clear();
            tAmount.Clear();
            btn_save.Text = "Save";
            tDescription.Select();
        }
    }
}
