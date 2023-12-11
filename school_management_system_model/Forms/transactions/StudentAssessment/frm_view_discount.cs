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

namespace school_management_system_model.Forms.transactions.StudentAssessment
{
    public partial class frm_view_discount : KryptonForm
    {
        public decimal totalDiscount { get; set; }
        public frm_view_discount()
        {
            InitializeComponent();
        }

        private void frm_view_discount_Load(object sender, EventArgs e)
        {
            loadRecords();
        }

        private void loadRecords()
        {
            dgv.Columns.Add("category", "Category");
            dgv.Columns.Add("fee_type", "fee_type");
            dgv.Columns.Add("amount", "Amount");
            dgv.Columns.Add("units", "Units");
            dgv.Columns.Add("computation", "Computation");
        }
    }
}
