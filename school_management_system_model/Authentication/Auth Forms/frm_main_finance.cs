using Krypton.Toolkit;
using school_management_system_model.Authentication.Login;
using school_management_system_model.Forms.settings;
using school_management_system_model.Forms.settings.FeeSetup;
using school_management_system_model.Forms.settings.UserManagement;
using school_management_system_model.Forms.transactions;
using school_management_system_model.Forms.transactions.Collection;
using school_management_system_model.Forms.transactions.StudentDiscounts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace school_management_system_model.Authentication.Auth_Forms
{
    public partial class frm_main_finance : KryptonForm
    {
        public string Fullname { get; set; }
        public string AccessLevel { get; set; }
        public bool IsAdministrator { get; set; }
        public bool IsAdd { get; set; }
        public bool IsEdit { get; set; }
        public bool IsDelete { get; set; }
        public string Email { get; set; }

        const string Office = "Finance";

        public frm_main_finance()
        {
            InitializeComponent();
            
        }

        private void frm_main_finance_Load(object sender, EventArgs e)
        {
            loadUserCredentials();
        }

        private void loadUserCredentials()
        {
            tName.Text = Fullname;
            tAccessLevel.Text = AccessLevel;

            if (IsAdministrator)
            {
                btnSettings.Visible = true;
                btnStudentAssessment.Visible = true;
                btnDiscounts.Visible = true;
                btnFeeCollection.Visible = true;
                btnStatementofAccounts.Visible = true;
                btnFeeAdjustment.Visible = true;
            }
            else
            {
                btnSettings.Visible = false;
            }

            if (AccessLevel == "Cashier")
            {
                btnFeeCollection.Visible = true;
            }
            else if (AccessLevel == "Student Accounts")
            {
                btnStudentAssessment.Visible = true;
                btnDiscounts.Visible = true;
                btnFeeAdjustment.Visible = true;
                btnStatementofAccounts.Visible = true;
            }
            
        }

        private void btnTransaction_Click(object sender, EventArgs e)
        {
            if (panelTransaction.Visible == false)
            {
                panelTransaction.Visible = true;
                btnTransaction.BackColor = Color.FromArgb(0, 0, 50);
            }
            else
            {
                panelTransaction.Visible = false;
                btnTransaction.BackColor = Color.FromArgb(0,0, 50);
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            if (panelSettings.Visible == false)
            {
                panelSettings.Visible = true;
            }
            else if (panelSettings.Visible == true)
            {
                panelSettings.Visible = false;
            }
        }

        private void tLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to logout?","Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var frm = new frm_login();
                frm.Show();
                this.Close();
            }
        }

        // Transaction Menu
        private void btnStudentAssessment_Click(object sender, EventArgs e)
        {
            var frm = new frm_student_assessment();
            frm.TopLevel = false;
            panelTask.Controls.Clear();
            panelTask.Controls.Add(frm);
            frm.Show();
        }

        private void btnDiscounts_Click(object sender, EventArgs e)
        {
            var frm = new frm_student_discounts();
            frm.TopLevel = false;
            panelTask.Controls.Clear();
            panelTask.Controls.Add(frm);
            frm.Show();
        }

        private void btnFeeCollection_Click(object sender, EventArgs e)
        {
            var frm = new frm_fee_collection();
            frm.TopLevel = false;
            panelTask.Controls.Clear();
            panelTask.Controls.Add(frm);
            frm.Show();
        }

        private void btnStatementofAccounts_Click(object sender, EventArgs e)
        {
            var frm = new frm_statements_of_accounts();
            frm.TopLevel = false;
            panelTask.Controls.Clear();
            panelTask.Controls.Add(frm);
            frm.Show();
        }

        private void btnFeeAdjustment_Click(object sender, EventArgs e)
        {
            
        }

        // Settings Menu
        private void btnMiscellaneous_Click(object sender, EventArgs e)
        {
            var frm = new frm_miscellaneous_setup(Email);
            frm.TopLevel = false;
            panelTask.Controls.Clear();
            panelTask.Controls.Add(frm);
            frm.Show();
        }

        private void btnTuitionFee_Click(object sender, EventArgs e)
        {
            var frm = new frm_tuition_fee(Email);
            frm.TopLevel = false;
            panelTask.Controls.Clear();
            panelTask.Controls.Add(frm);
            frm.Show();
        }

        private void btnLaboratoryFee_Click(object sender, EventArgs e)
        {
            var frm = new frm_lab_fee_setup(Email);
            frm.TopLevel = false;
            panelTask.Controls.Clear();
            panelTask.Controls.Add(frm);
            frm.Show();
        }

        private void btnDiscountSetup_Click(object sender, EventArgs e)
        {
            var frm = new frm_discount_setup(Email);
            frm.TopLevel = false;
            panelTask.Controls.Clear();
            panelTask.Controls.Add(frm);
            frm.Show();
        }

        private void btnOtherFees_Click(object sender, EventArgs e)
        {
            var frm = new frm_other_fees(Email);
            frm.TopLevel = false;
            panelTask.Controls.Clear();
            panelTask.Controls.Add(frm);
            frm.Show();
        }

        private void btnOrSetter_Click(object sender, EventArgs e)
        {
            var frm = new frm_or_number_setup();
            frm.ShowDialog();
        }

        private void btnUserManagement_Click(object sender, EventArgs e)
        {
            var frm = new frm_user_management(Office);
            frm.TopLevel = false;
            panelTask.Controls.Clear();
            panelTask.Controls.Add(frm);
            frm.Show();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            panelTask.Controls.Clear();
            panelTransaction.Visible = false;
            panelSettings.Visible = false;

            btnTransaction.BackColor = Color.FromArgb(0, 0, 25);
            btnSettings.BackColor = Color.FromArgb(0, 0, 25);
        }
    }
}
