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
        private StoreContext _context = new StoreContext();
        public frmTest()
        {
            InitializeComponent();
        }

        private async void frmTest_Load(object sender, EventArgs e)
        {
            dgv.DataSource = await GetSectionSubjectssesAsync();
        }

        private async Task<IReadOnlyList<SectionSubjectss>> GetSectionSubjectssesAsync()
        {
            var studentSubjects = await _context.SectionSubjects();
            var subjects = studentSubjects.ToList();
            return subjects;
        }
    }
}
