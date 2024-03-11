using school_management_system_model.Forms.transactions.StudentAccounts.StudentAccountsComponents;
using System;
using System.Windows.Forms;

namespace school_management_system_model.Forms.transactions.StudentEnrollment
{
    public partial class frm_select_students : Form
    {
        public frm_select_students()
        {
            InitializeComponent();
        }

        private void frm_select_student_Load(object sender, EventArgs e)
        {
            OpenStudentList();
        }

        private int GetStudentKey()
        {
            return frmStudentAccountsList.instance.ID;
        }

        private void OpenStudentList()
        {
            var frm = new frmStudentAccountsList();
            frm.TopLevel = false;
            panelTask.Controls.Clear();
            panelTask.Controls.Add(frm);
            frm.Show();
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            frm_student_enrollment.instance.Id = GetStudentKey();
            Close();
        }
    }
}
