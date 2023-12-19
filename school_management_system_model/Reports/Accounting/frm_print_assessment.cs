using Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace school_management_system_model.Reports.Accounting
{
    public partial class frm_print_assessment : KryptonForm
    {
        public frm_print_assessment()
        {
            InitializeComponent();
        }

        private void frm_print_assessment_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
