using System;
using System.Drawing;
using System.Windows.Forms;

namespace school_management_system_model.Forms.Reports.Registrar.MasterlistOfStudentEnrolled
{
    public partial class frmMasterlistOfStudentEnrolledParentModule : Form
    {
        public frmMasterlistOfStudentEnrolledParentModule()
        {
            InitializeComponent();
        }

        private void frmMasterlistOfStudentEnrolledParentModule_Load(object sender, EventArgs e)
        {
            loadMasterlist();
        }

        private void loadMasterlist()
        {
            var frm = new frmMasterlistOfStudentChildModule();
            frm.TopLevel = false;
            panelTask.Controls.Clear();
            panelTask.Controls.Add(frm);
            frm.Show();
        }

        private async void btnFilterByCourse_Click(object sender, EventArgs e)
        {
            await frmMasterlistOfStudentChildModule.instance.enableCourse();
        }

        private async void btnFilterByYearLevel_Click(object sender, EventArgs e)
        {
            await frmMasterlistOfStudentChildModule.instance.enableYearLevel();
        }

        private async void btnFilterByGender_Click(object sender, EventArgs e)
        {
            await frmMasterlistOfStudentChildModule.instance.enableGender();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmMasterlistOfStudentChildModule.instance.ExcelExport();
        }
    }
}
