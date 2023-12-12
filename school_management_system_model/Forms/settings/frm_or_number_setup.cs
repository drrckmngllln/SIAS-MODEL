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

namespace school_management_system_model.Forms.settings
{
    public partial class frm_or_number_setup : KryptonForm
    {
        public frm_or_number_setup()
        {
            InitializeComponent();
        }

        private void frm_or_number_setup_Load(object sender, EventArgs e)
        {
            loadRecords();
        }

        private void loadRecords()
        {
            tReferenceNumber.Text = loadRefNumber().ToString();
        }

        private int loadRefNumber()
        {
            var con = new MySqlConnection(connection.con());
            var da = new MySqlDataAdapter("select * from reference_number_setup", con);
            var dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0]["reference_number"]);
            }
            else
            {
                return 0;
            }
        }

        private void saveRefNumber()
        {
            if (tReferenceNumber.Text.Length > 0)
            {
                var con = new MySqlConnection(connection.con());
                con.Open();
                var cmd = new MySqlCommand("insert into reference_number_setup(reference_number) values('" + tReferenceNumber.Text + "')", con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("OR Number Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else
            {
                MessageBox.Show("Please Input Valid OR Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            saveRefNumber();
        }
    }
}
