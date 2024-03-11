using school_management_system_model.Forms.transactions.StudentAccounts.StudentAccountsComponents;
using System;
using System.Windows.Forms;

namespace school_management_system_model.Forms.transactions.StudentAccounts
{
    public partial class frmStudentAccountModule : Form
    {
        public frmStudentAccountModule()
        {
            InitializeComponent();
        }

        private void frmStudentAccountModule_Load(object sender, EventArgs e)
        {
            OpenStudentAccountMasterList();
        }

        private void OpenStudentAccountMasterList()
        {
            var frm = new frmStudentAccountsList();
            frm.TopLevel = false;
            panelTask.Controls.Clear();
            panelTask.Controls.Add(frm);
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
