using Krypton.Toolkit;
using MySql.Data.MySqlClient;
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
        public string id_number { get; set; }
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
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from student_discounts where id_number='" + id_number + "'", con);
            var dt = new DataTable();
            da.Fill(dt);
            dgv.DataSource = dt;
            dgv.Columns["id"].Visible = false;
            dgv.Columns["id_number"].Visible = false;
            dgv.Columns["code"].Visible = false;
            dgv.Columns["discount_target"].HeaderText = "Disount Target";
            dgv.Columns["description"].HeaderText = "Description";
            dgv.Columns["discount_percentage"].HeaderText = "Discount Percentage";
        }

        private void frm_view_discount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) 
            { 
                Close();
            }
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
