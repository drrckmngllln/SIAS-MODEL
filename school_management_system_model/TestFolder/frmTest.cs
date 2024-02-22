using school_management_system_model.Data.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace school_management_system_model.TestFolder
{
    public partial class frmTest : Form
    {
        //private SectionRepository _sectionRepo = new SectionRepository();
        CoursessssRepository _courseRepo = new CoursessssRepository();

        public frmTest()
        {
            InitializeComponent();
        }

        private async void frmTest_Load(object sender, EventArgs e)
        {
            var courses = await _courseRepo.GetAllAsync();
            dgv.DataSource = courses;
        }

        
    }
}
