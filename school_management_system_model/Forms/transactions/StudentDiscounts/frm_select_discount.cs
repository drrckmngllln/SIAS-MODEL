using Krypton.Toolkit;
using MySql.Data.MySqlClient;
using school_management_system_model.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace school_management_system_model.Forms.transactions.StudentDiscounts
{
    public partial class frm_select_discount : KryptonForm
    {
        public static frm_select_discount instance;
        public string idNumber { get; set; }
        public string fullname { get; set; }
        public frm_select_discount()
        {
            instance = this;
            InitializeComponent();
        }

        private void frm_select_discount_Load(object sender, EventArgs e)
        {
            loadRecords();
        }

        private void loadRecords()
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from discount_setup", con);
            var dt = new DataTable();
            da.Fill(dt);
            dgv.DataSource = dt;
            dgv.Columns["id"].Visible = false;
            dgv.Columns["code"].HeaderText = "Code";
            dgv.Columns["discount_target"].HeaderText = "Discount Target";
            dgv.Columns["description"].HeaderText = "Description";
            dgv.Columns["discount_percentage"].HeaderText = "Discount Percentage";
        }
        
        private void selectDiscount()
        {
            frm_student_discounts.instance.code = dgv.CurrentRow.Cells["code"].Value.ToString();
            frm_student_discounts.instance.description = dgv.CurrentRow.Cells["description"].Value.ToString();
            frm_student_discounts.instance.discount_target = dgv.CurrentRow.Cells["discount_target"].Value.ToString();
            frm_student_discounts.instance.discount_percentage = dgv.CurrentRow.Cells["discount_percentage"].Value.ToString();
            Close();
        }

        private void frm_select_discount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                selectDiscount();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            selectDiscount();
        }
    }
}
