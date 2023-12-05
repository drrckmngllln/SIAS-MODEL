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
            dgv.Columns["description"].HeaderText = "Description";
            dgv.Columns["discount_percentage"].HeaderText = "Discount Percentage";
        }
        private void addRecords()
        {
            var add = new StudentDiscount
            {
                id_number = idNumber,
                code = dgv.CurrentRow.Cells["code"].Value.ToString(),
                description = dgv.CurrentRow.Cells["description"].Value.ToString(),
                discount_percentage = Convert.ToInt32(dgv.CurrentRow.Cells["discount_percentage"].Value.ToString())
            };
            add.addRecords();
            Close();
        }

        private void frm_select_discount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                addRecords();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
    }
}
